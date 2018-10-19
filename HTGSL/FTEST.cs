using Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
	public class FTEST : Form
	{

		public enum DataMode
		{
			Text,
			Hex
		}
		public enum LogMsgType
		{
			Incoming,
			Outgoing,
			Normal,
			Warning,
			Error
		}
		private IContainer components = null;
		private TextBox textBox1;
		private TextBox textBox2;
		private TextBox textBox3;
		private Button button2;
		private Button button3;
		private Button button4;
		private Button button5;
		private TextBox textBox4;
		private Button button1;
		private Button button6;
		private TextBox textBox5;
		private Button button7;
		private ColorDialog colorDialog1;
		private Button button8;
		private Button button9;
		private Button button10;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem newToolStripMenuItem;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Button button11;
		private Button button12;
		private Button button13;
		private Button button14;
		private SqlConnection conn;
		private DataSet ds;
		private SqlDataAdapter da;
		private DataProvider provider = new DataProvider();
		private string strSQL;
		private string sRegion = "";
		private string sRoom = "";
		private string sEquipment = "";
		private string sBed = "";
		private string sType_Request = "";
		private string sCheck_Sum = "";
		private string strRev = "";
		private SerialPort comport = new SerialPort();
		private string strPortName;
		private string strStopBits;
		private string strDataBits;
		private string strParity;
		private string strBaudRate;
		private FTEST.DataMode CurrentDataMode = FTEST.DataMode.Hex;
        FMAIN fmain;
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
			this.textBox1 = new TextBox();
			this.textBox2 = new TextBox();
			this.textBox3 = new TextBox();
			this.button2 = new Button();
			this.button3 = new Button();
			this.button4 = new Button();
			this.button5 = new Button();
			this.textBox4 = new TextBox();
			this.button1 = new Button();
			this.button6 = new Button();
			this.textBox5 = new TextBox();
			this.button7 = new Button();
			this.colorDialog1 = new ColorDialog();
			this.button8 = new Button();
			this.button9 = new Button();
			this.button10 = new Button();
			this.menuStrip1 = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.newToolStripMenuItem = new ToolStripMenuItem();
			this.editToolStripMenuItem = new ToolStripMenuItem();
			this.deleteToolStripMenuItem = new ToolStripMenuItem();
			this.helpToolStripMenuItem = new ToolStripMenuItem();
			this.aboutToolStripMenuItem = new ToolStripMenuItem();
			this.button11 = new Button();
			this.button12 = new Button();
			this.button13 = new Button();
			this.button14 = new Button();
			this.menuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.textBox1.Location = new Point(105, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(235, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "02 01, 01, 301, 4, Z 03";
			this.textBox2.Location = new Point(105, 38);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new Size(235, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.Tag = "";
			this.textBox2.Text = "02 01, 01, 301, 6, Z 03";
			this.textBox3.Location = new Point(25, 77);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new Size(614, 20);
			this.textBox3.TabIndex = 4;
			this.textBox3.Tag = "";
			this.button2.Location = new Point(529, 199);
			this.button2.Name = "button2";
			this.button2.Size = new Size(125, 30);
			this.button2.TabIndex = 6;
			this.button2.Text = "Inserted";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.button3.Location = new Point(529, 346);
			this.button3.Name = "button3";
			this.button3.Size = new Size(125, 30);
			this.button3.TabIndex = 6;
			this.button3.Text = "Edited";
			this.button3.UseVisualStyleBackColor = true;
			this.button4.Location = new Point(529, 274);
			this.button4.Name = "button4";
			this.button4.Size = new Size(125, 30);
			this.button4.TabIndex = 6;
			this.button4.Text = "XOR";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new EventHandler(this.button4_Click);
			this.button5.Location = new Point(529, 238);
			this.button5.Name = "button5";
			this.button5.Size = new Size(125, 30);
			this.button5.TabIndex = 6;
			this.button5.Text = "To Hex String";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new EventHandler(this.button5_Click);
			this.textBox4.Location = new Point(25, 105);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new Size(614, 20);
			this.textBox4.TabIndex = 4;
			this.textBox4.Tag = "";
			this.button1.Location = new Point(529, 387);
			this.button1.Name = "button1";
			this.button1.Size = new Size(125, 30);
			this.button1.TabIndex = 6;
			this.button1.Text = "Read Sound";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button6.Location = new Point(529, 310);
			this.button6.Name = "button6";
			this.button6.Size = new Size(125, 30);
			this.button6.TabIndex = 6;
			this.button6.Text = "Hex To String";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new EventHandler(this.button6_Click);
			this.textBox5.Location = new Point(25, 131);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new Size(614, 20);
			this.textBox5.TabIndex = 4;
			this.textBox5.Tag = "";
			this.button7.Location = new Point(529, 163);
			this.button7.Name = "button7";
			this.button7.Size = new Size(125, 30);
			this.button7.TabIndex = 6;
			this.button7.Text = "Get Path";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new EventHandler(this.button7_Click);
			this.button8.Location = new Point(389, 387);
			this.button8.Name = "button8";
			this.button8.Size = new Size(125, 30);
			this.button8.TabIndex = 6;
			this.button8.Text = "Get Connect";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new EventHandler(this.button8_Click);
			this.button9.Location = new Point(389, 351);
			this.button9.Name = "button9";
			this.button9.Size = new Size(125, 30);
			this.button9.TabIndex = 6;
			this.button9.Text = "Set Connect";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new EventHandler(this.button9_Click);
			this.button10.Location = new Point(389, 310);
			this.button10.Name = "button10";
			this.button10.Size = new Size(125, 30);
			this.button10.TabIndex = 6;
			this.button10.Text = "Test Connect";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new EventHandler(this.button10_Click);
			this.menuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.helpToolStripMenuItem
			});
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size(666, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.newToolStripMenuItem,
				this.editToolStripMenuItem,
				this.deleteToolStripMenuItem
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new Size(107, 22);
			this.newToolStripMenuItem.Text = "New";
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new Size(107, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.aboutToolStripMenuItem
			});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.button11.Location = new Point(389, 274);
			this.button11.Name = "button11";
			this.button11.Size = new Size(125, 30);
			this.button11.TabIndex = 6;
			this.button11.Text = "Test Menu";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new EventHandler(this.button11_Click);
			this.button12.Location = new Point(389, 227);
			this.button12.Name = "button12";
			this.button12.Size = new Size(125, 32);
			this.button12.TabIndex = 8;
			this.button12.Text = "Send Mail";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new EventHandler(this.button12_Click);
			this.button13.Location = new Point(389, 181);
			this.button13.Name = "button13";
			this.button13.Size = new Size(125, 30);
			this.button13.TabIndex = 6;
			this.button13.Text = "Test Connect";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new EventHandler(this.button13_Click);
			this.button14.Location = new Point(265, 180);
			this.button14.Name = "button14";
			this.button14.Size = new Size(103, 30);
			this.button14.TabIndex = 9;
			this.button14.Text = "Write Log";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new EventHandler(this.button14_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(666, 462);
			base.Controls.Add(this.button14);
			base.Controls.Add(this.button12);
			base.Controls.Add(this.button6);
			base.Controls.Add(this.button11);
			base.Controls.Add(this.button13);
			base.Controls.Add(this.button10);
			base.Controls.Add(this.button9);
			base.Controls.Add(this.button8);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.button5);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button7);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.textBox5);
			base.Controls.Add(this.textBox4);
			base.Controls.Add(this.textBox3);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.menuStrip1);
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "FTEST";
			this.Text = "FTEST";
			base.Load += new EventHandler(this.FTEST_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public FTEST(FMAIN _main)
		{
			this.InitializeComponent();
            fmain = _main;
		}
		private void FTEST_Load(object sender, EventArgs e)
		{
		}
		private void LoadData()
		{
			this.conn = new SqlConnection(this.GetStringConnect());
			this.conn.Open();
			this.ds = new DataSet();
			this.strSQL = "SELECT [shift_id],[shift_name],[start_time],[end_time],[active]  FROM  [dbo].[SHIFTS]";
			this.da = new SqlDataAdapter(this.strSQL, this.conn);
			this.da.Fill(this.ds, "shift");
			this.conn.Close();
		}
		private void FlexGridFormat()
		{
		}
		private void ShowTotals()
		{
		}
		private string GetStringConnect()
		{
			string result;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Application.StartupPath + "\\DATA.XML");
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("SQLServer");
				string innerText = elementsByTagName.Item(0).ChildNodes[0].InnerText;
				string innerText2 = elementsByTagName.Item(0).ChildNodes[1].InnerText;
				string innerText3 = elementsByTagName.Item(0).ChildNodes[2].InnerText;
				string innerText4 = elementsByTagName.Item(0).ChildNodes[3].InnerText;
				result = string.Concat(new string[]
				{
					"Server=",
					innerText,
					";Database=",
					innerText2,
					";uid=",
					innerText3,
					";pwd=",
					innerText4
				});
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		private void button1_Click(object sender, EventArgs e)
		{
        //    clsSound clsSound = new clsSound();
        //    clsSound.SetSoundTemplate("002");
        ////	clsSound.PlaySoundWav("1", "002", "2");

        //    string str = clsSound.GetSoundToPlay("01", "002", "2");
        //    if (!string.IsNullOrEmpty(str))
        //        FMAIN.playList.AddRange(str.Split('|'));

            fmain.InsertCallRequire("01", "002", "2");
		}
		private void ParseStringCallRequest(string strInput)
		{
			int num = strInput.IndexOf(",");
			this.sRegion = strInput.Substring(0, num);
			int length = strInput.Length;
			strInput = strInput.Substring(num + 2, length - num - 2);
			int num2 = strInput.IndexOf(",");
			this.sRoom = strInput.Substring(0, num2);
			length = strInput.Length;
			strInput = strInput.Substring(num2 + 2, length - num2 - 2);
			int num3 = strInput.IndexOf(",");
			this.sEquipment = strInput.Substring(0, num3);
			length = strInput.Length;
			strInput = strInput.Substring(num3 + 2, length - num3 - 2);
			int num4 = strInput.IndexOf(",");
			this.sType_Request = strInput.Substring(0, num4);
			length = strInput.Length;
			strInput = strInput.Substring(num4 + 2, strInput.Length - num4 - 2);
			int num5 = strInput.IndexOf(",");
			this.sBed = strInput.Substring(0, num5);
			length = strInput.Length;
			strInput = strInput.Substring(num5 + 1, length - num5 - 1);
			this.sCheck_Sum = strInput.Trim();
		}
		private bool InsertCallDetail(string strRegion, string strRoom, string strBed)
		{
			bool result;
			try
			{
				this.strSQL = string.Concat(new object[]
				{
					"INSERT INTO  [dbo].[CALL_DETAILS]([bed_id],[room_id],[region_id],[shift_id],[user_id],[start_call],[transaction_date]) VALUES(",
					Convert.ToInt32(strBed),
					",",
					Convert.ToInt32(strRoom),
					",",
					Convert.ToInt32(strRegion),
					",",
					clsUtl.SHIFT_ID,
					",",
					clsUtl.USER_ID,
					", getdate(), getdate())"
				});
				Console.WriteLine(this.strSQL);
				this.provider.excuteNonQuery(this.strSQL);
				result = true;
			}
			catch (Exception ex)
			{
				MyMsgBox.MsgErrorTitle(ex.Message, "InsertCallDetail");
				result = false;
			}
			return result;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			this.ParseStringCallRequest(this.textBox1.Text);
			MessageBox.Show(this.SaveData(int.Parse(this.sRegion), int.Parse(this.sRoom), int.Parse(this.sBed), 1, 1, 1).ToString());
		}
		private bool SaveData(int iRegion, int iRoom, int iBed, int iShift, int iUser, int iAction)
		{
			bool result;
			try
			{
				bool flag = false;
				this.conn = new SqlConnection(DataProvider.ConnectionString);
				this.conn.Open();
				SqlCommand sqlCommand = new SqlCommand("sp_call_detail", this.conn);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Add("@Region", SqlDbType.Int).Value = iRegion;
				sqlCommand.Parameters.Add("@Room", SqlDbType.Int).Value = iRoom;
				sqlCommand.Parameters.Add("@Bed", SqlDbType.Int).Value = iBed;
				sqlCommand.Parameters.Add("@Action", SqlDbType.Int).Value = iAction;
				sqlCommand.Parameters.Add("@Shift", SqlDbType.Int).Value = iShift;
				sqlCommand.Parameters.Add("@User", SqlDbType.Int).Value = iUser;
				sqlCommand.Parameters.Add("@Result", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
				sqlCommand.ExecuteNonQuery();
				Console.WriteLine(sqlCommand.Parameters["@Result"].Value);
				if (sqlCommand.Parameters["@Result"].Value.ToString() == "Y")
				{
					flag = true;
				}
				sqlCommand.Dispose();
				this.conn.Close();
				result = flag;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}
		private bool SaveData(int iRegion, string sRoom, string sEquip, string sBed, int iShift, int iUser, int iAction)
		{
			bool result;
			try
			{
				bool flag = false;
				this.conn = new SqlConnection(DataProvider.ConnectionString);
				this.conn.Open();
				SqlCommand sqlCommand = new SqlCommand("sp_call_details", this.conn);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = iRegion;
				sqlCommand.Parameters.Add("@vRoom", SqlDbType.NVarChar, 40).Value = sRoom;
				sqlCommand.Parameters.Add("@vBed", SqlDbType.NVarChar, 40).Value = sBed;
				sqlCommand.Parameters.Add("@vEquipment", SqlDbType.VarChar, 10).Value = this.sEquipment;
				sqlCommand.Parameters.Add("@iAction", SqlDbType.Int).Value = iAction;
				sqlCommand.Parameters.Add("@iShift", SqlDbType.Int).Value = iShift;
				sqlCommand.Parameters.Add("@iUser", SqlDbType.Int).Value = iUser;
				sqlCommand.Parameters.Add("@vResult", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
				sqlCommand.ExecuteNonQuery();
				if (sqlCommand.Parameters["@vResult"].Value.ToString() == "Y")
				{
					flag = true;
				}
				sqlCommand.Dispose();
				this.conn.Close();
				result = flag;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}
		private void button6_Click(object sender, EventArgs e)
		{
		}
		private void button4_Click(object sender, EventArgs e)
		{
		}
		private void button5_Click(object sender, EventArgs e)
		{
		}
		private void OpenOrCloseSerialPort()
		{
			this.Cursor = Cursors.WaitCursor;
			string portName = "COM6";
			if (this.comport.IsOpen)
			{
				this.comport.Close();
			}
			else
			{
				try
				{
					this.strPortName = Settings.Default.PortName;
					this.strStopBits = Settings.Default.StopBits.ToString();
					this.strDataBits = Settings.Default.DataBits.ToString();
					this.strParity = Settings.Default.Parity.ToString();
					this.strBaudRate = Settings.Default.BaudRate.ToString();
					this.comport.BaudRate = int.Parse(this.strBaudRate);
					this.comport.DataBits = int.Parse(this.strDataBits);
					this.comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.strStopBits);
					this.comport.Parity = (Parity)Enum.Parse(typeof(Parity), this.strParity);
					this.comport.PortName = portName;
					this.comport.DataReceived += new SerialDataReceivedEventHandler(this.port_DataReceived);
					this.comport.Open();
				}
				catch (Exception ex)
				{
					MyMsgBox.MsgError(ex.Message);
				}
			}
			this.Cursor = Cursors.Default;
		}
		private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			while (this.comport.BytesToRead > 0)
			{
				int bytesToRead = this.comport.BytesToRead;
				byte[] array = new byte[bytesToRead];
				this.comport.Read(array, 0, bytesToRead);
				if (array.Length > 0)
				{
					this.strRev = this.strRev + BitConverter.ToString(array) + "-";
				}
				if (this.strRev.Contains("02") && this.strRev.Contains("03"))
				{
					string sCommand = this.strRev;
					this.strRev = "";
					this.ParseToCommand(sCommand);
				}
			}
		}
		private void ParseToCommand(string sCommand)
		{
			int num = sCommand.IndexOf("02");
			int num2 = sCommand.IndexOf("03");
			sCommand = sCommand.Substring(num + 3, num2 - (num + 3));
			string text = clsString.HexString2Ascii(sCommand);
			string a = text.Substring(text.Length - 2, 2);
			string b = clsString.XOR(text.Substring(0, text.Length - 2)).Trim();
			if (a == b)
			{
				this.ParseStringCallRequest(text);
				string text2 = this.sType_Request;
				if (text2 != null)
				{
					if (text2 == "4")
					{
						MessageBox.Show(this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, 1, 1, 1).ToString());
					}
				}
			}
		}
		public static string HexStr(byte[] p)
		{
			char[] array = new char[p.Length * 2 + 2];
			array[0] = '0';
			array[1] = 'x';
			int i = 0;
			int num = 2;
			while (i < p.Length)
			{
				byte b = (byte)(p[i] >> 4);
				array[num] = (char)((b > 9) ? (b + 55) : (b + 48));
				b = (byte)(p[i] & 15);
				array[++num] = (char)((b > 9) ? (b + 55) : (b + 48));
				i++;
				num++;
			}
			return new string(array);
		}
		private void button7_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Application.StartupPath + "\\sounds";
			openFileDialog.DefaultExt = "wav";
			openFileDialog.Filter = "Wave|*.wav";
			openFileDialog.ShowDialog();
			string[] fileNames = openFileDialog.FileNames;
		}
		private void button8_Click(object sender, EventArgs e)
		{
			this.textBox5.Text = clsUtl.CONNECT_STRING;
		}
		private void button9_Click(object sender, EventArgs e)
		{
			clsUtl.CONNECT_STRING = "data source=Localhost;initial catalog=ErrorSystem;integrated security=SSPI;";
		}
		private void button10_Click(object sender, EventArgs e)
		{
			this.textBox4.Text = clsUtl.CONNECT_STATUS.ToString();
		}
		private void button11_Click(object sender, EventArgs e)
		{
			foreach (ToolStripMenuItem toolStripMenuItem in this.menuStrip1.Items)
			{
				foreach (ToolStripMenuItem toolStripMenuItem2 in toolStripMenuItem.DropDownItems)
				{
					if (toolStripMenuItem2.Name.ToString() == "newToolStripMenuItem")
					{
						toolStripMenuItem2.Enabled = false;
					}
				}
			}
		}
		private void button12_Click(object sender, EventArgs e)
		{
			try
			{
				clsMail clsMail = new clsMail();
				clsMail.Type = "Outlook";
				clsMail.Host = "smtp.easycgi.com";
				clsMail.From = "phongvt@pythis.com";
				clsMail.Password = "@p1409";
				clsMail.To = "vthphong@gmail.com, vtphong@yahoo.com";
				clsMail.Subject = "I Love You";
				clsMail.Body = "I just lie :)";
				clsMail.AddAttachment("C:\\1.sql");
				clsMail.AddAttachment("C:\\2.sql");
				clsMail.SendMail();
				MessageBox.Show("OK");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void button13_Click(object sender, EventArgs e)
		{
			this.textBox4.Text = this.textBox3.Text.IndexOf("abc").ToString();
		}
		private void button14_Click(object sender, EventArgs e)
		{
			clsUtl.WriteLog(this.textBox1.Text);
		}
	}
}
