using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Walle.Scenario;
using Walle.UI.Dialogs;

namespace Walle.UI{
   public delegate void ErrorEventHandler(Exception e);

   public partial class FormMapDesigner : Form
   {
      #region Instance Variables
      /// <summary>
      /// Mapa a modificar.
      /// </summary>
      Map map;

      /// <summary>
      /// Paleta de tipos de celdas.
      /// </summary>
      List<Cell> cellList = new List<Cell>();
      /// <summary>
      /// Paleta de tipos de objetos.
      /// </summary>
      List<Item> itemList = new List<Item>();

      // Dialogos para editar y crear nuevos tipos.
      private DlgEditCell editCellDialog;
      private DlgEditItem editItemDialog;
      private DlgNewMap newMapDialog;
      private DlgEditRobot editRobotDialog;

      #endregion

      #region Constructor and Form_Load
      public FormMapDesigner()
      {
         InitializeComponent();
      }
      private void FormMapDesigner_Load(object sender, EventArgs e)
      {
         lstItems.Items.Add("(none)"); // El elemento none permite eliminar un objeto de una celda en especifico.
      }
      #endregion

      #region Auxiliar Methods

      /// <summary>
      /// Actualiza el listbox de celdas.
      /// </summary>
      private void UpdateCellList()
      {
         lstCells.Items.Clear();
         foreach (Cell type in cellList)
         {
            lstCells.Items.Add(type.Name);
         }
      }
      /// <summary>
      /// Actualiza el listbox de objetos.
      /// </summary>
      private void UpdateItemList()
      {
         lstItems.Items.Clear();
         foreach (Item item in itemList)
         {
            if (item is Components.Robot)
            {
               lstItems.Items.Add(item.Name + " (robot)");
            }
            else
            {
               lstItems.Items.Add(item.Name);
            }
         }
         lstItems.Items.Add("(none)");
      }
      /// <summary>
      /// Crea e inicializa un nuevo mapa.
      /// </summary>
      private void CreateMap()
      {
         newMapDialog = new DlgNewMap(cellList);
         if (cellList.Count > 0 && newMapDialog.ShowDialog() == DialogResult.OK)
         {
            map = new Map(newMapDialog.NewMapHeight, newMapDialog.NewMapWidth, cellList[newMapDialog.DefaultCellIndex]);
            ResizeBox();
         }
      }
      /// <summary>
      /// Redimensiona el formulario para ajustarse al tamaño del mapa.
      /// </summary>
      private void ResizeBox()
      {
         if (map != null)
         {
            pboxGrid.Size = new Size(map.GetLength(1) * map[0, 0].Image.Width,
                                     map.GetLength(0) * map[0, 0].Image.Height);
            Size size = new Size(pboxGrid.Location.X + pboxGrid.Width + 30, pboxGrid.Location.Y + pboxGrid.Height + 60);
            if (size.Height < 563) size.Height = 563;
            Size = size;
         }
      }

      #endregion

      #region Preview Events
      /// <summary>
      /// Actualiza la imagen de la celda mostrada.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void lstCellTypes_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (lstCells.SelectedIndex != -1)
         {
            pboxCellPreview.Image = cellList[lstCells.SelectedIndex].Image;
         }
      }
      /// <summary>
      /// Actualiza la imagen mostrada del objeto seleccionado.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (lstItems.SelectedIndex != -1 && lstItems.SelectedIndex != itemList.Count)
         {
            pboxItemPreview.Image = itemList[lstItems.SelectedIndex].Image;
         }
         else pboxItemPreview.Image = null;
      }
      #endregion

      #region Cell and Item Editor
      /// <summary>
      /// Permite editar las propiedades del tipo de celda seleccionado.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void pboxCellPreview_Click(object sender, EventArgs e)
      {
         if (lstCells.SelectedIndex != -1)
         {
            editCellDialog = new DlgEditCell(cellList[lstCells.SelectedIndex]);
            if (editCellDialog.ShowDialog() == DialogResult.OK)
            {
               int selected = lstCells.SelectedIndex;
               UpdateCellList();
               lstCells.SelectedIndex = selected;
               pboxGrid.Invalidate();
            }
         }
      }
      /// <summary>
      /// Permite modificar las propiedades del tipo de objeto seleccionado.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void pboxItemPreview_Click(object sender, EventArgs e)
      {
         if (lstItems.SelectedIndex > -1 && lstItems.SelectedIndex < itemList.Count)
         {
            if (itemList[lstItems.SelectedIndex] is Components.Robot)
            {
               editRobotDialog = new DlgEditRobot((Components.Robot)itemList[lstItems.SelectedIndex]);
               if (editRobotDialog.ShowDialog() == DialogResult.OK)
               {
                  int selected = lstItems.SelectedIndex;
                  UpdateItemList();
                  lstCells.SelectedIndex = selected;
                  pboxGrid.Invalidate();
               }
            }
            else
            {
               editItemDialog = new DlgEditItem(itemList[lstItems.SelectedIndex]);
               if (editItemDialog.ShowDialog() == DialogResult.OK)
               {
                  int selected = lstItems.SelectedIndex;
                  UpdateItemList();
                  lstCells.SelectedIndex = selected;
                  pboxGrid.Invalidate();
               }
            }
         }
      }
      #endregion

      #region Menu Options

      #region Map Options
      /// <summary>
      /// Crea un nuevo mapa.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuNewMap_Click(object sender, EventArgs e)
      {
         if (cellList.Count == 0)
         {
            MessageBox.Show("Please load a valid terrain palette first!");
            menuLoadCellPalette_Click(sender, e);
         }
         CreateMap();

         pboxGrid.Invalidate();
      }
      /// <summary>
      /// Cierra el mapa actual.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuCloseMap_Click(object sender, EventArgs e)
      {
         map = null;
         pboxGrid.Invalidate();
      }
      /// <summary>
      /// Carga un mapa de disco para modificarlo.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuOpenMap_Click(object sender, EventArgs e)
      {
         if (openMapDialog.ShowDialog() == DialogResult.OK){
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(openMapDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            map = (Map) formatter.Deserialize(stream);
            stream.Close();

            cellList = map.FieldPalette;
            itemList = map.ItemPalette;

            UpdateCellList();
            UpdateItemList();
         }
         ResizeBox();
         pboxGrid.Invalidate();
      }
      /// <summary>
      /// Guarda el mapa actual.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuSaveMap_Click(object sender, EventArgs e)
      {
         try
         {
            if (map != null)
            {
               if (this.map.HasRobot)
               {

                  if (saveMapDialog.ShowDialog() == DialogResult.OK)
                  {
                     map.ItemPalette = itemList;
                     map.FieldPalette = cellList;

                     IFormatter formatter = new BinaryFormatter();
                     Stream stream = new FileStream(saveMapDialog.FileName, FileMode.Create,
                                                    FileAccess.Write, FileShare.None);
                     formatter.Serialize(stream, map);
                     stream.Close();
                  }
               }

               else
                  MessageBox.Show("This map doesn't have a robot!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else MessageBox.Show("No map to save.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
      #endregion

      #region Palette Options
      /// <summary>
      /// Carga una paleta de objetos.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuLoadItemPalette_Click(object sender, EventArgs e)
      {
         if (openItemPaletteDialog.ShowDialog() == DialogResult.OK)
         {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(openItemPaletteDialog.FileName, FileMode.Open, FileAccess.Read,
                                           FileShare.Read);
            itemList = (List<Item>)formatter.Deserialize(stream);
            stream.Close();
            UpdateItemList();
         }
      }
      /// <summary>
      /// Carga una paleta de celdas.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuLoadCellPalette_Click(object sender, EventArgs e)
      {
         if (openCellPaletteDialog.ShowDialog() == DialogResult.OK)
         {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(openCellPaletteDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            cellList = (List<Cell>)formatter.Deserialize(stream);
            stream.Close();
            UpdateCellList();
         }
      }

      /// <summary>
      /// Guarda a disco una paleta de objetos.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuSaveItemPalette_Click(object sender, EventArgs e)
      {
         if (itemList.Count > 0)
         {
            if (saveItemPaletteDialog.ShowDialog() == DialogResult.OK)
            {
               try
               {

                  IFormatter formatter = new BinaryFormatter();
                  Stream stream = new FileStream(saveItemPaletteDialog.FileName, FileMode.Create,
                                                 FileAccess.Write, FileShare.None);
                  formatter.Serialize(stream, itemList);
                  stream.Close();
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message);
               }
            }
         }
         else MessageBox.Show("Why are you saving an empty palette?");
      }

      /// <summary>
      /// Guarda a disco una paleta de celdas.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuSaveCellPalette_Click(object sender, EventArgs e)
      {
         if (cellList.Count > 0)
         {
            if (saveCellPaletteDialog.ShowDialog() == DialogResult.OK)
            {
               IFormatter formatter = new BinaryFormatter();
               Stream stream = new FileStream(saveCellPaletteDialog.FileName, FileMode.Create,
                                              FileAccess.Write, FileShare.None);
               formatter.Serialize(stream, cellList);
               stream.Close();
            }
         }
         else MessageBox.Show("Why are you saving an empty palette?");
      }

      /// <summary>
      /// Elimina el tipo de celda seleccionado de la lista.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuRemoveSCell_Click(object sender, EventArgs e)
      {
         if (lstCells.SelectedIndex != -1)
         {
            cellList.RemoveAt(lstCells.SelectedIndex);
            lstCells.Items.RemoveAt(lstCells.SelectedIndex);
         }
         pboxGrid.Invalidate();
      }
      /// <summary>
      /// Elimina todos los tipos de celda de la lista.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuRemoveAllCells_Click(object sender, EventArgs e)
      {
         lstCells.Items.Clear();
         cellList.Clear();
         pboxGrid.Invalidate();
      }
      /// <summary>
      /// Elimina el objeto seleccionado de la lista.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuRemoveSItem_Click(object sender, EventArgs e)
      {
         {
            if (lstItems.SelectedIndex != -1)
            {
               itemList.RemoveAt(lstItems.SelectedIndex);
               lstItems.Items.RemoveAt(lstItems.SelectedIndex);
            }
         }
      }
      /// <summary>
      /// Elimina todos los objetos de la lista.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuRemoveAllItems_Click(object sender, EventArgs e)
      {
         lstItems.Items.Clear();
         itemList.Clear();
         lstItems.Items.Add("(none)");
      }

      /// <summary>
      /// Agrega un nuevo tipo de objeto.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuAddNewItem_Click(object sender, EventArgs e)
      {
         editItemDialog = new DlgEditItem(itemList);
         if (editItemDialog.ShowDialog() == DialogResult.OK)
            UpdateItemList();
      }
      /// <summary>
      /// Permite crear un nuevo robot.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuAddNewRobot_Click(object sender, EventArgs e)
      {
         editRobotDialog = new DlgEditRobot(itemList);
         if (editRobotDialog.ShowDialog() == DialogResult.OK)
            UpdateItemList();
      }
      /// <summary>
      /// Permite crear una nueva celda.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuAddNewCell_Click(object sender, EventArgs e)
      {
         editCellDialog = new DlgEditCell(cellList);
         if (editCellDialog.ShowDialog() == DialogResult.OK)
            UpdateCellList();
      }

      #endregion

      #endregion

      #region Misc Methods
      /// <summary>
      /// Cierra el formulario.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }
      #endregion

      #region Canvas EventHandlers
      /// <summary>
      /// Pinta el mapa.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void pboxGrid_Paint(object sender, PaintEventArgs e)
      {
         Bitmap canvas = new Bitmap(pboxGrid.Width, pboxGrid.Height, e.Graphics);
         Graphics g = Graphics.FromImage(canvas);

         if (map != null)
         {
            for (int i = 0; i < map.GetLength(0); i++)
            {
               for (int j = 0; j < map.GetLength(1); j++)
               {
                  g.DrawImage(map[i, j].Image, j * map[0, 0].Image.Width, i * map[0, 0].Image.Height);
                  if (map[i, j].FilledBy != null)
                  {
                     Rectangle dstRect = new Rectangle(j * map[0, 0].Image.Width, i * map[0, 0].Image.Height,
                                                       map[0, 0].Image.Width, map[0, 0].Image.Height);
                     g.DrawImage(map[i, j].FilledBy.Image, dstRect);
                  }
                  if (map[i, j].Item != null)
                  {
                     Bitmap bmp = new Bitmap(map[i, j].Item.Image);
                     Rectangle dstRect = new Rectangle(j * map[0, 0].Image.Width, i * map[0, 0].Image.Height,
                                                       map[i, j].Image.Width, map[i, j].Image.Height);
                     g.DrawImage(bmp, dstRect);
                  }
               }
            }
            e.Graphics.DrawImage(canvas, new PointF(0F, 0F));
         }
      }
      /// <summary>
      /// Captura los clicks en el mapa. Este metodo es el encargado de modificar el mapa.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void pboxGrid_MouseClick(object sender, MouseEventArgs e)
      {
         if (map != null)
         {
            int i = e.Y / map[0, 0].Image.Height;
            int j = e.X / map[0, 0].Image.Width;

            if (e.Button == MouseButtons.Left && lstCells.SelectedIndex != -1)
            {
               map[i, j] = (Cell)cellList[lstCells.SelectedIndex].Clone();
            }
            else if (e.Button == MouseButtons.Right && lstItems.SelectedIndex != -1)
            {
               if (lstItems.SelectedIndex == itemList.Count)
               {
                  map[i, j].Item = null;
               }
               else if (!(itemList[lstItems.SelectedIndex] is Components.Robot))
               {
                  map[i, j].Item = (Item)itemList[lstItems.SelectedIndex].Clone();
               }
               else
               {
                  Components.Robot robot = (Components.Robot)itemList[lstItems.SelectedIndex];
                  robot.PlaceInMap(map, new Point(i, j));
               }

            }
            pboxGrid.Invalidate();
         }
      }
      #endregion


   }
}