using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Walle.Scenario;
using Walle.UI;

namespace Walle.UI
{
   public partial class FormManual : Form
   {
      private Map map;
      private FormMain mainForm;

      public FormManual(Map map, FormMain mainForm)
      {
         InitializeComponent();
         this.map = map;
         this.mainForm = mainForm;
      }

      /// <summary>
      /// Al cerrarse este formulario, vuelve a mostrar el principal.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void FormManual_FormClosed(object sender, FormClosedEventArgs e)
      {
         mainForm.Show();
         mainForm.Activate();
      }

      /// <summary>
      /// Pinta el mapa.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void pictureBox2_Paint(object sender, PaintEventArgs e)
      {

         Bitmap canvas = new Bitmap(pboxCanvas.Width, pboxCanvas.Height, e.Graphics);
         Graphics g = Graphics.FromImage(canvas);
         Pen pen = new Pen(Color.Black, 1);

         if (map != null)
         {
            for (int i = 0; i < map.GetLength(0); i++)
            {
               for (int j = 0; j < map.GetLength(1); j++)
               {
                  g.DrawImage(map[i, j].Image, j * map[0, 0].Image.Width, i * map[0, 0].Image.Height);
                  Rectangle destinationRectangle = new Rectangle(j * map[0, 0].Image.Width, i * map[0, 0].Image.Height,
                                                      map[0, 0].Image.Width, map[0, 0].Image.Height);
                  if (map[i, j].FilledBy != null)
                  {
                     g.DrawImage(map[i, j].FilledBy.Image, destinationRectangle);
                  }
                  if (map[i, j].Item != null)
                  {
                     Bitmap bmp = new Bitmap(map[i, j].Item.Image);
                     g.DrawImage(bmp, destinationRectangle);
                  }
               }
            }
            e.Graphics.DrawImage(canvas, new PointF(0F, 0F));
         }
      }

      /// <summary>
      /// Captura las teclas presionadas, y maneja al robot.
      /// W para avanzar,
      /// S para retroceder,
      /// A para girar izquierda,
      /// D para girar derecha,
      /// Barra espaciadora para cargar o descargar objetos.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void FormManual_KeyDown(object sender, KeyEventArgs e)
      {
         try
         {
            e.Handled = true;
            if (map.Robot != null)
               switch (e.KeyCode)
               {
                  case Keys.W:
                     map.Robot.Motor.MoveForward();
                     break;
                  case Keys.S:
                     map.Robot.Motor.MoveBackward();
                     break;
                  case Keys.A:
                     map.Robot.Motor.TurnLeft();
                     break;
                  case Keys.D:
                     map.Robot.Motor.TurnRight();
                     break;
                  case Keys.Space:
                     if (map.Robot.LoadedItem == null)
                        map.Robot.Motor.LoadItem();
                     else map.Robot.Motor.UnloadItem();
                     break;
                  default:
                     break;
               }
         }
         catch (RobotDeathException)
         {
            MessageBox.Show("You have killed your own robot!","Good job!");
         }
         if (map.Robot != null) lblSensors.Text = map.Robot.Sensors.ToString();
         pboxCanvas.Invalidate();
      }

      /// <summary>
      /// Al cargar el formulario, pone las dimensiones por defecto.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void FormManual_Load(object sender, EventArgs e)
      {
         lblSensors.Text = map.Robot.Sensors.ToString();
         int width = splitContainer1.Panel1.Width + 12  + map[0, 0].Image.Width * map.GetLength(1);
         int height = map.GetLength(0) * map[0,0].Image.Height + 25;
         if (height < 500) height = 500;
         this.Size = new Size(width, height);
      }

      /// <summary>
      /// Muestra las propiedades de los elementos sobre los que esta el cursor.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void pboxCanvas_MouseMove(object sender, MouseEventArgs e)
      {
         int i = e.Y / map[0, 0].Image.Height;
         int j = e.X / map[0, 0].Image.Width;

         if (map.PosInRange(new Point(i, j)))
         {
            if (map[i, j].Item != null)
               lblItem.Text = map[i, j].Item.ToString();

            else
            {
               lblItem.Text = "";
            }

            lblCell.Text = map[i, j].ToString();
         }
      }

      /// <summary>
      /// Al salir el mouse del mapa, oculta los labels.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void pboxCanvas_MouseLeave(object sender, EventArgs e)
      {
         lblCell.Text = "";
         lblItem.Text = "";
      }

   }

}

