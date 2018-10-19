using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form2 : Form
	{
		private string the_strPortName;
		private string the_strBaudRate;
		private string the_strParity;
		private string the_strDataBits;
		private string the_strStopBits;
		private IContainer components = null;
		private Button okButton;
		private Button cancelButton;
		private Label portNameLabel;
		private Label baudRateLabel;
		private Label parityLabel;
		private Label databitsLabel;
		private Label stopBitsLabel;
		private ComboBox portNameComboBox;
		private ComboBox baudRateComboBox;
		private ComboBox parityComboBox;
		private ComboBox dataBitsComboBox;
		private ComboBox stopBitsComboBox;
		private GroupBox parametersGroupBox;
		public string The_strPortName
		{
			get
			{
				return this.the_strPortName;
			}
			set
			{
				this.the_strPortName = value;
			}
		}
		public string The_strBaudRate
		{
			get
			{
				return this.the_strBaudRate;
			}
			set
			{
				this.the_strBaudRate = value;
			}
		}
		public string The_strParity
		{
			get
			{
				return this.the_strParity;
			}
			set
			{
				this.the_strParity = value;
			}
		}
		public string The_strDataBits
		{
			get
			{
				return this.the_strDataBits;
			}
			set
			{
				this.the_strDataBits = value;
			}
		}
		public string The_strStopBits
		{
			get
			{
				return this.the_strStopBits;
			}
			set
			{
				this.the_strStopBits = value;
			}
		}
		public Form2()
		{
			this.InitializeComponent();
		}
		private void InitializeControlValues()
		{
			this.baudRateComboBox.Text = this.the_strBaudRate;
			this.dataBitsComboBox.Text = this.the_strDataBits;
			this.parityComboBox.Items.Clear();
			this.parityComboBox.Items.AddRange(Enum.GetNames(typeof(Parity)));
			this.parityComboBox.Text = this.the_strParity;
			this.stopBitsComboBox.Items.Clear();
			this.stopBitsComboBox.Items.AddRange(Enum.GetNames(typeof(StopBits)));
			this.stopBitsComboBox.Text = this.the_strStopBits;
			this.portNameComboBox.Items.Clear();
			string[] portNames = SerialPort.GetPortNames();
			for (int i = 0; i < portNames.Length; i++)
			{
				string item = portNames[i];
				this.portNameComboBox.Items.Add(item);
			}
			if (this.portNameComboBox.Items.Contains(this.the_strPortName))
			{
				this.portNameComboBox.Text = this.the_strPortName;
			}
			else
			{
				if (this.portNameComboBox.Items.Count > 0)
				{
					this.portNameComboBox.SelectedIndex = 0;
				}
				else
				{
					MyMsgBox.MsgErrorTitle("Không có Comport.\nHãy mở Comport và mở lại chương trình.", "Thông báo");
					base.Close();
				}
			}
		}
		private void Form2_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.InitializeControlValues();
		}
		private void LoadCaptionForControls()
		{
			this.Text = "F2 - " + Properties.Resources.SerialPortSettings;
			this.parametersGroupBox.Text = Properties.Resources.Parameters;
			this.portNameLabel.Text = Properties.Resources.PortName + ":";
			this.baudRateLabel.Text = Properties.Resources.BaudRate + ":";
			this.parityLabel.Text = Properties.Resources.Parity + ":";
			this.databitsLabel.Text = Properties.Resources.DataBits + ":";
			this.stopBitsLabel.Text = Properties.Resources.StopBits + ":";
			this.okButton.Text = Properties.Resources.OK;
			this.cancelButton.Text = Properties.Resources.Cancel;
		}
		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult != DialogResult.Cancel)
			{
				this.the_strPortName = this.portNameComboBox.Text;
				this.the_strBaudRate = this.baudRateComboBox.Text;
				this.the_strParity = this.parityComboBox.Text;
				this.the_strDataBits = this.dataBitsComboBox.Text;
				this.the_strStopBits = this.stopBitsComboBox.Text;
			}
		}
		private void baudRateComboBox_Validating(object sender, CancelEventArgs e)
		{
			int num;
			e.Cancel = !int.TryParse(this.baudRateComboBox.Text, out num);
		}
		private void dataBitsComboBox_Validating(object sender, CancelEventArgs e)
		{
			int num;
			e.Cancel = !int.TryParse(this.dataBitsComboBox.Text, out num);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form2));
			this.okButton = new Button();
			this.cancelButton = new Button();
			this.portNameLabel = new Label();
			this.baudRateLabel = new Label();
			this.parityLabel = new Label();
			this.databitsLabel = new Label();
			this.stopBitsLabel = new Label();
			this.portNameComboBox = new ComboBox();
			this.baudRateComboBox = new ComboBox();
			this.parityComboBox = new ComboBox();
			this.dataBitsComboBox = new ComboBox();
			this.stopBitsComboBox = new ComboBox();
			this.parametersGroupBox = new GroupBox();
			this.parametersGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.okButton.DialogResult = DialogResult.OK;
			this.okButton.Location = new Point(132, 196);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(75, 23);
			this.okButton.TabIndex = 11;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(212, 196);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(75, 23);
			this.cancelButton.TabIndex = 12;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.portNameLabel.AutoSize = true;
			this.portNameLabel.Location = new Point(24, 28);
			this.portNameLabel.Name = "portNameLabel";
			this.portNameLabel.Size = new Size(61, 13);
			this.portNameLabel.TabIndex = 1;
			this.portNameLabel.Text = "Port Name:";
			this.baudRateLabel.AutoSize = true;
			this.baudRateLabel.Location = new Point(24, 55);
			this.baudRateLabel.Name = "baudRateLabel";
			this.baudRateLabel.Size = new Size(61, 13);
			this.baudRateLabel.TabIndex = 3;
			this.baudRateLabel.Text = "Baud Rate:";
			this.parityLabel.AutoSize = true;
			this.parityLabel.Location = new Point(24, 82);
			this.parityLabel.Name = "parityLabel";
			this.parityLabel.Size = new Size(39, 13);
			this.parityLabel.TabIndex = 5;
			this.parityLabel.Text = "Parity:";
			this.databitsLabel.AutoSize = true;
			this.databitsLabel.Location = new Point(24, 109);
			this.databitsLabel.Name = "databitsLabel";
			this.databitsLabel.Size = new Size(54, 13);
			this.databitsLabel.TabIndex = 7;
			this.databitsLabel.Text = "Data Bits:";
			this.stopBitsLabel.AutoSize = true;
			this.stopBitsLabel.Location = new Point(24, 136);
			this.stopBitsLabel.Name = "stopBitsLabel";
			this.stopBitsLabel.Size = new Size(53, 13);
			this.stopBitsLabel.TabIndex = 9;
			this.stopBitsLabel.Text = "Stop Bits:";
			this.portNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.portNameComboBox.FormattingEnabled = true;
			this.portNameComboBox.Location = new Point(120, 24);
			this.portNameComboBox.Name = "portNameComboBox";
			this.portNameComboBox.Size = new Size(155, 21);
			this.portNameComboBox.TabIndex = 2;
			this.baudRateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.baudRateComboBox.FormattingEnabled = true;
			this.baudRateComboBox.Items.AddRange(new object[]
			{
				"300",
				"600",
				"1200",
				"2400",
				"4800",
				"9600",
				"14400",
				"28800",
				"36000",
				"115000"
			});
			this.baudRateComboBox.Location = new Point(120, 51);
			this.baudRateComboBox.Name = "baudRateComboBox";
			this.baudRateComboBox.Size = new Size(155, 21);
			this.baudRateComboBox.TabIndex = 4;
			this.baudRateComboBox.Validating += new CancelEventHandler(this.baudRateComboBox_Validating);
			this.parityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.parityComboBox.FormattingEnabled = true;
			this.parityComboBox.Items.AddRange(new object[]
			{
				"None",
				"Even",
				"Odd"
			});
			this.parityComboBox.Location = new Point(120, 78);
			this.parityComboBox.Name = "parityComboBox";
			this.parityComboBox.Size = new Size(155, 21);
			this.parityComboBox.TabIndex = 6;
			this.dataBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.dataBitsComboBox.FormattingEnabled = true;
			this.dataBitsComboBox.Items.AddRange(new object[]
			{
				"5",
				"6",
				"7",
				"8"
			});
			this.dataBitsComboBox.Location = new Point(120, 105);
			this.dataBitsComboBox.Name = "dataBitsComboBox";
			this.dataBitsComboBox.Size = new Size(155, 21);
			this.dataBitsComboBox.TabIndex = 8;
			this.dataBitsComboBox.Validating += new CancelEventHandler(this.dataBitsComboBox_Validating);
			this.stopBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.stopBitsComboBox.FormattingEnabled = true;
			this.stopBitsComboBox.ItemHeight = 13;
			this.stopBitsComboBox.Items.AddRange(new object[]
			{
				"1",
				"2",
				"3"
			});
			this.stopBitsComboBox.Location = new Point(120, 132);
			this.stopBitsComboBox.Name = "stopBitsComboBox";
			this.stopBitsComboBox.Size = new Size(155, 21);
			this.stopBitsComboBox.TabIndex = 10;
			this.parametersGroupBox.Controls.Add(this.portNameComboBox);
			this.parametersGroupBox.Controls.Add(this.dataBitsComboBox);
			this.parametersGroupBox.Controls.Add(this.stopBitsComboBox);
			this.parametersGroupBox.Controls.Add(this.portNameLabel);
			this.parametersGroupBox.Controls.Add(this.baudRateLabel);
			this.parametersGroupBox.Controls.Add(this.stopBitsLabel);
			this.parametersGroupBox.Controls.Add(this.parityComboBox);
			this.parametersGroupBox.Controls.Add(this.databitsLabel);
			this.parametersGroupBox.Controls.Add(this.baudRateComboBox);
			this.parametersGroupBox.Controls.Add(this.parityLabel);
			this.parametersGroupBox.Location = new Point(12, 12);
			this.parametersGroupBox.Name = "parametersGroupBox";
			this.parametersGroupBox.Size = new Size(300, 170);
			this.parametersGroupBox.TabIndex = 0;
			this.parametersGroupBox.TabStop = false;
			this.parametersGroupBox.Text = "Parameters";
			base.AcceptButton = this.okButton;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(324, 232);
			base.Controls.Add(this.parametersGroupBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form2";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F2 - Serial Port Settings";
			base.Load += new EventHandler(this.Form2_Load);
			base.FormClosing += new FormClosingEventHandler(this.Form2_FormClosing);
			this.parametersGroupBox.ResumeLayout(false);
			this.parametersGroupBox.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
