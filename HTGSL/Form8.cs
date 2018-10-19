//using HTGSL.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form8 : Form
	{
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private Label idLabel;
		private TextBox hospitalNameTextBox;
		private TextBox hospitalIdTextBox;
		private Label noteLabel;
		private GroupBox hospitalInfoGroupBox;
		private TextBox noteTextBox;
		private Label faxLabel;
		private Label phoneLabel;
		private Label emailLabel;
		private Label websiteLabel;
		private TextBox emailTextBox;
		private TextBox websiteTextBox;
		private Label addressLabel;
		private TextBox addressTextBox;
		private TextBox faxTextBox;
		private TextBox phoneTextBox;
		private Label nameLabel;
		public bool bModify = false;
		private int the_iHospitalID;
		private string the_strHospitalName;
		private string the_strAddress;
		private string the_strWebsite;
		private string the_strEmail;
		private string the_strPhone;
		private string the_strFax;
		private string the_strNote;
		public int The_iHospitalID
		{
			get
			{
				return this.the_iHospitalID;
			}
			set
			{
				this.the_iHospitalID = value;
			}
		}
		public string The_strHospitalName
		{
			get
			{
				return this.the_strHospitalName;
			}
			set
			{
				this.the_strHospitalName = value;
			}
		}
		public string The_strAddress
		{
			get
			{
				return this.the_strAddress;
			}
			set
			{
				this.the_strAddress = value;
			}
		}
		public string The_strWebsite
		{
			get
			{
				return this.the_strWebsite;
			}
			set
			{
				this.the_strWebsite = value;
			}
		}
		public string The_strEmail
		{
			get
			{
				return this.the_strEmail;
			}
			set
			{
				this.the_strEmail = value;
			}
		}
		public string The_strPhone
		{
			get
			{
				return this.the_strPhone;
			}
			set
			{
				this.the_strPhone = value;
			}
		}
		public string The_strFax
		{
			get
			{
				return this.the_strFax;
			}
			set
			{
				this.the_strFax = value;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form8));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.idLabel = new Label();
			this.hospitalNameTextBox = new TextBox();
			this.hospitalIdTextBox = new TextBox();
			this.noteLabel = new Label();
			this.hospitalInfoGroupBox = new GroupBox();
			this.nameLabel = new Label();
			this.faxTextBox = new TextBox();
			this.phoneTextBox = new TextBox();
			this.faxLabel = new Label();
			this.phoneLabel = new Label();
			this.emailLabel = new Label();
			this.websiteLabel = new Label();
			this.emailTextBox = new TextBox();
			this.websiteTextBox = new TextBox();
			this.addressLabel = new Label();
			this.addressTextBox = new TextBox();
			this.noteTextBox = new TextBox();
			this.hospitalInfoGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.okButton.Location = new Point(192, 278);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(95, 25);
			this.okButton.TabIndex = 17;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(292, 278);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(95, 25);
			this.cancelButton.TabIndex = 18;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.idLabel.AutoSize = true;
			this.idLabel.Location = new Point(24, 28);
			this.idLabel.Name = "idLabel";
			this.idLabel.Size = new Size(22, 13);
			this.idLabel.TabIndex = 1;
			this.idLabel.Text = "ID:";
			this.hospitalNameTextBox.Location = new Point(135, 51);
			this.hospitalNameTextBox.MaxLength = 50;
			this.hospitalNameTextBox.Name = "hospitalNameTextBox";
			this.hospitalNameTextBox.Size = new Size(240, 21);
			this.hospitalNameTextBox.TabIndex = 4;
			this.hospitalNameTextBox.Validated += new EventHandler(this.TextBox_Validated);
			this.hospitalIdTextBox.Location = new Point(135, 24);
			this.hospitalIdTextBox.MaxLength = 2;
			this.hospitalIdTextBox.Name = "hospitalIdTextBox";
			this.hospitalIdTextBox.Size = new Size(48, 21);
			this.hospitalIdTextBox.TabIndex = 2;
			this.hospitalIdTextBox.Text = "0";
			this.hospitalIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.hospitalIdTextBox.KeyPress += new KeyPressEventHandler(this.NumberChecked_KeyPress);
			this.noteLabel.AutoSize = true;
			this.noteLabel.Location = new Point(24, 217);
			this.noteLabel.Name = "noteLabel";
			this.noteLabel.Size = new Size(34, 13);
			this.noteLabel.TabIndex = 15;
			this.noteLabel.Text = "Note:";
			this.hospitalInfoGroupBox.Controls.Add(this.nameLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.faxTextBox);
			this.hospitalInfoGroupBox.Controls.Add(this.phoneTextBox);
			this.hospitalInfoGroupBox.Controls.Add(this.faxLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.phoneLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.emailLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.websiteLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.emailTextBox);
			this.hospitalInfoGroupBox.Controls.Add(this.websiteTextBox);
			this.hospitalInfoGroupBox.Controls.Add(this.addressLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.addressTextBox);
			this.hospitalInfoGroupBox.Controls.Add(this.noteTextBox);
			this.hospitalInfoGroupBox.Controls.Add(this.idLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.hospitalIdTextBox);
			this.hospitalInfoGroupBox.Controls.Add(this.noteLabel);
			this.hospitalInfoGroupBox.Controls.Add(this.hospitalNameTextBox);
			this.hospitalInfoGroupBox.Location = new Point(12, 12);
			this.hospitalInfoGroupBox.Name = "hospitalInfoGroupBox";
			this.hospitalInfoGroupBox.Size = new Size(400, 253);
			this.hospitalInfoGroupBox.TabIndex = 0;
			this.hospitalInfoGroupBox.TabStop = false;
			this.hospitalInfoGroupBox.Text = "Hospital Info";
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new Point(24, 55);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new Size(38, 13);
			this.nameLabel.TabIndex = 3;
			this.nameLabel.Text = "Name:";
			this.faxTextBox.Location = new Point(135, 186);
			this.faxTextBox.MaxLength = 20;
			this.faxTextBox.Name = "faxTextBox";
			this.faxTextBox.Size = new Size(158, 21);
			this.faxTextBox.TabIndex = 14;
			this.faxTextBox.Validated += new EventHandler(this.TextBox_Validated);
			this.phoneTextBox.Location = new Point(135, 159);
			this.phoneTextBox.MaxLength = 20;
			this.phoneTextBox.Name = "phoneTextBox";
			this.phoneTextBox.Size = new Size(158, 21);
			this.phoneTextBox.TabIndex = 12;
			this.phoneTextBox.Validated += new EventHandler(this.TextBox_Validated);
			this.faxLabel.AutoSize = true;
			this.faxLabel.Location = new Point(24, 190);
			this.faxLabel.Name = "faxLabel";
			this.faxLabel.Size = new Size(29, 13);
			this.faxLabel.TabIndex = 13;
			this.faxLabel.Text = "Fax:";
			this.phoneLabel.AutoSize = true;
			this.phoneLabel.Location = new Point(24, 163);
			this.phoneLabel.Name = "phoneLabel";
			this.phoneLabel.Size = new Size(41, 13);
			this.phoneLabel.TabIndex = 11;
			this.phoneLabel.Text = "Phone:";
			this.emailLabel.AutoSize = true;
			this.emailLabel.Location = new Point(24, 136);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new Size(35, 13);
			this.emailLabel.TabIndex = 9;
			this.emailLabel.Text = "Email:";
			this.websiteLabel.AutoSize = true;
			this.websiteLabel.Location = new Point(24, 109);
			this.websiteLabel.Name = "websiteLabel";
			this.websiteLabel.Size = new Size(50, 13);
			this.websiteLabel.TabIndex = 7;
			this.websiteLabel.Text = "Website:";
			this.emailTextBox.Location = new Point(135, 132);
			this.emailTextBox.MaxLength = 50;
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.Size = new Size(240, 21);
			this.emailTextBox.TabIndex = 10;
			this.emailTextBox.Validated += new EventHandler(this.TextBox_Validated);
			this.websiteTextBox.Location = new Point(135, 105);
			this.websiteTextBox.MaxLength = 50;
			this.websiteTextBox.Name = "websiteTextBox";
			this.websiteTextBox.Size = new Size(240, 21);
			this.websiteTextBox.TabIndex = 8;
			this.websiteTextBox.Validated += new EventHandler(this.TextBox_Validated);
			this.addressLabel.AutoSize = true;
			this.addressLabel.Location = new Point(24, 82);
			this.addressLabel.Name = "addressLabel";
			this.addressLabel.Size = new Size(50, 13);
			this.addressLabel.TabIndex = 5;
			this.addressLabel.Text = "Address:";
			this.addressTextBox.Location = new Point(135, 78);
			this.addressTextBox.MaxLength = 50;
			this.addressTextBox.Name = "addressTextBox";
			this.addressTextBox.Size = new Size(240, 21);
			this.addressTextBox.TabIndex = 6;
			this.addressTextBox.Validated += new EventHandler(this.TextBox_Validated);
			this.noteTextBox.Location = new Point(135, 213);
			this.noteTextBox.MaxLength = 50;
			this.noteTextBox.Name = "noteTextBox";
			this.noteTextBox.Size = new Size(240, 21);
			this.noteTextBox.TabIndex = 16;
			this.noteTextBox.Validated += new EventHandler(this.TextBox_Validated);
			base.AcceptButton = this.okButton;
			base.ClientSize = new Size(424, 317);
			base.Controls.Add(this.hospitalInfoGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form8";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F8 - Hospital Properties";
			base.Load += new EventHandler(this.Form8_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form8_FormClosing);
			this.hospitalInfoGroupBox.ResumeLayout(false);
			this.hospitalInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
		public Form8()
		{
			this.InitializeComponent();
		}
		private void Form8_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.hospitalIdTextBox.ReadOnly = true;
			this.hospitalIdTextBox.TabStop = false;
			this.hospitalIdTextBox.Text = this.the_iHospitalID.ToString();
			this.hospitalNameTextBox.Text = this.the_strHospitalName;
			this.addressTextBox.Text = this.the_strAddress;
			this.websiteTextBox.Text = this.the_strWebsite;
			this.emailTextBox.Text = this.the_strEmail;
			this.phoneTextBox.Text = this.the_strPhone;
			this.faxTextBox.Text = this.the_strFax;
			this.noteTextBox.Text = this.the_strNote;
		}
		private void LoadCaptionForControls()
		{
			this.Text = Properties.Resources.HospitalProperties;
			this.hospitalInfoGroupBox.Text = Properties.Resources.HospitalInfo;
			this.idLabel.Text = Properties.Resources.ID + ":";
			this.nameLabel.Text = Properties.Resources.Name + ":";
			this.addressLabel.Text = Properties.Resources.Address + ":";
			this.websiteLabel.Text = Properties.Resources.Website + ":";
			this.emailLabel.Text = Properties.Resources.Email + ":";
			this.phoneLabel.Text = Properties.Resources.Phone + ":";
			this.faxLabel.Text = Properties.Resources.Fax + ":";
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
				string text = this.hospitalIdTextBox.Text.Trim();
				if (text == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.HospitalID + " " + Properties.Resources.IsNotEmpty + "!");
					this.hospitalIdTextBox.Focus();
					return;
				}
				if (!StringEx.IsStrNumber(text))
				{
					MyMsgBox.MsgError(Properties.Resources.HospitalID + " " + Properties.Resources.IsNumber + "!");
					this.hospitalIdTextBox.Focus();
					return;
				}
				int num = int.Parse(text);
				if (num < 1)
				{
					MyMsgBox.MsgError(Properties.Resources.HospitalID + " > 0 !");
					this.hospitalIdTextBox.Focus();
					return;
				}
			}
			if (this.hospitalNameTextBox.Text.Trim() == string.Empty)
			{
				MyMsgBox.MsgError(Properties.Resources.HospitalName + " " + Properties.Resources.IsNotEmpty + "!");
				this.hospitalNameTextBox.Focus();
			}
			else
			{
				if (this.addressTextBox.Text.Trim() == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.Address + " " + Properties.Resources.IsNotEmpty + "!");
					this.addressTextBox.Focus();
				}
				else
				{
					base.DialogResult = DialogResult.OK;
				}
			}
		}
		private void Form8_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.the_iHospitalID = int.Parse(this.hospitalIdTextBox.Text);
				this.the_strHospitalName = StringEx.CutBlanks(this.hospitalNameTextBox.Text);
				this.the_strAddress = StringEx.CutBlanks(this.addressTextBox.Text);
				this.the_strWebsite = StringEx.CutBlanks(this.websiteTextBox.Text);
				this.the_strEmail = StringEx.CutBlanks(this.emailTextBox.Text);
				this.the_strPhone = StringEx.CutBlanks(this.phoneTextBox.Text);
				this.the_strFax = StringEx.CutBlanks(this.faxTextBox.Text);
				this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
			}
		}
		private void TextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
	}
}
