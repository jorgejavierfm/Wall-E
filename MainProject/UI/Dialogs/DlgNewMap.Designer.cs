namespace Walle.UI.Dialogs{
   partial class DlgNewMap
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
         this.lblWidth = new System.Windows.Forms.Label();
         this.nudWidth = new System.Windows.Forms.NumericUpDown();
         this.lblHeight = new System.Windows.Forms.Label();
         this.nudHeight = new System.Windows.Forms.NumericUpDown();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.cmbType = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
         this.SuspendLayout();
         // 
         // lblWidth
         // 
         this.lblWidth.AutoSize = true;
         this.lblWidth.Location = new System.Drawing.Point(11, 12);
         this.lblWidth.Name = "lblWidth";
         this.lblWidth.Size = new System.Drawing.Size(38, 13);
         this.lblWidth.TabIndex = 0;
         this.lblWidth.Text = "Width:";
         // 
         // nudWidth
         // 
         this.nudWidth.Location = new System.Drawing.Point(55, 10);
         this.nudWidth.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
         this.nudWidth.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
         this.nudWidth.Name = "nudWidth";
         this.nudWidth.Size = new System.Drawing.Size(82, 20);
         this.nudWidth.TabIndex = 1;
         this.nudWidth.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
         // 
         // lblHeight
         // 
         this.lblHeight.AutoSize = true;
         this.lblHeight.Location = new System.Drawing.Point(11, 41);
         this.lblHeight.Name = "lblHeight";
         this.lblHeight.Size = new System.Drawing.Size(41, 13);
         this.lblHeight.TabIndex = 2;
         this.lblHeight.Text = "Height:";
         // 
         // nudHeight
         // 
         this.nudHeight.Location = new System.Drawing.Point(55, 39);
         this.nudHeight.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
         this.nudHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this.nudHeight.Name = "nudHeight";
         this.nudHeight.Size = new System.Drawing.Size(82, 20);
         this.nudHeight.TabIndex = 3;
         this.nudHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point(152, 7);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(83, 23);
         this.btnOK.TabIndex = 4;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(152, 36);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(83, 23);
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // cmbType
         // 
         this.cmbType.FormattingEnabled = true;
         this.cmbType.Location = new System.Drawing.Point(107, 73);
         this.cmbType.Name = "cmbType";
         this.cmbType.Size = new System.Drawing.Size(128, 21);
         this.cmbType.TabIndex = 6;
         this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(11, 76);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(89, 13);
         this.label1.TabIndex = 7;
         this.label1.Text = "Default field type:";
         // 
         // DlgNewMap
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(247, 106);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cmbType);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.nudHeight);
         this.Controls.Add(this.lblHeight);
         this.Controls.Add(this.nudWidth);
         this.Controls.Add(this.lblWidth);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "DlgNewMap";
         this.Text = "Set Map Dimensions...";
         this.Load += new System.EventHandler(this.DlgNewMap_Load);
         ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblWidth;
      private System.Windows.Forms.NumericUpDown nudWidth;
      private System.Windows.Forms.Label lblHeight;
      private System.Windows.Forms.NumericUpDown nudHeight;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.ComboBox cmbType;
      private System.Windows.Forms.Label label1;
   }
}