using System;
using Walle.Scenario;
using System.Reflection;
using System.Drawing;

namespace Walle.Components.Sensors
{
   /// <summary>
   /// Define un conjunto de sensores de un robot.
   /// </summary>
   [Serializable]
   public class RobotSensors
   {
      public RobotSensors(Map map)
      {
         this.GPS = new GPS(map);
         this.Thermometer = new Thermometer(map);
         this.Ultrasonic = new Ultrasonic(map);
         this.Webcam = new Webcam(map);
         this.Scale = new Scale(map);
      }

      public Thermometer Thermometer { get; set; }

      public Ultrasonic Ultrasonic { get; set; }

      public Webcam Webcam { get; set; }

      public Scale Scale { get; set; }

      public GPS GPS { get; set; }

      /// <summary>
      /// Devuelve una representacion en string de los valores actuales de cada uno de los sensores.
      /// </summary>
      /// <returns></returns>
      public override string ToString()
      {
         var typeOfSensores = this.GetType();

         PropertyInfo[] sensoresProperties = typeOfSensores.GetProperties();

         string result = "";

         foreach (PropertyInfo info in sensoresProperties)
         {
            object sensor = info.GetValue(this, null);
            Type currentSensorType = sensor.GetType();

            result += currentSensorType.Name + ": \n\t";

            foreach (PropertyInfo sensorProperties in currentSensorType.GetProperties())
            {

               string propertyName = sensorProperties.Name;
               if (propertyName != "Map")
               {
                  var value = sensorProperties.GetValue(sensor, null);
                  result += "  " + propertyName + ":\t " + value.ToString() + "\n";
               }
            }
         }

         return result;
      }
   }
}