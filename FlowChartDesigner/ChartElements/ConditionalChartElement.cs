using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace FlowChartDesigner.ChartElements{
   [Serializable]
   public class ConditionalChartElement : ChartElement
   {
      /// <summary>
      /// Inicializa el elemento con las conecciones validas para este.
      /// </summary>
      public ConditionalChartElement()
      {
         AddConnection(0, "False"); // adiciona la salida false.
         AddConnection(1, "True"); // adiciona la salida true.
      }

      private string _Condition;
      /// <summary>
      /// Devuelve o establece la condicional. Al mismo tiempo, redimensiona el elemento para que quepa dentro la expresion.
      /// </summary>
      public string Condition
      {
         get { return _Condition; }
         set
         {
            _Condition = value;
            this.BackColor = DefaultColor;
            if (_Condition != "")
            {
               Size size = TextRenderer.MeasureText(this._Condition, this.Font);
               Rectangle display = new Rectangle(Display.X, Display.Y, size.Width + 40, (size.Width + 20)/2);
               this.Display = display;
            }
         }
      }

      /// <summary>
      /// Redefine el metodo OnPaint para visualizar el texto de la condicional.
      /// </summary>
      /// <param name="e"></param>
      protected internal override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);

         StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);
         format.Alignment = StringAlignment.Center;
         format.LineAlignment = StringAlignment.Center;
            
         e.Graphics.DrawString(Condition, Font, Brushes.Black, Display, format);
      }

      /// <summary>
      /// Se redefine la propiedad geometry para visualizar un rombo en lugar de un rectangulo.
      /// </summary>
      public override GraphicsPath Geometry
      {
         get
         {
            GraphicsPath path = new GraphicsPath();

            path.AddPolygon(new Point[] { 
                                              new Point(Display.X + Display.Width / 2, Display.Y),
                                              new Point(Display.X, Display.Y + Display.Height / 2),
                                              new Point(Display.X + Display.Width / 2, Display.Y + Display.Height),
                                              new Point(Display.X + Display.Width, Display.Y + Display.Height / 2)
                                        });

            return path;
         }
      }

      /// <summary>
      /// Devuelve 1 como cantidad de entradas validas.
      /// </summary>
      public override int NumberOfValidInputs
      {
         get { return 1; }
      }

      /// <summary>
      /// Devuelve 2 como cantidad de salidas validas.
      /// </summary>
      public override int NumberOfValidOutputs
      {
         get { return 2; }
      }

      /// <summary>
      /// Determina la posicion de cada uno de los pines de entrada.
      /// </summary>
      protected internal override System.Drawing.Point GetPositionForInputPin(int index)
      {
         switch (index)
         {
            case 0: return new System.Drawing.Point(Display.X + Display.Width / 2, Display.Y);
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
            case 0: return new System.Drawing.Point(Display.X, Display.Y + Display.Height / 2);
            case 1: return new System.Drawing.Point(Display.X + Display.Width, Display.Y + Display.Height / 2);
         }

         throw new ArgumentOutOfRangeException();
      }

      /// <summary>
      /// Devuelve el color por defecto de este elemento.
      /// </summary>
      protected override Color DefaultColor
      {
         get
         {
            return Color.LightBlue;
         }
      }

   }
}