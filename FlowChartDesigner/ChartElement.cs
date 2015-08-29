using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace FlowChartDesigner
{
   /// <summary>
   /// Representa la base clase para los elementos basicos en un diagrama.
   /// Un elemento de un diagrama tiene un conjunto de pines de entrada (lugares por donde se anclan conexiones de entrada)
   /// y un conjunto de pines de salida (lugares por donde se sacan conexiones a otros elementos).
   /// Tiene a su vez un conjunto de conexiones de salida que se pueden usar para conectar con otros elementos.
   /// </summary>
   [Serializable]
   public abstract class ChartElement
   {

      #region Variables de instancia

      /// <summary>
      /// Lista con las conexiones de salida de este elemento.
      /// Esta lista podra ser actualizada utilizando el metodo AddConnection.
      /// </summary>
      List<Connection> _Connections = new List<Connection>();

      #endregion

      /// <summary>
      /// Inicializa un objeto de tipo ChartElement. Este constructor establece los pines de entrada y salida del elemento
      /// utilizando los valores de las propiedades NumberOfValidInputs y NumberOfValidOutputs.
      /// </summary>
      public ChartElement()
      {
         /// Se crea la coleccion de pines de entrada.
         ValidInputs = new PinCollection(this, NumberOfValidInputs, PinType.Input);
         /// Se crea la coleccion de pines de salida.
         ValidOutputs = new PinCollection(this, NumberOfValidOutputs, PinType.Output);

         ShowInputPins = false;
         ShowOutputPins = false;

         Display = new Rectangle(0, 0, 100, 20);
      }

      PinCollection _ValidInputs;
      /// <summary>
      /// Devuelve el conjunto de pines de entrada.
      /// </summary>
      [Browsable(false)]
      public PinCollection ValidInputs { get { return _ValidInputs; } private set { _ValidInputs = value; } }

      PinCollection _ValidOutputs;
      /// <summary>
      /// Devuelve el conjunto de pines de salida.
      /// </summary>
      [Browsable(false)]
      public PinCollection ValidOutputs { get { return _ValidOutputs; } private set { _ValidOutputs = value; } }

      /// <summary>
      /// Cuando se implemente, debera devolver el numero valido de pines de entrada.
      /// </summary>
      [Browsable(false)]
      public abstract int NumberOfValidInputs { get; }

      /// <summary>
      /// Cuando se implemente, debera devolver el numero valido de pines de salida.
      /// </summary>
      [Browsable(false)]
      public abstract int NumberOfValidOutputs { get; }

      /// <summary>
      /// Cuando se implemente, debera devolver la posicion del index-esimo pin de entrada.
      /// </summary>
      /// <param name="index">Indice para referirse al pin de entrada</param>
      /// <returns>Un objeto de tipo Point con las coordenadas donde debera quedar el pin de entrada.</returns>
      protected internal abstract Point GetPositionForInputPin(int index);

      /// <summary>
      /// Cuando se implemente, debera devolver la posicion del index-esimo pin de salida.
      /// </summary>
      /// <param name="index">Indice para referirse al pin de salida</param>
      /// <returns>Un objeto de tipo Point con las coordenadas donde debera quedar el pin de salida.</returns>
      protected internal abstract Point GetPositionForOutputPin(int index);

      /// <summary>
      /// Devuelve un objeto IEnumerable con las conexiones de este elemento.
      /// </summary>
      [Browsable(false)]
      public IEnumerable<Connection> Connections { get { return _Connections; } }

      /// <summary>
      /// Permite agregar una nueva conexion al conjunto de conexiones de este elemento.
      /// </summary>
      /// <param name="outputPinIndex">Indice del pin de salida a partir del cual sale la conexion (varias conexiones pueden salir del mismo pin).</param>
      /// <param name="label">Etiqueta de texto para la conexion.</param>
      protected void AddConnection(int outputPinIndex, string label)
      {
         Connection newConnection = new Connection(ValidOutputs[outputPinIndex], null);
         newConnection.Label = label;

         _Connections.Add(newConnection);
      }

      Rectangle _Display;
      /// <summary>
      /// Determina o asigna el rectangulo de visualizacion de este elemento dentro del diagrama.
      /// </summary>
      [Browsable(false)]
      public Rectangle Display { get { return _Display; } set { _Display = value; } }

      bool _Selected;
      /// <summary>
      /// Determina si este elemento esta seleccionado o no.
      /// </summary>
      [Browsable(false)]
      public bool Selected { get { return _Selected; } internal set { _Selected = value; } }

      bool _HighLight;
      /// <summary>
      /// Determina si este elemento esta alumbrado o no.
      /// </summary>
      [Browsable(false)]
      public bool HighLight { get { return _HighLight; } internal set { _HighLight = value; } }

      /// <summary>
      /// Crea un path que representa la geometria del borde de este elemento.
      /// </summary>
      [Browsable(false)]
      public virtual GraphicsPath Geometry
      {
         get
         {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(Display);
            return path;
         }
      }

      /// <summary>
      /// Este metodo es llamado para pintar el fondo del elemento.
      /// </summary>
      /// <param name="e">El argumento de pintado con el objeto Graphics que se debe usar para dibujar.</param>
      internal protected virtual void OnPaintBackground(PaintEventArgs e)
      {
         e.Graphics.FillPath(new LinearGradientBrush(Display, BackColor, Color.AliceBlue, 315), Geometry);

         Pen pen = Pens.Black;

         if (Selected && HighLight)
            pen = new Pen(Color.White, 3);
         else if (HighLight)
            pen = Pens.White;
         else if (Selected)
            pen = new Pen(Color.DarkBlue, 3);

         e.Graphics.DrawPath(pen, Geometry);
      }

      bool _ShowInputPins;
      /// <summary>
      /// Determina si deben visualizarse o no los pines de entrada.
      /// </summary>
      [Browsable(false)]
      public bool ShowInputPins { get { return _ShowInputPins; } set { _ShowInputPins = value; } }

      bool _ShowOutputPins;
      /// <summary>
      /// Determina si deben visualizarse o no los pines de salida.
      /// </summary>
      [Browsable(false)]
      public bool ShowOutputPins { get { return _ShowOutputPins; } set { _ShowOutputPins = value; } }

      Size _PinSize;
      /// <summary>
      /// Devuelve o establece el tamaño de un pin.
      /// </summary>
      [Browsable(false)]
      public Size PinSize { get { return _PinSize; } set { _PinSize = value; } }

      /// <summary>
      /// Este metodo es llamado cuando una conexion debe ser pintada.
      /// </summary>
      /// <param name="gr">Objeto Graphics utilizado para pintar.</param>
      /// <param name="connection">La conexion que se quiere visualizar.</param>
      protected virtual void DrawConnection(Graphics gr, Connection connection)
      {
         if (connection.To != null)
            DrawFreeConnection(gr, connection, connection.To.Position, connection.To.Orientation);
      }

      /// <summary>
      /// Metodo para visualizar una conexion directa entre dos puntos.
      /// </summary>
      /// <param name="gr">Objeto Graphics utilizado para pintar.</param>
      /// <param name="from">Punto de origen de la conexion.</param>
      /// <param name="to">Punto de llegada de la conexion.</param>
      /// <param name="endArrow">Un valor boolean que indica si se visualiza o no una flecha al final de la linea.</param>
      protected void DrawDirectConnector(Graphics gr, Point from, Point to, bool endArrow)
      {
         Pen pen = new Pen(Color.Black, 4);
         if (endArrow)
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

         gr.DrawLine(pen, from, to);
      }

      /// <summary>
      /// Este metodo se llama cuando se desea pintar una conexion que está "suelta" hasta un punto.
      /// </summary>
      /// <param name="gr">Objeto Graphics utilizado para pintar.</param>
      /// <param name="connection">Conexion que se desea visualizar.</param>
      /// <param name="freePoint">Punto de llegada de la conexion.</param>
      /// <param name="orientation">Orientacion por la que se quiere llegar la linea. Digamos, que la linea llegue al punto final viniendo de arriba.</param>
      internal protected virtual void DrawFreeConnection(Graphics gr, Connection connection, Point freePoint, PinOrientation orientation)
      {
         DrawDirectConnector(gr, connection.From.Position, freePoint, true);
      }

      /// <summary>
      /// Metodo que visualiza un pin.
      /// </summary>
      /// <param name="gr">Objeto Graphics utilizado para pintar.</param>
      /// <param name="pin">Pin que se desea visualizar.</param>
      protected virtual void DrawPin(Graphics gr, Pin pin)
      {
         Point position = pin.Position;

         Rectangle pinRectangle = new Rectangle(position.X - PinSize.Width / 2, position.Y - PinSize.Height / 2, PinSize.Width, PinSize.Height);

         switch (pin.PinType)
         {
            case PinType.Input:
               gr.FillEllipse(Brushes.White, pinRectangle);
               gr.DrawEllipse(Pens.Black, pinRectangle);
               break;

            case PinType.Output:
               gr.FillRectangle(Brushes.White, pinRectangle);
               gr.DrawRectangle(Pens.Black, pinRectangle);
               break;
         }
      }

      /// <summary>
      /// Este metodo se invoca cuando se desea pintar los detalles de este elemento.
      /// </summary>
      /// <param name="e">Argumento con los elementos para visualizar.</param>
      internal protected virtual void OnPaint(PaintEventArgs e)
      {
         if (ShowInputPins || HighLight)
            foreach (Pin inputPin in ValidInputs)
               DrawPin(e.Graphics, inputPin);

         if (ShowOutputPins || HighLight)
            foreach (Pin outputPin in ValidOutputs)
               DrawPin(e.Graphics, outputPin);

         foreach (Connection connection in Connections)
            DrawConnection(e.Graphics, connection);
      }

      Color _BackColor = Color.Aquamarine;
      /// <summary>
      /// Determina o asigna el color de fondo de este elemento.
      /// </summary>
      [Category("Style")]
      public Color BackColor { get { return _BackColor; } set { _BackColor = value; } }

      Font _Font = new Font("Courier New", 9);
      /// <summary>
      /// Determina o asigna el tipo de letra del elemento.
      /// </summary>
      [Category("Style")]
      public virtual Font Font
      {
         get { return this._Font; }
         set { this._Font = value; }
      }

      /// <summary>
      /// Cuando se reimplemente, debe devolver el color por defecto del elemento.
      /// </summary>
      protected virtual Color DefaultColor
      {
         get { return this.BackColor; }
      }

   }

}
