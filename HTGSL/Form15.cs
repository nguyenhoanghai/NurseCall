using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form15 : Form
	{
		private int the_iRegionID;
		private int the_iRoomID;
		private int the_iBedID;
		private IContainer components = null;
		private GroupBox bedInfoGroupBox;
		private Label bedIdLabel;
		private TextBox bedIdTextBox;
		private TextBox regionIdTextBox;
		private Label regionIdLabel;
		private Label roomIdLabel;
		private TextBox roomIdTextBox;
		private Button okButton;
		private Button cancelButton;
		public int The_iRegionID
		{
			get
			{
				return this.the_iRegionID;
			}
			set
			{
				this.the_iRegionID = value;
			}
		}
		public int The_iRoomID
		{
			get
			{
				return this.the_iRoomID;
			}
			set
			{
				this.the_iRoomID = value;
			}
		}
		public int The_iBedID
		{
			get
			{
				return this.the_iBedID;
			}
			set
			{
				this.the_iBedID = value;
			}
		}
		public Form15()
		{
			this.InitializeComponent();
		}
		private void Form15_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.regionIdTextBox.Text = this.the_iRegionID.ToString();
			this.roomIdTextBox.Text = this.the_iRoomID.ToString();
			this.bedIdTextBox.Text = this.the_iBedID.ToString();
		}
		private void LoadCaptionForControls()
		{
			this.Text = "F15 - " + Properties.Resources.FindBed;
			this.bedInfoGroupBox.Text = Properties.Resources.BedInfo;
			this.regionIdLabel.Text = Properties.Resources.RegionID + ":";
			this.roomIdLabel.Text = Properties.Resources.RoomID + ":";
			this.bedIdLabel.Text = Properties.Resources.BedID + ":";
			this.okButton.Text = Properties.Resources.OK;
			this.cancelButton.Text = Properties.Resources.Cancel;
		}
		private void Form15_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.the_iRegionID = int.Parse(this.regionIdTextBox.Text);
			this.the_iRoomID = int.Parse(this.roomIdTextBox.Text);
			this.the_iBedID = int.Parse(this.bedIdTextBox.Text);
		}
		private void okButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form15));
			this.bedInfoGroupBox = new GroupBox();
			this.bedIdLabel = new Label();
			this.bedIdTextBox = new TextBox();
			this.regionIdTextBox = new TextBox();
			this.regionIdLabel = new Label();
			this.roomIdLabel = new Label();
			this.roomIdTextBox = new TextBox();
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.bedInfoGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.bedInfoGroupBox.Controls.Add(this.bedIdLabel);
			this.bedInfoGroupBox.Controls.Add(this.bedIdTextBox);
			this.bedInfoGroupBox.Controls.Add(this.regionIdTextBox);
			this.bedInfoGroupBox.Controls.Add(this.regionIdLabel);
			this.bedInfoGroupBox.Controls.Add(this.roomIdLabel);
			this.bedInfoGroupBox.Controls.Add(this.roomIdTextBox);
			this.bedInfoGroupBox.Location = new Point(12, 12);
			this.bedInfoGroupBox.Name = "bedInfoGroupBox";
			this.bedInfoGroupBox.Size = new Size(185, 116);
			this.bedInfoGroupBox.TabIndex = 0;
			this.bedInfoGroupBox.TabStop = false;
			this.bedInfoGroupBox.Text = "Bed Info";
			this.bedIdLabel.AutoSize = true;
			this.bedIdLabel.Location = new Point(24, 82);
			this.bedIdLabel.Name = "bedIdLabel";
			this.bedIdLabel.Size = new Size(43, 13);
			this.bedIdLabel.TabIndex = 5;
			this.bedIdLabel.Text = "Bed ID:";
			this.bedIdTextBox.Location = new Point(122, 78);
			this.bedIdTextBox.MaxLength = 2;
			this.bedIdTextBox.Name = "bedIdTextBox";
			this.bedIdTextBox.Size = new Size(36, 21);
			this.bedIdTextBox.TabIndex = 6;
			this.bedIdTextBox.Text = "0";
			this.bedIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.regionIdTextBox.Location = new Point(122, 24);
			this.regionIdTextBox.MaxLength = 2;
			this.regionIdTextBox.Name = "regionIdTextBox";
			this.regionIdTextBox.Size = new Size(36, 21);
			this.regionIdTextBox.TabIndex = 2;
			this.regionIdTextBox.Text = "0";
			this.regionIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.regionIdLabel.AutoSize = true;
			this.regionIdLabel.Location = new Point(24, 28);
			this.regionIdLabel.Name = "regionIdLabel";
			this.regionIdLabel.Size = new Size(58, 13);
			this.regionIdLabel.TabIndex = 1;
			this.regionIdLabel.Text = "Region ID:";
			this.roomIdLabel.AutoSize = true;
			this.roomIdLabel.Location = new Point(24, 55);
			this.roomIdLabel.Name = "roomIdLabel";
			this.roomIdLabel.Size = new Size(52, 13);
			this.roomIdLabel.TabIndex = 3;
			this.roomIdLabel.Text = "Room ID:";
			this.roomIdTextBox.Location = new Point(122, 51);
			this.roomIdTextBox.MaxLength = 2;
			this.roomIdTextBox.Name = "roomIdTextBox";
			this.roomIdTextBox.Size = new Size(36, 21);
			this.roomIdTextBox.TabIndex = 4;
			this.roomIdTextBox.Text = "0";
			this.roomIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.okButton.Location = new Point(210, 63);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(75, 23);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(210, 89);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(75, 23);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			base.AcceptButton = this.okButton;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(296, 146);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.bedInfoGroupBox);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form15";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F15 - Find";
			base.Load += new EventHandler(this.Form15_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form15_FormClosing);
			this.bedInfoGroupBox.ResumeLayout(false);
			this.bedInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
