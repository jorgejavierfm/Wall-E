using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using FlowChartDesigner;
using FlowChartDesigner.ChartElements;
using Walle.ExpressionEvaluator;
using Components;
using Walle.Components.Sensors;
using Walle.UI;

namespace Walle.Components
{
   /// <summary>
   /// Clase que interpreta conjuntos de instrucciones, y envia ordenes al robot. 
   /// </summary>
   public class Interpreter
   {
      public Dictionary<string, ChartElementCollection> ActivityList; // Almacena todas las actividades del algoritmo actual, incluyendo el "Main".
      public int wait = 500; // Demora entre instruccion e instruccion.
      public event EventHandler FinishedExecution; // Este evento se lanza cuando termina la ejecucion del algoritmo.
      public Robot Robot { get; private set; } // Robot que ejecutara las ordenes.
      public Evaluator Evaluator { get; set; } // Evaluador. Contiene la memoria del robot.
      public bool shouldStop = false; // Para no detener el hilo abruptamente.

      /// <summary>
      /// Crea un nuevo interprete de instrucciones a partir de un conjunto de actividades y un robot.
      /// </summary>
      /// <param name="robot">El robot sobre el cual el interprete va a ejecutar las acciones.</param>
      /// <param name="actList">La lista de actividades a interpretar.</param>
      public Interpreter(Robot robot, Dictionary<string, ChartElementCollection> actList)
      {
         Robot = robot;
         ActivityList = actList;
         Evaluator = new Evaluator();
      }

      /// <summary>
      /// Ejecuta un algoritmo determinado, dado por un ChartElementCollection.
      /// </summary>
      /// <param name="instructionCollection">El conjunto de instrucciones a ejecutar.</param>
      public void ExecuteAlgorithm(ChartElementCollection instructionCollection)
      {

         ChartElement current = null;
         try
         {
            ChartElement first = instructionCollection.First; // Obtiene el elemento "Begin" si existe.

            if (first == null || first.Connections == null) throw new Exception("Invalid algorithm to execute."); // Si no existe el "Begin", el algoritmo no es valido.

            foreach (var connection in first.Connections)
               if (connection.To != null) current = connection.To.ChartElement; // Obtiene la primera instruccion a ejecutar.

            while (!(current is EndChartElement) && !shouldStop)
            {

               if (current == null) throw new InvalidOperationException("Unconnected chart element. Check your chart connections.");

               if (current is ConditionalChartElement)
               {
                  ConditionalChartElement conditionalChart = (ConditionalChartElement)current;
                  if (conditionalChart.Condition == "") throw new InvalidOperationException("Invalid conditional chart.");
                  string preExpression = ParseSensorData(conditionalChart.Condition).ToLower();
                  string evaluationResult = Evaluator.Evaluate(preExpression);
                  bool found = false;
                  foreach (var connection in current.Connections)
                  {
                     if (evaluationResult.Equals(connection.Label))
                     {
                        if (connection.To != null)
                        {
                           current = connection.To.ChartElement;
                           found = true;
                        }
                        else throw new Exception("Invalid connection");
                        break;
                     }
                  }
                  if (!found) throw new InvalidOperationException("Invalid conditional expression.");
               }
               else
               {
                  if (current is CommandChartElement)
                  {
                     ExecuteCommand((CommandChartElement)current);
                  }

                  else if (current is ActivityChartElement)
                  {
                     string activityName = ((ActivityChartElement)current).ActivityName;
                     if (ActivityList.ContainsKey(activityName))
                     {
                        ExecuteAlgorithm(ActivityList[activityName]);
                     }
                     else throw new InvalidOperationException("Invalid activity.");
                  }

                  else if (current is AssignationChartElement)
                  {
                     AssignationChartElement assignChart = (AssignationChartElement)current;
                     if (assignChart.Name == "" || assignChart.Expression == "") throw new InvalidOperationException("Invalid assignation chart element.");
                     string where = ParseSensorData(assignChart.Name);
                     string preExpression = ParseSensorData(((AssignationChartElement)current).Expression).ToLower();
                     string what = Evaluator.Evaluate(preExpression);

                     Evaluator.Assign(where, what);
                  }

                  foreach (var connection in current.Connections)
                  {
                     if (connection.To != null)
                        current = connection.To.ChartElement;
                     else throw new InvalidOperationException("Unconnected chart element. Check your chart connections.");
                     break;
                  }
               }
            }
         }
         catch (Exception exception)
         {
            if (!(exception is ThreadAbortException))
            {
               OnError(exception); // Lanza el evento Error con el mensaje incluido.
               if (current != null) current.BackColor = Color.Red; // Cambia el color del chartElement actual para permitir al usuario conocer la fuente del error.
               Thread.CurrentThread.Abort(); // Termina la ejecucion del hilo actual.
            }
         }
      }

      /// <summary>
      /// Ejecuta un comando del robot.
      /// </summary>
      /// <param name="commandChart">Un chartElement que contiene la instruccion a ejecutar.</param>
      public void ExecuteCommand(CommandChartElement commandChart)
      {
         switch (commandChart.CommandName.ToLower())
         {
            case "moveforward":
               Robot.Motor.MoveForward();
               break;
            case "movebackward":
               Robot.Motor.MoveBackward();
               break;
            case "turnleft":
               Robot.Motor.TurnLeft();
               break;
            case "turnright":
               Robot.Motor.TurnRight();
               break;
            case "loaditem":
               Robot.Motor.LoadItem();
               break;
            case "unloaditem":
               Robot.Motor.UnloadItem();
               break;
            default:
               throw new InvalidOperationException(string.Format("Invalid Command: {0}", commandChart.CommandName));
         }
         Robot.OnMove();
         Thread.Sleep(wait);
      }

      /// <summary>
      /// Ejecuta la actividad "Main". La ejecucion del algoritmo comienza aqui.
      /// </summary>
      public void ExecuteMain()
      {
         ExecuteAlgorithm(ActivityList["Main"]);
         if (FinishedExecution != null) FinishedExecution.Invoke(this, EventArgs.Empty);
      }

      /// <summary>
      /// Evento lanzado en caso de error.
      /// </summary>
      public event ErrorEventHandler ExecutionError;

      /// <summary>
      ///    Lanza el evento ExecutionError.
      /// </summary>
      /// <param name="e"></param>
      public void OnError(Exception e)
      {
         if (ExecutionError != null) ExecutionError(e);
      }

      /// <summary>
      /// Dada una expresion, reconoce los nombres de sensores presentes en ella, 
      /// y sustituye esos literales por sus valores.
      /// </summary>
      /// <param name="expression"></param>
      /// <returns></returns>
      private string ParseSensorData(string expression)
      {
         if (expression == null || expression == "") return "";
         Tokenizer tokenizer = new Tokenizer(expression);

         var enumerator = tokenizer.GetTokens().GetEnumerator();

         while (enumerator.MoveNext())
         {
            Token current = enumerator.Current;

            string possibleSensorName = "";
            string possibleSensorProperty = "";

            if (current != null && current.Type == TokenType.Name)
            {

               possibleSensorName = current.Value;
               enumerator.MoveNext();
               if (enumerator.Current.Type == TokenType.Dot)
               {
                  enumerator.MoveNext();
                  if (enumerator.Current.Type == TokenType.Name)
                  {
                     possibleSensorProperty = enumerator.Current.Value;
                  }
                  else throw new Exception("Invalid expression");
               }
            }

            if (possibleSensorName != "" && possibleSensorProperty != "")
            {
               string fullSensorLiteral = possibleSensorName + "." + possibleSensorProperty;
               possibleSensorName = possibleSensorName.ToLower();
               possibleSensorProperty = possibleSensorProperty.ToLower();
               bool ok = false;

               //Comienza por parsear los colores.
               if (possibleSensorName == "color")
               {
                  Color c = Color.FromName(possibleSensorProperty);
                  if (c.IsKnownColor)
                  {
                     expression.Replace(fullSensorLiteral, c.ToArgb().ToString());
                  }
                  else throw new Exception("A specified color is not supported or does not exist.");
               }
               else
               {
                  // Se usa Reflection para obtener todos los sensores del robot con sus correspondientes valores.
                  RobotSensors conjunto = Robot.Sensors;

                  var typeOfSensores = conjunto.GetType();

                  PropertyInfo[] sensoresProperties = typeOfSensores.GetProperties();

                  string result = "";

                  foreach (PropertyInfo info in sensoresProperties)
                  {
                     var l = info.GetValue(conjunto, null);

                     Type currentSensorType = l.GetType();
                     if (currentSensorType.Name.ToLower() == possibleSensorName)
                     {
                        foreach (PropertyInfo sensorProperties in currentSensorType.GetProperties())
                        {
                           if (sensorProperties.Name.ToLower() == possibleSensorProperty)
                           {
                              var value = sensorProperties.GetValue(l, null);
                              if (value != null)
                              {
                                 result = value.ToString();
                                 expression = expression.Replace(fullSensorLiteral, result);
                                 ok = true;
                                 break;
                              }
                           }
                        }
                     }
                  }
                  if (!ok) throw new Exception("A specified sensor or property does not exist.");
               }
            }
         }
         return expression;
      }
   }
}