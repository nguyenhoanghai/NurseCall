using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form14 : Form
	{
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private TextBox jobIdTextBox;
		private Label noteLabel;
		private GroupBox jobInfoGroupBox;
		private TextBox noteTextBox;
		private Label jobLabel;
		private TextBox jobNameTextBox;
		public bool bModify = false;
		private int the_iJobID;
		private string the_strJobName;
		private string the_strNote;
		public int The_iJobID
		{
			get
			{
				return this.the_iJobID;
			}
			set
			{
				this.the_iJobID = value;
			}
		}
		public string The_strJobName
		{
			get
			{
				return this.the_strJobName;
			}
			set
			{
				this.the_strJobName = value;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form14));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.jobIdTextBox = new TextBox();
			this.noteLabel = new Label();
			this.jobInfoGroupBox = new GroupBox();
			this.jobNameTextBox = new TextBox();
			this.jobLabel = new Label();
			this.noteTextBox = new TextBox();
			this.jobInfoGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.okButton.Location = new Point(191, 114);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(95, 25);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(292, 114);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(95, 25);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.jobIdTextBox.Location = new Point(135, 24);
			this.jobIdTextBox.MaxLength = 2;
			this.jobIdTextBox.Name = "jobIdTextBox";
			this.jobIdTextBox.Size = new Size(36, 21);
			this.jobIdTextBox.TabIndex = 2;
			this.jobIdTextBox.Text = "0";
			this.jobIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.jobIdTextBox.KeyPress += new KeyPressEventHandler(this.NumberChecked_KeyPress);
			this.noteLabel.AutoSize = true;
			this.noteLabel.Location = new Point(24, 54);
			this.noteLabel.Name = "noteLabel";
			this.noteLabel.Size = new Size(34, 13);
			this.noteLabel.TabIndex = 4;
			this.noteLabel.Text = "Note:";
			this.jobInfoGroupBox.Controls.Add(this.jobNameTextBox);
			this.jobInfoGroupBox.Controls.Add(this.jobLabel);
			this.jobInfoGroupBox.Controls.Add(this.noteTextBox);
			this.jobInfoGroupBox.Controls.Add(this.jobIdTextBox);
			this.jobInfoGroupBox.Controls.Add(this.noteLabel);
			this.jobInfoGroupBox.Location = new Point(12, 12);
			this.jobInfoGroupBox.Name = "jobInfoGroupBox";
			this.jobInfoGroupBox.Size = new Size(400, 89);
			this.jobInfoGroupBox.TabIndex = 0;
			this.jobInfoGroupBox.TabStop = false;
			this.jobInfoGroupBox.Text = "Job Info";
			this.jobNameTextBox.Location = new Point(175, 24);
			this.jobNameTextBox.Name = "jobNameTextBox";
			this.jobNameTextBox.Size = new Size(200, 21);
			this.jobNameTextBox.TabIndex = 3;
			this.jobNameTextBox.Validated += new EventHandler(this.jobNameTextBox_Validated);
			this.jobLabel.AutoSize = true;
			this.jobLabel.Location = new Point(24, 28);
			this.jobLabel.Name = "jobLabel";
			this.jobLabel.Size = new Size(28, 13);
			this.jobLabel.TabIndex = 1;
			this.jobLabel.Text = "Job:";
			this.noteTextBox.Location = new Point(135, 51);
			this.noteTextBox.MaxLength = 50;
			this.noteTextBox.Name = "noteTextBox";
			this.noteTextBox.Size = new Size(240, 21);
			this.noteTextBox.TabIndex = 5;
			this.noteTextBox.Validated += new EventHandler(this.noteTextBox_Validated);
			base.AcceptButton = this.okButton;
			base.ClientSize = new Size(424, 152);
			base.Controls.Add(this.jobInfoGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form14";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F14 - New Job";
			base.Load += new EventHandler(this.Form14_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form14_FormClosing);
			this.jobInfoGroupBox.ResumeLayout(false);
			this.jobInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
		public Form14()
		{
			this.InitializeComponent();
		}
		private void Form14_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.jobIdTextBox.ReadOnly = this.bModify;
			this.jobIdTextBox.TabStop = !this.bModify;
			this.jobIdTextBox.Text = this.the_iJobID.ToString();
			this.jobNameTextBox.Text = this.the_strJobName;
			this.noteTextBox.Text = this.the_strNote;
		}
		private void LoadCaptionForControls()
		{
			this.Text = (this.bModify ? ("F14 - " + Properties.Resources.ModifyJob) : ("F14 - " + Properties.Resources.NewJob));
			this.jobInfoGroupBox.Text = Properties.Resources.JobInfo;
			this.jobLabel.Text = Properties.Resources.Job + ":";
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
				string text = this.jobIdTextBox.Text.Trim();
				if (text == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.JobID + " " + Properties.Resources.IsNotEmpty + "!");
					this.jobIdTextBox.Focus();
					return;
				}
				if (!StringEx.IsStrNumber(text))
				{
					MyMsgBox.MsgError(Properties.Resources.JobID + " " + Properties.Resources.IsNumber + "!");
					this.jobIdTextBox.Focus();
					return;
				}
				int num = int.Parse(text);
				if (num < 1)
				{
					MyMsgBox.MsgError(Properties.Resources.JobID + " > 0 !");
					this.jobIdTextBox.Focus();
					return;
				}
			}
			if (this.jobNameTextBox.Text.Trim() == string.Empty)
			{
				MyMsgBox.MsgError(Properties.Resources.JobName + " " + Properties.Resources.IsNotEmpty + "!");
				this.jobNameTextBox.Focus();
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void Form14_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.the_iJobID = int.Parse(this.jobIdTextBox.Text);
				this.the_strJobName = this.jobNameTextBox.Text;
				this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
			}
		}
		private void jobNameTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void noteTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
	}
}
