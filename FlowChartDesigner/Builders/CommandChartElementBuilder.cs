using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using FlowChartDesigner.ChartElements;

namespace FlowChartDesigner.Builders{
   /// <summary>
   /// Construye un elemento que representa una accion que el robot puede ejecutar. 
   /// </summary>
   public class CommandChartElementBuilder : PredefinedChartBuilder
   {
      /// <summary>
      /// Devuelve el nombre del elemento a crear.
      /// </summary>
      public override string BuilderName
      {
         get { return "Command"; }
      }

      /// <summary>
      /// Devuelve un nuevo CommandChartElement.
      /// </summary>
      /// <param name="index">Define que instruccion crear de la lista de instrucciones posibles.</param>
      /// <returns>El nuevo CommandChartElement.</returns>
      public override ChartElement Build(int index)
      {
         CommandChartElement element = new CommandChartElement();

         element.PinSize = new Size(5, 5);
         element.BackColor = Color.Gray;
         element.Display = new Rectangle(Center.X - 50, Center.Y - 10, 100, 20);
         element.ShowInputPins = false;
         element.ShowOutputPins = false;
         element.CommandName = ValuesList[index];

         return element;
      }
   }
}