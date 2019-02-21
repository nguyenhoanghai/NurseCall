namespace HTGSL
{
    partial class FrmRoom
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
            this.roomInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.txtLabor = new System.Windows.Forms.NumericUpDown();
            this.laborLabel = new System.Windows.Forms.Label();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.roomIdTextBox = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.roomLabel = new System.Windows.Forms.Label();
            this.regionLabel = new System.Windows.Forms.Label();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.regionIdTextBox = new System.Windows.Forms.TextBox();
            this.regionNameTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.roomInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLabor)).BeginInit();
            this.SuspendLayout();
            // 
            // roomInfoGroupBox
            // 
            this.roomInfoGroupBox.Controls.Add(this.txtLabor);
            this.roomInfoGroupBox.Controls.Add(this.laborLabel);
            this.roomInfoGroupBox.Controls.Add(this.roomNameTextBox);
            this.roomInfoGroupBox.Controls.Add(this.roomIdTextBox);
            this.roomInfoGroupBox.Controls.Add(this.noteLabel);
            this.roomInfoGroupBox.Controls.Add(this.roomLabel);
            this.roomInfoGroupBox.Controls.Add(this.regionLabel);
            this.roomInfoGroupBox.Controls.Add(this.noteTextBox);
            this.roomInfoGroupBox.Controls.Add(this.regionIdTextBox);
            this.roomInfoGroupBox.Controls.Add(this.regionNameTextBox);
            this.roomInfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.roomInfoGroupBox.Name = "roomInfoGroupBox";
            this.roomInfoGroupBox.Size = new System.Drawing.Size(393, 149);
            this.roomInfoGroupBox.TabIndex = 0;
            this.roomInfoGroupBox.TabStop = false;
            this.roomInfoGroupBox.Text = "Room Info";
            // 
            // txtLabor
            // 
            this.txtLabor.Location = new System.Drawing.Point(135, 84);
            this.txtLabor.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtLabor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLabor.Name = "txtLabor";
            this.txtLabor.Size = new System.Drawing.Size(83, 24);
            this.txtLabor.TabIndex = 9;
            this.txtLabor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLabor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // laborLabel
            // 
            this.laborLabel.AutoSize = true;
            this.laborLabel.Location = new System.Drawing.Point(24, 86);
            this.laborLabel.Name = "laborLabel";
            this.laborLabel.Size = new System.Drawing.Size(58, 17);
            this.laborLabel.TabIndex = 8;
            this.laborLabel.Text = "Labors :";
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.Location = new System.Drawing.Point(175, 54);
            this.roomNameTextBox.MaxLength = 40;
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(200, 24);
            this.roomNameTextBox.TabIndex = 7;
            this.roomNameTextBox.Validated += new System.EventHandler(this.roomNameTextBox_Validated);
            // 
            // roomIdTextBox
            // 
            this.roomIdTextBox.Location = new System.Drawing.Point(135, 54);
            this.roomIdTextBox.MaxLength = 2;
            this.roomIdTextBox.Name = "roomIdTextBox";
            this.roomIdTextBox.Size = new System.Drawing.Size(36, 24);
            this.roomIdTextBox.TabIndex = 6;
            this.roomIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.roomIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roomIdTextBox_KeyPress);
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(24, 117);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(42, 17);
            this.noteLabel.TabIndex = 5;
            this.noteLabel.Text = "Note:"; 
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Location = new System.Drawing.Point(24, 57);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(50, 17);
            this.roomLabel.TabIndex = 4;
            this.roomLabel.Text = "Room:";
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Location = new System.Drawing.Point(24, 28);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(55, 17);
            this.regionLabel.TabIndex = 3;
            this.regionLabel.Text = "Region:";
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(135, 114);
            this.noteTextBox.MaxLength = 50;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(240, 24);
            this.noteTextBox.TabIndex = 2;
            this.noteTextBox.Validated += new System.EventHandler(this.noteTextBox_Validated);
            // 
            // regionIdTextBox
            // 
            this.regionIdTextBox.Location = new System.Drawing.Point(135, 24);
            this.regionIdTextBox.Name = "regionIdTextBox";
            this.regionIdTextBox.Size = new System.Drawing.Size(36, 24);
            this.regionIdTextBox.TabIndex = 1;
            this.regionIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // regionNameTextBox
            // 
            this.regionNameTextBox.Location = new System.Drawing.Point(175, 24);
            this.regionNameTextBox.MaxLength = 40;
            this.regionNameTextBox.Name = "regionNameTextBox";
            this.regionNameTextBox.ReadOnly = true;
            this.regionNameTextBox.Size = new System.Drawing.Size(200, 24);
            this.regionNameTextBox.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(210, 167);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(95, 25);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(310, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 25);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // FrmRoom
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 200);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.roomInfoGroupBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F5 - New Room ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRoom_FormClosing);
            this.Load += new System.EventHandler(this.FrmRoom_Load);
            this.roomInfoGroupBox.ResumeLayout(false);
            this.roomInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLabor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox roomInfoGroupBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.TextBox regionIdTextBox;
        private System.Windows.Forms.TextBox regionNameTextBox;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.Label regionLabel;
        private System.Windows.Forms.TextBox roomIdTextBox;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown txtLabor;
        private System.Windows.Forms.Label laborLabel;
    }
}