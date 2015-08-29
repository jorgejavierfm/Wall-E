using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using FlowChartDesigner;
using FlowChartDesigner.Builders;
using Walle.ExpressionEvaluator;
using Walle.UI.Dialogs;

namespace Walle.UI
{
   public partial class FormAlgDesigner : Form
   {
      public FormAlgDesigner()
      {
         InitializeComponent();
      }

      private DlgNewActivity dlgNewActivity;

      private readonly ActivityChartElementBuilder activityBuilder = new ActivityChartElementBuilder();
      public Dictionary<string, ChartElementCollection> AlgorithmListDict;

      // Inicializa los Builders del flowChartViewer.
      private void FormAlgDesigner_Load(object sender, EventArgs e)
      {
         flowChartViewer1.Builders.Add(new BeginChartElementBuilder());
         flowChartViewer1.Builders.Add(new AssignationChartElementBuilder());
         flowChartViewer1.Builders.Add(new ConditionalChartElementBuilder());

         CommandChartElementBuilder commandBuilder = new CommandChartElementBuilder();

         commandBuilder.ValuesList.Add("MoveForward");
         commandBuilder.ValuesList.Add("MoveBackward");
         commandBuilder.ValuesList.Add("TurnLeft");
         commandBuilder.ValuesList.Add("TurnRight");
         commandBuilder.ValuesList.Add("LoadItem");
         commandBuilder.ValuesList.Add("UnloadItem");

         flowChartViewer1.Builders.Add(commandBuilder);
         flowChartViewer1.Builders.Add(activityBuilder);

         flowChartViewer1.Builders.Add(new EndChartElementBuilder());
      }

      /// <summary>
      /// Actualiza el propertyGrid con el ChartElement seleccionado
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void flowChartViewer_SelectedItemChanged(object sender, EventArgs e)
      {
         this.propertyGrid1.SelectedObject = flowChartViewer1.SelectedItem;
      }

      /// <summary>
      /// Refresca el flowChartViewer cada vez que se cambia una propiedad.
      /// </summary>
      /// <param name="s"></param>
      /// <param name="e"></param>
      private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
         flowChartViewer1.Invalidate();
      }

      /// <summary>
      /// Muestra la actividad seleccionada.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void lstActivity_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (lstActivities.SelectedIndex != -1)
         {
            string selectedAlgorithmName = lstActivities.Items[lstActivities.SelectedIndex].ToString();
            flowChartViewer1.ChangeCurrentChartCollection(AlgorithmListDict[selectedAlgorithmName]);
         }

      }

      /// <summary>
      /// Crea una nueva actividad.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void newActivity_Click(object sender, EventArgs e)
      {
         dlgNewActivity = new DlgNewActivity();
         if (dlgNewActivity.ShowDialog() == DialogResult.OK)
         {
            if (!AlgorithmListDict.ContainsKey(dlgNewActivity.ActivityName))
            {
               lstActivities.Items.Add(dlgNewActivity.ActivityName);
               AlgorithmListDict.Add(dlgNewActivity.ActivityName, new ChartElementCollection());
            }
            else MessageBox.Show("There is already another activity with the same name defined in the application.");
         }
         UpdateActivityBuilder();
      }

      /// <summary>
      /// Elimina la actividad seleccionada.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void removeSelectedActivity_Click(object sender, EventArgs e)
      {
         if (lstActivities.SelectedIndex != -1)
         {
            string actToRemoveName = lstActivities.Items[lstActivities.SelectedIndex].ToString();

            if (!actToRemoveName.Equals("Main"))
            {
               lstActivities.Items.RemoveAt(lstActivities.SelectedIndex);
               AlgorithmListDict.Remove(actToRemoveName);
               lstActivities.SelectedIndex = lstActivities.Items.Count - 1;
               propertyGrid1.SelectedObject = null;
            }
            else
            {
               MessageBox.Show("Main activity cannot be removed.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateActivityBuilder();
         }
      }

      /// <summary>
      /// Actualiza el Builder de actividades para que muestre las actividades agregadas.
      /// </summary>
      private void UpdateActivityBuilder()
      {
         List<string> l = new List<string>(AlgorithmListDict.Keys);
         l.Remove("Main");
         activityBuilder.ValuesList = l;
      }

      /// <summary>
      /// Asigna al formulario actual el algoritmo (o conjunto de actividades) a modificar.
      /// </summary>
      /// <param name="algList"></param>
      /// <param name="algName"></param>
      public void SetAlgorithmsToEdit(Dictionary<string, ChartElementCollection> algList, string algName)
      {
         AlgorithmListDict = algList;
         flowChartViewer1.ChangeCurrentChartCollection(AlgorithmListDict[algName]);

         lstActivities.Items.Clear();
         foreach (var pair in algList)
         {
            lstActivities.Items.Add(pair.Key);
         }
      }

      /// <summary>
      /// Carga una actividad de disco.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void loadActivityMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (odlgImportActivity.ShowDialog() == DialogResult.OK)
            {
               IFormatter formatter = new BinaryFormatter();
               Stream stream = new FileStream(odlgImportActivity.FileName, FileMode.Open, FileAccess.Read,
                                              FileShare.Read);
               KeyValuePair<string, ChartElementCollection> temp =
                     (KeyValuePair<string, ChartElementCollection>)formatter.Deserialize(stream);
               if (!AlgorithmListDict.ContainsKey(temp.Key))
               {
                  AlgorithmListDict.Add(temp.Key, temp.Value);
                  lstActivities.Items.Add(temp.Key);
               }
               else
                  MessageBox.Show(
                        "There is already another activity with the same name defined in the current algorithm. \n Please remove the redundant activity before importing the new one.");

               stream.Close();
               UpdateActivityBuilder();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error loading activity. Error message is: " + ex.Message);
         }
      }

      /// <summary>
      /// Guarda una actividad a disco.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void saveActivityMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (lstActivities.SelectedIndex != -1)
            {
               if (sdlgExportActivity.ShowDialog() == DialogResult.OK)
               {
                  IFormatter formatter = new BinaryFormatter();
                  Stream stream = new FileStream(sdlgExportActivity.FileName, FileMode.Create,
                                                 FileAccess.Write, FileShare.None);
                  string activityName = lstActivities.SelectedItem.ToString();

                  ChartElementCollection activity = AlgorithmListDict[activityName];

                  var activityWithName = new KeyValuePair<string, ChartElementCollection>(activityName, activity);

                  formatter.Serialize(stream, activityWithName);
                  stream.Close();
                  UpdateActivityBuilder();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error saving activity. Error message is: " + ex.Message);
         }
      }

      /// <summary>
      /// Cierra el formulario.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void closeMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      /// <summary>
      /// Carga un algoritmo de disco.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void openAlgorithmItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (odlgOpenAlgorithm.ShowDialog() == DialogResult.OK)
            {
               IFormatter formatter = new BinaryFormatter();
               Stream stream = new FileStream(odlgOpenAlgorithm.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
               Dictionary<string, ChartElementCollection> temp = (Dictionary<string, ChartElementCollection>)formatter.Deserialize(stream);
               stream.Close();
               SetAlgorithmsToEdit(temp, "Main");
               UpdateActivityBuilder();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error loading algorithm file. Error message is: " + ex.Message);
         }
      }


      /// <summary>
      /// Guarda un algoritmo a disco.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void saveAlgorithmItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (sdlgSaveAlgorithm.ShowDialog() == DialogResult.OK)
            {
               IFormatter formatter = new BinaryFormatter();
               Stream stream = new FileStream(sdlgSaveAlgorithm.FileName, FileMode.Create,
                                              FileAccess.Write, FileShare.None);
               var toSave = AlgorithmListDict;

               formatter.Serialize(stream, toSave);
               stream.Close();
            }
         }
         catch (Exception ex) { MessageBox.Show("Error saving algorithm file. Error message is: " + ex.Message); }
      }

   }
}

