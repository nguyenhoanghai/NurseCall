using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form7 : Form
	{
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private Label locationLabel;
		private TextBox locationNameTextBox;
		private TextBox locationIdTextBox;
		private Label noteLabel;
		private GroupBox locationInfoGroupBox;
		private TextBox noteTextBox;
		private TextBox regionIdTextBox;
		private Label regionLabel;
		private TextBox regionNameTextBox;
		private ComboBox typeNameComboBox;
		private TextBox typeIdTextBox;
		private Label typeLabel;
		private TextBox typeNameTextBox;
		private Label installLabel;
		private RadioButton noRadioButton;
		private RadioButton yesRadioButton;
		public bool bModify = false;
		public string[] The_TypeNames;
		public int[] The_TypeIDs;
		private int the_iRegionID;
		private string the_strRegionName;
		private int the_iLocationID;
		private string the_strLocationName;
		private int the_iTypeID;
		private string the_strTypeName;
		private string the_strNote;
		private bool the_bInstall;
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
		public int The_iLocationID
		{
			get
			{
				return this.the_iLocationID;
			}
			set
			{
				this.the_iLocationID = value;
			}
		}
		public string The_strLocationName
		{
			get
			{
				return this.the_strLocationName;
			}
			set
			{
				this.the_strLocationName = value;
			}
		}
		public int The_iTypeID
		{
			get
			{
				return this.the_iTypeID;
			}
			set
			{
				this.the_iTypeID = value;
			}
		}
		public string The_strTypeName
		{
			get
			{
				return this.the_strTypeName;
			}
			set
			{
				this.the_strTypeName = value;
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
		public bool The_bInstall
		{
			get
			{
				return this.the_bInstall;
			}
			set
			{
				this.the_bInstall = value;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form7));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.locationLabel = new Label();
			this.locationNameTextBox = new TextBox();
			this.locationIdTextBox = new TextBox();
			this.noteLabel = new Label();
			this.locationInfoGroupBox = new GroupBox();
			this.yesRadioButton = new RadioButton();
			this.noRadioButton = new RadioButton();
			this.installLabel = new Label();
			this.typeNameComboBox = new ComboBox();
			this.typeIdTextBox = new TextBox();
			this.typeLabel = new Label();
			this.regionNameTextBox = new TextBox();
			this.regionIdTextBox = new TextBox();
			this.regionLabel = new Label();
			this.noteTextBox = new TextBox();
			this.typeNameTextBox = new TextBox();
			this.locationInfoGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.okButton.Location = new Point(191, 194);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(95, 25);
			this.okButton.TabIndex = 16;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(292, 194);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(95, 25);
			this.cancelButton.TabIndex = 17;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.locationLabel.AutoSize = true;
			this.locationLabel.Location = new Point(24, 82);
			this.locationLabel.Name = "locationLabel";
			this.locationLabel.Size = new Size(51, 13);
			this.locationLabel.TabIndex = 8;
			this.locationLabel.Text = "Location:";
			this.locationNameTextBox.Location = new Point(175, 78);
			this.locationNameTextBox.MaxLength = 40;
			this.locationNameTextBox.Name = "locationNameTextBox";
			this.locationNameTextBox.Size = new Size(200, 21);
			this.locationNameTextBox.TabIndex = 10;
			this.locationNameTextBox.Validated += new EventHandler(this.locationNameTextBox_Validated);
			this.locationIdTextBox.Location = new Point(135, 78);
			this.locationIdTextBox.MaxLength = 2;
			this.locationIdTextBox.Name = "locationIdTextBox";
			this.locationIdTextBox.Size = new Size(36, 21);
			this.locationIdTextBox.TabIndex = 9;
			this.locationIdTextBox.Text = "0";
			this.locationIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.locationIdTextBox.KeyPress += new KeyPressEventHandler(this.NumberChecked_KeyPress);
			this.noteLabel.AutoSize = true;
			this.noteLabel.Location = new Point(24, 109);
			this.noteLabel.Name = "noteLabel";
			this.noteLabel.Size = new Size(34, 13);
			this.noteLabel.TabIndex = 11;
			this.noteLabel.Text = "Note:";
			this.locationInfoGroupBox.Controls.Add(this.yesRadioButton);
			this.locationInfoGroupBox.Controls.Add(this.noRadioButton);
			this.locationInfoGroupBox.Controls.Add(this.installLabel);
			this.locationInfoGroupBox.Controls.Add(this.typeNameComboBox);
			this.locationInfoGroupBox.Controls.Add(this.typeIdTextBox);
			this.locationInfoGroupBox.Controls.Add(this.typeLabel);
			this.locationInfoGroupBox.Controls.Add(this.regionNameTextBox);
			this.locationInfoGroupBox.Controls.Add(this.regionIdTextBox);
			this.locationInfoGroupBox.Controls.Add(this.regionLabel);
			this.locationInfoGroupBox.Controls.Add(this.noteTextBox);
			this.locationInfoGroupBox.Controls.Add(this.locationLabel);
			this.locationInfoGroupBox.Controls.Add(this.locationIdTextBox);
			this.locationInfoGroupBox.Controls.Add(this.noteLabel);
			this.locationInfoGroupBox.Controls.Add(this.locationNameTextBox);
			this.locationInfoGroupBox.Controls.Add(this.typeNameTextBox);
			this.locationInfoGroupBox.Location = new Point(12, 12);
			this.locationInfoGroupBox.Name = "locationInfoGroupBox";
			this.locationInfoGroupBox.Size = new Size(400, 167);
			this.locationInfoGroupBox.TabIndex = 0;
			this.locationInfoGroupBox.TabStop = false;
			this.locationInfoGroupBox.Text = "Location Info";
			this.yesRadioButton.AutoSize = true;
			this.yesRadioButton.Location = new Point(245, 134);
			this.yesRadioButton.Name = "yesRadioButton";
			this.yesRadioButton.Size = new Size(42, 17);
			this.yesRadioButton.TabIndex = 15;
			this.yesRadioButton.Text = "Yes";
			this.yesRadioButton.UseVisualStyleBackColor = true;
			this.noRadioButton.AutoSize = true;
			this.noRadioButton.Checked = true;
			this.noRadioButton.Location = new Point(135, 134);
			this.noRadioButton.Name = "noRadioButton";
			this.noRadioButton.Size = new Size(38, 17);
			this.noRadioButton.TabIndex = 14;
			this.noRadioButton.TabStop = true;
			this.noRadioButton.Text = "No";
			this.noRadioButton.UseVisualStyleBackColor = true;
			this.installLabel.AutoSize = true;
			this.installLabel.Location = new Point(24, 136);
			this.installLabel.Name = "installLabel";
			this.installLabel.Size = new Size(40, 13);
			this.installLabel.TabIndex = 13;
			this.installLabel.Text = "Install:";
			this.typeNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.typeNameComboBox.FormattingEnabled = true;
			this.typeNameComboBox.Location = new Point(175, 51);
			this.typeNameComboBox.Name = "typeNameComboBox";
			this.typeNameComboBox.Size = new Size(200, 21);
			this.typeNameComboBox.TabIndex = 6;
			this.typeNameComboBox.SelectedIndexChanged += new EventHandler(this.typeNameComboBox_SelectedIndexChanged);
			this.typeIdTextBox.Location = new Point(135, 51);
			this.typeIdTextBox.MaxLength = 40;
			this.typeIdTextBox.Name = "typeIdTextBox";
			this.typeIdTextBox.ReadOnly = true;
			this.typeIdTextBox.Size = new Size(36, 21);
			this.typeIdTextBox.TabIndex = 5;
			this.typeIdTextBox.TabStop = false;
			this.typeIdTextBox.Text = "0";
			this.typeIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.typeLabel.AutoSize = true;
			this.typeLabel.Location = new Point(24, 55);
			this.typeLabel.Name = "typeLabel";
			this.typeLabel.Size = new Size(35, 13);
			this.typeLabel.TabIndex = 4;
			this.typeLabel.Text = "Type:";
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
			this.noteTextBox.Location = new Point(135, 105);
			this.noteTextBox.MaxLength = 50;
			this.noteTextBox.Name = "noteTextBox";
			this.noteTextBox.Size = new Size(240, 21);
			this.noteTextBox.TabIndex = 12;
			this.noteTextBox.Validated += new EventHandler(this.noteTextBox_Validated);
			this.typeNameTextBox.Location = new Point(175, 51);
			this.typeNameTextBox.MaxLength = 40;
			this.typeNameTextBox.Name = "typeNameTextBox";
			this.typeNameTextBox.ReadOnly = true;
			this.typeNameTextBox.Size = new Size(200, 21);
			this.typeNameTextBox.TabIndex = 7;
			this.typeNameTextBox.TabStop = false;
			base.AcceptButton = this.okButton;
			base.ClientSize = new Size(424, 235);
			base.Controls.Add(this.locationInfoGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form7";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F7 - New Location";
			base.Load += new EventHandler(this.Form7_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form7_FormClosing);
			this.locationInfoGroupBox.ResumeLayout(false);
			this.locationInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
		public Form7()
		{
			this.InitializeComponent();
		}
		private void Form7_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.regionIdTextBox.Text = this.the_iRegionID.ToString();
			this.regionNameTextBox.Text = this.the_strRegionName;
			this.typeIdTextBox.Text = this.the_iTypeID.ToString();
			if (this.bModify)
			{
				this.typeNameComboBox.Visible = false;
				this.typeNameTextBox.Text = this.the_strTypeName;
			}
			else
			{
				this.typeNameTextBox.Visible = false;
				this.LoadLTypes(this.typeNameComboBox, this.The_TypeNames);
				this.typeNameComboBox.Text = this.the_strTypeName;
			}
			this.locationIdTextBox.ReadOnly = this.bModify;
			this.locationIdTextBox.TabStop = !this.bModify;
			this.locationIdTextBox.Text = this.the_iLocationID.ToString();
			this.locationNameTextBox.Text = this.the_strLocationName;
			this.noteTextBox.Text = this.the_strNote;
			this.yesRadioButton.Checked = this.the_bInstall;
		}
		private void LoadCaptionForControls()
		{
			this.Text = (this.bModify ? ("F7 - " + Properties.Resources.ModifyLocation) : ("F7 - " + Properties.Resources.NewLocation));
			this.locationInfoGroupBox.Text = Properties.Resources.LocationInfo;
			this.regionLabel.Text = Properties.Resources.Region + ":";
			this.typeLabel.Text = Properties.Resources.Type + ":";
			this.locationLabel.Text = Properties.Resources.Location + ":";
			this.noteLabel.Text = Properties.Resources.Note + ":";
			this.installLabel.Text = Properties.Resources.Install + ":";
			this.noRadioButton.Text = Properties.Resources.No;
			this.yesRadioButton.Text = Properties.Resources.Yes;
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
				int selectedIndex = this.typeNameComboBox.SelectedIndex;
				if (selectedIndex == -1)
				{
					MyMsgBox.MsgError(Properties.Resources.LocationType + " " + Properties.Resources.IsNotSelected + "!");
					this.typeNameComboBox.Focus();
					return;
				}
				string text = this.locationIdTextBox.Text.Trim();
				if (text == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.LocationID + " " + Properties.Resources.IsNotEmpty + "!");
					this.locationIdTextBox.Focus();
					return;
				}
				if (!StringEx.IsStrNumber(text))
				{
					MyMsgBox.MsgError(Properties.Resources.LocationID + " " + Properties.Resources.IsNumber + "!");
					this.locationIdTextBox.Focus();
					return;
				}
				int num = int.Parse(text);
				if (num < 1)
				{
					MyMsgBox.MsgError(Properties.Resources.LocationID + " > 0 !");
					this.locationIdTextBox.Focus();
					return;
				}
			}
			if (this.locationNameTextBox.Text.Trim() == string.Empty)
			{
				MyMsgBox.MsgError(Properties.Resources.LocationName + " " + Properties.Resources.IsNotEmpty + "!");
				this.locationNameTextBox.Focus();
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void Form7_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.the_iRegionID = int.Parse(this.regionIdTextBox.Text);
				this.the_strRegionName = this.regionNameTextBox.Text;
				this.the_iTypeID = int.Parse(this.typeIdTextBox.Text);
				this.the_strTypeName = (this.bModify ? this.typeNameTextBox.Text : this.typeNameComboBox.Text);
				this.the_iLocationID = int.Parse(this.locationIdTextBox.Text);
				this.the_strLocationName = StringEx.CutBlanks(this.locationNameTextBox.Text);
				this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
				this.the_bInstall = this.yesRadioButton.Checked;
			}
		}
		private void LoadLTypes(ComboBox cb, string[] l_types)
		{
			cb.Items.AddRange(l_types);
		}
		private void locationNameTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void noteTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void typeNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			int selectedIndex = comboBox.SelectedIndex;
			if (selectedIndex != -1)
			{
				this.typeIdTextBox.Text = this.The_TypeIDs[selectedIndex].ToString();
			}
		}
	}
}
