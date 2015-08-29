using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using FlowChartDesigner.ChartElements;

namespace FlowChartDesigner.Builders{

   /// <summary>
   /// Construye un elemento especial. El algoritmo concluye al llegar a este.
   /// </summary>
   public class EndChartElementBuilder : NormalChartBuilder
   {
      /// <summary>
      /// Devuelve el nombre del elemento a crear.
      /// </summary>
      public override string BuilderName
      {
         get { return "End"; }
      }

      /// <summary>
      /// Devuelve un nuevo EndChartElement.
      /// </summary>
      /// <param name="index">Parametro no relevante.</param>
      /// <returns>El nuevo EndChartElement.</returns>
      public override ChartElement Build(int index)
      {
         EndChartElement element = new EndChartElement();

         element.PinSize = new Size(5, 5);
         element.BackColor = Color.Red;
         element.Display = new Rectangle(Center.X - 10, Center.Y - 10, 20, 20);
         element.ShowInputPins = false;
         element.ShowOutputPins = false;

         return element;
      }
   }
}