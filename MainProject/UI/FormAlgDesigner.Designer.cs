namespace Walle.UI
{
   partial class FormAlgDesigner
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.flowChartViewer1 = new FlowChartDesigner.FlowChartViewer();
         this.menuToolbar = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
         this.lstActivities = new System.Windows.Forms.ListBox();
         this.activityContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.newActivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadActivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveActivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.odlgOpenAlgorithm = new System.Windows.Forms.OpenFileDialog();
         this.sdlgSaveAlgorithm = new System.Windows.Forms.SaveFileDialog();
         this.odlgImportActivity = new System.Windows.Forms.OpenFileDialog();
         this.sdlgExportActivity = new System.Windows.Forms.SaveFileDialog();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.flowChartViewer1.SuspendLayout();
         this.menuToolbar.SuspendLayout();
         this.splitContainer2.Panel1.SuspendLayout();
         this.splitContainer2.Panel2.SuspendLayout();
         this.splitContainer2.SuspendLayout();
         this.activityContextMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.flowChartViewer1);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
         this.splitContainer1.Size = new System.Drawing.Size(688, 488);
         this.splitContainer1.SplitterDistance = 517;
         this.splitContainer1.TabIndex = 0;
         // 
         // flowChartViewer1
         // 
         this.flowChartViewer1.AutoScroll = true;
         this.flowChartViewer1.BackColor = System.Drawing.Color.White;
         this.flowChartViewer1.Controls.Add(this.menuToolbar);
         this.flowChartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.flowChartViewer1.Location = new System.Drawing.Point(0, 0);
         this.flowChartViewer1.Name = "flowChartViewer1";
         this.flowChartViewer1.SelectedItem = null;
         this.flowChartViewer1.Size = new System.Drawing.Size(517, 488);
         this.flowChartViewer1.TabIndex = 0;
         this.flowChartViewer1.Text = "flowChartViewer1";
         this.flowChartViewer1.SelectedItemChanged += new System.EventHandler(this.flowChartViewer_SelectedItemChanged);
         // 
         // menuToolbar
         // 
         this.menuToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.menuToolbar.Location = new System.Drawing.Point(0, 0);
         this.menuToolbar.Name = "menuToolbar";
         this.menuToolbar.Size = new System.Drawing.Size(517, 24);
         this.menuToolbar.TabIndex = 0;
         this.menuToolbar.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.openToolStripMenuItem.Text = "Open...";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openAlgorithmItem_Click);
         // 
         // saveToolStripMenuItem
         // 
         this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
         this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.saveToolStripMenuItem.Text = "Save...";
         this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveAlgorithmItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
         // 
         // closeToolStripMenuItem
         // 
         this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
         this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.closeToolStripMenuItem.Text = "Close";
         this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer2.Location = new System.Drawing.Point(0, 0);
         this.splitContainer2.Name = "splitContainer2";
         this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer2.Panel1
         // 
         this.splitContainer2.Panel1.Controls.Add(this.propertyGrid1);
         // 
         // splitContainer2.Panel2
         // 
         this.splitContainer2.Panel2.Controls.Add(this.lstActivities);
         this.splitContainer2.Size = new System.Drawing.Size(167, 488);
         this.splitContainer2.SplitterDistance = 359;
         this.splitContainer2.TabIndex = 0;
         // 
         // propertyGrid1
         // 
         this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.propertyGrid1.HelpVisible = false;
         this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
         this.propertyGrid1.Name = "propertyGrid1";
         this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
         this.propertyGrid1.Size = new System.Drawing.Size(167, 359);
         this.propertyGrid1.TabIndex = 0;
         this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
         // 
         // lstActivities
         // 
         this.lstActivities.ContextMenuStrip = this.activityContextMenu;
         this.lstActivities.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lstActivities.FormattingEnabled = true;
         this.lstActivities.Location = new System.Drawing.Point(0, 0);
         this.lstActivities.Name = "lstActivities";
         this.lstActivities.Size = new System.Drawing.Size(167, 125);
         this.lstActivities.TabIndex = 0;
         this.lstActivities.SelectedIndexChanged += new System.EventHandler(this.lstActivity_SelectedIndexChanged);
         // 
         // activityContextMenu
         // 
         this.activityContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newActivityToolStripMenuItem,
            this.loadActivityToolStripMenuItem,
            this.saveActivityToolStripMenuItem,
            this.removeSelectedToolStripMenuItem});
         this.activityContextMenu.Name = "contextMenuStrip1";
         this.activityContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.activityContextMenu.Size = new System.Drawing.Size(121, 92);
         // 
         // newActivityToolStripMenuItem
         // 
         this.newActivityToolStripMenuItem.Name = "newActivityToolStripMenuItem";
         this.newActivityToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
         this.newActivityToolStripMenuItem.Text = "New...";
         this.newActivityToolStripMenuItem.Click += new System.EventHandler(this.newActivity_Click);
         // 
         // loadActivityToolStripMenuItem
         // 
         this.loadActivityToolStripMenuItem.Name = "loadActivityToolStripMenuItem";
         this.loadActivityToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
         this.loadActivityToolStripMenuItem.Text = "Import...";
         this.loadActivityToolStripMenuItem.Click += new System.EventHandler(this.loadActivityMenuItem_Click);
         // 
         // saveActivityToolStripMenuItem
         // 
         this.saveActivityToolStripMenuItem.Name = "saveActivityToolStripMenuItem";
         this.saveActivityToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
         this.saveActivityToolStripMenuItem.Text = "Export...";
         this.saveActivityToolStripMenuItem.Click += new System.EventHandler(this.saveActivityMenuItem_Click);
         // 
         // removeSelectedToolStripMenuItem
         // 
         this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
         this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
         this.removeSelectedToolStripMenuItem.Text = "Remove ";
         this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedActivity_Click);
         // 
         // odlgOpenAlgorithm
         // 
         this.odlgOpenAlgorithm.DefaultExt = "alg";
         this.odlgOpenAlgorithm.Filter = "Algorithm files|*.alg";
         // 
         // sdlgSaveAlgorithm
         // 
         this.sdlgSaveAlgorithm.DefaultExt = "alg";
         this.sdlgSaveAlgorithm.Filter = "Algorithm files|*.alg";
         // 
         // odlgImportActivity
         // 
         this.odlgImportActivity.DefaultExt = "act";
         this.odlgImportActivity.Filter = "Activity files|*.act";
         // 
         // sdlgExportActivity
         // 
         this.sdlgExportActivity.DefaultExt = "act";
         this.sdlgExportActivity.Filter = "Activity files|*.act";
         // 
         // FormAlgDesigner
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(688, 488);
         this.Controls.Add(this.splitContainer1);
         this.MainMenuStrip = this.menuToolbar;
         this.Name = "FormAlgDesigner";
         this.Text = "Algorithm Designer";
         this.Load += new System.EventHandler(this.FormAlgDesigner_Load);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.flowChartViewer1.ResumeLayout(false);
         this.flowChartViewer1.PerformLayout();
         this.menuToolbar.ResumeLayout(false);
         this.menuToolbar.PerformLayout();
         this.splitContainer2.Panel1.ResumeLayout(false);
         this.splitContainer2.Panel2.ResumeLayout(false);
         this.splitContainer2.ResumeLayout(false);
         this.activityContextMenu.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private FlowChartDesigner.FlowChartViewer flowChartViewer1;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private System.Windows.Forms.PropertyGrid propertyGrid1;
      private System.Windows.Forms.ListBox lstActivities;
      private System.Windows.Forms.ContextMenuStrip activityContextMenu;
      private System.Windows.Forms.ToolStripMenuItem newActivityToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
      private System.Windows.Forms.MenuStrip menuToolbar;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem loadActivityToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveActivityToolStripMenuItem;
      private System.Windows.Forms.OpenFileDialog odlgOpenAlgorithm;
      private System.Windows.Forms.SaveFileDialog sdlgSaveAlgorithm;
      private System.Windows.Forms.OpenFileDialog odlgImportActivity;
      private System.Windows.Forms.SaveFileDialog sdlgExportActivity;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
   }
}