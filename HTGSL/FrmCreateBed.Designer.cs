namespace HTGSL
{
    partial class FrmCreateBed
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
            this.bedInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.cbuser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.noRadioButton = new System.Windows.Forms.RadioButton();
            this.yesRadioButton = new System.Windows.Forms.RadioButton();
            this.installLabel = new System.Windows.Forms.Label();
            this.bedLabel = new System.Windows.Forms.Label();
            this.bedNameTextBox = new System.Windows.Forms.TextBox();
            this.bedIdTextBox = new System.Windows.Forms.TextBox();
            this.regionNameTextBox = new System.Windows.Forms.TextBox();
            this.regionIdTextBox = new System.Windows.Forms.TextBox();
            this.regionLabel = new System.Windows.Forms.Label();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.roomLabel = new System.Windows.Forms.Label();
            this.roomIdTextBox = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.bedInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bedInfoGroupBox
            // 
            this.bedInfoGroupBox.Controls.Add(this.cbuser);
            this.bedInfoGroupBox.Controls.Add(this.label1);
            this.bedInfoGroupBox.Controls.Add(this.noRadioButton);
            this.bedInfoGroupBox.Controls.Add(this.yesRadioButton);
            this.bedInfoGroupBox.Controls.Add(this.installLabel);
            this.bedInfoGroupBox.Controls.Add(this.bedLabel);
            this.bedInfoGroupBox.Controls.Add(this.bedNameTextBox);
            this.bedInfoGroupBox.Controls.Add(this.bedIdTextBox);
            this.bedInfoGroupBox.Controls.Add(this.regionNameTextBox);
            this.bedInfoGroupBox.Controls.Add(this.regionIdTextBox);
            this.bedInfoGroupBox.Controls.Add(this.regionLabel);
            this.bedInfoGroupBox.Controls.Add(this.noteTextBox);
            this.bedInfoGroupBox.Controls.Add(this.roomLabel);
            this.bedInfoGroupBox.Controls.Add(this.roomIdTextBox);
            this.bedInfoGroupBox.Controls.Add(this.noteLabel);
            this.bedInfoGroupBox.Controls.Add(this.roomNameTextBox);
            this.bedInfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.bedInfoGroupBox.Name = "bedInfoGroupBox";
            this.bedInfoGroupBox.Size = new System.Drawing.Size(400, 212);
            this.bedInfoGroupBox.TabIndex = 17;
            this.bedInfoGroupBox.TabStop = false;
            this.bedInfoGroupBox.Text = "Bed Info";
            // 
            // cbuser
            // 
            this.cbuser.FormattingEnabled = true;
            this.cbuser.Location = new System.Drawing.Point(135, 136);
            this.cbuser.Name = "cbuser";
            this.cbuser.Size = new System.Drawing.Size(240, 21);
            this.cbuser.TabIndex = 16;
            this.cbuser.SelectedIndexChanged += new System.EventHandler(this.cbuser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Curator:";
            // 
            // noRadioButton
            // 
            this.noRadioButton.AutoSize = true;
            this.noRadioButton.Checked = true;
            this.noRadioButton.Location = new System.Drawing.Point(135, 163);
            this.noRadioButton.Name = "noRadioButton";
            this.noRadioButton.Size = new System.Drawing.Size(39, 17);
            this.noRadioButton.TabIndex = 13;
            this.noRadioButton.TabStop = true;
            this.noRadioButton.Text = "No";
            this.noRadioButton.UseVisualStyleBackColor = true;
            // 
            // yesRadioButton
            // 
            this.yesRadioButton.AutoSize = true;
            this.yesRadioButton.Location = new System.Drawing.Point(245, 163);
            this.yesRadioButton.Name = "yesRadioButton";
            this.yesRadioButton.Size = new System.Drawing.Size(43, 17);
            this.yesRadioButton.TabIndex = 14;
            this.yesRadioButton.Text = "Yes";
            this.yesRadioButton.UseVisualStyleBackColor = true;
            // 
            // installLabel
            // 
            this.installLabel.AutoSize = true;
            this.installLabel.Location = new System.Drawing.Point(24, 165);
            this.installLabel.Name = "installLabel";
            this.installLabel.Size = new System.Drawing.Size(37, 13);
            this.installLabel.TabIndex = 12;
            this.installLabel.Text = "Install:";
            // 
            // bedLabel
            // 
            this.bedLabel.AutoSize = true;
            this.bedLabel.Location = new System.Drawing.Point(24, 82);
            this.bedLabel.Name = "bedLabel";
            this.bedLabel.Size = new System.Drawing.Size(29, 13);
            this.bedLabel.TabIndex = 7;
            this.bedLabel.Text = "Bed:";
            // 
            // bedNameTextBox
            // 
            this.bedNameTextBox.Location = new System.Drawing.Point(175, 78);
            this.bedNameTextBox.MaxLength = 40;
            this.bedNameTextBox.Name = "bedNameTextBox";
            this.bedNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.bedNameTextBox.TabIndex = 9;
            this.bedNameTextBox.Validated += new System.EventHandler(this.bedNameTextBox_Validated);
            // 
            // bedIdTextBox
            // 
            this.bedIdTextBox.Location = new System.Drawing.Point(135, 78);
            this.bedIdTextBox.MaxLength = 2;
            this.bedIdTextBox.Name = "bedIdTextBox";
            this.bedIdTextBox.Size = new System.Drawing.Size(36, 20);
            this.bedIdTextBox.TabIndex = 8;
            this.bedIdTextBox.Text = "0";
            this.bedIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bedIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberChecked_KeyPress);
            // 
            // regionNameTextBox
            // 
            this.regionNameTextBox.Location = new System.Drawing.Point(175, 24);
            this.regionNameTextBox.MaxLength = 40;
            this.regionNameTextBox.Name = "regionNameTextBox";
            this.regionNameTextBox.ReadOnly = true;
            this.regionNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.regionNameTextBox.TabIndex = 3;
            this.regionNameTextBox.TabStop = false;
            // 
            // regionIdTextBox
            // 
            this.regionIdTextBox.Location = new System.Drawing.Point(135, 24);
            this.regionIdTextBox.MaxLength = 40;
            this.regionIdTextBox.Name = "regionIdTextBox";
            this.regionIdTextBox.ReadOnly = true;
            this.regionIdTextBox.Size = new System.Drawing.Size(36, 20);
            this.regionIdTextBox.TabIndex = 2;
            this.regionIdTextBox.TabStop = false;
            this.regionIdTextBox.Text = "0";
            this.regionIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Location = new System.Drawing.Point(24, 28);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(44, 13);
            this.regionLabel.TabIndex = 1;
            this.regionLabel.Text = "Region:";
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(135, 105);
            this.noteTextBox.MaxLength = 50;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(240, 20);
            this.noteTextBox.TabIndex = 11;
            this.noteTextBox.Validated += new System.EventHandler(this.noteTextBox_Validated);
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Location = new System.Drawing.Point(24, 55);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(38, 13);
            this.roomLabel.TabIndex = 4;
            this.roomLabel.Text = "Room:";
            // 
            // roomIdTextBox
            // 
            this.roomIdTextBox.Location = new System.Drawing.Point(135, 51);
            this.roomIdTextBox.MaxLength = 2;
            this.roomIdTextBox.Name = "roomIdTextBox";
            this.roomIdTextBox.ReadOnly = true;
            this.roomIdTextBox.Size = new System.Drawing.Size(36, 20);
            this.roomIdTextBox.TabIndex = 5;
            this.roomIdTextBox.TabStop = false;
            this.roomIdTextBox.Text = "0";
            this.roomIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(24, 109);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(33, 13);
            this.noteLabel.TabIndex = 10;
            this.noteLabel.Text = "Note:";
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.Location = new System.Drawing.Point(175, 51);
            this.roomNameTextBox.MaxLength = 40;
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.ReadOnly = true;
            this.roomNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.roomNameTextBox.TabIndex = 6;
            this.roomNameTextBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(305, 230);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 25);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(204, 230);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(95, 25);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // f6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 267);
            this.Controls.Add(this.bedInfoGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "f6";
            this.Text = "f6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form6_FormClosing);
            this.Load += new System.EventHandler(this.Form6_Load);
            this.bedInfoGroupBox.ResumeLayout(false);
            this.bedInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bedInfoGroupBox;
        private System.Windows.Forms.ComboBox cbuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton noRadioButton;
        private System.Windows.Forms.RadioButton yesRadioButton;
        private System.Windows.Forms.Label installLabel;
        private System.Windows.Forms.Label bedLabel;
        private System.Windows.Forms.TextBox bedNameTextBox;
        private System.Windows.Forms.TextBox bedIdTextBox;
        private System.Windows.Forms.TextBox regionNameTextBox;
        private System.Windows.Forms.TextBox regionIdTextBox;
        private System.Windows.Forms.Label regionLabel;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.TextBox roomIdTextBox;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}