//using HTGSL.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form9 : Form
	{
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private TextBox addressTextBox;
		private TextBox employeeIdTextBox;
		private Label noteLabel;
		private GroupBox employeeInfoGroupBox;
		private TextBox noteTextBox;
		private Label employeeIdLabel;
		private ComboBox departmentNameComboBox;
		private Label genderLabel;
		private TextBox firstNameTextBox;
		private Label departmentLabel;
		private ComboBox jobNameComboBox;
		private Label titleLabel;
		private TextBox titleTextBox;
		private RadioButton womenRadioButton;
		private RadioButton menRadioButton;
		private DateTimePicker hireDateDateTimePicker;
		private DateTimePicker birthDateDateTimePicker;
		private Label hireDateLabel;
		private Label birthDateLabel;
		private Label jobLabel;
		private TextBox phoneTextBox;
		private Label phoneLabel;
		private TextBox cityTextBox;
		private Label cityLabel;
		private Label addressLabel;
		private TextBox departmentIdTextBox;
		private TextBox jobIdTextBox;
		private TextBox lastNameTextBox;
		private Label employeeNameLabel;
		public bool bModify = false;
		public int[] The_DepartmentIDs;
		public string[] The_DepartmentNames;
		public int[] The_JobIDs;
		public string[] The_JobNames;
		private int the_iEmployeeID;
		private string the_strFirstName;
		private string the_strLastName;
		private bool the_bMenOrWomen;
		private DateTime the_dtBirthDate;
		private string the_strTitle;
		private int the_iDepartmentID;
		private string the_strDepartmentName;
		private int the_iJobID;
		private string the_strJobName;
		private DateTime the_dtHireDate;
		private string the_strAddress;
		private string the_strCity;
		private string the_strPhone;
		private string the_strNote;
		public int The_iEmployeeID
		{
			get
			{
				return this.the_iEmployeeID;
			}
			set
			{
				this.the_iEmployeeID = value;
			}
		}
		public string The_strFirstName
		{
			get
			{
				return this.the_strFirstName;
			}
			set
			{
				this.the_strFirstName = value;
			}
		}
		public string The_strLastName
		{
			get
			{
				return this.the_strLastName;
			}
			set
			{
				this.the_strLastName = value;
			}
		}
		public bool The_bMenOrWomen
		{
			get
			{
				return this.the_bMenOrWomen;
			}
			set
			{
				this.the_bMenOrWomen = value;
			}
		}
		public DateTime The_dtBirthDate
		{
			get
			{
				return this.the_dtBirthDate;
			}
			set
			{
				this.the_dtBirthDate = value;
			}
		}
		public string The_strTitle
		{
			get
			{
				return this.the_strTitle;
			}
			set
			{
				this.the_strTitle = value;
			}
		}
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
		public DateTime The_dtHireDate
		{
			get
			{
				return this.the_dtHireDate;
			}
			set
			{
				this.the_dtHireDate = value;
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
		public string The_strCity
		{
			get
			{
				return this.the_strCity;
			}
			set
			{
				this.the_strCity = value;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form9));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.addressTextBox = new TextBox();
			this.employeeIdTextBox = new TextBox();
			this.noteLabel = new Label();
			this.employeeInfoGroupBox = new GroupBox();
			this.employeeNameLabel = new Label();
			this.lastNameTextBox = new TextBox();
			this.jobIdTextBox = new TextBox();
			this.departmentIdTextBox = new TextBox();
			this.phoneTextBox = new TextBox();
			this.phoneLabel = new Label();
			this.cityTextBox = new TextBox();
			this.cityLabel = new Label();
			this.addressLabel = new Label();
			this.hireDateDateTimePicker = new DateTimePicker();
			this.birthDateDateTimePicker = new DateTimePicker();
			this.hireDateLabel = new Label();
			this.birthDateLabel = new Label();
			this.jobLabel = new Label();
			this.departmentLabel = new Label();
			this.jobNameComboBox = new ComboBox();
			this.titleLabel = new Label();
			this.titleTextBox = new TextBox();
			this.womenRadioButton = new RadioButton();
			this.menRadioButton = new RadioButton();
			this.genderLabel = new Label();
			this.firstNameTextBox = new TextBox();
			this.departmentNameComboBox = new ComboBox();
			this.employeeIdLabel = new Label();
			this.noteTextBox = new TextBox();
			this.employeeInfoGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.okButton.Location = new Point(191, 388);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(95, 25);
			this.okButton.TabIndex = 29;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(292, 388);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(95, 25);
			this.cancelButton.TabIndex = 30;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.addressTextBox.Location = new Point(135, 240);
			this.addressTextBox.MaxLength = 40;
			this.addressTextBox.Name = "addressTextBox";
			this.addressTextBox.Size = new Size(240, 21);
			this.addressTextBox.TabIndex = 22;
			this.addressTextBox.Validated += new EventHandler(this.addressTextBox_Validated);
			this.employeeIdTextBox.Location = new Point(135, 24);
			this.employeeIdTextBox.MaxLength = 2;
			this.employeeIdTextBox.Name = "employeeIdTextBox";
			this.employeeIdTextBox.Size = new Size(36, 21);
			this.employeeIdTextBox.TabIndex = 2;
			this.employeeIdTextBox.Text = "0";
			this.employeeIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.employeeIdTextBox.KeyPress += new KeyPressEventHandler(this.NumberChecked_KeyPress);
			this.noteLabel.AutoSize = true;
			this.noteLabel.Location = new Point(24, 325);
			this.noteLabel.Name = "noteLabel";
			this.noteLabel.Size = new Size(34, 13);
			this.noteLabel.TabIndex = 27;
			this.noteLabel.Text = "Note:";
			this.employeeInfoGroupBox.Controls.Add(this.employeeNameLabel);
			this.employeeInfoGroupBox.Controls.Add(this.lastNameTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.jobIdTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.departmentIdTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.phoneTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.phoneLabel);
			this.employeeInfoGroupBox.Controls.Add(this.cityTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.cityLabel);
			this.employeeInfoGroupBox.Controls.Add(this.addressLabel);
			this.employeeInfoGroupBox.Controls.Add(this.hireDateDateTimePicker);
			this.employeeInfoGroupBox.Controls.Add(this.birthDateDateTimePicker);
			this.employeeInfoGroupBox.Controls.Add(this.hireDateLabel);
			this.employeeInfoGroupBox.Controls.Add(this.birthDateLabel);
			this.employeeInfoGroupBox.Controls.Add(this.jobLabel);
			this.employeeInfoGroupBox.Controls.Add(this.departmentLabel);
			this.employeeInfoGroupBox.Controls.Add(this.jobNameComboBox);
			this.employeeInfoGroupBox.Controls.Add(this.titleLabel);
			this.employeeInfoGroupBox.Controls.Add(this.titleTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.womenRadioButton);
			this.employeeInfoGroupBox.Controls.Add(this.menRadioButton);
			this.employeeInfoGroupBox.Controls.Add(this.genderLabel);
			this.employeeInfoGroupBox.Controls.Add(this.firstNameTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.departmentNameComboBox);
			this.employeeInfoGroupBox.Controls.Add(this.employeeIdLabel);
			this.employeeInfoGroupBox.Controls.Add(this.noteTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.employeeIdTextBox);
			this.employeeInfoGroupBox.Controls.Add(this.noteLabel);
			this.employeeInfoGroupBox.Controls.Add(this.addressTextBox);
			this.employeeInfoGroupBox.Location = new Point(12, 12);
			this.employeeInfoGroupBox.Name = "employeeInfoGroupBox";
			this.employeeInfoGroupBox.Size = new Size(400, 362);
			this.employeeInfoGroupBox.TabIndex = 0;
			this.employeeInfoGroupBox.TabStop = false;
			this.employeeInfoGroupBox.Text = "Employee Info";
			this.employeeNameLabel.AutoSize = true;
			this.employeeNameLabel.Location = new Point(24, 55);
			this.employeeNameLabel.Name = "employeeNameLabel";
			this.employeeNameLabel.Size = new Size(86, 13);
			this.employeeNameLabel.TabIndex = 3;
			this.employeeNameLabel.Text = "Employee name:";
			this.lastNameTextBox.Location = new Point(308, 51);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new Size(67, 21);
			this.lastNameTextBox.TabIndex = 5;
			this.lastNameTextBox.Validated += new EventHandler(this.lastNameTextBox_Validated);
			this.jobIdTextBox.Location = new Point(135, 186);
			this.jobIdTextBox.MaxLength = 2;
			this.jobIdTextBox.Name = "jobIdTextBox";
			this.jobIdTextBox.ReadOnly = true;
			this.jobIdTextBox.Size = new Size(36, 21);
			this.jobIdTextBox.TabIndex = 17;
			this.jobIdTextBox.TabStop = false;
			this.jobIdTextBox.Text = "0";
			this.jobIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.departmentIdTextBox.Location = new Point(135, 159);
			this.departmentIdTextBox.MaxLength = 2;
			this.departmentIdTextBox.Name = "departmentIdTextBox";
			this.departmentIdTextBox.ReadOnly = true;
			this.departmentIdTextBox.Size = new Size(36, 21);
			this.departmentIdTextBox.TabIndex = 14;
			this.departmentIdTextBox.TabStop = false;
			this.departmentIdTextBox.Text = "0";
			this.departmentIdTextBox.TextAlign = HorizontalAlignment.Right;
			this.phoneTextBox.Location = new Point(135, 294);
			this.phoneTextBox.MaxLength = 40;
			this.phoneTextBox.Name = "phoneTextBox";
			this.phoneTextBox.Size = new Size(170, 21);
			this.phoneTextBox.TabIndex = 26;
			this.phoneTextBox.Validated += new EventHandler(this.phoneTextBox_Validated);
			this.phoneLabel.AutoSize = true;
			this.phoneLabel.Location = new Point(24, 298);
			this.phoneLabel.Name = "phoneLabel";
			this.phoneLabel.Size = new Size(41, 13);
			this.phoneLabel.TabIndex = 25;
			this.phoneLabel.Text = "Phone:";
			this.cityTextBox.Location = new Point(135, 267);
			this.cityTextBox.MaxLength = 40;
			this.cityTextBox.Name = "cityTextBox";
			this.cityTextBox.Size = new Size(170, 21);
			this.cityTextBox.TabIndex = 24;
			this.cityTextBox.Validated += new EventHandler(this.cityTextBox_Validated);
			this.cityLabel.AutoSize = true;
			this.cityLabel.Location = new Point(24, 271);
			this.cityLabel.Name = "cityLabel";
			this.cityLabel.Size = new Size(30, 13);
			this.cityLabel.TabIndex = 23;
			this.cityLabel.Text = "City:";
			this.addressLabel.AutoSize = true;
			this.addressLabel.Location = new Point(24, 244);
			this.addressLabel.Name = "addressLabel";
			this.addressLabel.Size = new Size(50, 13);
			this.addressLabel.TabIndex = 21;
			this.addressLabel.Text = "Address:";
			this.hireDateDateTimePicker.CustomFormat = "dd/MM/yyyy";
			this.hireDateDateTimePicker.Format = DateTimePickerFormat.Custom;
			this.hireDateDateTimePicker.Location = new Point(135, 213);
			this.hireDateDateTimePicker.Name = "hireDateDateTimePicker";
			this.hireDateDateTimePicker.Size = new Size(85, 21);
			this.hireDateDateTimePicker.TabIndex = 20;
			this.birthDateDateTimePicker.CustomFormat = "dd/MM/yyyy";
			this.birthDateDateTimePicker.Format = DateTimePickerFormat.Custom;
			this.birthDateDateTimePicker.Location = new Point(135, 105);
			this.birthDateDateTimePicker.Name = "birthDateDateTimePicker";
			this.birthDateDateTimePicker.Size = new Size(85, 21);
			this.birthDateDateTimePicker.TabIndex = 10;
			this.hireDateLabel.AutoSize = true;
			this.hireDateLabel.Location = new Point(24, 217);
			this.hireDateLabel.Name = "hireDateLabel";
			this.hireDateLabel.Size = new Size(55, 13);
			this.hireDateLabel.TabIndex = 19;
			this.hireDateLabel.Text = "Hire date:";
			this.birthDateLabel.AutoSize = true;
			this.birthDateLabel.Location = new Point(24, 109);
			this.birthDateLabel.Name = "birthDateLabel";
			this.birthDateLabel.Size = new Size(58, 13);
			this.birthDateLabel.TabIndex = 9;
			this.birthDateLabel.Text = "Birth date:";
			this.jobLabel.AutoSize = true;
			this.jobLabel.Location = new Point(24, 190);
			this.jobLabel.Name = "jobLabel";
			this.jobLabel.Size = new Size(28, 13);
			this.jobLabel.TabIndex = 16;
			this.jobLabel.Text = "Job:";
			this.departmentLabel.AutoSize = true;
			this.departmentLabel.Location = new Point(24, 163);
			this.departmentLabel.Name = "departmentLabel";
			this.departmentLabel.Size = new Size(68, 13);
			this.departmentLabel.TabIndex = 13;
			this.departmentLabel.Text = "Department:";
			this.jobNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.jobNameComboBox.FormattingEnabled = true;
			this.jobNameComboBox.ItemHeight = 13;
			this.jobNameComboBox.Location = new Point(175, 186);
			this.jobNameComboBox.Name = "jobNameComboBox";
			this.jobNameComboBox.Size = new Size(200, 21);
			this.jobNameComboBox.TabIndex = 18;
			this.jobNameComboBox.SelectedIndexChanged += new EventHandler(this.jobNameComboBox_SelectedIndexChanged);
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new Point(24, 136);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new Size(31, 13);
			this.titleLabel.TabIndex = 11;
			this.titleLabel.Text = "Title:";
			this.titleTextBox.Location = new Point(135, 132);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.Size = new Size(240, 21);
			this.titleTextBox.TabIndex = 12;
			this.titleTextBox.Validated += new EventHandler(this.titleTextBox_Validated);
			this.womenRadioButton.AutoSize = true;
			this.womenRadioButton.Location = new Point(254, 80);
			this.womenRadioButton.Name = "womenRadioButton";
			this.womenRadioButton.Size = new Size(61, 17);
			this.womenRadioButton.TabIndex = 8;
			this.womenRadioButton.TabStop = true;
			this.womenRadioButton.Text = "Women";
			this.womenRadioButton.UseVisualStyleBackColor = true;
			this.menRadioButton.AutoSize = true;
			this.menRadioButton.Location = new Point(135, 80);
			this.menRadioButton.Name = "menRadioButton";
			this.menRadioButton.Size = new Size(45, 17);
			this.menRadioButton.TabIndex = 7;
			this.menRadioButton.TabStop = true;
			this.menRadioButton.Text = "Men";
			this.menRadioButton.UseVisualStyleBackColor = true;
			this.genderLabel.AutoSize = true;
			this.genderLabel.Location = new Point(24, 82);
			this.genderLabel.Name = "genderLabel";
			this.genderLabel.Size = new Size(46, 13);
			this.genderLabel.TabIndex = 6;
			this.genderLabel.Text = "Gender:";
			this.firstNameTextBox.Location = new Point(135, 51);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new Size(170, 21);
			this.firstNameTextBox.TabIndex = 4;
			this.departmentNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.departmentNameComboBox.FormattingEnabled = true;
			this.departmentNameComboBox.ItemHeight = 13;
			this.departmentNameComboBox.Location = new Point(175, 159);
			this.departmentNameComboBox.Name = "departmentNameComboBox";
			this.departmentNameComboBox.Size = new Size(200, 21);
			this.departmentNameComboBox.TabIndex = 15;
			this.departmentNameComboBox.SelectedIndexChanged += new EventHandler(this.departmentNameComboBox_SelectedIndexChanged);
			this.employeeIdLabel.AutoSize = true;
			this.employeeIdLabel.Location = new Point(24, 28);
			this.employeeIdLabel.Name = "employeeIdLabel";
			this.employeeIdLabel.Size = new Size(71, 13);
			this.employeeIdLabel.TabIndex = 1;
			this.employeeIdLabel.Text = "Employee ID:";
			this.noteTextBox.Location = new Point(135, 321);
			this.noteTextBox.MaxLength = 50;
			this.noteTextBox.Name = "noteTextBox";
			this.noteTextBox.Size = new Size(240, 21);
			this.noteTextBox.TabIndex = 28;
			this.noteTextBox.Validated += new EventHandler(this.noteTextBox_Validated);
			base.AcceptButton = this.okButton;
			base.ClientSize = new Size(424, 427);
			base.Controls.Add(this.employeeInfoGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form9";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F9 - New Empolyee";
			base.Load += new EventHandler(this.Form9_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form9_FormClosing);
			this.employeeInfoGroupBox.ResumeLayout(false);
			this.employeeInfoGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
		public Form9()
		{
			this.InitializeComponent();
		}
		private void Form9_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.employeeIdTextBox.ReadOnly = this.bModify;
			this.employeeIdTextBox.TabStop = !this.bModify;
			this.employeeIdTextBox.Text = this.the_iEmployeeID.ToString();
			this.firstNameTextBox.Text = this.the_strFirstName;
			this.lastNameTextBox.Text = this.the_strLastName;
			this.menRadioButton.Checked = this.the_bMenOrWomen;
			this.womenRadioButton.Checked = !this.the_bMenOrWomen;
			this.birthDateDateTimePicker.Value = this.the_dtBirthDate;
			this.titleTextBox.Text = this.the_strTitle;
			this.departmentIdTextBox.Text = this.the_iDepartmentID.ToString();
			this.jobIdTextBox.Text = this.the_iJobID.ToString();
			this.LoadComboBoxNames(this.departmentNameComboBox, this.The_DepartmentNames);
			this.departmentNameComboBox.Text = this.the_strDepartmentName;
			this.LoadComboBoxNames(this.jobNameComboBox, this.The_JobNames);
			this.jobNameComboBox.Text = this.the_strJobName;
			this.hireDateDateTimePicker.Value = this.the_dtHireDate;
			this.addressTextBox.Text = this.the_strAddress;
			this.cityTextBox.Text = this.the_strCity;
			this.phoneTextBox.Text = this.the_strPhone;
			this.noteTextBox.Text = this.the_strNote;
		}
		private void LoadCaptionForControls()
		{
			this.Text = (this.bModify ? Properties.Resources.ModifyEmployee : Properties.Resources.NewEmployee);
			this.employeeInfoGroupBox.Text = Properties.Resources.EmployeeInfo;
			this.employeeIdLabel.Text = Properties.Resources.EmployeeID + ":";
			this.employeeNameLabel.Text = Properties.Resources.EmployeeName + ":";
			this.genderLabel.Text = Properties.Resources.Gender + ":";
			this.menRadioButton.Text = Properties.Resources.Men;
			this.womenRadioButton.Text = Properties.Resources.Women;
			this.birthDateLabel.Text = Properties.Resources.BirthDate + ":";
			this.titleLabel.Text = Properties.Resources.Title + ":";
			this.departmentLabel.Text = Properties.Resources.Department + ":";
			this.jobLabel.Text = Properties.Resources.Job + ":";
			this.hireDateLabel.Text = Properties.Resources.HireDate + ":";
			this.addressLabel.Text = Properties.Resources.Address + ":";
			this.cityLabel.Text = Properties.Resources.City + ":";
			this.phoneLabel.Text = Properties.Resources.Phone + ":";
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
				string text = this.employeeIdTextBox.Text.Trim();
				if (text == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.EmployeeID + " " + Properties.Resources.IsNotEmpty + "!");
					this.employeeIdTextBox.Focus();
					return;
				}
				if (!StringEx.IsStrNumber(text))
				{
					MyMsgBox.MsgError(Properties.Resources.EmployeeID + " " + Properties.Resources.IsNumber + "!");
					this.employeeIdTextBox.Focus();
					return;
				}
				int num = int.Parse(text);
				if (num < 1)
				{
					MyMsgBox.MsgError(Properties.Resources.EmployeeID + " > 0 !");
					this.employeeIdTextBox.Focus();
					return;
				}
			}
			if (this.firstNameTextBox.Text.Trim() == string.Empty)
			{
				MyMsgBox.MsgError(Properties.Resources.FirstName + " " + Properties.Resources.IsNotEmpty + "!");
				this.firstNameTextBox.Focus();
			}
			else
			{
				if (this.lastNameTextBox.Text.Trim() == string.Empty)
				{
					MyMsgBox.MsgError(Properties.Resources.LastName + " " + Properties.Resources.IsNotEmpty + "!");
					this.lastNameTextBox.Focus();
				}
				else
				{
					if (this.titleTextBox.Text.Trim() == string.Empty)
					{
						MyMsgBox.MsgError(Properties.Resources.Title + " " + Properties.Resources.IsNotEmpty + "!");
						this.titleTextBox.Focus();
					}
					else
					{
						int selectedIndex = this.departmentNameComboBox.SelectedIndex;
						if (selectedIndex == -1)
						{
							MyMsgBox.MsgError(Properties.Resources.Department + " " + Properties.Resources.IsNotSelected + "!");
							this.departmentNameComboBox.Focus();
						}
						else
						{
							int selectedIndex2 = this.jobNameComboBox.SelectedIndex;
							if (selectedIndex2 == -1)
							{
								MyMsgBox.MsgError(Properties.Resources.Job + " " + Properties.Resources.IsNotSelected + "!");
								this.jobNameComboBox.Focus();
							}
							else
							{
								int num2 = DateTime.Now.Year - this.birthDateDateTimePicker.Value.Year;
								if (num2 < 18)
								{
									MyMsgBox.MsgError(Properties.Resources.Employee + " >= 18 " + Properties.Resources.Years + "!");
									this.birthDateDateTimePicker.Focus();
								}
								else
								{
									if (num2 > 60)
									{
										MyMsgBox.MsgError(Properties.Resources.Employee + " <= 60 " + Properties.Resources.Years + "!");
										this.birthDateDateTimePicker.Focus();
									}
									else
									{
										if (this.hireDateDateTimePicker.Value > DateTime.Now)
										{
											MyMsgBox.MsgError(Properties.Resources.HireDate + " " + Properties.Resources.Invalid + "!");
											this.hireDateDateTimePicker.Focus();
										}
										else
										{
											if (this.hireDateDateTimePicker.Value.Year - 18 < this.birthDateDateTimePicker.Value.Year)
											{
												MyMsgBox.MsgError(Properties.Resources.HireDate + " " + Properties.Resources.Invalid + "!");
												this.hireDateDateTimePicker.Focus();
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
													if (this.cityTextBox.Text.Trim() == string.Empty)
													{
														MyMsgBox.MsgError(Properties.Resources.City + " " + Properties.Resources.IsNotEmpty + "!");
														this.cityTextBox.Focus();
													}
													else
													{
														base.DialogResult = DialogResult.OK;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void Form9_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.the_iEmployeeID = int.Parse(this.employeeIdTextBox.Text);
				this.the_strFirstName = StringEx.CutBlanksUpper(this.firstNameTextBox.Text);
				this.the_strLastName = StringEx.CutBlanksUpper(this.lastNameTextBox.Text);
				this.the_bMenOrWomen = this.menRadioButton.Checked;
				this.the_dtBirthDate = this.birthDateDateTimePicker.Value;
				this.the_strTitle = StringEx.CutBlanks(this.titleTextBox.Text);
				this.the_iDepartmentID = int.Parse(this.departmentIdTextBox.Text);
				this.the_strDepartmentName = this.departmentNameComboBox.Text;
				this.the_iJobID = int.Parse(this.jobIdTextBox.Text);
				this.the_strJobName = this.jobNameComboBox.Text;
				this.the_dtHireDate = this.hireDateDateTimePicker.Value;
				this.the_strAddress = StringEx.CutBlanks(this.addressTextBox.Text);
				this.the_strCity = StringEx.CutBlanks(this.cityTextBox.Text);
				this.the_strPhone = StringEx.CutBlanks(this.phoneTextBox.Text);
				this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
			}
		}
		private void LoadComboBoxNames(ComboBox cb, string[] names)
		{
			cb.Items.AddRange(names);
		}
		private void firstNameTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanksUpper(textBox.Text);
		}
		private void lastNameTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanksUpper(textBox.Text);
		}
		private void titleTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void addressTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void cityTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void phoneTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void noteTextBox_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.Text = StringEx.CutBlanks(textBox.Text);
		}
		private void departmentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			int selectedIndex = comboBox.SelectedIndex;
			if (selectedIndex != -1)
			{
				this.departmentIdTextBox.Text = this.The_DepartmentIDs[selectedIndex].ToString();
			}
		}
		private void jobNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			int selectedIndex = comboBox.SelectedIndex;
			if (selectedIndex != -1)
			{
				this.jobIdTextBox.Text = this.The_JobIDs[selectedIndex].ToString();
			}
		}
	}
}
