using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form12 : Form
	{
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private TextBox departmentIdTextBox;
		private Label noteLabel;
		private GroupBox departmentInfoGroupBox;
		private TextBox noteTextBox;
		private Label departmentLabel;
		private TextBox departmentNameTextBox;
		public bool bModify = false;
		private int the_iDepartmentID;
		private string the_strDepartmentName;
		private string the_strNote;
		public int The_iDepartmentID
		{
			get
			{
				return this.the_iDepartmentID;
			}
			set
			{
				this.the_iDepartmentID = value;
			}
		}
		public string The_strDepartmentName
		{
			get
			{
				return this.the_strDepartmentName;
			}
			set
			{
				this.the_strDepartmentName = value;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form12));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.departmentIdTextBox = new TextBox();
			this.noteLabel = new Label();
			this.departmentInfoGroupBox = new GroupBox();
			this.departmentNameTextBox = new TextBox();
			this.departmentLabel = new Label();
			this.noteTextBox = new TextBox();
			this.departmentInfoGroupBox.SuspendLayout();
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
			this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
			this.departmentIdTextBox.Location = new Point(135, 24);
			this.departmentIdTextBox.MaxLength = 2;
			this.departmentIdTextBox.Name = "departmentIdTextBox";
			this.departmentIdTextBox.Size = new Size(36, 21);
			this.departmentIdTextBox.TabIndex = 2;
			this.departmentIdTextBox.Text = "0";
			this.departmentIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.departmentIdTextBox.KeyPress += new KeyPressEventHandler(this.NumberChecked_KeyPress);
			this.noteLabel.AutoSize = true;
			this.noteLabel.Location = new Point(24, 54);
			this.noteLabel.Name = "noteLabel";
			this.noteLabel.Size = new Size(34, 13);
			this.noteLabel.TabIndex = 4;
			this.noteLabel.Text = "Note:";
			this.departmentInfoGroupBox.Controls.Add(this.departmentNameTextBox);
			this.departmentInfoGroupBox.Controls.Add(this.departmentLabel);
			this.departmentInfoGroupBox.Controls.Add(this.noteTextBox);
			this.departmentInfoGroupBox.Controls.Add(this.departmentIdTextBox);
			this.departmentInfoGroupBox.Controls.Add(this.noteLabel);
			this.departmentInfoGroupBox.Location = new Point(12, 12);
			this.departmentInfoGroupBox.Name = "departmentInfoGroupBox";
			this.departmentInfoGroupBox.Size = new Size(400, 89);
			this.departmentInfoGroupBox.TabIndex = 0;
			this.departmentInfoGroupBox.TabStop = false;
			this.departmentInfoGroupBox.Text = "Department Info";
			this.departmentNameTextBox.Location = new Point(175, 24);
			this.departmentNameTextBox.Name = "departmentNameTextBox";
			this.departmentNameTextBox.Size = new Size(200, 21);
			this.departmentNameTextBox.TabIndex = 3;
			this.departmentNameTextBox.Validated += new EventHandler(this.departmentNameTextBox_Validated);
			this.departmentLabel.AutoSize = true;
			this.departmentLabel.Location = new Point(24, 28);
			this.departmentLabel.Name = "departmentLabel";
			this.departmentLabel.Size = new Size(68, 13);
			this.departmentLabel.TabIndex = 1;
			this.departmentLabel.Text = "Department:";
			this.noteTextBox.Location = new Point(135, 51);
			this.noteTextBox.MaxLength = 50;
			this.noteTextBox.Name = "noteTextBox";
			this.noteTextBox.Size = new Size(240, 21);
			this.noteTextBox.TabIndex = 5;
			this.noteTextBox.Validated += new EventHandler(this.noteTextBox_Validated);
			base.AcceptButton = this.okButton;
			base.ClientSize = new Size(424, 152);
			base.Controls.Add(this.departmentInfoGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form12";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F12 - New Department";
			base.Load += new EventHandler(this.Form12_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form12_FormClosing);
			this.departmentInfoGroupBox.ResumeLayout(false);
			this.departmentInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
		public Form12()
		{
			this.InitializeComponent();
		}
		private void Form12_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.departmentIdTextBox.ReadOnly = this.bModify;
			this.departmentIdTextBox.TabStop = !this.bModify;
			this.departmentIdTextBox.Text = this.the_iDepartmentID.ToString();
			this.departmentNameTextBox.Text = this.the_strDepartmentName;
			this.noteTextBox.Text = this.the_strNote;
		}
		private void LoadCaptionForControls()
		{
			this.Text = (this.bModify ? ("F12 - " + Properties.Resources.ModifyDepartment) : ("F12 - " + Properties.Resources.NewDepartment));
			this.departmentInfoGroupBox.Text = Properties.Resources.DepartmentInfo;
			this.departmentLabel.Text = Properties.Resources.Department + ":";
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
				string text = this.departmentIdTextBox.Text.Trim();
				if (text == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.DepartmentID + " " + Properties.Resources.IsNotEmpty + "!");
					this.departmentIdTextBox.Focus();
					return;
				}
				if (!StringEx.IsStrNumber(text))
				{
					MyMsgBox.MsgError(Properties.Resources.DepartmentID + " " + Properties.Resources.IsNumber + "!");
					this.departmentIdTextBox.Focus();
					return;
				}
				int num = int.Parse(text);
				if (num < 1)
				{
					MyMsgBox.MsgError(Properties.Resources.DepartmentID + " > 0 !");
					this.departmentIdTextBox.Focus();
					return;
				}
			}
			if (this.departmentNameTextBox.Text.Trim() == string.Empty)
			{
				MyMsgBox.MsgError(Properties.Resources.DepartmentName + " " + Properties.Resources.IsNotEmpty + "!");
				this.departmentNameTextBox.Focus();
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void Form12_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.the_iDepartmentID = int.Parse(this.departmentIdTextBox.Text);
				this.the_strDepartmentName = this.departmentNameTextBox.Text;
				this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
			}
		}
		private void departmentNameTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void noteTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void cancelButton_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
