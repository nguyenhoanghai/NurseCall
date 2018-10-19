using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form5 : Form
	{
		public bool bModify = false;
		private int the_iRegionID;
		private string the_strRegionName;
		private int the_iRoomID;
		private string the_strRoomName;
		private string the_strNote;
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private Label roomLabel;
		private TextBox roomNameTextBox;
		private TextBox roomIdTextBox;
		private Label noteLabel;
		private GroupBox roomInfoGroupBox;
		private TextBox noteTextBox;
		private TextBox regionIdTextBox;
		private Label regionLabel;
		private TextBox regionNameTextBox;
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
		public string The_strRegionName
		{
			get
			{
				return this.the_strRegionName;
			}
			set
			{
				this.the_strRegionName = value;
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
		public string The_strRoomName
		{
			get
			{
				return this.the_strRoomName;
			}
			set
			{
				this.the_strRoomName = value;
			}
		}
		public string The_strNote
		{
			get
			{
				return this.the_strNote;
			}
			set
			{
				this.the_strNote = value;
			}
		}
		public Form5()
		{
			this.InitializeComponent();
		}
		private void Form5_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.regionIdTextBox.Text = this.the_iRegionID.ToString();
			this.regionNameTextBox.Text = this.the_strRegionName;
			this.roomIdTextBox.ReadOnly = this.bModify;
			this.roomIdTextBox.TabStop = !this.bModify;
			this.roomIdTextBox.Text = this.the_iRoomID.ToString();
			this.roomNameTextBox.Text = this.the_strRoomName;
			this.noteTextBox.Text = this.the_strNote;
		}
		private void LoadCaptionForControls()
		{
			this.Text = (this.bModify ? ("F5 - " + Properties.Resources.ModifyRoom) : ("F5 - " + Properties.Resources.NewRoom));
			this.roomInfoGroupBox.Text = Properties.Resources.RoomInfo;
			this.regionLabel.Text = Properties.Resources.Region + ":";
			this.roomLabel.Text = Properties.Resources.Room + ":";
			this.noteLabel.Text = Properties.Resources.Note + ":";
			this.okButton.Text = Properties.Resources.OK;
			this.cancelButton.Text = Properties.Resources.Cancel;
		}
		private void NumberChecked_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b');
		}
		private void okButton_Click(object sender, EventArgs e)
		{
			if (!this.bModify)
			{
				string text = this.roomIdTextBox.Text.Trim();
				if (text == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.RoomID + " " + Properties.Resources.IsNotEmpty + "!");
					this.roomIdTextBox.Focus();
					return;
				}
				if (!StringEx.IsStrNumber(text))
				{
					MyMsgBox.MsgError(Properties.Resources.RoomID + " " + Properties.Resources.IsNumber + "!");
					this.roomIdTextBox.Focus();
					return;
				}
				int num = int.Parse(text);
				if (num < 1)
				{
					MyMsgBox.MsgError(Properties.Resources.RoomID + " > 0 !");
					this.roomIdTextBox.Focus();
					return;
				}
			}
			if (this.roomNameTextBox.Text.Trim() == string.Empty)
			{
				MyMsgBox.MsgError(Properties.Resources.RoomName + " " + Properties.Resources.IsNotEmpty + "!");
				this.roomNameTextBox.Focus();
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void Form5_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.the_iRegionID = int.Parse(this.regionIdTextBox.Text);
				this.the_strRegionName = this.regionNameTextBox.Text;
				this.the_iRoomID = int.Parse(this.roomIdTextBox.Text);
				this.the_strRoomName = StringEx.CutBlanks(this.roomNameTextBox.Text);
				this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
			}
		}
		private void roomNameTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void noteTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form5));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.roomLabel = new Label();
			this.roomNameTextBox = new TextBox();
			this.roomIdTextBox = new TextBox();
			this.noteLabel = new Label();
			this.roomInfoGroupBox = new GroupBox();
			this.regionNameTextBox = new TextBox();
			this.regionIdTextBox = new TextBox();
			this.regionLabel = new Label();
			this.noteTextBox = new TextBox();
			this.roomInfoGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.okButton.Location = new Point(192, 142);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(95, 25);
			this.okButton.TabIndex = 9;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(292, 142);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(95, 25);
			this.cancelButton.TabIndex = 10;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.roomLabel.AutoSize = true;
			this.roomLabel.Location = new Point(24, 55);
			this.roomLabel.Name = "roomLabel";
			this.roomLabel.Size = new Size(38, 13);
			this.roomLabel.TabIndex = 4;
			this.roomLabel.Text = "Room:";
			this.roomNameTextBox.Location = new Point(175, 51);
			this.roomNameTextBox.MaxLength = 40;
			this.roomNameTextBox.Name = "roomNameTextBox";
			this.roomNameTextBox.Size = new Size(200, 21);
			this.roomNameTextBox.TabIndex = 6;
			this.roomNameTextBox.Validated += new EventHandler(this.roomNameTextBox_Validated);
			this.roomIdTextBox.Location = new Point(135, 51);
			this.roomIdTextBox.MaxLength = 2;
			this.roomIdTextBox.Name = "roomIdTextBox";
			this.roomIdTextBox.Size = new Size(36, 21);
			this.roomIdTextBox.TabIndex = 5;
			this.roomIdTextBox.Text = "0";
			this.roomIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.roomIdTextBox.KeyPress += new KeyPressEventHandler(this.NumberChecked_KeyPress);
			this.noteLabel.AutoSize = true;
			this.noteLabel.Location = new Point(24, 82);
			this.noteLabel.Name = "noteLabel";
			this.noteLabel.Size = new Size(34, 13);
			this.noteLabel.TabIndex = 7;
			this.noteLabel.Text = "Note:";
			this.roomInfoGroupBox.Controls.Add(this.regionNameTextBox);
			this.roomInfoGroupBox.Controls.Add(this.regionIdTextBox);
			this.roomInfoGroupBox.Controls.Add(this.regionLabel);
			this.roomInfoGroupBox.Controls.Add(this.noteTextBox);
			this.roomInfoGroupBox.Controls.Add(this.roomLabel);
			this.roomInfoGroupBox.Controls.Add(this.roomIdTextBox);
			this.roomInfoGroupBox.Controls.Add(this.noteLabel);
			this.roomInfoGroupBox.Controls.Add(this.roomNameTextBox);
			this.roomInfoGroupBox.Location = new Point(12, 12);
			this.roomInfoGroupBox.Name = "roomInfoGroupBox";
			this.roomInfoGroupBox.Size = new Size(400, 116);
			this.roomInfoGroupBox.TabIndex = 0;
			this.roomInfoGroupBox.TabStop = false;
			this.roomInfoGroupBox.Text = "Room Info";
			this.regionNameTextBox.Location = new Point(175, 24);
			this.regionNameTextBox.MaxLength = 40;
			this.regionNameTextBox.Name = "regionNameTextBox";
			this.regionNameTextBox.ReadOnly = true;
			this.regionNameTextBox.Size = new Size(200, 21);
			this.regionNameTextBox.TabIndex = 3;
			this.regionNameTextBox.TabStop = false;
			this.regionIdTextBox.Location = new Point(135, 24);
			this.regionIdTextBox.MaxLength = 40;
			this.regionIdTextBox.Name = "regionIdTextBox";
			this.regionIdTextBox.ReadOnly = true;
			this.regionIdTextBox.Size = new Size(36, 21);
			this.regionIdTextBox.TabIndex = 2;
			this.regionIdTextBox.TabStop = false;
			this.regionIdTextBox.Text = "0";
			this.regionIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.regionLabel.AutoSize = true;
			this.regionLabel.Location = new Point(24, 28);
			this.regionLabel.Name = "regionLabel";
			this.regionLabel.Size = new Size(44, 13);
			this.regionLabel.TabIndex = 1;
			this.regionLabel.Text = "Region:";
			this.noteTextBox.Location = new Point(135, 78);
			this.noteTextBox.MaxLength = 50;
			this.noteTextBox.Name = "noteTextBox";
			this.noteTextBox.Size = new Size(240, 21);
			this.noteTextBox.TabIndex = 8;
			this.noteTextBox.Validated += new EventHandler(this.noteTextBox_Validated);
			base.AcceptButton = this.okButton;
			base.ClientSize = new Size(424, 180);
			base.Controls.Add(this.roomInfoGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form5";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F5 - New Room ";
			base.Load += new EventHandler(this.Form5_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form5_FormClosing);
			this.roomInfoGroupBox.ResumeLayout(false);
			this.roomInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
