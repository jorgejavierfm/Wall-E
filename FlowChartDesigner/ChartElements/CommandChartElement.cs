using System;
using System.ComponentModel;
using System.Drawing;

namespace FlowChartDesigner.ChartElements{
   [Serializable]
   public class CommandChartElement : ChartElement
   {
      public CommandChartElement()
      {
         AddConnection(0, "Next");
      }
   
      public override int NumberOfValidInputs
      {
         get { return 3; }
      }

      public override int NumberOfValidOutputs
      {
         get { return 1; }
      }

      /// <summary>
      /// Devuelve o asigna el nombre del comando a ejecutar. Esta propiedad no debe ser modificable en tiempo de ejecucion.
      /// </summary>
      [Browsable(false)]
      public string CommandName
      {
         get; set;
      }

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

      protected internal override Point GetPositionForOutputPin(int index)
      {
         switch (index)
         {
            case 0: return new Point(Display.X + Display.Width / 2, Display.Y + Display.Height);
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

         e.Graphics.DrawString(CommandName, Font, Brushes.Black, Display, format);
      }

      protected override Color DefaultColor
      {
          get
          {
              return Color.Gray;
          }
      }
   }
}