using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlowChartDesigner.Builders;
using FlowChartDesigner.ChartElements;

namespace FlowChartDesigner
{
   /// <summary>
   /// Este control visualiza un diagrama cuyos elementos se agregan en la coleccion Charts.
   /// </summary>
   public partial class FlowChartViewer : ScrollableControl
   {
      #region Instances

      /// <summary>
      /// Determina el elemento actualmente seleccionado.
      /// </summary>
      private ChartElement _SelectedItem = null;

      /// <summary>
      /// Determina los builders disponibles para agregar nuevos elementos en el diagrama.
      /// </summary>
      private List<ChartElementBuilder> builders = new List<ChartElementBuilder>();

      /// <summary>
      /// Determina si se esta estableciendo una conexion o no.
      /// </summary>
      private bool isConnecting = false;

      /// <summary>
      /// Ultima posicion del mouse. Se utiliza para determinar cuanto hay que desplazar un objeto que se esta haciendo drag and drop.
      /// </summary>
      private Point lastMousePlace;

      /// <summary>
      /// Determina la conexion que esta siendo cambiada.
      /// </summary>
      private Connection modifyingConnection = null;

      #endregion

      #region Constructor

      /// <summary>
      /// Inicializa el control.
      /// </summary>
      public FlowChartViewer()
      {
         InitializeComponent();

         // El metodo SetStyle permite configurar aspectos de la ejecucion de un control en los momentos de visualizacion e interaccion.
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         // determina que se debe utilizar doble buffer para evitar el parpadeo durante las animaciones.
         SetStyle(ControlStyles.UserPaint, true); // determina que se debe disparar el evento Paint.
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         // determina que todo el pintado sera establecido en el metodo OnPaint por lo que no se borra el fondo y evita parpadeo.

         // se crea una coleccion para almacenar los elementos del diagrama.
         this._Charts = new ChartElementCollection();
         // se suscribe al evento que notifica el cambio en la coleccion y esto permite refrescar visualmente el control a cualquiera de estos cambios.
         //Charts.CollectionChanged += new EventHandler(Charts_CollectionChanged);

         AutoScroll = true;
      }

      #endregion

      #region Privates

      /// <summary>
      /// Determina la distancia euclideana entre dos puntos.
      /// </summary>
      private double Distance(Point p1, Point p2)
      {
         return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
      }

      /// <summary>
      /// Crea un menu contextual global.
      /// </summary>
      private ContextMenu GetGlobalContextMenu(Point center)
      {
         var cm = new ContextMenu();

         // Opcion Create... esta opcion permitira agregar nuevos elementos al diagrama.
         var create = new MenuItem("Create");
         foreach (ChartElementBuilder builder in Builders)
         // Para cada objeto "Builder" se crea una opcion dentro del menu item.
         {
            var builderMenuItem = new MenuItem();
            builder.Center = center; // se especifica al builder donde quedaria el elemento.
            builderMenuItem.Text = builder.BuilderName; // se nombra la opcion con el nombre del Builder.

            if(builder is NormalChartBuilder){
               builderMenuItem.Click += new EventHandler(builderMenuItem_Click); // se suscribe al metodo Click para realizar la accion para esta opcion.
               builderMenuItem.Tag = builder; // se asocia el builder al menu item para su futuro uso.
            }
            else if (builder is PredefinedChartBuilder ){

               var predefinedBuilder = (PredefinedChartBuilder) builder;

               if (predefinedBuilder.ValuesList != null && predefinedBuilder.ValuesList.Count > 0){
                  foreach (var name in ((PredefinedChartBuilder)builder).ValuesList)
                  {
                     MenuItem specialOption = new MenuItem(name);
                     specialOption.Tag = builder;
                     specialOption.Click += builderMenuItem_Click;
                     builderMenuItem.Enabled = true;
                     builderMenuItem.MenuItems.Add(specialOption);
                  }   
               } else builderMenuItem.Enabled = false;
            }
            create.MenuItems.Add(builderMenuItem);
            // se adiciona el menu item como submenu dentro del menu Create.
         }

         cm.MenuItems.Add(create); // se agrega Create como unica opcion del menu contextual global.

         // Utilice este menu contextual para agregar nuevas opciones a nivel global que Ud. decida.

         return cm;
      }

      private void builderMenuItem_Click(object sender, EventArgs e)
      {
         var item = sender as MenuItem;
         var builder = item.Tag as ChartElementBuilder; // se recupera el Builder a partir del menu item.

         ChartElement element = builder.Build(item.Index); // se crea un nuevo elemento utilizando ese builder.
         
         if (element is BeginChartElement && Charts.First != null){
            if (AddedASecondBeginElement != null) AddedASecondBeginElement.Invoke(this, EventArgs.Empty);
         }
         else
            Charts.Add(element); // se agrega a la coleccion de elementos del diagrama.

         Invalidate();
      }

      /// <summary>
      /// Crea un menu contextual para cierto elemento del diagrama.
      /// Permite eliminar el elemento, conectar a otro, etc.
      /// </summary>
      /// <param name="chart">Elemento al que se le aplican las opciones.</param>
      /// <returns>Un objeto ContextMenu con las opciones.</returns>
      private ContextMenu GetContextMenuFor(ChartElement chart)
      {
         var cm = new ContextMenu();

         foreach (Connection c in chart.Connections) // para cada conexion del elemento
         {
            var item = new MenuItem(); // se crea un nuevo MenuItem.
            item.Text = "Connect " + c.Label + " to..."; // el texto del menu es la etiqueta de la conexion.
            item.Tag = c; // se almacena la conexion como un objeto asociado al MenuItem.
            item.Click += new EventHandler(item_Click);
            // se determina que accion se ejecuta para el click del MenuItem.
            cm.MenuItems.Add(item); // se agrega el menu item a los menuItems del menu contextual.
         }

         var sep = new MenuItem();
         sep.Text = "-";

         cm.MenuItems.Add(sep);

         var removeMenuItem = new MenuItem();
         removeMenuItem.Text = "Remove";
         removeMenuItem.Tag = chart;
         removeMenuItem.Click += new EventHandler(removeMenuItem_Click);

         cm.MenuItems.Add(removeMenuItem);
         return cm;
      }

      /// <summary>
      /// Accion que se produce cuando se elimina un elemento.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void removeMenuItem_Click(object sender, EventArgs e)
      {
         var item = sender as MenuItem;

         var element = item.Tag as ChartElement;

         if (element is BeginChartElement) this.Charts.First = null;

         Charts.Remove(element);
      }

      /// <summary>
      /// Accion que se produce cuando se selecciona una conexion.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void item_Click(object sender, EventArgs e)
      {
         var item = sender as MenuItem;
         // recuperar la conexion de la propiedad Tag.
         var connection = item.Tag as Connection;
         modifyingConnection = connection;
         isConnecting = true;
      }

      #endregion

      #region Public

      private ChartElementCollection _Charts;

      /// <summary>
      /// Devuelve el conjunto de elementos del diagrama.
      /// </summary>
      public ChartElementCollection Charts
      {
         get { return _Charts; }
      }

      /// <summary>
      /// Cambia el ChartElementCollection a mostrar.
      /// </summary>
      /// <param name="charts">La coleccion de charts a mostrar.</param>
      public void ChangeCurrentChartCollection(ChartElementCollection charts){
         this._Charts = charts;
         this.Invalidate();
      }

      /// <summary>
      /// Devuelve o establece el elemento seleccionado dentro del diagrama.
      /// </summary>
      public ChartElement SelectedItem
      {
         get { return _SelectedItem; }
         set
         {
            _SelectedItem = value;

            if (SelectedItemChanged != null)
               SelectedItemChanged(this, EventArgs.Empty);
         }
      }

      /// <summary>
      /// Devuelve una lista con los builders disponibles para agregar elementos en el diagrama.
      /// Utilice esta lista para agregar builders y aumentar asi los posibles elementos a estar presentes en el diagrama.
      /// </summary>
      public IList<ChartElementBuilder> Builders
      {
         get { return builders; }
      }

      /// <summary>
      /// Evento que se dispara cuando un elemento del diagrama es seleccionado.
      /// </summary>
      public event EventHandler SelectedItemChanged;

      /// <summary>
      /// Notifica que el usuario ha intentado agregar un segundo elemento Begin.
      /// </summary>
      public event EventHandler AddedASecondBeginElement;

      #endregion

      #region Protected

      /// <summary>
      /// Metodo que se invoca cuando el mouse se mueve sobre el control.
      /// </summary>
      /// <param name="e"></param>
      protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);

         Point mousePositionInCanvas = FromClientToCanvas(e.Location);

         if (e.Button == MouseButtons.Left && SelectedItem != null)
         {
            Rectangle translate = SelectedItem.Display;
            translate.Offset(mousePositionInCanvas.X - lastMousePlace.X,
                             mousePositionInCanvas.Y - lastMousePlace.Y);
            SelectedItem.Display = translate;
         }

         foreach (ChartElement c in Charts)
            if (c.Display.Contains(mousePositionInCanvas))
            {
               c.HighLight = true;
            }
            else
               c.HighLight = false;

         lastMousePlace = mousePositionInCanvas;

         Invalidate();
      }

      /// <summary>
      /// Este metodo permite convertir una coordenada del area cliente en una coordenada en el lienzo real *considerando la posicion del scroll*.
      /// </summary>
      protected Point FromClientToCanvas(Point p)
      {
         p.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);
         return p;
      }

      /// <summary>
      /// Metodo que se invoca cuando se presiona un boton del mouse.
      /// </summary>
      /// <param name="e"></param>
      protected override void OnMouseDown(MouseEventArgs e)
      {
         lastMousePlace = FromClientToCanvas(e.Location);

         ChartElement nextSelected = null;

         foreach (ChartElement c in Charts)
            if (c.Display.Contains(FromClientToCanvas(e.Location)))
               nextSelected = c;

         if (SelectedItem != null) SelectedItem.Selected = false;
         SelectedItem = nextSelected;
         if (SelectedItem != null) SelectedItem.Selected = true;

         if (e.Button == MouseButtons.Right)
         {
            isConnecting = false;
            modifyingConnection = null;

            if (SelectedItem != null)
            {
               ContextMenu cm = GetContextMenuFor(SelectedItem);
               ContextMenu = cm;
            }
            else
            {
               ContextMenu cm = GetGlobalContextMenu(FromClientToCanvas(e.Location));
               ContextMenu = cm;
            }
         }
         else
         {
            if (isConnecting)
            {
               Pin nearestInput = null;
               if (SelectedItem != null)
                  foreach (Pin input in SelectedItem.ValidInputs)
                     if (nearestInput == null ||
                         Distance(input.Position, FromClientToCanvas(e.Location)) <
                         Distance(nearestInput.Position, FromClientToCanvas(e.Location)))
                        nearestInput = input;

               modifyingConnection.To = nearestInput;
               isConnecting = false;
               modifyingConnection = null;
            }
         }

         Invalidate();

         base.OnMouseDown(e);
      }

      protected override void OnScroll(ScrollEventArgs se)
      {
         base.OnScroll(se);

         Invalidate();
      }

      /// <summary>
      /// Metodo que se invoca cuando se repinta el control.
      /// </summary>
      /// <param name="e"></param>
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);

         var transform = new Matrix();
         transform.Translate(AutoScrollPosition.X, AutoScrollPosition.Y);
         e.Graphics.Transform = transform;

         e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
         e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

         int maxX = 0, maxY = 0;

         foreach (ChartElement chart in Charts)
         {
            chart.OnPaintBackground(e);
            chart.OnPaint(e);

            maxX = Math.Max(maxX, chart.Display.Right);
            maxY = Math.Max(maxY, chart.Display.Bottom);
         }

         if (isConnecting)
            modifyingConnection.From.ChartElement.DrawFreeConnection(e.Graphics, modifyingConnection,
                                                                     FromClientToCanvas(
                                                                               PointToClient(MousePosition)),
                                                                     PinOrientation.Up);

         AutoScrollMinSize = new Size(maxX, maxY);
      }

      #endregion
   }
}