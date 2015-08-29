using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Walle.UI.Dialogs{
   public partial class DlgNewActivity : Form
   {
      public DlgNewActivity()
      {
         InitializeComponent();
      }

      public string ActivityName { get; private set; }

      private void button1_Click(object sender, EventArgs e)
      {
         this.ActivityName = textBox1.Text;
      }

      private void DlgNewActivity_Validating(object sender, CancelEventArgs e)
      {
         if (this.textBox1.Text == ""){
            e.Cancel = true;
         }
      }

   }
}