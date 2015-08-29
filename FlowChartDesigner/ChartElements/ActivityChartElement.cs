using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace FlowChartDesigner.ChartElements{
   [Serializable]
   public class ActivityChartElement : ChartElement
   {
      public override int NumberOfValidInputs
      {
         get { return 3; }
      }

      public override int NumberOfValidOutputs
      {
         get { return 1; }
      }

      public ActivityChartElement()
      {
         AddConnection(0, "Next"); // adiciona una unica conexion de salida disponible.
      }
      
      /// <summary>
      /// Devuelve o asigna el nombre de la actividad. Esta propiedad no es modificable en tiempo de ejecucion.
      /// </summary>
      [Browsable(false)]
      public string ActivityName { get; set; }

      protected internal override Point GetPositionForInputPin(int index)
      {
         switch (index)
         {
            case 0: return new Point(Display.X + Display.Width / 2, Display.Y);
            case 1: return new Point(Display.X, Display.Y + Display.Height / 2);
            case 2: return new Point(Display.X + Display.Width, Display.Y + Display.Height / 2);
            case 3: return new Point(Display.X + Display.Width / 2, Display.Y + Display.Height);
         }

         throw new ArgumentOutOfRangeException();
      }

      /// <summary>
      /// Determina la posicion de cada uno de los pines de salida.
      /// </summary>
      protected internal override System.Drawing.Point GetPositionForOutputPin(int index)
      {
         switch (index)
         {
            case 0: return new System.Drawing.Point(Display.X + Display.Width / 2, Display.Y + Display.Height);
         }

         throw new ArgumentOutOfRangeException();
      }

      protected internal override void OnPaint(System.Windows.Forms.PaintEventArgs e)
      {
         /// Se pinta primero como su padre.
         base.OnPaint(e);

         /// Pinta el texto alineado al centro.
         StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);
         format.Alignment = StringAlignment.Center;
         format.LineAlignment = StringAlignment.Center;

         e.Graphics.DrawString(ActivityName, Font, Brushes.Black, Display, format);
      }

      protected override Color DefaultColor
      {
          get
          {
              return Color.DarkSlateGray;
          }
      }
   }
}