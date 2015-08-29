namespace Walle.UI
{
   partial class FormManual
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
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.lblCell = new System.Windows.Forms.Label();
         this.lblItem = new System.Windows.Forms.Label();
         this.lblSensors = new System.Windows.Forms.Label();
         this.pboxCanvas = new System.Windows.Forms.PictureBox();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pboxCanvas)).BeginInit();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.pboxCanvas);
         this.splitContainer1.Size = new System.Drawing.Size(763, 474);
         this.splitContainer1.SplitterDistance = 163;
         this.splitContainer1.TabIndex = 0;
         this.splitContainer1.TabStop = false;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.lblCell);
         this.groupBox1.Controls.Add(this.lblItem);
         this.groupBox1.Controls.Add(this.lblSensors);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(163, 474);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Information";
         // 
         // lblCell
         // 
         this.lblCell.AutoSize = true;
         this.lblCell.Location = new System.Drawing.Point(12, 308);
         this.lblCell.Name = "lblCell";
         this.lblCell.Size = new System.Drawing.Size(0, 13);
         this.lblCell.TabIndex = 3;
         // 
         // lblItem
         // 
         this.lblItem.AutoSize = true;
         this.lblItem.Location = new System.Drawing.Point(12, 373);
         this.lblItem.Name = "lblItem";
         this.lblItem.Size = new System.Drawing.Size(0, 13);
         this.lblItem.TabIndex = 2;
         // 
         // lblSensors
         // 
         this.lblSensors.AutoSize = true;
         this.lblSensors.Location = new System.Drawing.Point(12, 21);
         this.lblSensors.Name = "lblSensors";
         this.lblSensors.Size = new System.Drawing.Size(45, 13);
         this.lblSensors.TabIndex = 1;
         this.lblSensors.Text = "Sensors";
         // 
         // pboxCanvas
         // 
         this.pboxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pboxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pboxCanvas.Location = new System.Drawing.Point(0, 0);
         this.pboxCanvas.Name = "pboxCanvas";
         this.pboxCanvas.Size = new System.Drawing.Size(596, 474);
         this.pboxCanvas.TabIndex = 1;
         this.pboxCanvas.TabStop = false;
         this.pboxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
         this.pboxCanvas.MouseLeave += new System.EventHandler(this.pboxCanvas_MouseLeave);
         this.pboxCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pboxCanvas_MouseMove);
         // 
         // FormManual
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(763, 474);
         this.Controls.Add(this.splitContainer1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "FormManual";
         this.Text = "Manual Operation";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormManual_FormClosed);
         this.Load += new System.EventHandler(this.FormManual_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormManual_KeyDown);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pboxCanvas)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.PictureBox pboxCanvas;
      private System.Windows.Forms.Label lblSensors;
      private System.Windows.Forms.Label lblCell;
      private System.Windows.Forms.Label lblItem;
   }
}