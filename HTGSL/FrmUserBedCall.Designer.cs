namespace HTGSL
{
    partial class FrmUserBedCall
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
            this.btnUncheck = new System.Windows.Forms.Button();
            this.btnChkAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkList = new System.Windows.Forms.CheckedListBox();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnrefreshUsers = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUncheck
            // 
            this.btnUncheck.Location = new System.Drawing.Point(11, 107);
            this.btnUncheck.Name = "btnUncheck";
            this.btnUncheck.Size = new System.Drawing.Size(75, 23);
            this.btnUncheck.TabIndex = 18;
            this.btnUncheck.Text = "Bỏ chọn";
            this.btnUncheck.UseVisualStyleBackColor = true;
            this.btnUncheck.Click += new System.EventHandler(this.btnUncheck_Click);
            // 
            // btnChkAll
            // 
            this.btnChkAll.Location = new System.Drawing.Point(11, 78);
            this.btnChkAll.Name = "btnChkAll";
            this.btnChkAll.Size = new System.Drawing.Size(75, 23);
            this.btnChkAll.TabIndex = 17;
            this.btnChkAll.Text = "Chọn tất cả";
            this.btnChkAll.UseVisualStyleBackColor = true;
            this.btnChkAll.Click += new System.EventHandler(this.btnChkAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "DS giường";
            // 
            // chkList
            // 
            this.chkList.FormattingEnabled = true;
            this.chkList.Location = new System.Drawing.Point(92, 47);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(298, 289);
            this.chkList.TabIndex = 14;
            // 
            // cbUser
            // 
            this.cbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(92, 13);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(263, 21);
            this.cbUser.TabIndex = 13;
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tài khoản";
            // 
            // btnrefreshUsers
            // 
            this.btnrefreshUsers.Image = global::Properties.Resources.refresh;
            this.btnrefreshUsers.Location = new System.Drawing.Point(361, 13);
            this.btnrefreshUsers.Name = "btnrefreshUsers";
            this.btnrefreshUsers.Size = new System.Drawing.Size(29, 23);
            this.btnrefreshUsers.TabIndex = 19;
            this.btnrefreshUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnrefreshUsers.UseVisualStyleBackColor = true;
            this.btnrefreshUsers.Click += new System.EventHandler(this.btnrefreshUsers_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(273, 342);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 35);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmUserBedCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 385);
            this.Controls.Add(this.btnrefreshUsers);
            this.Controls.Add(this.btnUncheck);
            this.Controls.Add(this.btnChkAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkList);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.label3);
            this.Name = "FrmUserBedCall";
            this.Text = "FrmUserBedCall";
            this.Load += new System.EventHandler(this.FrmUserBedCall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUncheck;
        private System.Windows.Forms.Button btnChkAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkList;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnrefreshUsers;
    }
}