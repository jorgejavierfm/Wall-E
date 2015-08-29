namespace Walle.UI.Dialogs{
   partial class DlgEditCell
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
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.odlgOpenImage = new System.Windows.Forms.OpenFileDialog();
         this.lblName = new System.Windows.Forms.Label();
         this.txtName = new System.Windows.Forms.TextBox();
         this.lblImage = new System.Windows.Forms.Label();
         this.pboxImage = new System.Windows.Forms.PictureBox();
         this.lblTemp = new System.Windows.Forms.Label();
         this.nudTemp = new System.Windows.Forms.NumericUpDown();
         this.chkHole = new System.Windows.Forms.CheckBox();
         this.chkLiquid = new System.Windows.Forms.CheckBox();
         ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudTemp)).BeginInit();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point(12, 117);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(66, 23);
         this.btnOK.TabIndex = 0;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(107, 117);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(61, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // odlgOpenImage
         // 
         this.odlgOpenImage.DefaultExt = "png";
         this.odlgOpenImage.Filter = "Image files (*.bmp; *.jpg; *.png; *.ico; *.gif)|*.bmp; *.jpg; *.png; *.ico;*.gif";
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(9, 9);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(38, 13);
         this.lblName.TabIndex = 2;
         this.lblName.Text = "Name:";
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(53, 6);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(115, 20);
         this.txtName.TabIndex = 3;
         // 
         // lblImage
         // 
         this.lblImage.AutoSize = true;
         this.lblImage.Location = new System.Drawing.Point(8, 32);
         this.lblImage.Name = "lblImage";
         this.lblImage.Size = new System.Drawing.Size(39, 13);
         this.lblImage.TabIndex = 8;
         this.lblImage.Text = "Image:";
         // 
         // pboxImage
         // 
         this.pboxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pboxImage.Location = new System.Drawing.Point(53, 32);
         this.pboxImage.Name = "pboxImage";
         this.pboxImage.Size = new System.Drawing.Size(32, 32);
         this.pboxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.pboxImage.TabIndex = 9;
         this.pboxImage.TabStop = false;
         this.pboxImage.Click += new System.EventHandler(this.pboxImage_Click);
         // 
         // lblTemp
         // 
         this.lblTemp.AutoSize = true;
         this.lblTemp.Location = new System.Drawing.Point(8, 80);
         this.lblTemp.Name = "lblTemp";
         this.lblTemp.Size = new System.Drawing.Size(70, 13);
         this.lblTemp.TabIndex = 10;
         this.lblTemp.Text = "Temperature:";
         // 
         // nudTemp
         // 
         this.nudTemp.Location = new System.Drawing.Point(85, 78);
         this.nudTemp.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
         this.nudTemp.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
         this.nudTemp.Name = "nudTemp";
         this.nudTemp.Size = new System.Drawing.Size(83, 20);
         this.nudTemp.TabIndex = 11;
         // 
         // chkHole
         // 
         this.chkHole.AutoSize = true;
         this.chkHole.Location = new System.Drawing.Point(114, 31);
         this.chkHole.Name = "chkHole";
         this.chkHole.Size = new System.Drawing.Size(54, 17);
         this.chkHole.TabIndex = 12;
         this.chkHole.Text = "Hole?";
         this.chkHole.UseVisualStyleBackColor = true;
         this.chkHole.CheckedChanged += new System.EventHandler(this.chkHole_CheckedChanged);
         // 
         // chkLiquid
         // 
         this.chkLiquid.AutoSize = true;
         this.chkLiquid.Location = new System.Drawing.Point(114, 54);
         this.chkLiquid.Name = "chkLiquid";
         this.chkLiquid.Size = new System.Drawing.Size(60, 17);
         this.chkLiquid.TabIndex = 13;
         this.chkLiquid.Text = "Liquid?";
         this.chkLiquid.UseVisualStyleBackColor = true;
         this.chkLiquid.CheckedChanged += new System.EventHandler(this.chkLiquid_CheckedChanged);
         // 
         // DlgEditCell
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(180, 158);
         this.Controls.Add(this.chkLiquid);
         this.Controls.Add(this.chkHole);
         this.Controls.Add(this.nudTemp);
         this.Controls.Add(this.lblTemp);
         this.Controls.Add(this.pboxImage);
         this.Controls.Add(this.lblImage);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "DlgEditCell";
         this.Text = "Cell";
         this.Load += new System.EventHandler(this.dlgEditCell_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudTemp)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.OpenFileDialog odlgOpenImage;
      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label lblImage;
      private System.Windows.Forms.PictureBox pboxImage;
      private System.Windows.Forms.Label lblTemp;
      private System.Windows.Forms.NumericUpDown nudTemp;
      private System.Windows.Forms.CheckBox chkHole;
      private System.Windows.Forms.CheckBox chkLiquid;
   }
}