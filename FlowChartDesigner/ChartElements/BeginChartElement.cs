using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace FlowChartDesigner
{
   [Serializable]
   public class BeginChartElement : ChartElement
   {
      public BeginChartElement()
      {
         this.AddConnection(0,"Next");
      }
   
      public override int NumberOfValidInputs
      {
         get { return 0; }
      }

      public override int NumberOfValidOutputs
      {
         get { return 1; }
      }

      protected internal override Point GetPositionForInputPin(int index)
      {
         throw new ArgumentOutOfRangeException();
      }

      protected internal override Point GetPositionForOutputPin(int index)
      {
         switch (index){
            case 0: 
               return new Point(Display.X + Display.Width /2,Display.Y + Display.Height / 2);
            default:
               throw new ArgumentOutOfRangeException();
         }
      }

      /// <summary>
      /// Redefine la forma del elemento para mostrar un circulo.
      /// </summary>
      public override System.Drawing.Drawing2D.GraphicsPath Geometry
      {
         get
         {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(Display.X,Display.Y,Display.Width,Display.Height);
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
