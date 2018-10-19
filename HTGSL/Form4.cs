using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form4 : Form
	{
		public bool bModify = false;
		private int the_iRegionID;
		private string the_strRegionName;
		private string the_strNote;
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private Label regionLabel;
		private TextBox regionNameTextBox;
		private TextBox regionIdTextBox;
		private Label noteLabel;
		private GroupBox regionInfoGroupBox;
		private TextBox noteTextBox;
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
		public Form4()
		{
			this.InitializeComponent();
		}
		private void Form4_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.regionIdTextBox.ReadOnly = this.bModify;
			this.regionIdTextBox.TabStop = !this.bModify;
			this.regionIdTextBox.Text = this.the_iRegionID.ToString();
			this.regionNameTextBox.Text = this.the_strRegionName;
			this.noteTextBox.Text = this.the_strNote;
		}
		private void LoadCaptionForControls()
		{
			this.Text = (this.bModify ? ("F4 - " + Properties.Resources.ModifyRegion) : ("F4 - " + Properties.Resources.NewRegion));
			this.regionInfoGroupBox.Text = Properties.Resources.RegionInfo;
			this.regionLabel.Text = Properties.Resources.Region + ":";
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
				string text = this.regionIdTextBox.Text.Trim();
				if (text == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.RegionID + " " + Properties.Resources.IsNotEmpty + "!");
					this.regionIdTextBox.Focus();
					return;
				}
				if (!StringEx.IsStrNumber(text))
				{
					MyMsgBox.MsgError(Properties.Resources.RegionID + " " + Properties.Resources.IsNumber + "!");
					this.regionIdTextBox.Focus();
					return;
				}
				int num = int.Parse(text);
				if (num < 1)
				{
					MyMsgBox.MsgError(Properties.Resources.RegionID + " > 0 !");
					this.regionIdTextBox.Focus();
					return;
				}
			}
			if (this.regionNameTextBox.Text.Trim() == string.Empty)
			{
				MyMsgBox.MsgError(Properties.Resources.RegionName + " " + Properties.Resources.IsNotEmpty + "!");
				this.regionNameTextBox.Focus();
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void Form4_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.the_iRegionID = int.Parse(this.regionIdTextBox.Text);
				this.the_strRegionName = StringEx.CutBlanks(this.regionNameTextBox.Text);
				this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
			}
		}
		private void regionNameTextBox_Validated(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form4));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.regionLabel = new Label();
			this.regionNameTextBox = new TextBox();
			this.regionIdTextBox = new TextBox();
			this.noteLabel = new Label();
			this.regionInfoGroupBox = new GroupBox();
			this.noteTextBox = new TextBox();
			this.regionInfoGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.okButton.Location = new Point(192, 116);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(95, 25);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(292, 116);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(95, 25);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.regionLabel.AutoSize = true;
			this.regionLabel.Location = new Point(24, 28);
			this.regionLabel.Name = "regionLabel";
			this.regionLabel.Size = new Size(44, 13);
			this.regionLabel.TabIndex = 1;
			this.regionLabel.Text = "Region:";
			this.regionNameTextBox.Location = new Point(175, 24);
			this.regionNameTextBox.MaxLength = 40;
			this.regionNameTextBox.Name = "regionNameTextBox";
			this.regionNameTextBox.Size = new Size(200, 21);
			this.regionNameTextBox.TabIndex = 3;
			this.regionNameTextBox.Validated += new EventHandler(this.regionNameTextBox_Validated);
			this.regionIdTextBox.Location = new Point(135, 24);
			this.regionIdTextBox.MaxLength = 2;
			this.regionIdTextBox.Name = "regionIdTextBox";
			this.regionIdTextBox.Size = new Size(36, 21);
			this.regionIdTextBox.TabIndex = 2;
			this.regionIdTextBox.Text = "0";
			this.regionIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.regionIdTextBox.KeyPress += new KeyPressEventHandler(this.NumberChecked_KeyPress);
			this.noteLabel.AutoSize = true;
			this.noteLabel.Location = new Point(24, 55);
			this.noteLabel.Name = "noteLabel";
			this.noteLabel.Size = new Size(34, 13);
			this.noteLabel.TabIndex = 4;
			this.noteLabel.Text = "Note:";
			this.regionInfoGroupBox.Controls.Add(this.noteTextBox);
			this.regionInfoGroupBox.Controls.Add(this.regionLabel);
			this.regionInfoGroupBox.Controls.Add(this.regionIdTextBox);
			this.regionInfoGroupBox.Controls.Add(this.noteLabel);
			this.regionInfoGroupBox.Controls.Add(this.regionNameTextBox);
			this.regionInfoGroupBox.Location = new Point(12, 12);
			this.regionInfoGroupBox.Name = "regionInfoGroupBox";
			this.regionInfoGroupBox.Size = new Size(400, 90);
			this.regionInfoGroupBox.TabIndex = 0;
			this.regionInfoGroupBox.TabStop = false;
			this.regionInfoGroupBox.Text = "Region Info";
			this.noteTextBox.Location = new Point(135, 51);
			this.noteTextBox.MaxLength = 50;
			this.noteTextBox.Name = "noteTextBox";
			this.noteTextBox.Size = new Size(240, 21);
			this.noteTextBox.TabIndex = 5;
			this.noteTextBox.Validated += new EventHandler(this.noteTextBox_Validated);
			base.AcceptButton = this.okButton;
			base.ClientSize = new Size(424, 154);
			base.Controls.Add(this.regionInfoGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form4";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F4 - New Region ";
			base.Load += new EventHandler(this.Form4_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
			this.regionInfoGroupBox.ResumeLayout(false);
			this.regionInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
