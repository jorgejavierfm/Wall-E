using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using FlowChartDesigner.ChartElements;

namespace FlowChartDesigner.Builders
{
   /// <summary>
   /// Construye un elemento especial. El algoritmo comienza a ejecutarse por este.
   /// </summary>
   public class BeginChartElementBuilder : NormalChartBuilder
   {
      /// <summary>
      /// Devuelve el nombre del elemento a crear.
      /// </summary>
      public override string BuilderName
      {
         get { return "Begin"; }
      }

      /// <summary>
      /// Devuelve un nuevo BeginChartElement.
      /// </summary>
      /// <param name="index">Este parametro no es relevante para este metodo.</param>
      /// <returns>El nuevo BeginChartElement</returns>
      public override ChartElement Build(int index)
      {
         BeginChartElement element = new BeginChartElement();

         element.PinSize = new Size(5, 5);
         element.BackColor = Color.Green;
         element.Display = new Rectangle(Center.X - 10, Center.Y - 10, 20, 20);
         element.ShowInputPins = false;
         element.ShowOutputPins = false;

         return element;
      }
   }
}
