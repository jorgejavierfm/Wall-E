using System.Drawing;
using FlowChartDesigner.ChartElements;

namespace FlowChartDesigner.Builders{
   /// <summary>
   /// Crea un elemento de asignacion, ya sea en una variable o en un array.
   /// </summary>
   public class AssignationChartElementBuilder : NormalChartBuilder
   {
      /// <summary>
      /// Devuelve el nombre del elemento a crear.
      /// </summary>
      public override string BuilderName
      {
         get { return "Assignation"; }
      }
      /// <summary>
      /// Crea un nuevo AssignationChartElement.
      /// </summary>
      /// <param name="index">Esta propiedad no es relevante para esta clase.</param>
      /// <returns>Un nuevo AssignationChartElement.</returns>
      public override ChartElement Build(int index)
      {
         AssignationChartElement element = new AssignationChartElement();

         element.PinSize = new Size(5, 5);
         element.BackColor = Color.LightBlue;
         element.Display = new Rectangle(Center.X - 50, Center.Y - 10, 100, 20);
         element.ShowInputPins = false;
         element.ShowOutputPins = false;
         element.Name = "";
         element.Expression = "";

         return element;
      }

   }

}