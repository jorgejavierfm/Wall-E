namespace Walle.UI.Dialogs{
   partial class DlgEditRobot
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
         this.pboxLookingLeft = new System.Windows.Forms.PictureBox();
         this.lblImage = new System.Windows.Forms.Label();
         this.txtName = new System.Windows.Forms.TextBox();
         this.lblPower = new System.Windows.Forms.Label();
         this.nudPower = new System.Windows.Forms.NumericUpDown();
         this.odlgOpenImage = new System.Windows.Forms.OpenFileDialog();
         this.lblCapacity = new System.Windows.Forms.Label();
         this.nudCapacity = new System.Windows.Forms.NumericUpDown();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.lblTemp = new System.Windows.Forms.Label();
         this.nudMeltTemp = new System.Windows.Forms.NumericUpDown();
         this.pboxLookingRight = new System.Windows.Forms.PictureBox();
         this.pboxLookingUp = new System.Windows.Forms.PictureBox();
         this.pboxLookingDown = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingLeft)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudPower)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudMeltTemp)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingRight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingUp)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingDown)).BeginInit();
         this.SuspendLayout();
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(12, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(68, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Robot name:";
         // 
         // pboxLookingLeft
         // 
         this.pboxLookingLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pboxLookingLeft.Location = new System.Drawing.Point(52, 159);
         this.pboxLookingLeft.Name = "pboxLookingLeft";
         this.pboxLookingLeft.Size = new System.Drawing.Size(32, 32);
         this.pboxLookingLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pboxLookingLeft.TabIndex = 11;
         this.pboxLookingLeft.TabStop = false;
         this.pboxLookingLeft.Click += new System.EventHandler(this.pboxLooking_Click);
         // 
         // lblImage
         // 
         this.lblImage.AutoSize = true;
         this.lblImage.Location = new System.Drawing.Point(18, 127);
         this.lblImage.Name = "lblImage";
         this.lblImage.Size = new System.Drawing.Size(44, 13);
         this.lblImage.TabIndex = 10;
         this.lblImage.Text = "Images:";
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(97, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(100, 20);
         this.txtName.TabIndex = 12;
         this.txtName.Text = "Rob";
         this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // lblPower
         // 
         this.lblPower.AutoSize = true;
         this.lblPower.Location = new System.Drawing.Point(12, 40);
         this.lblPower.Name = "lblPower";
         this.lblPower.Size = new System.Drawing.Size(40, 13);
         this.lblPower.TabIndex = 13;
         this.lblPower.Text = "Power:";
         // 
         // nudPower
         // 
         this.nudPower.Location = new System.Drawing.Point(133, 38);
         this.nudPower.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.nudPower.Name = "nudPower";
         this.nudPower.Size = new System.Drawing.Size(64, 20);
         this.nudPower.TabIndex = 14;
         this.nudPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.nudPower.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
         // 
         // odlgOpenImage
         // 
         this.odlgOpenImage.Filter = "Image files (*.bmp; *.jpg; *.png; *.ico; *.gif)|*.bmp; *.jpg; *.png; *.ico;*.gif";
         // 
         // lblCapacity
         // 
         this.lblCapacity.AutoSize = true;
         this.lblCapacity.Location = new System.Drawing.Point(12, 66);
         this.lblCapacity.Name = "lblCapacity";
         this.lblCapacity.Size = new System.Drawing.Size(51, 13);
         this.lblCapacity.TabIndex = 15;
         this.lblCapacity.Text = "Capacity:";
         // 
         // nudCapacity
         // 
         this.nudCapacity.Location = new System.Drawing.Point(133, 64);
         this.nudCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.nudCapacity.Name = "nudCapacity";
         this.nudCapacity.Size = new System.Drawing.Size(64, 20);
         this.nudCapacity.TabIndex = 16;
         this.nudCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.nudCapacity.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(12, 227);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 17;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(133, 227);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(64, 23);
         this.btnCancel.TabIndex = 18;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // lblTemp
         // 
         this.lblTemp.AutoSize = true;
         this.lblTemp.Location = new System.Drawing.Point(12, 92);
         this.lblTemp.Name = "lblTemp";
         this.lblTemp.Size = new System.Drawing.Size(84, 13);
         this.lblTemp.TabIndex = 20;
         this.lblTemp.Text = "Temp tolerance:";
         // 
         // nudMeltTemp
         // 
         this.nudMeltTemp.Location = new System.Drawing.Point(133, 90);
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
            220,
            0,
            0,
            0});
         // 
         // pboxLookingRight
         // 
         this.pboxLookingRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pboxLookingRight.Location = new System.Drawing.Point(133, 159);
         this.pboxLookingRight.Name = "pboxLookingRight";
         this.pboxLookingRight.Size = new System.Drawing.Size(32, 32);
         this.pboxLookingRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pboxLookingRight.TabIndex = 22;
         this.pboxLookingRight.TabStop = false;
         this.pboxLookingRight.Click += new System.EventHandler(this.pboxLooking_Click);
         // 
         // pboxLookingUp
         // 
         this.pboxLookingUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pboxLookingUp.Location = new System.Drawing.Point(93, 118);
         this.pboxLookingUp.Name = "pboxLookingUp";
         this.pboxLookingUp.Size = new System.Drawing.Size(32, 32);
         this.pboxLookingUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pboxLookingUp.TabIndex = 23;
         this.pboxLookingUp.TabStop = false;
         this.pboxLookingUp.Click += new System.EventHandler(this.pboxLooking_Click);
         // 
         // pboxLookingDown
         // 
         this.pboxLookingDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pboxLookingDown.Location = new System.Drawing.Point(93, 195);
         this.pboxLookingDown.Name = "pboxLookingDown";
         this.pboxLookingDown.Size = new System.Drawing.Size(32, 32);
         this.pboxLookingDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pboxLookingDown.TabIndex = 22;
         this.pboxLookingDown.TabStop = false;
         this.pboxLookingDown.Click += new System.EventHandler(this.pboxLooking_Click);
         // 
         // DlgEditRobot
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(209, 262);
         this.Controls.Add(this.pboxLookingUp);
         this.Controls.Add(this.pboxLookingDown);
         this.Controls.Add(this.pboxLookingRight);
         this.Controls.Add(this.nudMeltTemp);
         this.Controls.Add(this.lblTemp);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.nudCapacity);
         this.Controls.Add(this.lblCapacity);
         this.Controls.Add(this.nudPower);
         this.Controls.Add(this.lblPower);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.pboxLookingLeft);
         this.Controls.Add(this.lblImage);
         this.Controls.Add(this.lblName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "DlgEditRobot";
         this.Text = "Robot";
         this.Load += new System.EventHandler(this.dlgEditItem_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingLeft)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudPower)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nudMeltTemp)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingRight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingUp)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pboxLookingDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.PictureBox pboxLookingLeft;
      private System.Windows.Forms.Label lblImage;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label lblPower;
      private System.Windows.Forms.NumericUpDown nudPower;
      private System.Windows.Forms.OpenFileDialog odlgOpenImage;
      private System.Windows.Forms.Label lblCapacity;
      private System.Windows.Forms.NumericUpDown nudCapacity;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Label lblTemp;
      private System.Windows.Forms.NumericUpDown nudMeltTemp;
      private System.Windows.Forms.PictureBox pboxLookingRight;
      private System.Windows.Forms.PictureBox pboxLookingUp;
      private System.Windows.Forms.PictureBox pboxLookingDown;
   }
}