namespace HTGSL
{
    partial class FrmTestform
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
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.btnHexString = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.btnSetConnect = new System.Windows.Forms.Button();
            this.btnGetConnect = new System.Windows.Forms.Button();
            this.btnReadsound = new System.Windows.Forms.Button();
            this.btnToHexString = new System.Windows.Forms.Button();
            this.btnXOR = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGetPath = new System.Windows.Forms.Button();
            this.txtroom = new System.Windows.Forms.TextBox();
            this.txtbed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btncall = new System.Windows.Forms.Button();
            this.btnprocess = new System.Windows.Forms.Button();
            this.btnend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 118);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(535, 20);
            this.textBox5.TabIndex = 5;
            this.textBox5.Tag = "";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(535, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Tag = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 64);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(535, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Tag = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(535, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.Tag = "";
            this.textBox2.Text = "02 01, 01, 301, 6, Z 03";
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(62, 12);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(28, 20);
            this.txtRegion.TabIndex = 9;
            this.txtRegion.Text = "01";
            this.txtRegion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnHexString
            // 
            this.btnHexString.Location = new System.Drawing.Point(405, 180);
            this.btnHexString.Name = "btnHexString";
            this.btnHexString.Size = new System.Drawing.Size(125, 30);
            this.btnHexString.TabIndex = 10;
            this.btnHexString.Text = "Hex To String";
            this.btnHexString.UseVisualStyleBackColor = true;
            this.btnHexString.Click += new System.EventHandler(this.button6_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(143, 180);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(125, 30);
            this.button11.TabIndex = 11;
            this.button11.Text = "Test Menu";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(12, 144);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(125, 30);
            this.btnTestConnect.TabIndex = 12;
            this.btnTestConnect.Text = "Test Connect";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // btnSetConnect
            // 
            this.btnSetConnect.Location = new System.Drawing.Point(12, 180);
            this.btnSetConnect.Name = "btnSetConnect";
            this.btnSetConnect.Size = new System.Drawing.Size(125, 30);
            this.btnSetConnect.TabIndex = 13;
            this.btnSetConnect.Text = "Set Connect";
            this.btnSetConnect.UseVisualStyleBackColor = true;
            this.btnSetConnect.Click += new System.EventHandler(this.btnSetConnect_Click);
            // 
            // btnGetConnect
            // 
            this.btnGetConnect.Location = new System.Drawing.Point(12, 216);
            this.btnGetConnect.Name = "btnGetConnect";
            this.btnGetConnect.Size = new System.Drawing.Size(125, 30);
            this.btnGetConnect.TabIndex = 14;
            this.btnGetConnect.Text = "Get Connect";
            this.btnGetConnect.UseVisualStyleBackColor = true;
            this.btnGetConnect.Click += new System.EventHandler(this.btnGetConnect_Click);
            // 
            // btnReadsound
            // 
            this.btnReadsound.Location = new System.Drawing.Point(143, 144);
            this.btnReadsound.Name = "btnReadsound";
            this.btnReadsound.Size = new System.Drawing.Size(125, 30);
            this.btnReadsound.TabIndex = 15;
            this.btnReadsound.Text = "Read Sound";
            this.btnReadsound.UseVisualStyleBackColor = true;
            this.btnReadsound.Click += new System.EventHandler(this.btnReadsound_Click);
            // 
            // btnToHexString
            // 
            this.btnToHexString.Location = new System.Drawing.Point(405, 144);
            this.btnToHexString.Name = "btnToHexString";
            this.btnToHexString.Size = new System.Drawing.Size(125, 30);
            this.btnToHexString.TabIndex = 16;
            this.btnToHexString.Text = "To Hex String";
            this.btnToHexString.UseVisualStyleBackColor = true;
            this.btnToHexString.Click += new System.EventHandler(this.btnToHexString_Click);
            // 
            // btnXOR
            // 
            this.btnXOR.Location = new System.Drawing.Point(405, 216);
            this.btnXOR.Name = "btnXOR";
            this.btnXOR.Size = new System.Drawing.Size(125, 30);
            this.btnXOR.TabIndex = 17;
            this.btnXOR.Text = "XOR";
            this.btnXOR.UseVisualStyleBackColor = true;
            this.btnXOR.Click += new System.EventHandler(this.btnXOR_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(274, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 30);
            this.button3.TabIndex = 18;
            this.button3.Text = "Edited";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnGetPath
            // 
            this.btnGetPath.Location = new System.Drawing.Point(274, 144);
            this.btnGetPath.Name = "btnGetPath";
            this.btnGetPath.Size = new System.Drawing.Size(125, 30);
            this.btnGetPath.TabIndex = 19;
            this.btnGetPath.Text = "Get Path";
            this.btnGetPath.UseVisualStyleBackColor = true;
            this.btnGetPath.Click += new System.EventHandler(this.btnGetPath_Click);
            // 
            // txtroom
            // 
            this.txtroom.Location = new System.Drawing.Point(161, 12);
            this.txtroom.Name = "txtroom";
            this.txtroom.Size = new System.Drawing.Size(50, 20);
            this.txtroom.TabIndex = 21;
            this.txtroom.Text = "001";
            this.txtroom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbed
            // 
            this.txtbed.Location = new System.Drawing.Point(264, 12);
            this.txtbed.Name = "txtbed";
            this.txtbed.Size = new System.Drawing.Size(40, 20);
            this.txtbed.TabIndex = 22;
            this.txtbed.Text = "01";
            this.txtbed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Khu vực";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tên phòng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Giường";
            // 
            // btncall
            // 
            this.btncall.Location = new System.Drawing.Point(310, 9);
            this.btncall.Name = "btncall";
            this.btncall.Size = new System.Drawing.Size(75, 24);
            this.btncall.TabIndex = 26;
            this.btncall.Text = "Call";
            this.btncall.UseVisualStyleBackColor = true;
            this.btncall.Click += new System.EventHandler(this.btncall_Click);
            // 
            // btnprocess
            // 
            this.btnprocess.Location = new System.Drawing.Point(391, 9);
            this.btnprocess.Name = "btnprocess";
            this.btnprocess.Size = new System.Drawing.Size(75, 24);
            this.btnprocess.TabIndex = 27;
            this.btnprocess.Text = "Process";
            this.btnprocess.UseVisualStyleBackColor = true;
            this.btnprocess.Click += new System.EventHandler(this.btnprocess_Click);
            // 
            // btnend
            // 
            this.btnend.Location = new System.Drawing.Point(472, 9);
            this.btnend.Name = "btnend";
            this.btnend.Size = new System.Drawing.Size(75, 24);
            this.btnend.TabIndex = 28;
            this.btnend.Text = "End";
            this.btnend.UseVisualStyleBackColor = true;
            this.btnend.Click += new System.EventHandler(this.btnend_Click);
            // 
            // FrmTestform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 258);
            this.Controls.Add(this.btnend);
            this.Controls.Add(this.btnprocess);
            this.Controls.Add(this.btncall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbed);
            this.Controls.Add(this.txtroom);
            this.Controls.Add(this.btnHexString);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.btnSetConnect);
            this.Controls.Add(this.btnGetConnect);
            this.Controls.Add(this.btnReadsound);
            this.Controls.Add(this.btnToHexString);
            this.Controls.Add(this.btnXOR);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGetPath);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtRegion);
            this.Name = "FrmTestform";
            this.Text = "FrmTestform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Button btnHexString;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.Button btnSetConnect;
        private System.Windows.Forms.Button btnGetConnect;
        private System.Windows.Forms.Button btnReadsound;
        private System.Windows.Forms.Button btnToHexString;
        private System.Windows.Forms.Button btnXOR;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnGetPath;
        private System.Windows.Forms.TextBox txtroom;
        private System.Windows.Forms.TextBox txtbed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncall;
        private System.Windows.Forms.Button btnprocess;
        private System.Windows.Forms.Button btnend;
    }
}