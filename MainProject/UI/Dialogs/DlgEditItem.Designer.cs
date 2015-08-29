namespace Walle.UI.Dialogs{
   partial class DlgEditItem
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
         this.lblName = new System.Windows.Forms.Label();
         this.pboxImage = new System.Windows.Forms.PictureBox();
         this.lblImage = new System.Windows.Forms.Label();
         this.txtName = new System.Windows.Forms.TextBox();
         this.nudWeight = new System.Windows.Forms.NumericUpDown();
         this.odlgOpenImage = new System.Windows.Forms.OpenFileDialog();
         this.nudVolume = new System.Windows.Forms.NumericUpDown();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.chkFill = new System.Windows.Forms.CheckBox();
         this.lblTemp = new System.Windows.Forms.Label();
         this.nudMeltTemp = new System.Windows.Forms.NumericUpDown();
         this.lblWeight = new System.Windows.Forms.Label();
         this.lblVolume = new System.Windows.Forms.Label();
         this.chkFloat = new System.Windows.Forms.CheckBox();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudMeltTemp)).BeginInit();
         this.SuspendLayout();
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(12, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(38, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name:";
         // 
         // pboxImage
         // 
         this.pboxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pboxImage.Location = new System.Drawing.Point(144, 143);
         this.pboxImage.Name = "pboxImage";
         this.pboxImage.Size = new System.Drawing.Size(32, 32);
         this.pboxImage.TabIndex = 11;
         this.pboxImage.TabStop = false;
         this.pboxImage.Click += new System.EventHandler(this.pboxImage_Click);
         // 
         // lblImage
         // 
         this.lblImage.AutoSize = true;
         this.lblImage.Location = new System.Drawing.Point(12, 143);
         this.lblImage.Name = "lblImage";
         this.lblImage.Size = new System.Drawing.Size(39, 13);
         this.lblImage.TabIndex = 10;
         this.lblImage.Text = "Image:";
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(56, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(120, 20);
         this.txtName.TabIndex = 12;
         // 
         // nudWeight
         // 
         this.nudWeight.Location = new System.Drawing.Point(112, 38);
         this.nudWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.nudWeight.Name = "nudWeight";
         this.nudWeight.Size = new System.Drawing.Size(64, 20);
         this.nudWeight.TabIndex = 14;
         this.nudWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.nudWeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
         // 
         // odlgOpenImage
         // 
         this.odlgOpenImage.Filter = "Image files (*.bmp; *.jpg; *.png; *.ico; *.gif)|*.bmp; *.jpg; *.png; *.ico;*.gif";
         // 
         // nudVolume
         // 
         this.nudVolume.Location = new System.Drawing.Point(112, 64);
         this.nudVolume.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.nudVolume.Name = "nudVolume";
         this.nudVolume.Size = new System.Drawing.Size(64, 20);
         this.nudVolume.TabIndex = 16;
         this.nudVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.nudVolume.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point(12, 213);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 17;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(101, 213);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 18;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // chkFill
         // 
         this.chkFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.chkFill.AutoSize = true;
         this.chkFill.Location = new System.Drawing.Point(12, 190);
         this.chkFill.Name = "chkFill";
         this.chkFill.Size = new System.Drawing.Size(77, 17);
         this.chkFill.TabIndex = 19;
         this.chkFill.Text = "Fills holes?";
         this.chkFill.UseVisualStyleBackColor = true;
         // 
         // lblTemp
         // 
         this.lblTemp.AutoSize = true;
         this.lblTemp.Location = new System.Drawing.Point(12, 92);
         this.lblTemp.Name = "lblTemp";
         this.lblTemp.Size = new System.Drawing.Size(48, 13);
         this.lblTemp.TabIndex = 20;
         this.lblTemp.Text = "Melts At:";
         // 
         // nudMeltTemp
         // 
         this.nudMeltTemp.Location = new System.Drawing.Point(112, 90);
         this.nudMeltTemp.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.nudMeltTemp.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
         this.nudMeltTemp.Name = "nudMeltTemp";
         this.nudMeltTemp.Size = new System.Drawing.Size(64, 20);
         this.nudMeltTemp.TabIndex = 21;
         this.nudMeltTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.nudMeltTemp.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
         // 
         // lblWeight
         // 
         this.lblWeight.AutoSize = true;
         this.lblWeight.Location = new System.Drawing.Point(12, 40);
         this.lblWeight.Name = "lblWeight";
         this.lblWeight.Size = new System.Drawing.Size(44, 13);
         this.lblWeight.TabIndex = 22;
         this.lblWeight.Text = "Weight:";
         // 
         // lblVolume
         // 
         this.lblVolume.AutoSize = true;
         this.lblVolume.Location = new System.Drawing.Point(12, 66);
         this.lblVolume.Name = "lblVolume";
         this.lblVolume.Size = new System.Drawing.Size(45, 13);
         this.lblVolume.TabIndex = 23;
         this.lblVolume.Text = "Volume:";
         // 
         // chkFloat
         // 
         this.chkFloat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.chkFloat.AutoSize = true;
         this.chkFloat.Location = new System.Drawing.Point(112, 190);
         this.chkFloat.Name = "chkFloat";
         this.chkFloat.Size = new System.Drawing.Size(60, 17);
         this.chkFloat.TabIndex = 24;
         this.chkFloat.Text = "Floats?";
         this.chkFloat.UseVisualStyleBackColor = true;
         // 
         // comboBox1
         // 
         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(74, 116);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(102, 21);
         this.comboBox1.TabIndex = 25;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 119);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(34, 13);
         this.label1.TabIndex = 26;
         this.label1.Text = "Color:";
         // 
         // DlgEditItem
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(188, 248);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.comboBox1);
         this.Controls.Add(this.chkFloat);
         this.Controls.Add(this.lblVolume);
         this.Controls.Add(this.lblWeight);
         this.Controls.Add(this.nudMeltTemp);
         this.Controls.Add(this.lblTemp);
         this.Controls.Add(this.chkFill);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.nudVolume);
         this.Controls.Add(this.nudWeight);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.pboxImage);
         this.Controls.Add(this.lblImage);
         this.Controls.Add(this.lblName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "DlgEditItem";
         this.Text = "Item";
         this.Load += new System.EventHandler(this.dlgEditItem_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudMeltTemp)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.PictureBox pboxImage;
      private System.Windows.Forms.Label lblImage;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.NumericUpDown nudWeight;
      private System.Windows.Forms.OpenFileDialog odlgOpenImage;
      private System.Windows.Forms.NumericUpDown nudVolume;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.CheckBox chkFill;
      private System.Windows.Forms.Label lblTemp;
      private System.Windows.Forms.NumericUpDown nudMeltTemp;
      private System.Windows.Forms.Label lblWeight;
      private System.Windows.Forms.Label lblVolume;
      private System.Windows.Forms.CheckBox chkFloat;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label1;
   }
}