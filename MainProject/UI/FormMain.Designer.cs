namespace Walle.UI{
   partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.openMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.menuToolbar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pboxCanvas = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.executeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.menuToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCanvas)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // openMapDialog
            // 
            this.openMapDialog.DefaultExt = "rmp";
            this.openMapDialog.Filter = "Map Files|*.rmp";
            this.openMapDialog.Title = "Open Map";
            // 
            // saveMapDialog
            // 
            this.saveMapDialog.DefaultExt = "rmp";
            this.saveMapDialog.Filter = "Map Files|*.rmp";
            this.saveMapDialog.Title = "Save Map";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // menuToolbar
            // 
            this.menuToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.designersToolStripMenuItem});
            this.menuToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuToolbar.Location = new System.Drawing.Point(0, 0);
            this.menuToolbar.Name = "menuToolbar";
            this.menuToolbar.Size = new System.Drawing.Size(602, 24);
            this.menuToolbar.TabIndex = 0;
            this.menuToolbar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.newToolStripMenuItem.Text = "&New map";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.OpenMapEditor_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenMap_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(122, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // designersToolStripMenuItem
            // 
            this.designersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.designMapToolStripMenuItem,
            this.editAlgorithmToolStripMenuItem,
            this.manualControlToolStripMenuItem,
            this.toolStripSeparator1,
            this.customizeToolStripMenuItem});
            this.designersToolStripMenuItem.Name = "designersToolStripMenuItem";
            this.designersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.designersToolStripMenuItem.Text = "&Tools";
            // 
            // designMapToolStripMenuItem
            // 
            this.designMapToolStripMenuItem.Name = "designMapToolStripMenuItem";
            this.designMapToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.designMapToolStripMenuItem.Text = "&Map designer...";
            this.designMapToolStripMenuItem.Click += new System.EventHandler(this.OpenMapEditor_Click);
            // 
            // editAlgorithmToolStripMenuItem
            // 
            this.editAlgorithmToolStripMenuItem.Name = "editAlgorithmToolStripMenuItem";
            this.editAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editAlgorithmToolStripMenuItem.Text = "&Algorithm editor...";
            this.editAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.EditAlgorithm_Click);
            // 
            // manualControlToolStripMenuItem
            // 
            this.manualControlToolStripMenuItem.Name = "manualControlToolStripMenuItem";
            this.manualControlToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.manualControlToolStripMenuItem.Text = "Ma&nual control...";
            this.manualControlToolStripMenuItem.Click += new System.EventHandler(this.manualControlToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGridMenuItem});
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // showGridMenuItem
            // 
            this.showGridMenuItem.CheckOnClick = true;
            this.showGridMenuItem.Name = "showGridMenuItem";
            this.showGridMenuItem.Size = new System.Drawing.Size(127, 22);
            this.showGridMenuItem.Text = "Show &grid";
            this.showGridMenuItem.Click += new System.EventHandler(this.showGridMenuItem_Click);
            // 
            // pboxCanvas
            // 
            this.pboxCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pboxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxCanvas.Image = ((System.Drawing.Image)(resources.GetObject("pboxCanvas.Image")));
            this.pboxCanvas.Location = new System.Drawing.Point(0, 0);
            this.pboxCanvas.Name = "pboxCanvas";
            this.pboxCanvas.Size = new System.Drawing.Size(602, 580);
            this.pboxCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxCanvas.TabIndex = 2;
            this.pboxCanvas.TabStop = false;
            this.pboxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 629);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(602, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(179, 17);
            this.statusLabel.Text = "Event messages will appear here.";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.toolStripSeparator,
            this.executeToolStripButton,
            this.stopToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(3, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(101, 25);
            this.mainToolStrip.TabIndex = 4;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.OpenMapEditor_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenMap_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // executeToolStripButton
            // 
            this.executeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.executeToolStripButton.Enabled = false;
            this.executeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("executeToolStripButton.Image")));
            this.executeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.executeToolStripButton.Name = "executeToolStripButton";
            this.executeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.executeToolStripButton.Text = "E&xecute";
            this.executeToolStripButton.Click += new System.EventHandler(this.Execute_Click);
            this.executeToolStripButton.EnabledChanged += new System.EventHandler(this.executeToolStripButton_EnabledChanged);
            // 
            // stopToolStripButton
            // 
            this.stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolStripButton.Enabled = false;
            this.stopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripButton.Image")));
            this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripButton.Name = "stopToolStripButton";
            this.stopToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopToolStripButton.Text = "&Stop";
            this.stopToolStripButton.Click += new System.EventHandler(this.abortExecution_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pboxCanvas);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(602, 580);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(602, 605);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(131, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wait:";
            this.label1.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 651);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuToolbar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuToolbar;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Programming WallE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuToolbar.ResumeLayout(false);
            this.menuToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCanvas)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.OpenFileDialog openMapDialog;
      private System.Windows.Forms.SaveFileDialog saveMapDialog;
      private System.Windows.Forms.MenuStrip menuToolbar;
      private System.Windows.Forms.ToolStripMenuItem designersToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem designMapToolStripMenuItem;
      private System.Windows.Forms.PictureBox pboxCanvas;
      private System.Windows.Forms.StatusStrip statusStrip;
      private System.Windows.Forms.ToolStripMenuItem editAlgorithmToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel statusLabel;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem showGridMenuItem;
      private System.Windows.Forms.ToolStripMenuItem manualControlToolStripMenuItem;
      private System.Windows.Forms.ToolStrip mainToolStrip;
      private System.Windows.Forms.ToolStripButton newToolStripButton;
      private System.Windows.Forms.ToolStripButton openToolStripButton;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
      private System.Windows.Forms.ToolStripButton executeToolStripButton;
      private System.Windows.Forms.ToolStripButton stopToolStripButton;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripContainer toolStripContainer1;
      private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
      private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
      private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
      private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
      private System.Windows.Forms.ToolStripContentPanel ContentPanel;
      private System.Windows.Forms.NumericUpDown numericUpDown1;
      private System.Windows.Forms.Label label1;


   }
}