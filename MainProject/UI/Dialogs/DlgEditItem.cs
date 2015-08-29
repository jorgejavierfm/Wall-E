using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Walle.Scenario;

namespace Walle.UI.Dialogs{
   public partial class DlgEditItem : Form
   {
      private List<Item> itemList;
      private Item itemEdited;

      public DlgEditItem(List<Item> list) // Para crear un nuevo objeto y añadirlo a la lista
      {
         itemList = list;
         InitializeComponent();
      }
      
      public DlgEditItem(Item itemToEdit) // Para modificar un objeto del mapa
      {
         itemEdited = itemToEdit;
         InitializeComponent();
      }
      private void pboxImage_Click(object sender, EventArgs e)
      {
         if (odlgOpenImage.ShowDialog() == DialogResult.OK)
         {
            Image image = Image.FromFile(odlgOpenImage.FileName);
            Bitmap bmp = new Bitmap(image);
            bmp.MakeTransparent(bmp.GetPixel(0, 0));
            Bitmap resizedBmp = new Bitmap(bmp,32,32);
            pboxImage.Image = resizedBmp;
            if(comboBox1.SelectedIndex != -1) btnOK.Enabled = true;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         string name = txtName.Text;
         Bitmap image = new Bitmap(pboxImage.Image);
         int weight = (int)nudWeight.Value;
         int volume = (int)nudVolume.Value;
         int tempToMelt = (int)nudMeltTemp.Value;
         bool fillsHoles = chkFill.Checked;
         bool floats = chkFloat.Checked;

         Color itemColor = Color.FromName(comboBox1.SelectedItem.ToString());

         if (itemEdited == null)
         {
            Item item = new Item(name, image, weight, volume, tempToMelt, fillsHoles, floats,itemColor);
            itemList.Add(item);
         }
         else
         {
            itemEdited.Name = name;
            itemEdited.Image = image;
            itemEdited.Weight = weight;
            itemEdited.Volume = volume;
            itemEdited.TempToMelt = tempToMelt;
            itemEdited.CanFillHoles = fillsHoles;
            itemEdited.Floats = floats;
            itemEdited.Color = itemColor;
         }
      }

      private void dlgEditItem_Load(object sender, EventArgs e)
      {
         //Usar Reflection para añadir solo colores validos soportados por .NET a la lista de colores posibles.
         Color c;
         Type colorType = typeof(Color);
         PropertyInfo[] infos = colorType.GetProperties(BindingFlags.Public | BindingFlags.Static);
         foreach (PropertyInfo info in infos)
         {
            // Don't add Transparent to the list
            if (info.Name == "Transparent")
            {
               continue;
            }
            if (info.PropertyType == typeof(Color))
            {
               c = (Color)info.GetValue(Color.Empty, null);
               comboBox1.Items.Add(c.Name);
            }
         }

         if (itemEdited != null)
         {
            txtName.Text = itemEdited.Name;
            pboxImage.Image = itemEdited.Image;
            nudWeight.Value = itemEdited.Weight;
            nudVolume.Value = itemEdited.Volume;
            nudMeltTemp.Value = itemEdited.TempToMelt;
            chkFill.Checked = itemEdited.CanFillHoles;
            chkFloat.Checked = itemEdited.Floats;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(itemEdited.Color.Name);
         }

         btnOK.Enabled = pboxImage.Image == null ? false : true;
      }

   }
}