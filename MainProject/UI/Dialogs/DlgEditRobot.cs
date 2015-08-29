using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Walle.Scenario;

namespace Walle.UI.Dialogs{
   public partial class DlgEditRobot : Form
   {
      private List<Item> ItemList;
      private Components.Robot RobotEdited;

      public DlgEditRobot(List<Item> list) // Para crear un nuevo robot y añadirlo a la lista
      {
         ItemList = list;
         InitializeComponent();
      }

      public DlgEditRobot(Components.Robot robotToEdit) // Para modificar un robot
      {
         RobotEdited = robotToEdit;
         InitializeComponent();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         string name = txtName.Text;
         int weight = 20;
         int volume = 30;
         int power = (int)nudPower.Value;
         int capacity = (int)nudCapacity.Value;
         int tempToMelt = (int) nudMeltTemp.Value;
         Bitmap lookingUp = new Bitmap(pboxLookingUp.Image);
         Bitmap lookingDown = new Bitmap(pboxLookingDown.Image);
         Bitmap lookingLeft = new Bitmap(pboxLookingLeft.Image);
         Bitmap lookingRight = new Bitmap(pboxLookingRight.Image);

         if (RobotEdited == null)
         {
            Components.Robot robot = new Components.Robot(name, weight, volume, power, capacity, tempToMelt, lookingUp, lookingRight, lookingDown, lookingLeft);
            ItemList.Add(robot);
         }
         else
         {
            RobotEdited.Name = name;
            RobotEdited.Power = power;
            RobotEdited.Capacity = capacity;
            RobotEdited.LookingUp = new Bitmap(lookingUp);
            RobotEdited.LookingDown = new Bitmap(lookingDown);
            RobotEdited.LookingLeft = new Bitmap(lookingLeft);
            RobotEdited.LookingRight = new Bitmap(lookingRight);
            RobotEdited.TempToMelt = tempToMelt;
         }
      }

      private void dlgEditItem_Load(object sender, EventArgs e)
      {
         if (RobotEdited != null)
         {
            txtName.Text = RobotEdited.Name;
            pboxLookingUp.Image = RobotEdited.LookingUp;
            pboxLookingDown.Image = RobotEdited.LookingDown;
            pboxLookingLeft.Image = RobotEdited.LookingLeft;
            pboxLookingRight.Image = RobotEdited.LookingRight;
            nudPower.Value = RobotEdited.Power;
            nudCapacity.Value = RobotEdited.Capacity;
            nudMeltTemp.Value = RobotEdited.TempToMelt;
         }

         btnOK.Enabled = pboxLookingUp.Image == null ? false : true;
      }

      private void pboxLooking_Click(object sender, EventArgs e)
      {
         var pbox = sender as PictureBox;

         if (pbox != null)
         {
            if (odlgOpenImage.ShowDialog() == DialogResult.OK)
            {
               Image image = Image.FromFile(odlgOpenImage.FileName);
               pbox.Image = new Bitmap(image);
            }

            if (pboxLookingUp.Image != null && pboxLookingDown.Image != null && pboxLookingLeft.Image != null && pboxLookingRight.Image != null)
               btnOK.Enabled = true;
         }
         else throw new Exception("This isn't supposed to happen!");

      }
   }
}