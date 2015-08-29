using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Walle.Scenario;

namespace Walle.UI.Dialogs{
   public partial class DlgEditCell : Form
   {
      private List<Cell> cellList;
      private Cell cellEditing;

      public DlgEditCell(List<Cell> list) // Para crear una nueva celda y añadirla a la lista
      {
         cellList = list;
         InitializeComponent();
      }

      public DlgEditCell(Cell cellToEdit) // Para modificar una celda del mapa
      {
         cellEditing = cellToEdit;
         InitializeComponent();
      }

      private void pboxImage_Click(object sender, EventArgs e)
      {
         if (odlgOpenImage.ShowDialog() == DialogResult.OK)
         {
            Image image = Image.FromFile(odlgOpenImage.FileName);

            Bitmap bmp = new Bitmap(32,32);
            Graphics g = Graphics.FromImage(bmp);

            g.DrawImage(image, 0, 0, 33, 33); // Para evitar una franja blanca si la imagen es menor 32x32.

            pboxImage.Image = bmp;
            btnOK.Enabled = true;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         string name = txtName.Text;
         int temp = (int)nudTemp.Value;
         Image image = pboxImage.Image;
         bool isHole = chkHole.Checked;
         bool isLiquid = chkLiquid.Checked;

         Cell cell = new Cell(name, temp, image, isHole, isLiquid);

         if (cellEditing == null)
         {
            cellList.Add(cell);
         }
         else
         {
            cellEditing.Name = cell.Name;
            cellEditing.Image = cell.Image;
            cellEditing.IsHole = cell.IsHole;
            cellEditing.Temperature = cell.Temperature;
            cellEditing.IsLiquid = cell.IsLiquid;
         }
      }

      private void dlgEditCell_Load(object sender, EventArgs e)
      {
         if (cellEditing != null)
         {
            txtName.Text = cellEditing.Name;
            nudTemp.Value = cellEditing.Temperature;
            pboxImage.Image = cellEditing.Image;
            chkHole.Checked = cellEditing.IsHole;
            chkLiquid.Checked = cellEditing.IsLiquid;
         }

         btnOK.Enabled = pboxImage.Image == null ? false : true;
      }

      private void chkLiquid_CheckedChanged(object sender, EventArgs e)
      {
         if (chkLiquid.Checked) chkHole.Checked = false;
      }

      private void chkHole_CheckedChanged(object sender, EventArgs e)
      {
         if (chkHole.Checked) chkLiquid.Checked = false;
      }
   }
}