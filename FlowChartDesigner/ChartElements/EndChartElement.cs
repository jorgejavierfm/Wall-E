using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FlowChartDesigner.ChartElements{
   [Serializable]
   public class EndChartElement : ChartElement
   {
      public override int NumberOfValidInputs
      {
         get { return 1; }
      }

      public override int NumberOfValidOutputs
      {
         get { return 0; }
      }

      protected internal override Point GetPositionForOutputPin(int index)
      {
         throw new ArgumentOutOfRangeException();
      }

      protected internal override Point GetPositionForInputPin(int index)
      {
         switch (index)
         {
            case 0:
               return new Point(Display.X + Display.Width /2, Display.Y + Display.Height / 2);
            default:
               throw new ArgumentOutOfRangeException();
         }
      }

      /// <summary>
      /// Muestra un circulo.
      /// </summary>
      public override GraphicsPath Geometry
      {
         get
         {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(Display.X, Display.Y, Display.Width, Display.Height);
            return gp;
         }
      }

      /// <summary>
      /// Esta propiedad no es relevante para esta clase.
      /// </summary>
      [Browsable(false)]
      public override Font Font
      {
         get
         {
            return base.Font;
         }
         set
         {
            base.Font = value;
         }
      }
   }
}