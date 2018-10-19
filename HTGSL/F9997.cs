using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class F9997 : Form
	{
		private IContainer components = null;
		private TextBox txtNGUOITAO;
		private Label label1;
		private TextBox txtNGAYTAO;
		private Label label2;
		private TextBox txtNGUOISUA;
		private Label label3;
		private TextBox txtNGAYSUA;
		private Label label4;
		public string NGUOI_TAO
		{
			get
			{
				return this.txtNGUOITAO.Text;
			}
			set
			{
				this.txtNGUOITAO.Text = value;
			}
		}
		public string NGAY_TAO
		{
			get
			{
				return this.txtNGAYTAO.Text;
			}
			set
			{
				this.txtNGAYTAO.Text = value;
			}
		}
		public string NGUOI_SUA
		{
			get
			{
				return this.txtNGUOISUA.Text;
			}
			set
			{
				this.txtNGUOISUA.Text = value;
			}
		}
		public string NGAY_SUA
		{
			get
			{
				return this.txtNGAYSUA.Text;
			}
			set
			{
				this.txtNGAYSUA.Text = value;
			}
		}
		public F9997()
		{
			this.InitializeComponent();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F9997));
			this.txtNGUOITAO = new TextBox();
			this.label1 = new Label();
			this.txtNGAYTAO = new TextBox();
			this.label2 = new Label();
			this.txtNGUOISUA = new TextBox();
			this.label3 = new Label();
			this.txtNGAYSUA = new TextBox();
			this.label4 = new Label();
			base.SuspendLayout();
			this.txtNGUOITAO.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNGUOITAO.Location = new Point(81, 17);
			this.txtNGUOITAO.Name = "txtNGUOITAO";
			this.txtNGUOITAO.ReadOnly = true;
			this.txtNGUOITAO.Size = new Size(191, 21);
			this.txtNGUOITAO.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Người tạo";
			this.txtNGAYTAO.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNGAYTAO.Location = new Point(81, 44);
			this.txtNGAYTAO.Name = "txtNGAYTAO";
			this.txtNGAYTAO.ReadOnly = true;
			this.txtNGAYTAO.Size = new Size(191, 21);
			this.txtNGAYTAO.TabIndex = 0;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(12, 47);
			this.label2.Name = "label2";
			this.label2.Size = new Size(55, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ngày tạo";
			this.txtNGUOISUA.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNGUOISUA.Location = new Point(81, 71);
			this.txtNGUOISUA.Name = "txtNGUOISUA";
			this.txtNGUOISUA.ReadOnly = true;
			this.txtNGUOISUA.Size = new Size(191, 21);
			this.txtNGUOISUA.TabIndex = 0;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(12, 74);
			this.label3.Name = "label3";
			this.label3.Size = new Size(63, 15);
			this.label3.TabIndex = 1;
			this.label3.Text = "Người sửa";
			this.txtNGAYSUA.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtNGAYSUA.Location = new Point(81, 98);
			this.txtNGAYSUA.Name = "txtNGAYSUA";
			this.txtNGAYSUA.ReadOnly = true;
			this.txtNGAYSUA.Size = new Size(191, 21);
			this.txtNGAYSUA.TabIndex = 0;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(12, 101);
			this.label4.Name = "label4";
			this.label4.Size = new Size(58, 15);
			this.label4.TabIndex = 1;
			this.label4.Text = "Ngày sửa";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(292, 143);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.txtNGAYSUA);
			base.Controls.Add(this.txtNGUOISUA);
			base.Controls.Add(this.txtNGAYTAO);
			base.Controls.Add(this.txtNGUOITAO);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "F9997";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F9997 - Thông tin cập nhật";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
