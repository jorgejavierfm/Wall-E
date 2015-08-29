using System.Collections.Generic;
using System.Windows.Forms;
using Walle.Scenario;

namespace Walle.UI.Dialogs{
   public partial class DlgNewMap : Form
   {
      public int NewMapWidth { get; private set; }
      public int NewMapHeight { get; private set; }

      public int DefaultCellIndex { get; private set; }

      public DlgNewMap(List<Cell> cells)
      {
         InitializeComponent();
         if (cells != null){
            foreach (var s in cells){
               cmbType.Items.Add(s.Name);
            }
         }
      }

      private void btnOK_Click(object sender, System.EventArgs e)
      {
         NewMapWidth = (int)nudWidth.Value;
         NewMapHeight = (int)nudHeight.Value;
         DefaultCellIndex = cmbType.SelectedIndex;
      }

      private void DlgNewMap_Load(object sender, System.EventArgs e)
      {
         if (cmbType.SelectedIndex != -1){
            btnOK.Enabled = true;
         }
      }

      private void cmbType_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if (cmbType.SelectedIndex != -1)
         {
            btnOK.Enabled = true;
         }
      }
   }
}