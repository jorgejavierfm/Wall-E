using System.Drawing;
using FlowChartDesigner.ChartElements;

namespace FlowChartDesigner.Builders
{
   /// <summary>
   /// Construye un elemento de actividad a partir de una lista de valores posibles (actividades existentes).
   /// </summary>
   public class ActivityChartElementBuilder : PredefinedChartBuilder
   {
      /// <summary>
      /// Devuelve el nombre del tipo de elemento a crear.
      /// </summary>
      public override string BuilderName
      {
         get { return "Activity"; }
      }

      /// <summary>
      /// Devuelve un nuevo elemento, con el nombre correspondiente al elemento en el "index" de la lista de valores posibles.
      /// </summary>
      /// <param name="index">El indice correspondiente en la lista del nombre de la actividad a crear.</param>
      /// <returns>Un nuevo ActivityChartElement.</returns>
      public override ChartElement Build(int index)
      {
         ActivityChartElement element = new ActivityChartElement();

         element.PinSize = new Size(5, 5);
         element.BackColor = Color.DarkSlateGray;
         element.Display = new Rectangle(Center.X - 50, Center.Y - 10, 100, 20);
         element.ShowInputPins = false;
         element.ShowOutputPins = false;
         element.ActivityName = ValuesList[index];

         return element;
      }

   }
}
