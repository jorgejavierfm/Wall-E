using System;
using System.Drawing;
using Components;
using System.Windows.Forms;

namespace FlowChartDesigner.ChartElements
{
   [Serializable]
   public class AssignationChartElement : ChartElement
   {
      public override int NumberOfValidInputs
      {
         get { return 3; }
      }

      public override int NumberOfValidOutputs
      {
         get { return 1; }
      }

      public AssignationChartElement()
      {
         AddConnection(0, "Next"); // adiciona una unica conexion de salida disponible.
      }

      private string _Name;

      /// <summary>
      /// Devuelve o asigna el nombre del lugar a guardar el valor.
      /// </summary>
      public string Name
      {
         get { return _Name; }
         set
         {
            _Name = value;
            this.BackColor = DefaultColor;
            this.Resize();
         }
      }

      private string _Expression;

      /// <summary>
      /// Devuelve o asigna la expresion a evaluar.
      /// </summary>
      public string Expression
      {
         get { return _Expression; }
         set
         {
            _Expression = value;
            this.BackColor = DefaultColor;
            this.Resize();
         }
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

         if (Name != "" && Expression != "")
         {
            e.Graphics.DrawString(Name + " = " + Expression, Font, Brushes.Black, Display, format);
         }
      }

      protected override Color DefaultColor
      {
         get
         {
            return Color.LightBlue;
         }
      }

      /// <summary>
      /// Metodo auxiliar que redimensiona el elemento en dependencia del tamaño del texto introducido.
      /// </summary>
      private void Resize()
      {
         if (this._Name != "" && this._Expression !=""){
            Size size = TextRenderer.MeasureText(_Name + _Expression + " ", this.Font);
            Rectangle display = new Rectangle(Display.X, Display.Y, size.Width + 40, size.Height+ 10);
            this.Display = display;
         }
      }

   }
}