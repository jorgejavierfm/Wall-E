using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using FlowChartDesigner;
using Walle.Components;
using Walle.Scenario;
using Walle.UI;

namespace Walle.UI
{
   public partial class FormMain : Form
   {
      private Map map;
      private Dictionary<string, ChartElementCollection> algorithmList = new Dictionary<string, ChartElementCollection>();
      private Interpreter interpreter; 

      private Thread t; // Hilo separado para ejecutar el interprete de instrucciones.

      private FormAlgDesigner algorithmDesigner;
      private FormMapDesigner mapDesigner;

      public FormMain()
      {
         InitializeComponent();

         ChartElementCollection defaultAlgorithm = new ChartElementCollection();
         algorithmList.Add("Main", defaultAlgorithm);

         CheckForIllegalCrossThreadCalls = false; // Esto permite modificar objetos creados en otro hilo de forma sencilla (suprime).
      }

      /// <summary>
      /// Carga un mapa de disco.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void OpenMap_Click(object sender, EventArgs e)
      {
         if (openMapDialog.ShowDialog() == DialogResult.OK)
         {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(openMapDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            map = (Map)formatter.Deserialize(stream);
            stream.Close();

            Size = new Size(map[0, 0].Image.Width * map.GetLength(1) + 9, map[0, 0].Image.Height * map.GetLength(0) + menuToolbar.Height + statusStrip.Height + mainToolStrip.Height + 32);

            map.Movement += MapSomethingMoved;
            map.Interaction += UpdateStatusText;
            map.Interaction += MapSomethingMoved;
            map.Robot.Motor.UnableToLoad += Robot_UnableToLoad;
            map.Robot.Motor.UnableToUnload += Robot_UnableToUnload;
            map.Robot.Motor.UnableToMove += Robot_UnableToMove;

            this.statusLabel.Text = "Event messages will appear here.";
            pboxCanvas.Image = null;
            pboxCanvas.Invalidate();
            statusStrip.Visible = true;
         }
      }

      /// <summary>
      /// Pinta el mapa en el lienzo.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Canvas_Paint(object sender, PaintEventArgs e)
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
                  if (showGridMenuItem.Checked)
                  {
                     g.DrawRectangle(pen, destinationRectangle);
                  }
               }
            }
            e.Graphics.DrawImage(canvas, new PointF(0F, 0F));
         }
      }

      /// <summary>
      /// Permite editar el algoritmo cargado, abriendo el diseñador de algoritmos.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void EditAlgorithm_Click(object sender, EventArgs e)
      {
         algorithmDesigner = new FormAlgDesigner();
         algorithmDesigner.SetAlgorithmsToEdit(algorithmList, "Main");
         algorithmDesigner.ShowDialog();
         algorithmList = algorithmDesigner.AlgorithmListDict;
         executeToolStripButton.Enabled = true;
      }

      /// <summary>
      /// Ejecuta el algoritmo cargado actualmente.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Execute_Click(object sender, EventArgs e)
      {
         if (map != null && algorithmDesigner != null)
         {
            if (map.Robot != null)
            {
               if (t != null && t.IsAlive) t.Abort();
               this.algorithmList = algorithmDesigner.AlgorithmListDict;
               interpreter = new Interpreter(map.Robot, algorithmList);
               interpreter.FinishedExecution += ExecutionFinish;
               interpreter.ExecutionError += InterpreterExecutionError;
               interpreter.wait = (int)numericUpDown1.Value;
               executeToolStripButton.Enabled = false;
               stopToolStripButton.Enabled = true;
               statusLabel.Text = "Executing algorithm...";
               t = new Thread(interpreter.ExecuteMain);
               t.Start();
            }
            else MessageBox.Show("Current map does not have a robot.\nPlease, load a valid map.", "Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         else MessageBox.Show("Please load a map and an algorithm first!", "Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      /// <summary>
      /// Este metodo se lanza en caso de error. Muestra el mensaje de error.
      /// </summary>
      /// <param name="e"></param>
      void InterpreterExecutionError(Exception e)
      {
         statusLabel.Text = e.Message;
         executeToolStripButton.Enabled = true;
         stopToolStripButton.Enabled = false;
         pboxCanvas.Invalidate();
      }

      private void OpenMapEditor_Click(object sender, EventArgs e)
      {
         mapDesigner = new FormMapDesigner();
         mapDesigner.ShowDialog();
      }

      /// <summary>
      /// Aborta el hilo de ejecucion del algoritmo al cerrarse la aplicacion si aun esta corriendo.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (t != null && t.IsAlive) t.Abort();
      }

      #region Small event handling methods

      /// <summary>
      /// Avisa de que el robot no pudo mover un objeto.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void Robot_UnableToMove(object sender, EventArgs e)
      {
         statusLabel.Text = "The robot tried to move an item, but it couldn't.";
      }

      /// <summary>
      /// Avisa de que el robot no pudo descargar un objeto.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void Robot_UnableToUnload(object sender, EventArgs e)
      {
         statusLabel.Text = "The robot tried to drop, but it couldn't.";
      }

      /// <summary>
      /// Avisa de que el robot no pudo cargar un objeto.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void Robot_UnableToLoad(object sender, EventArgs e)
      {
         statusLabel.Text = "The robot tried to load an item, but it couldn't.";
      }

      /// <summary>
      /// Actualiza el texto de estado.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void UpdateStatusText(object sender, InteractionEventArgs e)
      {
         statusLabel.Text = e.EventDescription;
         pboxCanvas.Invalidate();
      }

      /// <summary>
      /// Cada vez que algo se mueva, se repinta el control.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void MapSomethingMoved(object sender, EventArgs e)
      {
         pboxCanvas.Invalidate();
      }

      /// <summary>
      /// Cuando se termina la ejecucion, muestra un mensaje y cambia el estado de los controles.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void ExecutionFinish(object sender, EventArgs e)
      {
         if (map.Robot != null && interpreter != null && !interpreter.shouldStop)
            statusLabel.Text = "Execution finished!";
         executeToolStripButton.Enabled = true;
         stopToolStripButton.Enabled = false;
      }

      #endregion

      /// <summary>
      /// Detiene la ejecucion de un algoritmo.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void abortExecution_Click(object sender, EventArgs e)
      {
         if (interpreter != null) interpreter.shouldStop = true;
         this.statusLabel.Text = "Execution aborted.";
      }

      /// <summary>
      /// Muestra la cuadricula.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void showGridMenuItem_Click(object sender, EventArgs e)
      {
         pboxCanvas.Invalidate();
      }

      /// <summary>
      /// Cierra la aplicacion.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      /// <summary>
      /// Ejecuta el algoritmo actual.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void executeToolStripButton_EnabledChanged(object sender, EventArgs e)
      {
         if (executeToolStripButton.Enabled == true)
         {
            label1.Visible = true;
            numericUpDown1.Visible = true;
         }
         else
         {
            label1.Visible = false;
            numericUpDown1.Visible = false;
         }
      }

      /// <summary>
      /// Permite controlar manualmente al robot.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void manualControlToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (map != null && map.Robot != null)
         {
            if (t == null || !t.IsAlive)
            {
               FormManual m = new FormManual(this.map, this);
               this.Hide();
               m.Show();
            }
            else MessageBox.Show("Please stop the execution first!");
         }
         else MessageBox.Show("Please, load a valid map first.", "Manual mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
   }
}