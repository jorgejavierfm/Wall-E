using System;
using System.Drawing;
using FlowChartDesigner.ChartElements;

namespace FlowChartDesigner.Builders{
   /// <summary>
   /// Construye un elemento que representa una condicion.
   /// </summary>
   public class ConditionalChartElementBuilder : NormalChartBuilder
   {
      /// <summary>
      /// Devuelve el nombre del elemento a crear.
      /// </summary>
      public override string BuilderName
      {
         get { return "Conditional"; }
      }

      /// <summary>
      /// Contruye un nuevo ConditionalChartElement.
      /// </summary>
      /// <param name="index">El parametro no es relevante para este metodo.</param>
      /// <returns>El nuevo ConditionalChartElement.</returns>
      public override ChartElement Build(int index)
      {
         ConditionalChartElement element = new ConditionalChartElement
                                              {
                                                    PinSize = new Size(5, 5),
                                                    BackColor = Color.LightBlue,
                                                    Display = new Rectangle(Center.X - 100, Center.Y - 25, 200, 50),
                                                    ShowInputPins = false,
                                                    ShowOutputPins = false,
                                                    Condition = ""
                                              };

         return element;
      }
   }

   
}