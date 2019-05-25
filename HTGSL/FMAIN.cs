using C1.C1Report;
using C1.Win.C1TrueDBGrid;
using HTGSL.Models;
//using HTGSL.Properties;
using Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace HTGSL
{
    public class FMAIN : Form
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
        private int iRegionHeight = 0;
        private int iRoomHeight = 0;
        private int iBedHeight = 0;
        private int iBedsPerRow = 0;
        private int iTimeRefreshData = 0;
        private int iTimeReadSound = 0;
        private string strHospitalName = "";
        private bool First_Open = false;
        private string strConnString = "";
        private string strConnStringDefault = "data source=.;initial catalog=ErrorSystem;integrated security=SSPI;";
        private SqlConnection MySqlConnect;
        private MySqlDataClass SqlData;
        private HospitalInfo MyHi = new HospitalInfo();
        private RegionExArray MyRs = new RegionExArray();
        private BedsArray MyBeds = new BedsArray();
        private string strExecutingAssembly;
        private bool bIsSounding = false;
        private SerialPort comport = new SerialPort();
        private string strPortName;
        private string strStopBits;
        private string strDataBits;
        private string strParity;
        private string strBaudRate;
        private string strRev = "";
        private bool bAutoOpenSerialPort = false;
        private string sRegion = "";
        private string sRoom = "";
        private string sEquipment = "1";
        private string sBed = "";
        private string sType_Request = "";
        private string sCheck_Sum = "";
        private int iAction = 9;
        private int iShift = 1;
        private int iUser = 1;
        private int iAllowDouble = 0;
        private SqlConnection conn;
        private DataSet ds;
        private SqlDataAdapter da;
        private string strSQL;
        private string sACK = clsString.HexString2Ascii("06");
        private string sNAK = clsString.HexString2Ascii("15");
        private C1Report c1Report1;
        private C1Report c1Report2;
        private string strMailShedule = "";
        private string strFileAttactment1 = "";
        private string strFileAttactment2 = "";
        private static System.Timers.Timer timer5;
        private DataProvider provider = new DataProvider();
        private static System.Timers.Timer tiSendData;
        private bool blnSendData = true;
        private int giRegion = 0;
        private string gsEquipment = "";
        private IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem vietnameseToolStripMenuItem;
        private ToolStripMenuItem statisticsToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem clearAllCallToolStripMenuItem;
        private ToolStripMenuItem serialPortSettingsToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel serialPortStatusToolStripStatusLabel;
        private ToolStripStatusLabel statusToolStripStatusLabel;
        private ToolStripStatusLabel clockToolStripStatusLabel;
        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Timer tmerResetDateTime;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSplitButton serialPortToolStripSplitButton;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripLabel serialPortToolStripLabel;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem configManagerToolStripMenuItem;
        private ToolStripMenuItem hospitalPropertiesToolStripMenuItem;
        private ToolStripMenuItem employeesManagerToolStripMenuItem;
        private ToolStripMenuItem departmentsToolStripMenuItem;
        private ToolStripMenuItem jobsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator4;
        private Panel mainPanel;
        private VScrollBar mainVScrollBar;
        private Panel headerPanel;
        private ToolTip myToolTip;
        private ContextMenuStrip bedContextMenuStrip;
        private ToolStripMenuItem callBedToolStripMenuItem;
        private ToolStripMenuItem stopBedToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem bedDetailsToolStripMenuItem;
        private ContextMenuStrip roomContextMenuStrip;
        private ToolStripMenuItem callRoomToolStripMenuItem;
        private ToolStripSeparator roomPropertiesToolStripSeparator;
        private ToolStripMenuItem roomDetailsToolStripMenuItem;
        private ContextMenuStrip regionContextMenuStrip;
        private ToolStripMenuItem callRegionToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem regionDetailsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem userBedCallToolStripMenuItem;
        private ToolStripMenuItem loginToolStripMenuItem;
        private ToolStripMenuItem workShiftToolStripMenuItem;
        private ToolStripMenuItem shiftToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem soundsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem soundTemplatesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton toolStripButton2;
        private System.Windows.Forms.Timer timer2;
        private ToolStripMenuItem CallByDateTimeToolStripMenuItem;
        private ToolStripMenuItem CallTopNToolStripMenuItem;
        private ToolStripMenuItem CallTimeGreaterToolStripMenuItem;
        private ToolStripMenuItem CallByShiftToolStripMenuItem;
        private C1TrueDBGrid c1TrueDBGrid1;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem rightsToolStripMenuItem;
        private ToolStripMenuItem functionsToolStripMenuItem;
        private ToolStripMenuItem rightFunctionToolStripMenuItem;
        private System.Windows.Forms.Timer tmerQuetRepeatSound;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private ToolStripMenuItem callByRegionToolStripMenuItem;
        private ToolStripMenuItem mailSetupToolStripMenuItem;
        private ToolStripMenuItem mailScheduleToolStripMenuItem;
        private ToolStripMenuItem mailListsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.Timer tmerCheckSendMail;
        private ToolStripStatusLabel tssDataSend;
        private ToolStripMenuItem equipmentToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemConfigEvent;
        private ToolStripMenuItem productsToolStripMenuItem;

        //Hai
        public static List<string> playList = new List<string>();
        SoundPlayer player;
        bool isFinishRead = true, isFinishDrawData = true;
        Thread playThread;
        System.Windows.Forms.Timer tmerFindSound;

        private TimeSpan? TimeSendMail;
        public FMAIN()
        {
            this.InitializeComponent();
            this.InitializeSerialPortSettingsForControlValues();
            this.comport.DataReceived += new SerialDataReceivedEventHandler(this.Port_DataReceived);
        }

        private void FMAIN_Load(object sender, EventArgs e)
        {
            //if (SingleInstanceApplication.AlreadyExists)
            //{
            //    MyMsgBox.MsgAsterisk("The is an instance that was started with the /new command line");
            //}
            //	SingleInstanceApplication.NewInstanceMessage += new NewInstanceMessageEventHandler(this.SingleInstanceApplication_NewInstanceMessage);
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            this.strExecutingAssembly = executingAssembly.GetName().Name + ", Version=" + executingAssembly.GetName().Version.ToString();
            if (!clsUtl.CONNECT_STATUS)
            {
                Form form = new FrmDBConnect();//F0002();
                form.ShowDialog();
            }
            this.strConnString = this.GetStringConnect();
            clsUtl.CONNECT_STRING = this.strConnString;
            this.LoadCaptionForControls();
            this.englishToolStripMenuItem.Checked = (Settings.Default.Language == "en-US");
            this.vietnameseToolStripMenuItem.Checked = (Settings.Default.Language != "en-US");
            this.SetStateSerialPortControl(false);
            this.bAutoOpenSerialPort = Settings.Default.AutoOpenSerialPort;
            this.iTimeRefreshData = Settings.Default.TimeRefreshData;
            this.iTimeReadSound = Settings.Default.TimeReadSound;
            this.iRegionHeight = Settings.Default.RegionHeight;
            this.iRoomHeight = Settings.Default.RoomHeight;
            this.iBedHeight = Settings.Default.BedHeight;
            this.iBedsPerRow = Settings.Default.BedsPerRow;
            this.iAllowDouble = (Settings.Default.AllowDoubleCall ? 1 : 0);
            try
            {
                TimeSendMail = Settings.Default.TimeSend.TimeOfDay;
            }
            catch (Exception ex)
            {
                TimeSendMail = null;
                MessageBox.Show("Không thể cài đặt được thời gian gửi thư điện tử. Vui lòng kiểm tra lại cấu hình.");
            }

            try
            {
                this.MySqlConnect = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                this.MySqlConnect.Open();
                this.SqlData = new MySqlDataClass(this.MySqlConnect);
                this.MyHi = this.SqlData.ReaderHospitalInfo(1);
                this.strHospitalName = this.MyHi.strHospitalName;
                base.WindowState = FormWindowState.Maximized;
                if (!this.First_Open)
                {
                    this.First_Open = true;
                    Form form2 = new FrmLogin();
                    form2.ShowDialog();
                }
                this.MyRs = this.SqlData.ReaderRegionsEx();
                this.LoadMainPanel(this.MyRs);
                this.MyBeds = this.LoadBedAttributes();
                this.LoadData();
                this.TrueDBGridFormat();
                this.LoadDefaultValue();

                this.SetRightUserMenu(clsUtl.RIGHT);
                if (this.bAutoOpenSerialPort)
                    this.OpenOrCloseSerialPort();

                Control.CheckForIllegalCrossThreadCalls = false;
                this.tmerResetDateTime.Enabled = true;
                FMAIN.timer5 = new System.Timers.Timer();
                FMAIN.timer5.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
                FMAIN.timer5.Interval = (double)this.iTimeRefreshData;
                FMAIN.timer5.Enabled = true;
                this.tmerQuetRepeatSound.Interval = this.iTimeReadSound;
                this.tmerQuetRepeatSound.Enabled = true;
                string folderName = Application.StartupPath + "\\Outputs";
                this.ClearFolder(folderName);
                this.tmerCheckSendMail.Enabled = true;
                FMAIN.tiSendData = new System.Timers.Timer();
                FMAIN.tiSendData.Elapsed += new ElapsedEventHandler(this.OnTimedSendDataEvent);
                FMAIN.tiSendData.Interval = (double)Settings.Default.TimeSendData;
                FMAIN.tiSendData.Enabled = true;

                //SqlCommand sqlCommand = new SqlCommand("sp_process_read_sound", this.MySqlConnect);
                //sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add("@iUserId", SqlDbType.Int).Value = clsUtl.USER_ID;
                //sqlCommand.Parameters.Add("@iAction", SqlDbType.Int).Value = 0; //xoa
                //sqlCommand.Parameters.Add("@vResult", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                //sqlCommand.ExecuteNonQuery();
                //sqlCommand.Dispose();

                //HoangHai
                player = new SoundPlayer();
                tmerFindSound.Enabled = true;

                tmerCheckSendMail.Enabled = false;
                if (Settings.Default.SendMail)
                    tmerCheckSendMail.Enabled = true;

                // InsertCallRequire("03", "009", "02");
                //   ParseToCommand("02 30 31 2C 30 30 31 2C 38 2C 30 31 2C 30 39 03");
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "FMAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
            }
        }

        private void InitializeSerialPortSettingsForControlValues()
        {
            this.strPortName = Settings.Default.PortName;
            this.strStopBits = Settings.Default.StopBits.ToString();
            this.strDataBits = Settings.Default.DataBits.ToString();
            this.strParity = Settings.Default.Parity.ToString();
            this.strBaudRate = Settings.Default.BaudRate.ToString();
            bool flag = false;
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                string a = portNames[i];
                if (a == Settings.Default.PortName)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                this.serialPortToolStripLabel.Text = Settings.Default.PortName;
                this.serialPortStatusToolStripStatusLabel.Text = Settings.Default.PortName;
            }
            else
            {
                this.statusToolStripStatusLabel.Text = "Error - InitializeSerialPortSettingsForControlValues: There are no COM Ports detected on this computer. Please install a COM Port and restart this app.";
            }
        }

        private void SaveSerialPortSettings()
        {
            Settings.Default.PortName = this.strPortName;
            Settings.Default.BaudRate = int.Parse(this.strBaudRate);
            Settings.Default.DataBits = int.Parse(this.strDataBits);
            Settings.Default.Parity = (Parity)Enum.Parse(typeof(Parity), this.strParity);
            Settings.Default.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.strStopBits);
            Settings.Default.Save();
        }

        private void SetStateSerialPortControl(bool b_open)
        {
            this.openToolStripMenuItem.Enabled = !b_open;
            this.closeToolStripMenuItem.Enabled = b_open;
            this.serialPortToolStripSplitButton.Image = (b_open ? this.openToolStripMenuItem.Image : this.closeToolStripMenuItem.Image);
        }

        private void OpenOrCloseSerialPort()
        {
            this.Cursor = Cursors.WaitCursor;
            string text = this.serialPortToolStripLabel.Text;
            if (this.comport.IsOpen)
            {
                this.comport.Close();
            }
            else
            {
                try
                {
                    this.comport.BaudRate = int.Parse(this.strBaudRate);
                    this.comport.DataBits = int.Parse(this.strDataBits);
                    this.comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.strStopBits);
                    this.comport.Parity = (Parity)Enum.Parse(typeof(Parity), this.strParity);
                    this.comport.PortName = this.serialPortToolStripLabel.Text;
                    this.comport.ReadTimeout = 500;
                    this.comport.WriteTimeout = 500;
                    this.comport.Open();
                }
                catch (Exception ex)
                {
                    this.statusToolStripStatusLabel.Text = "Error - OpenOrCloseSerialPort: " + ex.Message;
                }
            }
            this.SetStateSerialPortControl(this.comport.IsOpen);
            this.Cursor = Cursors.Default;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (this.comport.BytesToRead > 0)
            {
                this.blnSendData = false;
                int bytesToRead = this.comport.BytesToRead;
                byte[] array = new byte[bytesToRead];
                this.comport.Read(array, 0, bytesToRead);
                if (array.Length > 0)
                {
                    this.strRev = this.strRev + BitConverter.ToString(array) + "-";
                }
                int num = this.strRev.IndexOf("02");
                if (num > 0)
                {
                    this.strRev = this.strRev.Substring(num, this.strRev.Length - num);
                }
                num = this.strRev.IndexOf("02");
                int num2 = this.strRev.IndexOf("03");
                if (this.strRev.Contains("02") && this.strRev.Contains("03") && num < num2)
                {
                    string sCommand = this.strRev;
                    this.strRev = this.strRev.Substring(num2 + 3, this.strRev.Length - (num2 + 3));
                    this.ParseToCommand(sCommand);
                }
                this.blnSendData = true;
            }
        }

        private void ParseToCommand(string sCommand)
        {
            // MessageBox.Show(sCommand);
            int num = sCommand.IndexOf("02");
            int num2 = sCommand.IndexOf("03");
            if (num2 > num + 3)
            {
                sCommand = sCommand.Substring(num + 3, num2 - (num + 3));
                string text = clsString.HexString2Ascii(sCommand);
                string a = text.Substring(text.Length - 2, 2);
                string b = clsString.XOR(text.Substring(0, text.Length - 2)).Trim();
                if (a == b)
                {
                    if (this.ParseStringCallRequest(text))
                    {
                        // MessageBox.Show("bat dau tra ack");
                        // tra ack hai
                        for (int i = 0; i < Settings.Default.TimeRepeatSendACK; i++)
                        {
                            this.WriteData2Comport(this.sRegion, this.sACK);
                            Thread.Sleep(Settings.Default.TimeSleepAfterSendACK);
                        }
                        //  MessageBox.Show("ket thuc tra ack");
                        //  MessageBox.Show("bat dau logic");
                        // 
                        this.iShift = clsUtl.SHIFT_ID;
                        this.iUser = clsUtl.USER_ID;
                        string text2 = this.sType_Request;
                        if (text2 != null)
                        {
                            if (!(text2 == "4"))
                            {
                                if (!(text2 == "8"))
                                {
                                    if (text2 == "9")
                                        if (Settings.Default.ProcessTime)
                                        {
                                            string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 3);
                                            if (a2 == "Y")
                                            {
                                                this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): đã xử lý." });
                                                SqlCommand sqlCommand = new SqlCommand("sp_delete_call_require", this.MySqlConnect);
                                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                                sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = int.Parse(this.sRegion);
                                                sqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar, 10).Value = this.sRoom;
                                                sqlCommand.Parameters.Add("@BedID", SqlDbType.VarChar, 10).Value = this.sBed;
                                                sqlCommand.ExecuteNonQuery();
                                                sqlCommand.Dispose();
                                            }
                                        }
                                }
                                else
                                {
                                    if (Settings.Default.ProcessTime)
                                    {
                                        string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 2);
                                        this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): kết thúc." });
                                        SqlCommand sqlCommand = new SqlCommand("sp_delete_call_require", this.MySqlConnect);
                                        sqlCommand.CommandType = CommandType.StoredProcedure;
                                        sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = int.Parse(this.sRegion);
                                        sqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar, 10).Value = this.sRoom;
                                        sqlCommand.Parameters.Add("@BedID", SqlDbType.VarChar, 10).Value = this.sBed;
                                        sqlCommand.ExecuteNonQuery();
                                        sqlCommand.Dispose();
                                    }
                                    else
                                    {
                                        string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 5);
                                        this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): kết thúc." });
                                        SqlCommand sqlCommand = new SqlCommand("sp_delete_call_require", this.MySqlConnect);
                                        sqlCommand.CommandType = CommandType.StoredProcedure;
                                        sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = int.Parse(this.sRegion);
                                        sqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar, 10).Value = this.sRoom;
                                        sqlCommand.Parameters.Add("@BedID", SqlDbType.VarChar, 10).Value = this.sBed;
                                        sqlCommand.ExecuteNonQuery();
                                        sqlCommand.Dispose();
                                    }
                                    int num3 = this.ExistCallRequest();

                                    if (num3 <= 0)
                                    {
                                        this.WriteData2Comport(this.gsEquipment, "10");
                                        Thread.Sleep(1000);
                                    }
                                }
                            }
                            else
                            {
                                this.WriteData2Comport(this.gsEquipment, "07");
                                Thread.Sleep(1000);
                                string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 1);
                                if (a2 == "Y" | a2 == "E")
                                {
                                    this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): vừa gọi." });
                                    InsertCallRequire(sRegion, sRoom, sBed);
                                }
                            }
                        }
                    }
                }
                else
                {
                    // MessageBox.Show("ko dung ack");
                    this.WriteData2Comport(this.sRegion, this.sNAK);
                    Thread.Sleep(1000);
                }
            }
        }

        public void ParseToCommand_frmTest(string strCMD)
        {
            try
            {
                if (this.ParseStringCallRequest(strCMD))
                {
                    // tra ack hai
                    for (int i = 0; i < Settings.Default.TimeRepeatSendACK; i++)
                    {
                        this.WriteData2Comport(this.sRegion, this.sACK);
                        Thread.Sleep(Settings.Default.TimeSleepAfterSendACK);
                    }
                    // 
                    this.iShift = clsUtl.SHIFT_ID;
                    this.iUser = clsUtl.USER_ID;
                    string text2 = this.sType_Request;
                    if (text2 != null)
                    {
                        if (!(text2 == "4"))
                        {
                            if (!(text2 == "8"))
                            {
                                if (text2 == "9")
                                    if (Settings.Default.ProcessTime)
                                    {
                                        string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 3);
                                        if (a2 == "Y")
                                        {
                                            this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): đã xử lý." });
                                            SqlCommand sqlCommand = new SqlCommand("sp_delete_call_require", this.MySqlConnect);
                                            sqlCommand.CommandType = CommandType.StoredProcedure;
                                            sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = int.Parse(this.sRegion);
                                            sqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar, 10).Value = this.sRoom;
                                            sqlCommand.Parameters.Add("@BedID", SqlDbType.VarChar, 10).Value = this.sBed;
                                            sqlCommand.ExecuteNonQuery();
                                            sqlCommand.Dispose();
                                        }
                                    }
                            }
                            else
                            {
                                if (Settings.Default.ProcessTime)
                                {
                                    string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 2);
                                    if (a2 == "Y")
                                    {
                                        this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): kết thúc." });
                                        SqlCommand sqlCommand = new SqlCommand("sp_delete_call_require", this.MySqlConnect);
                                        sqlCommand.CommandType = CommandType.StoredProcedure;
                                        sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = int.Parse(this.sRegion);
                                        sqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar, 10).Value = this.sRoom;
                                        sqlCommand.Parameters.Add("@BedID", SqlDbType.VarChar, 10).Value = this.sBed;
                                        sqlCommand.ExecuteNonQuery();
                                        sqlCommand.Dispose();
                                    }
                                }
                                else
                                {
                                    string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 5);
                                    if (a2 == "Y")
                                    {
                                        this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): kết thúc." });
                                        SqlCommand sqlCommand = new SqlCommand("sp_delete_call_require", this.MySqlConnect);
                                        sqlCommand.CommandType = CommandType.StoredProcedure;
                                        sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = int.Parse(this.sRegion);
                                        sqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar, 10).Value = this.sRoom;
                                        sqlCommand.Parameters.Add("@BedID", SqlDbType.VarChar, 10).Value = this.sBed;
                                        sqlCommand.ExecuteNonQuery();
                                        sqlCommand.Dispose();
                                    }
                                }
                                int num3 = this.ExistCallRequest();
                                if (num3 <= 0)
                                    this.WriteData2Comport(this.gsEquipment, "10");
                            }
                        }
                        else
                        {
                            //tat quet lap lai
                            tmerQuetRepeatSound.Enabled = false;
                            this.WriteData2Comport(this.gsEquipment, "07");
                            string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 1);
                            if (a2 == "Y" | a2 == "E")
                                this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): vừa gọi." });

                            if (a2 == "Y")
                                InsertCallRequire(sRegion, sRoom, sBed);

                            //bat quet lap lai
                            tmerQuetRepeatSound.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// HoangHai
        /// luu suong database de goi doc am thanh
        /// </summary>
        /// <param name="sRegion"></param>
        /// <param name="sRoom"></param>
        /// <param name="sBed"></param>
        public void InsertCallRequire(string sRegion, string sRoom, string sBed)
        {
            ///luu yeu cau doc am thanh xuong db
            ///doc dua theo ten file
            ///tach cai folder ra rieng chi lay ten file
            ///đường dẫn tach ra rieng cho mỗi may config rieng nhau 
            ///khi doc lay duong dan file + ten file doc ra 
            try
            {
                //  MessageBox.Show(sRoom);
                clsSound clsSound = new clsSound();
                clsSound.SetSoundTemplate(sRoom);
                string soundStr = clsSound.GetSoundToPlay(sRegion, sRoom, sBed);

                if (!string.IsNullOrEmpty(soundStr))
                {
                    string str = (int.Parse(sRegion) + "|" + sRoom + "|" + int.Parse(sBed));
                    string sql = "select user_id from users where bedids like '" + str + ",%' or bedids like '%," + str + "' or bedids like '%," + str + ",%' or bedids like '" + str + "'";
                    var table = provider.execute(sql).Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        var hasMe = false;
                        sql = "";
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (int.Parse(table.Rows[i][0].ToString()) == clsUtl.USER_ID)
                                hasMe = true;

                            sql += "INSERT INTO [dbo].[N_CallRequires]([UserId],[bed_id],[room_id],[region_id],[Content],[CreatedDate],[IsNewCall])" +
                                  "VALUES(" + table.Rows[i][0].ToString() + ",'" + sBed + "','" + sRoom + "'," + int.Parse(sRegion) + ",N'" + soundStr + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1) ";

                        }
                        //if (hasMe)
                        //    playList.AddRange(soundStr.Split('|'));

                        if (!string.IsNullOrEmpty(sql))
                        {
                            SqlDataReader ad = provider.excuteQuery(sql);
                            ad.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PlaySound");
            }
        }

        private int ExistCallRequest()
        {
            int result;
            try
            {
                int num = (int)this.provider.excuteScalar("SELECT count(*) FROM  [dbo].[v_wait_currents]");
                result = num;
            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }
        private bool ParseStringCallRequest(string strInput)
        {
            bool result;
            try
            {
                var arr = strInput.Split(',');
                if (arr.Length == 5)
                {
                    sRegion = arr[0];
                    sRoom = arr[1];
                    sType_Request = arr[2];
                    sBed = arr[3];
                    sCheck_Sum = arr[4];
                    result = true;
                }
                else
                {
                    this.sRegion = "";
                    this.sRoom = "";
                    this.sEquipment = "";
                    this.sType_Request = "";
                    this.sBed = "";
                    this.sCheck_Sum = "";
                    result = false;
                }

                //int num = strInput.IndexOf(",");
                //this.sRegion = strInput.Substring(0, num);
                //int length = strInput.Length;
                //strInput = strInput.Substring(num + 1, length - num - 1);
                //int num2 = strInput.IndexOf(",");
                //this.sRoom = strInput.Substring(0, num2);
                //length = strInput.Length;
                //strInput = strInput.Substring(num2 + 1, length - num2 - 1);
                //int num3 = strInput.IndexOf(",");
                //this.sType_Request = strInput.Substring(0, num3);
                //length = strInput.Length;
                //strInput = strInput.Substring(num3 + 1, strInput.Length - num3 - 1);
                //int num4 = strInput.IndexOf(",");
                //this.sBed = strInput.Substring(0, num4);
                //length = strInput.Length;
                //strInput = strInput.Substring(num4 + 1, length - num4 - 1);
                //this.sCheck_Sum = strInput.Trim();
                //result = true;
            }
            catch (Exception)
            {
                this.sRegion = "";
                this.sRoom = "";
                this.sEquipment = "";
                this.sType_Request = "";
                this.sBed = "";
                this.sCheck_Sum = "";
                result = false;
            }
            return result;
        }
        public string SaveData(int iRegion, string sRoom, string sEquip, string sBed, int iShift, int iUser, int iAction)
        {
            string result;
            try
            {
                if (this.MySqlConnect.State == ConnectionState.Closed)
                {
                    this.MySqlConnect.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_call_details", this.MySqlConnect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = iRegion;
                sqlCommand.Parameters.Add("@vRoom", SqlDbType.NVarChar, 40).Value = sRoom;
                sqlCommand.Parameters.Add("@vBed", SqlDbType.NVarChar, 40).Value = sBed;
                sqlCommand.Parameters.Add("@vEquipment", SqlDbType.VarChar, 10).Value = this.sEquipment;
                sqlCommand.Parameters.Add("@iAction", SqlDbType.Int).Value = iAction;
                sqlCommand.Parameters.Add("@iShift", SqlDbType.Int).Value = iShift;
                sqlCommand.Parameters.Add("@iUser", SqlDbType.Int).Value = iUser;
                sqlCommand.Parameters.Add("@iAllowDouble", SqlDbType.Int).Value = this.iAllowDouble;
                sqlCommand.Parameters.Add("@vResult", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                sqlCommand.ExecuteNonQuery();
                string text = sqlCommand.Parameters["@vResult"].Value.ToString();
                result = text;
                sqlCommand.Dispose();
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
        private string SaveData2(int iRegion, string sRoom, string sEquip, string sBed, int iShift, int iUser, int iAction)
        {
            string result;
            try
            {
                if (this.MySqlConnect.State == ConnectionState.Closed)
                {
                    this.MySqlConnect.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_call_details_2", this.MySqlConnect);
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
                string text = sqlCommand.Parameters["@vResult"].Value.ToString();
                sqlCommand.Dispose();
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
                result = text;
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] result;
            if (s.Length % 2 != 0)
            {
                byte[] array = new byte[1];
                result = array;
            }
            else
            {
                byte[] array2 = new byte[s.Length / 2];
                for (int i = 0; i < s.Length; i += 2)
                {
                    array2[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
                }
                result = array2;
            }
            return result;
        }
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder stringBuilder = new StringBuilder(data.Length * 3);
            for (int i = 0; i < data.Length; i++)
            {
                byte value = data[i];
                stringBuilder.Append(Convert.ToString(value, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return stringBuilder.ToString().ToUpper();
        }
        private void SingleInstanceApplication_NewInstanceMessage(object sender, object message)
        {
            int num = (int)message;
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.WindowState = FormWindowState.Normal;
            }
            base.BringToFront();
            base.Activate();
        }
        private void LoadCaptionForControls()
        {
            this.Text = Properties.Resources.HTGSL;
            this.fileToolStripMenuItem.Text = Properties.Resources.File;
            this.connectToolStripMenuItem.Text = Properties.Resources.SetConnect;
            this.loginToolStripMenuItem.Text = Properties.Resources.Login;
            this.exitToolStripMenuItem.Text = Properties.Resources.Exit;
            this.viewToolStripMenuItem.Text = Properties.Resources.View;
            this.languageToolStripMenuItem.Text = Properties.Resources.Language;
            this.englishToolStripMenuItem.Text = Properties.Resources.English;
            this.vietnameseToolStripMenuItem.Text = Properties.Resources.Vietnamese;
            this.statisticsToolStripMenuItem.Text = Properties.Resources.Statistic;
            this.CallByDateTimeToolStripMenuItem.Text = Properties.Resources.CallbyTime;
            this.CallTopNToolStripMenuItem.Text = Properties.Resources.CallTopN;
            this.CallTimeGreaterToolStripMenuItem.Text = Properties.Resources.CallWaitOver;
            this.CallByShiftToolStripMenuItem.Text = Properties.Resources.CallbyShift;
            this.callByRegionToolStripMenuItem.Text = Properties.Resources.CallbyRegion;
            this.toolsToolStripMenuItem.Text = Properties.Resources.Tools;
            this.serialPortSettingsToolStripMenuItem.Text = Properties.Resources.SerialPortSettings + "...";
            this.equipmentToolStripMenuItem.Text = Properties.Resources.Equipment + "...";
            this.optionsToolStripMenuItem.Text = Properties.Resources.Options + "...";
            this.soundsToolStripMenuItem.Text = Properties.Resources.Sounds;
            this.soundTemplatesToolStripMenuItem.Text = Properties.Resources.SoundTemplates;
            this.mailListsToolStripMenuItem.Text = Properties.Resources.MailLists;
            this.mailScheduleToolStripMenuItem.Text = Properties.Resources.MailSchedule;
            this.mailSetupToolStripMenuItem.Text = Properties.Resources.MailSetup;
            this.systemToolStripMenuItem.Text = Properties.Resources.System;
            this.configManagerToolStripMenuItem.Text = Properties.Resources.ConfigManager;
            this.servicesToolStripMenuItem.Text = Properties.Resources.Services;
            this.departmentsToolStripMenuItem.Text = Properties.Resources.Departments;
            this.jobsToolStripMenuItem.Text = Properties.Resources.Jobs;
            this.employeesManagerToolStripMenuItem.Text = Properties.Resources.EmployeesManager;
            this.hospitalPropertiesToolStripMenuItem.Text = Properties.Resources.HospitalProperties + "...";
            this.usersToolStripMenuItem.Text = Properties.Resources.Users;
            this.userBedCallToolStripMenuItem.Text = Properties.Resources.RegisterListenEventFromBed;
            this.shiftToolStripMenuItem.Text = Properties.Resources.Shifts;
            this.workShiftToolStripMenuItem.Text = Properties.Resources.WorkShifts;
            this.rightsToolStripMenuItem.Text = Properties.Resources.Rights;
            this.functionsToolStripMenuItem.Text = Properties.Resources.Functions;
            this.rightFunctionToolStripMenuItem.Text = Properties.Resources.Right_Function;
            this.helpToolStripMenuItem.Text = Properties.Resources.Help_;
            this.aboutToolStripMenuItem.Text = Properties.Resources.About + " " + this.strExecutingAssembly;
            this.testToolStripMenuItem.Text = Properties.Resources.TestForm;
            this.clearAllCallToolStripMenuItem.Text = Properties.Resources.ClearAllCall;
            this.serialPortToolStripSplitButton.Text = Properties.Resources.SerialPort;
            this.openToolStripMenuItem.Text = Properties.Resources.Open;
            this.closeToolStripMenuItem.Text = Properties.Resources.Close;
            this.helpToolStripButton.Text = Properties.Resources.Help_;
            this.callRegionToolStripMenuItem.Text = Properties.Resources.Call + "...";
            this.regionDetailsToolStripMenuItem.Text = Properties.Resources.Details + "...";
            this.callRoomToolStripMenuItem.Text = Properties.Resources.Call + "...";
            this.roomDetailsToolStripMenuItem.Text = Properties.Resources.Details + "...";
            this.callBedToolStripMenuItem.Text = Properties.Resources.Call + "...";
            this.stopBedToolStripMenuItem.Text = Properties.Resources.Stop_;
            this.bedDetailsToolStripMenuItem.Text = Properties.Resources.Details + "...";
            this.toolStripMenuItemConfigEvent.Text = Properties.Resources.ConfigEvent;
            this.productsToolStripMenuItem.Text = Properties.Resources.product;
        }
        private void LoadData()
        {
            try
            {
                this.conn = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.ds = new DataSet();
                this.strSQL = "SELECT [id], [shift_name],[bed_call] ,[start_call],[interval], [region_id], [room_id], [bed_id], [room_name], [bed_name], [region_note], [room_note], [bed_note], [equipment] FROM [dbo].[v_call_currents]";
                this.da = new SqlDataAdapter(this.strSQL, this.conn);
                this.da.Fill(this.ds, "call_currents");
                this.c1TrueDBGrid1.DataSource = this.ds.Tables["call_currents"];
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - LoadData: " + ex.Message;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }
        private void TrueDBGridFormat()
        {
            this.c1TrueDBGrid1.AlternatingRows = true;
            this.c1TrueDBGrid1.BorderStyle = BorderStyle.Fixed3D;
            this.c1TrueDBGrid1.MarqueeStyle = MarqueeEnum.DottedCellBorder;
            this.c1TrueDBGrid1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
            this.c1TrueDBGrid1.Font = new Font("Arial", 10f, FontStyle.Regular);
            this.c1TrueDBGrid1.HeadingStyle.Font = new Font("Arial", 11f, FontStyle.Regular);
            this.c1TrueDBGrid1.HeadingStyle.ForeColor = Color.Purple;
            this.c1TrueDBGrid1.ColumnFooters = true;
            this.c1TrueDBGrid1.ExtendRightColumn = false;
            this.c1TrueDBGrid1.EmptyRows = true;
            this.c1TrueDBGrid1.RowHeight = 36;
            this.c1TrueDBGrid1.Splits[0].ColumnCaptionHeight = 34;
            this.c1TrueDBGrid1.Caption = "Danh sách sự kiện";
            this.c1TrueDBGrid1.CaptionStyle.Font = new Font("Arial", 14f, FontStyle.Regular);
            this.c1TrueDBGrid1.CaptionStyle.ForeColor = Color.Blue;
            this.c1TrueDBGrid1.CaptionHeight = 34;
            this.c1TrueDBGrid1.AllowAddNew = false;
            this.c1TrueDBGrid1.AllowDelete = false;
            this.c1TrueDBGrid1.AllowUpdate = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["id"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["shift_name"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["region_id"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["room_id"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["bed_id"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["room_name"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["bed_name"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["region_note"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["room_note"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["bed_note"].Visible = false;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["equipment"].Visible = false;
            this.c1TrueDBGrid1.Columns["bed_call"].Caption = "Thông tin";
            this.c1TrueDBGrid1.Columns["start_call"].Caption = "Thời gian gọi";
            this.c1TrueDBGrid1.Columns["start_call"].NumberFormat = "dd/MM/yyyy HH:mm:ss";
            this.c1TrueDBGrid1.Columns["interval"].Caption = "Thời lượng";
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["bed_call"].Width = 140;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["bed_call"].Style.WrapText = true;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["start_call"].Width = 100;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["start_call"].Style.WrapText = true;
            this.c1TrueDBGrid1.Splits[0].DisplayColumns["interval"].Width = 70;
            this.CountFooterMaster();
        }
        private void RefreshData()
        {
            try
            {
                this.conn = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.ds = new DataSet();
                this.strSQL = "SELECT [id], [shift_name], [bed_call] ,[start_call],[interval], [region_id], [room_id], [bed_id], [room_name], [bed_name], [region_note], [room_note], [bed_note], [equipment] FROM  [dbo].[v_call_currents]";
                this.da = new SqlDataAdapter(this.strSQL, this.conn);
                this.da.Fill(this.ds, "call_currents");
                this.c1TrueDBGrid1.SetDataBinding(this.ds.Tables["call_currents"], "", true);
                this.da.Dispose();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "RefreshData Error: " + ex.Message;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        private void LoadDefaultValue()
        {
            SqlDataReader sqlDataReader = this.provider.excuteQuery("SELECT [time] FROM [dbo].[MAIL_SCHEDULE] WHERE [active] = 1");
            while (sqlDataReader.Read())
            {
                this.strMailShedule = this.strMailShedule + "," + sqlDataReader["time"].ToString();
            }
            SqlDataReader sqlDataReader2 = this.provider.excuteQuery("select equip_code from equipments where active = 1 order by equip_id");
            while (sqlDataReader2.Read())
            {
                this.gsEquipment = sqlDataReader2["equip_code"].ToString();
            }
            sqlDataReader.Close();
            sqlDataReader2.Close();
        }
        private void FMAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Settings.Default.EndAllCall)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa tất cả sự kiện ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.conn = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                        if (this.conn.State == ConnectionState.Closed)
                            this.conn.Open();

                        var sqlQuery = string.Empty;
                        if (clsUtl.UserBedIds != null && clsUtl.UserBedIds.Count > 0)
                        {
                            SqlDataReader ad = null;
                            for (int i = 0; i < clsUtl.UserBedIds.Count; i++)
                            {
                                var obj = clsUtl.UserBedIds[i].Split('|');
                                sqlQuery += " UPDATE dbo.CALL_DETAILS    SET[process_time] = GETDATE() ";
                                sqlQuery += ",[end_call] = GETDATE(),[wait_interval] =  DATEDIFF(ss, [start_call], GETDATE()) ";
                                sqlQuery += ",[time_interval] =  DATEDIFF(ss, [start_call], GETDATE()) ";
                                sqlQuery += "WHERE CONVERT(varchar(10),[start_call], 111) <= convert(varchar(10), GETDATE(), 111) ";
                                sqlQuery += "AND end_call is null and [bed_id] = " + Convert.ToInt32(obj[2]) + " and [region_id] = " + Convert.ToInt32(obj[0]);
                                sqlQuery += "    delete from [N_CallRequires] where [region_id] = " + Convert.ToInt32(obj[0]) + " and [bed_id] = " + Convert.ToInt32(obj[2]) + "   ";
                            }
                            ad = provider.excuteQuery(sqlQuery);
                            ad.Dispose();
                        }
                    }
                }
                if (this.MySqlConnect != null)
                {
                    this.MySqlConnect.Close();
                    this.tmerResetDateTime.Enabled = false;
                    this.timer2.Enabled = false;
                    if (this.comport.IsOpen)
                        this.comport.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void tmerResetDateTime_Tick(object sender, EventArgs e)
        {
            this.clockToolStripStatusLabel.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void serialPortSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.The_strPortName = this.strPortName;
            form.The_strBaudRate = this.strBaudRate;
            form.The_strParity = this.strParity;
            form.The_strDataBits = this.strDataBits;
            form.The_strStopBits = this.strStopBits;
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.serialPortToolStripLabel.Text = form.The_strPortName;
                this.serialPortStatusToolStripStatusLabel.Text = form.The_strPortName;
                this.strPortName = form.The_strPortName;
                this.strBaudRate = form.The_strBaudRate;
                this.strParity = form.The_strParity;
                this.strDataBits = form.The_strDataBits;
                this.strStopBits = form.The_strStopBits;
                this.SaveSerialPortSettings();
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenOrCloseSerialPort();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenOrCloseSerialPort();
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   Form form = new F0001();
            Form form = new FConfig();
            form.Show();
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Language != "en-US")
            {
                Settings.Default.Language = "en-US";
                Settings.Default.Save();
                MyMsgBox.MsgInformation(Properties.Resources.ConfirmMessage, Properties.Resources.ConfirmTitle);
                this.Restart(this);
            }
        }
        private void vietnameseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Language != "vi-VN")
            {
                Settings.Default.Language = "vi-VN";
                Settings.Default.Save();
                MyMsgBox.MsgInformation(Properties.Resources.ConfirmMessage, Properties.Resources.ConfirmTitle);
                this.Restart(this);
            }
        }
        public void Restart(FMAIN form)
        {
            string fileName = Path.Combine(Application.ExecutablePath, "");
            form.Close();
            form.Dispose();
            Process process = Process.Start(fileName);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        private void configManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SqlData.IsOpen())
                {
                    new FrmConfigManager
                    {
                        TheSqlData = this.SqlData
                    }.Show(this);
                }
            }
            catch (Exception ex)
            {
                MyMsgBox.MsgError(ex.Message);
            }
        }
        private void hospitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int num = 1;
            HospitalInfo hospitalInfo = this.SqlData.ReaderHospitalInfo(num);
            bool flag = hospitalInfo != null;
            string text = (hospitalInfo == null) ? "" : hospitalInfo.strHospitalName;
            string text2 = (hospitalInfo == null) ? "" : hospitalInfo.strAddress;
            string text3 = (hospitalInfo == null) ? "" : hospitalInfo.strWebsite;
            string text4 = (hospitalInfo == null) ? "" : hospitalInfo.strEmail;
            string text5 = (hospitalInfo == null) ? "" : hospitalInfo.strPhone;
            string text6 = (hospitalInfo == null) ? "" : hospitalInfo.strFax;
            string text7 = (hospitalInfo == null) ? "" : hospitalInfo.strNote;
            Form8 form = new Form8();
            form.bModify = flag;
            form.The_iHospitalID = num;
            form.The_strHospitalName = text;
            form.The_strAddress = text2;
            form.The_strWebsite = text3;
            form.The_strEmail = text4;
            form.The_strPhone = text5;
            form.The_strFax = text6;
            form.The_strNote = text7;
            if (form.ShowDialog() == DialogResult.OK)
            {
                num = form.The_iHospitalID;
                text = form.The_strHospitalName;
                text2 = form.The_strAddress;
                text3 = form.The_strWebsite;
                text4 = form.The_strEmail;
                text5 = form.The_strPhone;
                text6 = form.The_strFax;
                text7 = form.The_strNote;
                if (!flag)
                {
                    if (this.SqlData.InsertHospitalInfo(num, text, text2, text3, text4, text5, text6, text7))
                    {
                    }
                }
                else
                {
                    if (this.SqlData.UpdateHospitalInfo(num, text, text2, text3, text4, text5, text6, text7))
                    {
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }
        private void employeesManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SqlData.IsOpen())
                {
                    new Form10
                    {
                        TheSqlData = this.SqlData
                    }.Show(this);
                }
            }
            catch (Exception ex)
            {
                MyMsgBox.MsgError(ex.Message);
            }
        }
        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SqlData.IsOpen())
                {
                    new Form11
                    {
                        TheSqlData = this.SqlData
                    }.Show(this);
                }
            }
            catch (Exception ex)
            {
                MyMsgBox.MsgError(ex.Message);
            }
        }
        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SqlData.IsOpen())
                {
                    new Form13
                    {
                        TheSqlData = this.SqlData
                    }.Show(this);
                }
            }
            catch (Exception ex)
            {
                MyMsgBox.MsgError(ex.Message);
            }
        }
        private int GetHeightOfRegion(int i_region_idx)
        {
            int num = this.iRegionHeight;
            RegionExInfo regionExInfo = this.MyRs[i_region_idx];
            for (int i = 0; i < regionExInfo.Rooms.Count; i++)
            {
                num += this.GetHeightOfRoom(i_region_idx, i);
            }
            return num;
        }
        private int GetHeightOfRoom(int i_region_idx, int i_room_idx)
        {
            int num = this.iRoomHeight;
            RoomExInfo roomExInfo = this.MyRs[i_region_idx].Rooms[i_room_idx];
            num += roomExInfo.Beds.Count / this.iBedsPerRow * this.iBedHeight;
            return num + ((roomExInfo.Beds.Count % this.iBedsPerRow == 0) ? 0 : this.iBedHeight);
        }
        private void LoadMainPanel(RegionExArray Rs)
        {
            int num = 0;
            for (int i = 0; i < Rs.Count; i++)
            {
                RegionExInfo regionExInfo = Rs[i];
                Panel panel = new Panel();
                panel.Name = "pnRegionM" + i.ToString();
                panel.BackColor = Color.White;
                panel.Tag = regionExInfo.iRegionID.ToString("00");
                int heightOfRegion = this.GetHeightOfRegion(i);
                panel.Size = new Size(this.mainPanel.Width, heightOfRegion);
                panel.Location = new Point(0, num);
                num += heightOfRegion;
                Panel panel2 = new Panel();
                panel2.Name = "pnRegionH" + i.ToString();
                panel2.BackColor = Color.Gray;
                panel2.Tag = regionExInfo.iRegionID.ToString("00");
                panel2.Location = new Point(0, 0);
                panel2.Size = new Size(this.mainPanel.Width, this.iRegionHeight);
                panel2.Paint += new PaintEventHandler(this.pnRegionHi_Paint);
                panel2.MouseDown += new MouseEventHandler(this.pnRegionHi_MouseDown);
                Panel panel3 = new Panel();
                panel3.Name = "pnRegionD" + i.ToString();
                panel3.BackColor = Color.White;
                panel3.Tag = regionExInfo.iRegionID.ToString("00");
                panel3.Location = new Point(0, this.iRegionHeight);
                panel3.Size = new Size(this.mainPanel.Width, heightOfRegion - this.iRegionHeight);
                panel3.Resize += new EventHandler(this.pnRegionDi_Resize);
                int num2 = 0;
                for (int j = 0; j < regionExInfo.Rooms.Count; j++)
                {
                    int heightOfRoom = this.GetHeightOfRoom(i, j);
                    Panel panel4 = new Panel();
                    panel4.Name = "pnRoomH" + i.ToString("00") + j.ToString("00");
                    panel4.BackColor = Color.Silver;
                    panel4.Tag = regionExInfo.iRegionID.ToString("00") + regionExInfo.Rooms[j].iRoomID.ToString("00");
                    panel4.Location = new Point(0, num2);
                    panel4.Size = new Size(panel3.Width, this.iRoomHeight);
                    panel4.Paint += new PaintEventHandler(this.pnRoomHj_Paint);
                    panel4.MouseDown += new MouseEventHandler(this.pnRoomHj_MouseDown);
                    panel3.Controls.Add(panel4);
                    Panel panel5 = new Panel();
                    panel5.Name = "pnRoomD" + i.ToString("00") + j.ToString("00");
                    panel5.BackColor = Color.White;
                    panel5.Tag = regionExInfo.iRegionID.ToString("00") + regionExInfo.Rooms[j].iRoomID.ToString("00");
                    panel5.Location = new Point(0, num2 + this.iRoomHeight);
                    panel5.Size = new Size(panel3.Width, heightOfRoom - this.iRoomHeight);
                    panel5.Paint += new PaintEventHandler(this.pnRoomDj_Paint);
                    panel5.MouseDown += new MouseEventHandler(this.pnRoomDj_MouseDown);
                    panel3.Controls.Add(panel5);
                    num2 += heightOfRoom;
                }
                panel.Resize += new EventHandler(this.pnRegionMi_Resize);
                panel.Controls.Add(panel2);
                panel.Controls.Add(panel3);
                this.mainPanel.Controls.Add(panel);
            }
            this.ScrollY(this.mainPanel, this.mainVScrollBar, this.MyRs);
        }
        private void ScrollY(Panel pn, VScrollBar vsb, RegionExArray Rs)
        {
            int num = 0;
            int num2 = 22;
            int height = pn.Height;
            int num3 = num + num2;
            for (int i = 0; i < Rs.Count; i++)
            {
                num3 += this.GetHeightOfRegion(i);
            }
            bool enabled = false;
            if (num3 > height)
            {
                enabled = true;
                vsb.Minimum = 0;
                vsb.Maximum = num3 - height + num2;
            }
            else
            {
                vsb.Value = 0;
            }
            vsb.Enabled = enabled;
        }
        private void mainVScrollBar_ValueChanged(object sender, EventArgs e)
        {
            VScrollBar vScrollBar = (VScrollBar)sender;
            Panel panel = this.mainPanel;
            int value = vScrollBar.Value;
            int num = 0;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                Panel panel2 = (Panel)panel.Controls[i];
                panel2.Location = new Point(0, num - value);
                num += panel2.Height;
            }
        }
        private void mainPanel_Resize(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            VScrollBar vsb = this.mainVScrollBar;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                Panel panel2 = (Panel)panel.Controls[i];
                panel2.Size = new Size(panel.Width, panel2.Height);
            }
            this.ScrollY(panel, vsb, this.MyRs);
        }
        private void FillRectangleV(Graphics g, Rectangle rtg, Color colorLeft, Color colorRight)
        {
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rtg, colorLeft, colorRight, 0f, false);
            g.FillRectangle(linearGradientBrush, rtg);
            linearGradientBrush.Dispose();
        }
        private void pnRegionHi_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics graphics = e.Graphics;
            this.FillRectangleV(graphics, new Rectangle(0, 0, panel.Width, panel.Height), Color.Black, Color.White);
            Font font = new Font("Tahoma", 12f, FontStyle.Bold);
            Brush yellow = Brushes.Yellow;
            int i_region_id = int.Parse(panel.Tag.ToString().Substring(0, 2));
            int index = this.MyRs.GetIndex(i_region_id);
            string strRegionName = this.MyRs[index].strRegionName;
            SizeF sizeF = graphics.MeasureString(strRegionName, font);
            graphics.DrawString(strRegionName, font, yellow, new Point(8, (panel.Height - (int)sizeF.Height) / 2));
            graphics.Dispose();
        }
        private void pnRegionHi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int x = e.X;
                int y = e.Y;
                Panel panel = (Panel)sender;
                int i_region_id = int.Parse(panel.Tag.ToString().Substring(0, 2));
                int index = this.MyRs.GetIndex(i_region_id);
                this.regionContextMenuStrip.Show(panel, e.X, e.Y);
            }
        }
        private void pnRoomHj_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics graphics = e.Graphics;
            this.FillRectangleV(graphics, new Rectangle(0, 0, panel.Width, panel.Height), Color.FromArgb(62, 107, 240), Color.White);
            Font font = new Font("Tahoma", 11.25f, FontStyle.Bold);
            Brush purple = Brushes.Purple;
            int i_region_id = int.Parse(panel.Tag.ToString().Substring(0, 2));
            int i_room_id = int.Parse(panel.Tag.ToString().Substring(2, 2));
            int index = this.MyRs.GetIndex(i_region_id);
            int index2 = this.MyRs[index].Rooms.GetIndex(i_room_id);
            string strRoomNote = this.MyRs[index].Rooms[index2].strRoomNote;
            SizeF sizeF = graphics.MeasureString(strRoomNote, font);
            graphics.DrawString(strRoomNote, font, purple, new Point(24, (panel.Height - (int)sizeF.Height) / 2));
            graphics.Dispose();
        }
        private void pnRoomHj_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int x = e.X;
                int y = e.Y;
                Panel panel = (Panel)sender;
                int i_region_id = int.Parse(panel.Tag.ToString().Substring(0, 2));
                int i_room_id = int.Parse(panel.Tag.ToString().Substring(2, 2));
                int index = this.MyRs.GetIndex(i_region_id);
                RegionExInfo regionExInfo = this.MyRs[index];
                int index2 = regionExInfo.Rooms.GetIndex(i_room_id);
                this.roomContextMenuStrip.Show(panel, e.X, e.Y);
            }
        }
        private void pnRoomDj_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Font font = new Font("Tahoma", 10.25f, FontStyle.Bold);
            Brush black = Brushes.Black;
            int i_region_id = int.Parse(panel.Tag.ToString().Substring(0, 2));
            int i_room_id = int.Parse(panel.Tag.ToString().Substring(2, 2));
            int index = this.MyRs.GetIndex(i_region_id);
            int index2 = this.MyRs[index].Rooms.GetIndex(i_room_id);
            BedExArray beds = this.MyRs[index].Rooms[index2].Beds;
            int width = panel.Width;
            int height = panel.Height;
            int num = this.iBedHeight;
            int num2 = width / this.iBedsPerRow;
            Graphics graphics = e.Graphics;
            for (int i = 0; i < beds.Count; i++)
            {
                Rectangle rect = new Rectangle(i % this.iBedsPerRow * num2, i / this.iBedsPerRow * num, num2, num);
                this.DrawBed(graphics, rect, beds[i]);
            }
            graphics.Dispose();
        }
        private void DrawBed(Graphics g, Rectangle rect, BedExInfo Bi)
        {
            string strBedNote = Bi.strBedNote;
            if (Bi.bInstall)
            {
                switch (Bi.iStateID)
                {
                    case 0:
                        this.DrawRectangle(g, rect, strBedNote, Brushes.Black);
                        break;

                    case 1:
                        this.DrawRectangle(g, rect, strBedNote, Brushes.Black);
                        break;
                }
            }
            else
            {
                this.DrawRectangle(g, rect, strBedNote, Brushes.Black);
            }
        }
        private void pnRoomDj_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            Panel panel = (Panel)sender;
            int i_region_id = int.Parse(panel.Tag.ToString().Substring(0, 2));
            int i_room_id = int.Parse(panel.Tag.ToString().Substring(2, 2));
            int index = this.MyRs.GetIndex(i_region_id);
            RegionExInfo regionExInfo = this.MyRs[index];
            int index2 = regionExInfo.Rooms.GetIndex(i_room_id);
            RoomExInfo roomExInfo = regionExInfo.Rooms[index2];
            BedExArray beds = roomExInfo.Beds;
            int width = panel.Width;
            int height = panel.Height;
            int num = this.iBedHeight;
            int num2 = width / this.iBedsPerRow;
            int num3 = y / num;
            int num4 = x / num2;
            int num5 = num3 * this.iBedsPerRow + num4;
            if (num5 < beds.Count)
            {
                BedExInfo bedExInfo = beds[num5];
                string caption = string.Concat(new string[]
                {
                    regionExInfo.iRegionID.ToString(),
                    ". ",
                    regionExInfo.strRegionName,
                    "\n",
                    roomExInfo.iRoomID.ToString(),
                    ". ",
                    roomExInfo.strRoomName,
                    "\n",
                    bedExInfo.iBedID.ToString(),
                    ". ",
                    bedExInfo.strBedName
                });
                this.myToolTip.SetToolTip(panel, caption);
            }
            else
            {
                this.myToolTip.SetToolTip(panel, null);
            }
        }
        private void pnRoomDj_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void DrawRectangle(Graphics grfx, Rectangle rect, string strText, Brush brush)
        {
            this.FillRectangleV(grfx, new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2), Color.FromArgb(160, 180, 240), Color.White);
            Font font = new Font("Tahoma", 10.25f, FontStyle.Bold);
            SizeF sizeF = grfx.MeasureString(strText, font);
            grfx.DrawString(strText, font, brush, new PointF((float)(rect.Left + 10), (float)rect.Top + ((float)rect.Height - sizeF.Height) / 2f));
        }
        private void pnRegionMi_Resize(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                Panel panel2 = (Panel)panel.Controls[i];
                panel2.Size = new Size(panel.Width, panel2.Height);
            }
        }
        private void pnRegionDi_Resize(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                Panel panel2 = (Panel)panel.Controls[i];
                panel2.Size = new Size(panel.Width, panel2.Height);
            }
        }
        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Graphics graphics = e.Graphics;
            this.FillRectangleV(graphics, new Rectangle(0, 0, panel.Width, panel.Height), Color.Navy, Color.White);
            Font font = new Font("Tahoma", 12f, FontStyle.Bold);
            Brush white = Brushes.White;
            SizeF sizeF = graphics.MeasureString(this.strHospitalName, font);
            graphics.DrawString(this.strHospitalName, font, white, new PointF(10f, ((float)panel.Height - sizeF.Height) / 2f));
            graphics.Dispose();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void Room_Paint(int iRegionID, int iRoomID, int iBedID, string ColorName)
        {
            int index = this.MyRs.GetIndex(iRegionID);
            if (index != -1)
            {
                int index2 = this.MyRs[index].Rooms.GetIndex(iRoomID);
                if (index2 != -1)
                {
                    int index3 = this.MyRs[index].Rooms[index2].Beds.GetIndex(iBedID);
                    if (index3 != -1)
                    {
                        Panel panel = (Panel)this.mainPanel.Controls[index].Controls[1].Controls[index2 * 2 + 1];
                        Graphics graphics = panel.CreateGraphics();
                        int width = panel.Width;
                        int num = this.iBedHeight;
                        int num2 = width / this.iBedsPerRow;
                        Rectangle rect = new Rectangle(index3 % this.iBedsPerRow * num2, index3 / this.iBedsPerRow * num, num2, num);
                        string strBedNote = this.MyRs[index].Rooms[index2].Beds[index3].strBedNote;
                        if (ColorName == "Red")
                        {
                            this.DrawRectangle(graphics, rect, strBedNote, Brushes.Red);
                        }
                        else
                        {
                            this.DrawRectangle(graphics, rect, strBedNote, Brushes.Black);
                        }
                        graphics.Dispose();
                    }
                }
            }
        }
        private void Rooms_Paint_Red()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString))
                {
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlConnection.Open();
                        sqlCommand.CommandText = "SELECT [region_id], [room_id],[bed_id] FROM  [dbo].[BEDS]";
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                this.Room_Paint(int.Parse(sqlDataReader["region_id"].ToString()), int.Parse(sqlDataReader["room_id"].ToString()), int.Parse(sqlDataReader["bed_id"].ToString()), "");
                            }
                        }
                    }
                }
                using (SqlConnection sqlConnection2 = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString))
                {
                    using (SqlCommand sqlCommand2 = sqlConnection2.CreateCommand())
                    {
                        sqlConnection2.Open();
                        sqlCommand2.CommandText = "SELECT [region_id], [room_id], [bed_id] FROM  [dbo].[v_call_currents]";
                        using (SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader())
                        {
                            while (sqlDataReader2.Read())
                            {
                                this.Room_Paint(int.Parse(sqlDataReader2["region_id"].ToString()), int.Parse(sqlDataReader2["room_id"].ToString()), int.Parse(sqlDataReader2["bed_id"].ToString()), "Red");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Rooms_Paint_Red Error: " + ex.Message;
            }
        }
        private void FMAIN_Activated(object sender, EventArgs e)
        {
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new F9998();
            form.Show();
        }

        private void userBedCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FrmUserBedCall(MyRs);
            form.Show();
        }
        private void workShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new F0015();
            form.Show();
        }
        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new F0004();
            form.Show();
        }
        private void soundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F0016();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "soundsToolStripMenuItem_Click");
            }
        }
        private void soundTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F0017();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "soundTemplatesToolStripMenuItem_Click");
            }
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Form form = new F0000();
                Form form = new FrmLogin();
                form.ShowDialog();
                this.SetRightUserMenu(clsUtl.RIGHT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "loginToolStripMenuItem_Click");
            }
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
        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void stopBedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.sRegion = this.c1TrueDBGrid1.Columns["region_id"].Value.ToString();
                this.sRoom = this.c1TrueDBGrid1.Columns["room_name"].Value.ToString();
                this.sBed = this.c1TrueDBGrid1.Columns["bed_name"].Value.ToString();
                this.sEquipment = this.c1TrueDBGrid1.Columns["equipment"].Value.ToString();
                int num = int.Parse(this.c1TrueDBGrid1.Columns["room_id"].Value.ToString());
                int num2 = int.Parse(this.c1TrueDBGrid1.Columns["bed_id"].Value.ToString());
                this.sType_Request = "8";
                this.iAction = 5;
                this.iShift = clsUtl.SHIFT_ID;
                this.iUser = clsUtl.USER_ID;
                if (this.sRegion.Length > 0 && this.sRoom.Length > 0 && this.sBed.Length > 0)
                {
                    string a = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, this.iAction);
                    if (a == "Y")
                    {
                        this.statusToolStripStatusLabel.Text = string.Concat(new string[]
                        {
                            "(",
                            this.sRegion,
                            ", ",
                            this.sRoom,
                            ", ",
                            this.sBed,
                            "): vừa kết thúc"
                        });
                        SqlCommand sqlCommand = new SqlCommand("sp_delete_call_require", this.MySqlConnect);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@iRegion", SqlDbType.Int).Value = int.Parse(this.sRegion);
                        sqlCommand.Parameters.Add("@RoomID", SqlDbType.VarChar, 10).Value = this.sRoom;
                        sqlCommand.Parameters.Add("@BedID", SqlDbType.VarChar, 10).Value = this.sBed;
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                    }
                    int num3 = this.ExistCallRequest();
                    if (num3 <= 0)
                    {
                        this.WriteData2Comport(this.gsEquipment, "10");
                    }
                }
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error stopBedToolStripMenuItem_Click :" + ex.Message;
            }
        }
        public bool WriteData2Comport(string s_Region, string s_Room, string s_Equipment, string s_Type_Request, string s_Bed)
        {
            bool result;
            try
            {
                if (s_Region.Length == 1)
                {
                    s_Region = "0" + s_Region;
                }
                string text = string.Concat(new string[]
                {
                    s_Region,
                    ",",
                    s_Room,
                    ",",
                    s_Equipment,
                    ",",
                    s_Type_Request,
                    ",",
                    s_Bed,
                    ","
                });
                string str = clsString.XOR(text);
                text += str;
                text = "02" + clsString.Ascii2HexStringNull(text) + "03";
                byte[] array = this.HexStringToByteArray(text);
                this.comport.Write(array, 0, array.Length);
                result = true;
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error stopBedToolStripMenuItem_Click :" + ex.Message;
                result = false;
            }
            return result;
        }
        public void WriteData2Comport(string s_Equipment, string s_OnOff_107)
        {
            try
            {
                if (s_Equipment.Length == 1)
                {
                    s_Equipment = "0" + s_Equipment;
                }
                string text = s_Equipment + "," + s_OnOff_107 + ",";
                string str = clsString.XOR(text);
                text += str;
                text = "02 " + clsString.Ascii2HexStringNull(text) + " 03";
                byte[] array = this.HexStringToByteArray(text);
                this.comport.Write(array, 0, array.Length);
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error stopBedToolStripMenuItem_Click :" + ex.Message;
            }
        }
        public void WriteData2Comport(string s_Input)
        {
            try
            {
                string str = clsString.XOR(s_Input);
                string text = s_Input + str;
                text = "02 " + clsString.Ascii2HexStringNull(text) + " 03";
                byte[] array = this.HexStringToByteArray(text);
                this.comport.Write(array, 0, array.Length);
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error stopBedToolStripMenuItem_Click :" + ex.Message;
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }
        private void c1TrueDBGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FMAIN.timer5.Stop();
                int x = e.X;
                int y = e.Y;
                this.bedContextMenuStrip.Show(x, y);
            }
        }
        private void CountFooterMaster()
        {
            this.c1TrueDBGrid1.Columns["bed_call"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
            isFinishDrawData = true;
        }

        /// <summary>
        /// HoangHai
        /// </summary>
        /// <param name="s_Region"></param>
        /// <param name="s_Room"></param>
        /// <param name="s_Bed"></param>
        private void PlaySound(string s_Region, string s_Room, string s_Bed)
        {
            try
            {
                clsSound clsSound = new clsSound();
                clsSound.SetSoundTemplate(s_Room);
                // clsSound.PlaySoundWav(s_Region, s_Room, s_Bed);
                string str = clsSound.GetSoundToPlay(s_Region, s_Room, s_Bed);
                if (!string.IsNullOrEmpty(str))
                    playList.AddRange(str.Split('|'));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PlaySound");
            }
        }

        /// <summary>
        /// HoangHai
        /// quét tim file am thanh va đọc goi moi
        /// </summary>
        /// 
        private void tmerFindSound_Tick(object sender, EventArgs e)
        {
            FindSoundToRead(1);
        }

        private void FindSoundToRead(int isNewCall)
        {
            try
            {
                #region Ktra xem co yeu cau doc am thanh hay khong
                string sql = "select * from N_CallRequires where UserId =" + clsUtl.USER_ID + " and IsNewCall=" + isNewCall + " order by CreatedDate";
                var table = provider.execute(sql).Tables[0];
                if (table.Rows.Count > 0)
                {
                    sql = "";
                    for (int i = 0; i < table.Rows.Count; i++)
                        playList.AddRange(table.Rows[i]["Content"].ToString().Split('|'));

                    if (isNewCall == 1)
                    {
                        SqlCommand sqlCommand = new SqlCommand("sp_process_read_sound", this.MySqlConnect);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@iUserId", SqlDbType.Int).Value = clsUtl.USER_ID;

                        sqlCommand.Parameters.Add("@iAction", SqlDbType.Int).Value = 1; //change to waiting

                        sqlCommand.Parameters.Add("@vResult", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                    }
                }
                table.Dispose();
                #endregion

                if (isFinishRead && playList.Count > 0)
                {
                    playThread = new Thread(ReadSound);
                    playThread.Start();
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// HoangHai
        /// Doc am thanh
        /// </summary>
        private void ReadSound()
        {
            try
            {
                isFinishRead = false;
                while (playList.Count > 0)
                {
                    playList[0] = Settings.Default.SoundPath + "\\" + playList[0];
                    if (!string.IsNullOrEmpty(playList[0]) && File.Exists(playList[0]))
                    {
                        player.SoundLocation = (playList[0]);
                        int iTime = SoundInfo.GetSoundLength(player.SoundLocation.Trim()) - 0;
                        player.Play();
                        Thread.Sleep(iTime);
                        playList.Remove(playList[0]);
                    }
                    else
                    {
                        playList.Remove(playList[0]);
                        //  errorsms = "Không tìm được tệp âm thanh khóa ngưng cấp phiếu dịch vụ. Vui lòng kiểm tra lại.";
                    }
                }
                isFinishRead = true;
                playThread.Abort();
            }
            catch (Exception ex)
            {
            }
        }

        private void PlaySound()
        {
            try
            {
                DataProvider dataProvider = new DataProvider();
                this.strSQL = "SELECT [region_id],[room_name], [bed_name] FROM  [dbo].[v_wait_currents]";
                SqlDataReader sqlDataReader = dataProvider.excuteQuery(this.strSQL);
                while (sqlDataReader.Read())
                {
                    string text = sqlDataReader["region_id"].ToString();
                    if (text.Length < 2)
                    {
                        text = "0" + text;
                    }
                    string soundTemplate = sqlDataReader["room_name"].ToString();
                    string text2 = sqlDataReader["bed_name"].ToString();
                    this.bIsSounding = true;
                    using (clsSound clsSound = new clsSound())
                    {
                        clsSound.SetSoundTemplate(soundTemplate);
                        clsSound.PlaySoundWav(text, soundTemplate, text2);
                    }
                }
                this.bIsSounding = false;
            }
            catch (Exception)
            {
                this.bIsSounding = false;
            }
        }
        private void CallByDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmRDateToDate();// new FRCBT();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - CallByDateTimeToolStripMenuItem_Click: " + ex.Message;
            }
        }
        private void CallTopNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmRTopN();// FRCTN();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - CallTopNToolStripMenuItem_Click: " + ex.Message;
            }
        }
        private void CallTimeGreaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmROver();// FRCTO();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - CallTimeGreaterToolStripMenuItem_Click: " + ex.Message;
            }
        }
        private void CallByShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmRShift();// FRCTS();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - CallByShiftToolStripMenuItem_Click: " + ex.Message;
            }
        }
        private void SetRightUserMenu(int iUserRight)
        {
            string b = "";
            bool enabled = false;
            DataProvider dataProvider = new DataProvider();
            string sqlString = "SELECT dbo.RIGHT_FUNCTIONS.function_id, dbo.FUNCTIONS.function_code, dbo.RIGHT_FUNCTIONS.active FROM dbo.RIGHT_FUNCTIONS INNER JOIN dbo.FUNCTIONS ON dbo.RIGHT_FUNCTIONS.function_id = dbo.FUNCTIONS.function_id WHERE (dbo.RIGHT_FUNCTIONS.right_id = " + iUserRight + ")";
            SqlDataReader sqlDataReader = dataProvider.excuteQuery(sqlString);
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    if (sqlDataReader["function_code"].ToString() == "")
                    {
                        b = "";
                    }
                    else
                    {
                        b = sqlDataReader["function_code"].ToString();
                    }
                    enabled = (!(sqlDataReader["active"].ToString() == "") && (bool)sqlDataReader["active"]);
                    foreach (ToolStripMenuItem toolStripMenuItem in this.menuStrip1.Items)
                    {
                        for (int i = 0; i < toolStripMenuItem.DropDownItems.Count; i++)
                        {
                            if (toolStripMenuItem.DropDownItems[i].Name.ToString() == b)
                            {
                                toolStripMenuItem.DropDownItems[i].Enabled = enabled;
                            }
                        }
                    }
                    for (int i = 0; i < this.bedContextMenuStrip.Items.Count; i++)
                    {
                        if (this.bedContextMenuStrip.Items[i].Name.ToString() == b)
                        {
                            this.bedContextMenuStrip.Items[i].Enabled = enabled;
                        }
                    }
                }
            }
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FrmDBConnect();// F0002();
            form.ShowDialog();
        }
        private void rightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new F9993();
            form.ShowDialog();
        }
        private void rightFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new F9995();
            form.ShowDialog();
        }
        private void functionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new F9004();
            form.ShowDialog();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //new Thread(delegate
                //{
                //    this.SendMails();
                //}
                //)
                //{
                //    IsBackground = true
                //}.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FrmTestform(this);// FTEST(this);
            form.ShowDialog();
        }

        private void clearAllCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.EndAllCall)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa tất cả sự kiện ?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.conn = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                    if (this.conn.State == ConnectionState.Closed)
                        this.conn.Open();

                    var sqlQuery = string.Empty;
                    if (clsUtl.UserBedIds != null && clsUtl.UserBedIds.Count > 0)
                    {
                        SqlDataReader ad = null;
                        for (int i = 0; i < clsUtl.UserBedIds.Count; i++)
                        {
                            var obj = clsUtl.UserBedIds[i].Split('|');
                            sqlQuery += " UPDATE dbo.CALL_DETAILS    SET[process_time] = GETDATE() ";
                            sqlQuery += ",[end_call] = GETDATE(),[wait_interval] =  DATEDIFF(ss, [start_call], GETDATE()) ";
                            sqlQuery += ",[time_interval] =  DATEDIFF(ss, [start_call], GETDATE()) ";
                            sqlQuery += "WHERE CONVERT(varchar(10),[start_call], 111) <= convert(varchar(10), GETDATE(), 111) ";
                            sqlQuery += "AND end_call is null and [bed_id] = " + Convert.ToInt32(obj[2]) + " and [region_id] = " + Convert.ToInt32(obj[0]);
                            sqlQuery += "    delete from [N_CallRequires] where [region_id] = " + Convert.ToInt32(obj[0]) + " and [bed_id] = " + Convert.ToInt32(obj[2]) + "   ";
                        }
                        ad = provider.excuteQuery(sqlQuery);
                        ad.Dispose();
                    }
                }
            }

        }

        private void tmerQuetRepeatSound_Tick(object sender, EventArgs e)
        {
            try
            {
                // if (!this.bIsSounding)
                //{
                //    this.bIsSounding = true;
                //    
                //    //new Thread(delegate
                //    //{
                //    //    this.PlaySound();
                //    //}
                //    //)
                //    //{
                //    //    IsBackground = true
                //    //}.Start();
                //}
                //this.bIsSounding = false;
                //
                this.tmerQuetRepeatSound.Stop();
                FindSoundToRead(0);
                this.tmerQuetRepeatSound.Start();
            }
            catch (Exception ex)
            {
                this.bIsSounding = false;
                this.statusToolStripStatusLabel.Text = "tmerQuetRepeatSound_Tick Error: " + ex.Message;
            }
        }
        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new F9993();
            form.ShowDialog();
        }
        private void callByRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmRGetByRegion();// FRCTR();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "callByRegionToolStripMenuItem_Click Error: " + ex.Message;
            }
        }
        private void CallbyDatetimeExport()
        {
            DateTime now = DateTime.Now;
            DateTime now2 = DateTime.Now;
            try
            {
                this.strFileAttactment1 = Application.StartupPath + "\\Outputs\\CallbyDatetime" + now2.ToString("yyMMddhhmm") + ".xls";
                SqlConnection sqlConnection = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_call_by_time", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = now;
                sqlCommand.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = now2;
                sqlCommand.ExecuteNonQuery();
                string fileName = Application.StartupPath + "\\Reports\\CallbyDatetime.xml";
                this.c1Report1 = new C1Report();
                this.c1Report1.Load(fileName, "CallbyDatetime");
                this.c1Report1.DataSource.ConnectionString = this.GetStringConnectFull();
                this.c1Report1.DataSource.RecordSource = "v_call_by_time";
                this.c1Report1.Fields["DateFromTo"].Text = "Ngày: " + now2.ToString("dd/MM/yyyy");
                this.c1Report1.RenderToFile(this.strFileAttactment1, FileFormatEnum.Excel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CallbyDatetimeExport");
            }
            finally
            {
                this.c1Report1.Dispose();
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }
        private void ErrorsbyRegionExport()
        {
            try
            {
                DateTime now = DateTime.Now;
                DateTime now2 = DateTime.Now;
                this.strFileAttactment2 = Application.StartupPath + "\\Outputs\\ErrorsbyRegion" + now2.ToString("yyMMddhhmm") + ".xls";
                SqlConnection sqlConnection = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_call_detail_view", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = now;
                sqlCommand.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = now2;
                sqlCommand.Parameters.Add("@iRegionID", SqlDbType.Int).Value = 0;
                sqlCommand.ExecuteNonQuery();
                string fileName = Application.StartupPath + "\\Reports\\ErrorsbyRegion.xml";
                this.c1Report2 = new C1Report();
                this.c1Report2.Load(fileName, "ErrorsbyRegion");
                this.c1Report2.DataSource.ConnectionString = this.GetStringConnectFull();
                this.c1Report2.DataSource.RecordSource = "v_call_detail_view";
                this.c1Report2.Fields["Field6"].Subreport.DataSource.ConnectionString = this.GetStringConnectFull();
                this.c1Report2.Fields["Field6"].Subreport.DataSource.RecordSource = "v_call_detail_view";
                this.c1Report2.Fields["DateFromTo"].Text = "Ngày: " + now2.ToString("dd/MM/yyyy");
                this.c1Report2.RenderToFile(this.strFileAttactment2, FileFormatEnum.Excel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ErrorsbyRegionExport");
            }
            finally
            {
                this.c1Report2.Dispose();
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }
        private string GetStringConnectFull()
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
                    "Provider=SQLOLEDB;Password=",
                    innerText4,
                    ";Persist Security Info=True;User ID=",
                    innerText3,
                    ";Initial Catalog=",
                    innerText2,
                    ";Data Source=",
                    innerText
                });
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
        private void mailSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F9004();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "mailSetupToolStripMenuItem_Click Error: " + ex.Message;
            }
        }
        private void mailScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F9002();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "mailScheduleToolStripMenuItem_Click Error: " + ex.Message;
            }
        }
        private void mailListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F9003();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "mailListsToolStripMenuItem_Click Error: " + ex.Message;
            }
        }
        Thread sendMailThread;
        //Hai update 12/11/2018 
        private void tmerCheckSendMail_Tick(object sender, EventArgs e)
        {
            //string value = DateTime.Now.ToString("HH:mm:ss");
            //if (this.strMailShedule.IndexOf(value) >= 0)
            //{
            //    this.tmerCheckSendMail.Stop();
            //    //new Thread(delegate
            //    //{
            //    //    this.SendMails();
            //    //}
            //    //)
            //    //{
            //    //    IsBackground = true
            //    //}.Start();
            //    this.tmerCheckSendMail.Start();
            //}
            try
            {
                TimeSendMail = Settings.Default.TimeSend.TimeOfDay;
            }
            catch (Exception ex)
            {
                TimeSendMail = null;
                MessageBox.Show("Không thể cài đặt được thời gian gửi thư điện tử. Vui lòng kiểm tra lại cấu hình.");
            }
            if (TimeSendMail.HasValue)
            {
                TimeSpan dateTimeNow = DateTime.Now.TimeOfDay;
                TimeSpan timeNow = TimeSpan.Parse(dateTimeNow.Hours.ToString() + ":" + dateTimeNow.Minutes.ToString() + ":00");
                if (timeNow == TimeSendMail.Value)
                {
                    this.statusToolStripStatusLabel.Text = "bắt đầu gửi mail.";

                    sendMailThread = new Thread(this.SendMails);
                    sendMailThread.IsBackground = true;
                    sendMailThread.Start();
                }
            }
        }

        //Hai update 12/11/2018
        private void SendMails()
        {

            //try
            //{
            //    string type = "";
            //    string host = "";
            //    int port = 25;
            //    string from = "vthphong@gmail.com";
            //    string displayName = "vthphong";
            //    string password = "123456";
            //    string text = "";
            //    string subject = "Test mail";
            //    string body = "Hi All";
            //    this.CallbyDatetimeExport();
            //    this.ErrorsbyRegionExport();
            //    string text2 = "SELECT dbo.MAIL_TYPE.mail_type, dbo.MAIL_SETUP.host, dbo.MAIL_SETUP.port, dbo.MAIL_SETUP.fromaddress, dbo.MAIL_SETUP.frompassword, ";
            //    text2 += "dbo.MAIL_SETUP.displayname, dbo.MAIL_SETUP.subject, dbo.MAIL_SETUP.body, dbo.MAIL_SETUP.note ";
            //    text2 += "FROM dbo.MAIL_SETUP INNER JOIN dbo.MAIL_TYPE ON dbo.MAIL_SETUP.mail_type = dbo.MAIL_TYPE.id WHERE dbo.MAIL_SETUP.active = 1";
            //    SqlConnection sqlConnection = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
            //    if (sqlConnection.State == ConnectionState.Closed)
            //    {
            //        sqlConnection.Open();
            //    }
            //    SqlCommand sqlCommand = new SqlCommand(text2, sqlConnection);
            //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //    while (sqlDataReader.Read())
            //    {
            //        type = sqlDataReader["mail_type"].ToString();
            //        host = sqlDataReader["host"].ToString();
            //        port = int.Parse(sqlDataReader["port"].ToString());
            //        from = sqlDataReader["fromaddress"].ToString();
            //        displayName = sqlDataReader["displayname"].ToString();
            //        password = sqlDataReader["frompassword"].ToString();
            //        subject = sqlDataReader["subject"].ToString();
            //        body = sqlDataReader["body"].ToString();
            //    }
            //    sqlCommand.Dispose();
            //    sqlDataReader.Close();
            //    text2 = "SELECT [email] FROM  [dbo].[MAIL_LISTS] WHERE [active] = 1";
            //    SqlCommand sqlCommand2 = new SqlCommand(text2, sqlConnection);
            //    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
            //    while (sqlDataReader2.Read())
            //    {
            //        if (text.Length == 0)
            //        {
            //            text += sqlDataReader2["email"].ToString();
            //        }
            //        else
            //        {
            //            text = text + ", " + sqlDataReader2["email"].ToString();
            //        }
            //    }
            //    sqlCommand2.Dispose();
            //    sqlDataReader2.Close();
            //    clsMail clsMail = new clsMail();
            //    clsMail.Type = type;
            //    clsMail.Host = host;
            //    clsMail.Port = port;
            //    clsMail.From = from;
            //    clsMail.DisplayName = displayName;
            //    clsMail.Password = password;
            //    clsMail.To = text;
            //    clsMail.Subject = subject;
            //    clsMail.Body = body;
            //    clsMail.AddAttachment(this.strFileAttactment1);
            //    clsMail.AddAttachment(this.strFileAttactment2);
            //    clsMail.SendMail();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "SendMails");
            //}
            //finally
            //{
            //    if (this.conn.State == ConnectionState.Open)
            //    {
            //        this.conn.Close();
            //    }
            //}
            this.Invoke((MethodInvoker)delegate
            {
                this.tmerCheckSendMail.Enabled = false;
            });
            try
            {
                clsMail mail = new clsMail();
                mail.Type = "Google";
                mail.Host = "smtp.gmail.com";
                mail.Port = 587;
                mail.From = Settings.Default.MailSend;
                mail.DisplayName = "";
                mail.Password = Settings.Default.Password;
                mail.To = Settings.Default.MailRecieve;
                mail.Subject = "Sơn Hà báo cáo thông tin sự cố hàng ngày";
                mail.Body = "Hệ thống tự động gửi mail báo cáo sự cố hàng ngày. Vui lòng không reply!";

                int month = DateTime.Now.Month, year = DateTime.Now.Year;
                if (month == 12)
                {
                    month = 1;
                    year++;
                }

                //bao cao thang
                int endOfThisMonth = new DateTime(year, month+1, 1).AddDays(-1).Day;
                string startDate = DateTime.Now.Month + "/" + Settings.Default.StartDate + "/" + DateTime.Now.Year,
                  endDate = DateTime.Now.Month + "/" + (Settings.Default.EndDate < endOfThisMonth ? Settings.Default.EndDate : endOfThisMonth) + "/" + DateTime.Now.Year;
                mail.AddAttachment(GetReportFiles(startDate, endDate,endOfThisMonth));

                // bao cao ngay
                mail.AddAttachment(GetReportFiles(DateTime.Now.ToString("MM/dd/yyyy"), DateTime.Now.AddDays(1).ToString("MM/dd/yyyy"), null));

                mail.AddAttachment(BaoCaoChiTietNgay());
                mail.SendMail();
                DeleteAllFileInPath(Application.StartupPath + @"\SaveReports");
            }
            catch (Exception ex)
            {
                // threadSendMail.Abort();
                MessageBox.Show("Lỗi gửi mail: " + ex.Message);
            }
            Thread.Sleep(60000);
            this.Invoke((MethodInvoker)delegate
            {
                this.tmerCheckSendMail.Enabled = true;
            });
            this.statusToolStripStatusLabel.Text = "kết thúc gửi mail.";
            sendMailThread.Abort();
        }
        #region Hai 12/11/2018
        //Hai
        private string GetReportFiles(string startDate, string endDate, int? toD)
        {
            string templatePath = Application.StartupPath + @"\Templates_Report\SonHa_Template.xlsx";
            if (!File.Exists(templatePath))
                MessageBox.Show("Không tìm thấy file mail template.");
            else
            {
                try
                {
                    #region khoi tao cac doi tuong Com Excel de lam viec
                    Excel.Application xlApp;
                    Excel.Worksheet xlSheet;
                    Excel.Workbook xlBook;
                    Excel.Range oRng;
                    //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                    object missValue = System.Reflection.Missing.Value;
                    //khoi tao doi tuong Com Excel moi
                    xlApp = new Excel.Application();
                    xlBook = xlApp.Workbooks.Open(templatePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlBook.CheckCompatibility = false;
                    xlBook.DoNotPromptForConvert = true;

                    //su dung Sheet dau tien de thao tac
                    xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                    //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                    xlApp.Visible = false;

                    #endregion

                    string query = "SELECT " +
                                   "  dbo.CALL_DETAILS.transaction_date as Ngay, " +
                                   " CONVERT(varchar(10), dbo.CALL_DETAILS.transaction_date, 103) strNgay, " +
                                   " isnull(dbo.REGIONS.product_name,'') as SanPham," +
                                   " dbo.REGIONS.region_name as Chuyen," +

                                   " dbo.SHIFTS.shift_name as Ca, " +
                                   " dbo.SHIFTS.start_time as BDCaLV, " +
                                   " dbo.SHIFTS.end_time as KTCaLV, " +

                                   " dbo.CALL_DETAILS.start_call as BatDau,			" +
                                   " dbo.CALL_DETAILS.end_call as KetThuc,				" +
                                   " dbo.CALL_DETAILS.process_time as TGXuLy, " +
                                   " dbo.fn_second2time(dbo.CALL_DETAILS.wait_interval) wait_interval, " +
                                   " dbo.fn_second2time(dbo.CALL_DETAILS.time_interval) time_interval, " +
                                   " dbo.fn_second2time(dbo.CALL_DETAILS.time_interval - dbo.CALL_DETAILS.wait_interval) process_interval,	" +

                                   " dbo.CALL_DETAILS.region_id," +

                                   " dbo.REGIONS.note AS region_note,  " +

                                   " dbo.CALL_DETAILS.room_id, " +
                                   " dbo.ROOMS.room_name as room_code ," +
                                   " dbo.ROOMS.note AS room_note,	" +
                                   " dbo.ROOMS.labors AS room_labor,	" +

                                   " dbo.CALL_DETAILS.bed_id as bedId, 	" +
                                   " dbo.BEDS.bed_name as bed_code,  " +
                                   " dbo.BEDS.note AS bed_note,   	" +
                                   "dbo.CALL_DETAILS.id," +
                                   //" dbo.CALL_DETAILS.equipment, " +
                                   " isnull(dbo.REGIONS.make_time, 0) as make_time, isnull(dbo.REGIONS.price, 0) as price  " +
                                   // " dbo.fn_shift_employee(dbo.CALL_DETAILS.shift_id, dbo.CALL_DETAILS.start_call) AS shift_employee " +

                                   " FROM dbo.CALL_DETAILS INNER JOIN " +
                                   " dbo.REGIONS ON dbo.CALL_DETAILS.region_id = dbo.REGIONS.region_id INNER JOIN " +
                                   " dbo.SHIFTS ON dbo.CALL_DETAILS.shift_id = dbo.SHIFTS.shift_id INNER JOIN " +
                                   " dbo.ROOMS ON dbo.CALL_DETAILS.room_id = dbo.ROOMS.room_id AND dbo.CALL_DETAILS.region_id = dbo.ROOMS.region_id INNER JOIN " +
                                   " dbo.BEDS ON dbo.CALL_DETAILS.bed_id = dbo.BEDS.bed_id AND dbo.CALL_DETAILS.room_id = dbo.BEDS.room_id AND " +
                                   " dbo.CALL_DETAILS.region_id = dbo.BEDS.region_id " +

                                   " WHERE [start_call] >  '" + startDate + "' and [start_call] <=  '" + endDate + "' ";
                    //" WHERE [start_call] > convert(varchar(10), N'" + startDate + "', 111)  and [start_call] <= convert(varchar(10), N'" + endDate + "', 111) ";

                    var objs = new List<NewReportModel>();

                    SqlConnection sqlConnection = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        var obj = new NewReportModel();
                        obj.Date = DateTime.Parse(sqlDataReader["Ngay"].ToString());
                        obj.strDate = sqlDataReader["strNgay"].ToString();
                        obj.Start = DateTime.Parse(sqlDataReader["BatDau"].ToString());
                        obj.End = DateTime.Parse((!string.IsNullOrEmpty(sqlDataReader["KetThuc"].ToString()) ? sqlDataReader["KetThuc"].ToString() : sqlDataReader["BatDau"].ToString()));
                        obj.ShiftStart = DateTime.Parse(sqlDataReader["BDCaLV"].ToString());
                        obj.ShiftEnd = DateTime.Parse(sqlDataReader["KTCaLV"].ToString());
                        obj.Product = (!string.IsNullOrEmpty(sqlDataReader["SanPham"].ToString()) ? sqlDataReader["SanPham"].ToString() : "");
                        obj.Area = sqlDataReader["region_note"].ToString();
                        obj.Room = sqlDataReader["room_note"].ToString();
                        obj.Bed = sqlDataReader["bed_note"].ToString();
                        obj.BedId = int.Parse(sqlDataReader["bedId"].ToString());
                        obj.Labors = int.Parse(sqlDataReader["room_labor"].ToString());
                        obj.ProcessTime = obj.End.Subtract(obj.Start).TotalMinutes;
                        obj.WaitingTime = (!string.IsNullOrEmpty(sqlDataReader["TGXuLy"].ToString()) ? DateTime.Parse(sqlDataReader["TGXuLy"].ToString()).Subtract(obj.Start).TotalMinutes : 0);
                        objs.Add(obj);
                    }

                    #region sheet 1
                    var groupDate = objs.GroupBy(x => x.strDate).Select(x => new NewReportModel()
                    {
                        Date = x.First().Date,
                        strDate = x.First().strDate,
                        Area = x.First().Area,
                        Room = x.First().Room,
                        Bed = x.First().Bed,
                        Product = x.First().Product,
                        ShiftStart = x.First().ShiftStart,
                        ShiftEnd = x.First().ShiftEnd,
                        Details = x.ToList()
                    }).OrderBy(x => x.Date).ThenBy(x => x.Area).ToList();
                    int doc = 8;
                    double tongTG = 0, tgXuLy = 0, tongTGLV = 0;
                    Excel.Range range;

                    if (groupDate.Count > 0)
                    {
                        foreach (var item in groupDate)
                        {
                            var groupChuyen = item.Details.GroupBy(x => x.Area).Select(x => new NewReportModel()
                            {
                                Date = x.First().Date,
                                strDate = x.First().strDate,
                                Area = x.First().Area,
                                Room = x.First().Room,
                                Bed = x.First().Bed,
                                Product = x.First().Product,
                                ShiftStart = x.First().ShiftStart,
                                ShiftEnd = x.First().ShiftEnd,
                                Details = x.ToList()
                            }).OrderBy(x => x.Date).ThenBy(x => x.Area).ToList();

                            range = xlSheet.get_Range("B" + doc + ":B" + doc, "B" + (doc + groupChuyen.Count - 1));
                            range.Merge(Type.Missing);
                            range.Value = item.strDate.ToString();
                            range.HorizontalAlignment = Excel.Constants.xlCenter;
                            range.VerticalAlignment = Excel.Constants.xlCenter;
                            range.WrapText = true;
                            range.Borders.ColorIndex = 56;

                            foreach (var chuyen in groupChuyen)
                            {
                                for (int ngang = 0; ngang < 23; ngang++)
                                {
                                    switch (ngang)
                                    {
                                        // case 2: xlSheet.Cells[doc, ngang] = ; break;
                                        //san pham
                                        case 3: xlSheet.Cells[doc, ngang] = chuyen.Product; break;
                                        case 4:
                                            xlSheet.Cells[doc, ngang] = (Settings.Default.NameInReport == 0 ? chuyen.Area : chuyen.Room);
                                            break;
                                        //lao dong
                                        case 5: xlSheet.Cells[doc, ngang] = chuyen.Details.First().Labors; break;
                                        //tong thoi gian
                                        case 6:
                                            tongTG = chuyen.ShiftEnd.Subtract(chuyen.ShiftStart).TotalMinutes * chuyen.Details.First().Labors;
                                            tongTGLV += tongTG;
                                            xlSheet.Cells[doc, ngang] = tongTG; break;
                                        //tg chet
                                        case 7: xlSheet.Cells[doc, ngang] = Math.Ceiling(chuyen.Details.Sum(x => x.ProcessTime)); break;
                                        //tong su co
                                        case 8: xlSheet.Cells[doc, ngang] = chuyen.Details.Count; break;

                                        //to truong
                                        case 11: xlSheet.Cells[doc, ngang] = chuyen.Details.Where(x => x.BedId == 1).Count(); break;
                                        case 12:
                                            tgXuLy = Math.Ceiling(chuyen.Details.Where(x => x.BedId == 1).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;
                                        case 13: xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;

                                        // bao tri
                                        case 14: xlSheet.Cells[doc, ngang] = chuyen.Details.Where(x => x.BedId == 2).Count(); break;
                                        case 15:
                                            tgXuLy = Math.Ceiling(chuyen.Details.Where(x => x.BedId == 2).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;
                                        case 16: xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;

                                        // ky thuat
                                        case 17: xlSheet.Cells[doc, ngang] = chuyen.Details.Where(x => x.BedId == 3).Count(); break;
                                        case 18:
                                            tgXuLy = Math.Ceiling(chuyen.Details.Where(x => x.BedId == 3).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;
                                        case 19: xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;

                                        // to cat
                                        case 20: xlSheet.Cells[doc, ngang] = chuyen.Details.Where(x => x.BedId == 4).Count(); break;
                                        case 21:
                                            tgXuLy = Math.Ceiling(chuyen.Details.Where(x => x.BedId == 4).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;
                                        case 22: xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;
                                    }
                                }
                                doc++;
                            }
                        }
                    }

                    if (toD.HasValue)
                        xlSheet.Cells[3, 6] = "Từ " + Settings.Default.StartDate + " - " + toD + " tháng " + DateTime.Now.ToString("M - yyyy");
                    else
                        xlSheet.Cells[3, 6] = DateTime.Now.ToString("dd/MM/yyyy");

                    doc++;
                    range = xlSheet.get_Range("A" + doc + ":E" + doc);
                    range.Merge(Type.Missing);
                    range.Value = "TỔNG CỘNG";
                    range.HorizontalAlignment = Excel.Constants.xlCenter;
                    range.VerticalAlignment = Excel.Constants.xlCenter;
                    range.WrapText = true;
                    range.Borders.ColorIndex = 56;

                    xlSheet.Cells[doc, 6] = tongTGLV;
                    xlSheet.Cells[doc, 7] = "=SUM(G8:G" + (doc - 2) + ")";//  Math.Ceiling(objs.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 8] = objs.Count;

                    var slSuCo = objs.Where(x => x.BedId == 1).ToList();
                    xlSheet.Cells[doc, 11] = slSuCo.Count;
                    xlSheet.Cells[doc, 12] = "=SUM(L8:L" + (doc - 2) + ")";// Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 13] = "=L" + doc + "/F" + doc + "*100";// Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);

                    slSuCo = objs.Where(x => x.BedId == 2).ToList();
                    xlSheet.Cells[doc, 14] = slSuCo.Count;
                    xlSheet.Cells[doc, 15] = "=SUM(O8:O" + (doc - 2) + ")";//  Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 16] = "=O" + doc + "/F" + doc + "*100";//Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);

                    slSuCo = objs.Where(x => x.BedId == 3).ToList();
                    xlSheet.Cells[doc, 17] = slSuCo.Count;
                    xlSheet.Cells[doc, 18] = "=SUM(R8:R" + (doc - 2) + ")";//  Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 19] = "=R" + doc + "/F" + doc + "*100";//Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);

                    slSuCo = objs.Where(x => x.BedId == 4).ToList();
                    xlSheet.Cells[doc, 20] = slSuCo.Count;
                    xlSheet.Cells[doc, 21] = "=SUM(U8:U" + (doc - 2) + ")";// Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 22] = "=U" + doc + "/F" + doc + "*100";//Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);

                    #endregion

                    #region sheet 2
                    xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(2);
                    var groupByChuyen = objs.GroupBy(x => x.Area).Select(x => new NewReportModel()
                    {
                        Date = x.First().Date,
                        strDate = x.First().strDate,
                        Area = x.First().Area,
                        Room = x.First().Room,
                        Bed = x.First().Bed,
                        Product = x.First().Product,
                        ShiftStart = x.First().ShiftStart,
                        ShiftEnd = x.First().ShiftEnd,
                        Details = x.ToList()
                    }).OrderBy(x => x.Area).ThenBy(x => x.Date).ToList();
                    doc = 8;
                    tongTG = 0;
                    tgXuLy = 0;
                    tongTGLV = 0;

                    foreach (var item in groupByChuyen)
                    {
                        var groupByDate = item.Details.GroupBy(x => x.strDate).Select(x => new NewReportModel()
                        {
                            Date = x.First().Date,
                            strDate = x.First().strDate,
                            Area = x.First().Area,
                            Room = x.First().Room,
                            Bed = x.First().Bed,
                            Product = x.First().Product,
                            ShiftStart = x.First().ShiftStart,
                            ShiftEnd = x.First().ShiftEnd,
                            Details = x.ToList()
                        }).OrderBy(x => x.Date).ToList();

                        range = xlSheet.get_Range("D" + doc + ":D" + (doc + groupByDate.Count - 1));
                        range.Merge(Type.Missing);
                        range.Value = item.Area;
                        range.HorizontalAlignment = Excel.Constants.xlCenter;
                        range.VerticalAlignment = Excel.Constants.xlCenter;
                        range.WrapText = true;
                        range.Borders.ColorIndex = 56;
                        if (groupByDate.Count > 0)
                        {
                            foreach (var date in groupByDate)
                            {
                                for (int ngang = 0; ngang <= 15; ngang++)
                                {
                                    switch (ngang)
                                    {
                                        case 2: xlSheet.Cells[doc, ngang] = date.strDate; break;
                                        case 3: xlSheet.Cells[doc, ngang] = date.Product; break;
                                        case 4: xlSheet.Cells[doc, ngang] = (Settings.Default.NameInReport == 0 ? date.Area : date.Room); break;
                                        case 5: xlSheet.Cells[doc, ngang] = date.Details.First().Labors; break;
                                        case 6:
                                            tongTG = date.ShiftEnd.Subtract(date.ShiftStart).TotalMinutes * date.Details.First().Labors;
                                            tongTGLV += tongTG;
                                            xlSheet.Cells[doc, ngang] = tongTG; break;
                                        //tg chet
                                        case 7: xlSheet.Cells[doc, ngang] = Math.Ceiling(date.Details.Sum(x => x.ProcessTime)); break;

                                        case 8: //to truong
                                            tgXuLy = Math.Ceiling(date.Details.Where(x => x.BedId == 1).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;
                                        case 9:  // ky thuat 
                                            tgXuLy = Math.Ceiling(date.Details.Where(x => x.BedId == 3).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;
                                        case 10: // bao tri
                                            tgXuLy = Math.Ceiling(date.Details.Where(x => x.BedId == 2).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;
                                        case 11:   // to cat
                                            tgXuLy = Math.Ceiling(date.Details.Where(x => x.BedId == 4).ToList().Sum(x => x.ProcessTime));
                                            xlSheet.Cells[doc, ngang] = tgXuLy; break;

                                        case 12: //to truong
                                            tgXuLy = date.Details.Where(x => x.BedId == 1).ToList().Sum(x => x.ProcessTime);
                                            xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;
                                        case 13:  // ky thuat 
                                            tgXuLy = date.Details.Where(x => x.BedId == 3).ToList().Sum(x => x.ProcessTime);
                                            xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;
                                        case 14: // bao tri
                                            tgXuLy = date.Details.Where(x => x.BedId == 2).ToList().Sum(x => x.ProcessTime);
                                            xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;
                                        case 15:   // to cat
                                            tgXuLy = date.Details.Where(x => x.BedId == 4).ToList().Sum(x => x.ProcessTime);
                                            xlSheet.Cells[doc, ngang] = Math.Round((tgXuLy / tongTG) * 100, 2); break;
                                    }
                                }
                                doc++;
                            }
                        }
                    }
                    if (toD.HasValue)
                        xlSheet.Cells[3, 6] = "Từ " + Settings.Default.StartDate + " - " + toD + " tháng " + DateTime.Now.ToString("M - yyyy");
                    else
                        xlSheet.Cells[3, 6] = DateTime.Now.ToString("dd/MM/yyyy");

                    doc++;
                    range = xlSheet.get_Range("A" + doc + ":E" + doc);
                    range.Merge(Type.Missing);
                    range.Value = "TỔNG CỘNG";
                    range.HorizontalAlignment = Excel.Constants.xlCenter;
                    range.VerticalAlignment = Excel.Constants.xlCenter;
                    range.WrapText = true;
                    range.Borders.ColorIndex = 56;

                    xlSheet.Cells[doc, 6] = tongTGLV;
                    xlSheet.Cells[doc, 7] = "=SUM(G8:G" + (doc - 2) + ")";// Math.Ceiling(objs.Sum(x => x.ProcessTime));

                    slSuCo = objs.Where(x => x.BedId == 1).ToList();
                    xlSheet.Cells[doc, 8] = "=SUM(H8:H" + (doc - 2) + ")";// Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 12] = "=H" + doc + "/F"+doc+"*100";// Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);

                    slSuCo = objs.Where(x => x.BedId == 3).ToList();
                    xlSheet.Cells[doc, 9] = "=SUM(I8:I" + (doc - 2) + ")"; //Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 13] = "=I" + doc + "/F" + doc + "*100"; //Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);

                    slSuCo = objs.Where(x => x.BedId == 2).ToList();
                    xlSheet.Cells[doc, 10] = "=SUM(J8:J" + (doc - 2) + ")"; //Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 14] = "=J" + doc + "/F" + doc + "*100"; Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);

                    slSuCo = objs.Where(x => x.BedId == 4).ToList();
                    xlSheet.Cells[doc, 11] = "=SUM(K8:K" + (doc - 2) + ")";// Math.Ceiling(slSuCo.Sum(x => x.ProcessTime));
                    xlSheet.Cells[doc, 15] = "=K" + doc + "/F" + doc + "*100"; //Math.Round((slSuCo.Sum(x => x.ProcessTime) / tongTGLV) * 100, 2);
                    #endregion

                    xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                    string filePath = string.Empty;

                    //save file
                    if (toD.HasValue)
                        filePath = (Application.StartupPath + @"\SaveReports\BaocaoSH_Thang_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".xlsx" );
                    else
                        filePath = (Application.StartupPath + @"\SaveReports\BaocaoSH_Ngay_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".xlsx" );
                    xlBook.SaveAs( filePath, Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                    
                    xlBook.Close(true, missValue, missValue);
                    xlApp.Quit();

                    // release cac doi tuong COM
                    releaseObject(xlSheet);
                    releaseObject(xlBook);
                    releaseObject(xlApp);
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    return filePath  ; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tạo file mail bị lỗi.\n" + ex.Message);
                }
            }
            return "";
        }
        //Hai
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        //Hai
        private static void DeleteAllFileInPath(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    var dr = new DirectoryInfo(path);
                    foreach (var f in dr.GetFiles())
                        try
                        {
                            // xoa het file trong folder truoc khi tao file moi   
                            f.Delete();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                }
                else
                    Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
            }
        }

        private string BaoCaoChiTietNgay()
        {
            try
            {
                string templatePath = System.Windows.Forms.Application.StartupPath + @"\Reports\DtoD_2.xlsx";
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                Excel.Range oRng;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Open(templatePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlBook.CheckCompatibility = false;
                xlBook.DoNotPromptForConvert = true;
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;

                int month = DateTime.Now.Month, year = DateTime.Now.Year;
                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                int endOfThisMonth = new DateTime(year, month+1, 1).AddDays(-1).Day;
                string startDate = DateTime.Now.Month + "/" + Settings.Default.StartDate + "/" + DateTime.Now.Year,
                  endDate = DateTime.Now.Month + "/" + (Settings.Default.EndDate < endOfThisMonth ? Settings.Default.EndDate : endOfThisMonth) + "/" + DateTime.Now.Year;

                xlSheet.Cells[2, 1] = "Từ " + Settings.Default.StartDate + " - " + (Settings.Default.EndDate < endOfThisMonth ? Settings.Default.EndDate : endOfThisMonth) + " tháng " + DateTime.Now.ToString("M - yyyy");

                #region get data
                var myconn = new SqlConnection(strConnString == "" ? strConnStringDefault : strConnString);//DataProvider.ConnectionString);
                if (myconn.State == ConnectionState.Closed)
                {
                    myconn.Open();
                }
                //  MessageBox.Show("month " + month + " - year : " + year + " - startdate : " + startDate + " - enddate : " + endDate);
                SqlCommand cmd = new SqlCommand("hai_test", myconn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Set Parameters            
                cmd.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = DateTime.ParseExact((Settings.Default.StartDate + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year), "d/M/yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = DateTime.ParseExact(((Settings.Default.EndDate < endOfThisMonth ? Settings.Default.EndDate : endOfThisMonth) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year), "d/M/yyyy", CultureInfo.InvariantCulture);
                List<ReportModel> models = new List<ReportModel>();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Load(rdr);
                    if (dt.Rows.Count > 0)
                    {
                        ReportModel obj;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            obj = new ReportModel();
                            obj.Date = dt.Rows[i]["transaction_date"].ToString();
                            obj.Shift = dt.Rows[i]["shift_name"].ToString();
                            obj.Area = dt.Rows[i]["region_note"].ToString();
                            obj.Room = dt.Rows[i]["room_note"].ToString();
                            obj.Bed = dt.Rows[i]["bed_note"].ToString();
                            obj.User = dt.Rows[i]["user"].ToString();
                            obj.Start = dt.Rows[i]["start_call"].ToString();
                            obj.Process = dt.Rows[i]["process_time"].ToString();
                            obj.End = dt.Rows[i]["end_call"].ToString();
                            obj.ProcessTime = dt.Rows[i]["time_interval"].ToString();
                            obj.WattingTime = dt.Rows[i]["wait_interval"].ToString();
                            models.Add(obj);
                        }
                    }
                }
                #endregion 

                int row = 5;
                int cell = 1;
                for (int i = 0; i < models.Count; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        switch (j)
                        {
                            case 0: xlSheet.Cells[row, cell] = models[i].Date; break;
                            case 1: xlSheet.Cells[row, cell] = models[i].Shift; break;
                            case 2: xlSheet.Cells[row, cell] = models[i].Area; break;
                            case 3: xlSheet.Cells[row, cell] = models[i].Room; break;
                            case 4: xlSheet.Cells[row, cell] = models[i].Bed; break;
                            case 5: xlSheet.Cells[row, cell] = models[i].User; break;
                            case 6: xlSheet.Cells[row, cell] = models[i].Start; break;
                            case 7: xlSheet.Cells[row, cell] = models[i].Process; break;
                            case 8: xlSheet.Cells[row, cell] = models[i].End; break;
                            case 9: xlSheet.Cells[row, cell] = models[i].ProcessTime; break;
                            case 10: xlSheet.Cells[row, cell] = models[i].WattingTime; break;
                        }
                        cell++;
                    }
                    cell = 1;
                    row++;
                }

                //save file
                xlBook.SaveAs(Application.StartupPath + @"\SaveReports\BaocaoCT_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();

                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                myconn.Close();
                myconn.Dispose();
                return Application.StartupPath + @"\SaveReports\BaocaoCT_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".xlsx";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        #endregion


        private void ClearFolder(string FolderName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(FolderName);
            FileInfo[] files = directoryInfo.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = files[i];
                fileInfo.IsReadOnly = false;
                fileInfo.Delete();
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                DirectoryInfo directoryInfo2 = directories[i];
                this.ClearFolder(directoryInfo2.FullName);
                directoryInfo2.Delete();
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                if (isFinishDrawData)
                {
                    isFinishDrawData = false;
                    this.RefreshData();
                    this.CountFooterMaster();
                }
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - timer5_Tick: " + ex.Message;
            }
        }

        private void SaveTransactions()
        {
            try
            {
                string sqlString = string.Empty;
                sqlString = string.Concat(new string[]
                {
                    "INSERT INTO [dbo].[TRANSACTIONS] ([region],[room],[equipment],[command],[bed]) VALUES (",
                    this.sRegion,
                    ", ",
                    this.sRoom,
                    ", ",
                    this.sEquipment,
                    ", ",
                    this.sType_Request,
                    ", ",
                    this.sBed,
                    ")"
                });
                this.provider.excuteNonTran(sqlString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SaveTransactions", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void equipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F0044();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "equipmentToolStripMenuItem_Click Error: " + ex.Message;
            }
        }
        private BedsArray LoadBedAttributes()
        {
            BedsArray bedsArray = new BedsArray();
            BedsArray result;
            try
            {
                string sqlString = "SELECT CONVERT(varchar,[region_id])+ CONVERT(varchar,[room_id])+ CONVERT(varchar,[bed_id]) bed_id ,[event_type],[max_times] FROM [dbo].[BEDS] Order by region_id, room_id, bed_id";
                SqlDataReader sqlDataReader = this.provider.excuteQuery(sqlString);
                while (sqlDataReader.Read())
                {
                    try
                    {
                        string s_Bed_id = sqlDataReader["bed_id"].ToString();
                        int i_event_type = int.Parse(sqlDataReader["event_type"].ToString());
                        int i_max_times = int.Parse(sqlDataReader["max_times"].ToString());
                        BedInfor si = new BedInfor(s_Bed_id, i_event_type, i_max_times);
                        bedsArray.Add(si);
                    }
                    catch (Exception) { }
                }
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "LoadBedAttributes", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = new BedsArray();
                return result;
            }
            result = bedsArray;
            return result;
        }
        private void toolStripMenuItemConfigEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F0019();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "toolStripMenuItemConfigEvent_Click: " + ex.Message;
            }
        }
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new F0020();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "productsToolStripMenuItem_Click: " + ex.Message;
            }
        }
        private void bedContextMenuStrip_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void bedContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            FMAIN.timer5.Start();
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
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FMAIN));
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.loginToolStripMenuItem = new ToolStripMenuItem();
            this.connectToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator11 = new ToolStripSeparator();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.viewToolStripMenuItem = new ToolStripMenuItem();
            this.languageToolStripMenuItem = new ToolStripMenuItem();
            this.englishToolStripMenuItem = new ToolStripMenuItem();
            this.vietnameseToolStripMenuItem = new ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new ToolStripMenuItem();
            this.CallByDateTimeToolStripMenuItem = new ToolStripMenuItem();
            this.CallTopNToolStripMenuItem = new ToolStripMenuItem();
            this.CallTimeGreaterToolStripMenuItem = new ToolStripMenuItem();
            this.CallByShiftToolStripMenuItem = new ToolStripMenuItem();
            this.callByRegionToolStripMenuItem = new ToolStripMenuItem();
            this.toolsToolStripMenuItem = new ToolStripMenuItem();
            this.serialPortSettingsToolStripMenuItem = new ToolStripMenuItem();
            this.equipmentToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator10 = new ToolStripSeparator();
            this.soundsToolStripMenuItem = new ToolStripMenuItem();
            this.soundTemplatesToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.mailSetupToolStripMenuItem = new ToolStripMenuItem();
            this.mailScheduleToolStripMenuItem = new ToolStripMenuItem();
            this.mailListsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator13 = new ToolStripSeparator();
            this.optionsToolStripMenuItem = new ToolStripMenuItem();
            this.systemToolStripMenuItem = new ToolStripMenuItem();
            this.configManagerToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItemConfigEvent = new ToolStripMenuItem();
            this.servicesToolStripMenuItem = new ToolStripMenuItem();
            this.productsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator5 = new ToolStripSeparator();
            this.departmentsToolStripMenuItem = new ToolStripMenuItem();
            this.jobsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.employeesManagerToolStripMenuItem = new ToolStripMenuItem();
            this.hospitalPropertiesToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator8 = new ToolStripSeparator();
            this.shiftToolStripMenuItem = new ToolStripMenuItem();
            this.workShiftToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator9 = new ToolStripSeparator();
            this.usersToolStripMenuItem = new ToolStripMenuItem();
            this.userBedCallToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator12 = new ToolStripSeparator();
            this.rightsToolStripMenuItem = new ToolStripMenuItem();
            this.functionsToolStripMenuItem = new ToolStripMenuItem();
            this.rightFunctionToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.aboutToolStripMenuItem = new ToolStripMenuItem();
            this.testToolStripMenuItem = new ToolStripMenuItem();
            this.clearAllCallToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip1 = new StatusStrip();
            this.serialPortStatusToolStripStatusLabel = new ToolStripStatusLabel();
            this.tssDataSend = new ToolStripStatusLabel();
            this.statusToolStripStatusLabel = new ToolStripStatusLabel();
            this.clockToolStripStatusLabel = new ToolStripStatusLabel();
            this.toolStrip1 = new ToolStrip();
            this.toolStripButton1 = new ToolStripButton();
            this.toolStripButton2 = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.serialPortToolStripLabel = new ToolStripLabel();
            this.serialPortToolStripSplitButton = new ToolStripSplitButton();
            this.openToolStripMenuItem = new ToolStripMenuItem();
            this.closeToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.helpToolStripButton = new ToolStripButton();
            this.splitContainer1 = new SplitContainer();
            this.c1TrueDBGrid1 = new C1TrueDBGrid();
            this.mainPanel = new Panel();
            this.mainVScrollBar = new VScrollBar();
            this.headerPanel = new Panel();
            this.tmerResetDateTime = new System.Windows.Forms.Timer(this.components);
            this.myToolTip = new ToolTip(this.components);
            this.bedContextMenuStrip = new ContextMenuStrip(this.components);
            this.callBedToolStripMenuItem = new ToolStripMenuItem();
            this.stopBedToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator6 = new ToolStripSeparator();
            this.bedDetailsToolStripMenuItem = new ToolStripMenuItem();
            this.roomContextMenuStrip = new ContextMenuStrip(this.components);
            this.callRoomToolStripMenuItem = new ToolStripMenuItem();
            this.roomPropertiesToolStripSeparator = new ToolStripSeparator();
            this.roomDetailsToolStripMenuItem = new ToolStripMenuItem();
            this.regionContextMenuStrip = new ContextMenuStrip(this.components);
            this.callRegionToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator7 = new ToolStripSeparator();
            this.regionDetailsToolStripMenuItem = new ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tmerQuetRepeatSound = new System.Windows.Forms.Timer(this.components);
            this.tmerCheckSendMail = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
            this.bedContextMenuStrip.SuspendLayout();
            this.roomContextMenuStrip.SuspendLayout();
            this.regionContextMenuStrip.SuspendLayout();
            base.SuspendLayout();
            this.menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.fileToolStripMenuItem,
                this.viewToolStripMenuItem,
                this.statisticsToolStripMenuItem,
                this.toolsToolStripMenuItem,
                this.systemToolStripMenuItem,
                this.helpToolStripMenuItem
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(677, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.loginToolStripMenuItem,
                this.connectToolStripMenuItem,
                this.toolStripSeparator11,
                this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new Size(159, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new EventHandler(this.loginToolStripMenuItem_Click);
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new Size(159, 22);
            this.connectToolStripMenuItem.Text = "Thiết lập kết nối";
            this.connectToolStripMenuItem.Click += new EventHandler(this.connectToolStripMenuItem_Click);
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new Size(156, 6);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            this.viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.languageToolStripMenuItem
            });
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.englishToolStripMenuItem,
                this.vietnameseToolStripMenuItem
            });
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new Size(126, 22);
            this.languageToolStripMenuItem.Text = "Language";
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new Size(135, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new EventHandler(this.englishToolStripMenuItem_Click);
            this.vietnameseToolStripMenuItem.Name = "vietnameseToolStripMenuItem";
            this.vietnameseToolStripMenuItem.Size = new Size(135, 22);
            this.vietnameseToolStripMenuItem.Text = "Vietnamese";
            this.vietnameseToolStripMenuItem.Click += new EventHandler(this.vietnameseToolStripMenuItem_Click);
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.CallByDateTimeToolStripMenuItem,
                this.CallTopNToolStripMenuItem,
                this.CallTimeGreaterToolStripMenuItem,
                this.CallByShiftToolStripMenuItem,
                this.callByRegionToolStripMenuItem
            });
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new Size(65, 20);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            this.CallByDateTimeToolStripMenuItem.Name = "CallByDateTimeToolStripMenuItem";
            this.CallByDateTimeToolStripMenuItem.Size = new Size(150, 22);
            this.CallByDateTimeToolStripMenuItem.Text = "Call by Time";
            this.CallByDateTimeToolStripMenuItem.Click += new EventHandler(this.CallByDateTimeToolStripMenuItem_Click);
            this.CallTopNToolStripMenuItem.Name = "CallTopNToolStripMenuItem";
            this.CallTopNToolStripMenuItem.Size = new Size(150, 22);
            this.CallTopNToolStripMenuItem.Text = "Call Top N";
            this.CallTopNToolStripMenuItem.Click += new EventHandler(this.CallTopNToolStripMenuItem_Click);
            this.CallTimeGreaterToolStripMenuItem.Name = "CallTimeGreaterToolStripMenuItem";
            this.CallTimeGreaterToolStripMenuItem.Size = new Size(150, 22);
            this.CallTimeGreaterToolStripMenuItem.Text = "Call Wait Over";
            this.CallTimeGreaterToolStripMenuItem.Click += new EventHandler(this.CallTimeGreaterToolStripMenuItem_Click);
            this.CallByShiftToolStripMenuItem.Name = "CallByShiftToolStripMenuItem";
            this.CallByShiftToolStripMenuItem.Size = new Size(150, 22);
            this.CallByShiftToolStripMenuItem.Text = "Call by Shift";
            this.CallByShiftToolStripMenuItem.Click += new EventHandler(this.CallByShiftToolStripMenuItem_Click);
            this.callByRegionToolStripMenuItem.Name = "callByRegionToolStripMenuItem";
            this.callByRegionToolStripMenuItem.Size = new Size(150, 22);
            this.callByRegionToolStripMenuItem.Text = "Call by Region";
            this.callByRegionToolStripMenuItem.Click += new EventHandler(this.callByRegionToolStripMenuItem_Click);
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.serialPortSettingsToolStripMenuItem,
                this.equipmentToolStripMenuItem,
                this.toolStripSeparator10,
                this.soundsToolStripMenuItem,
                this.soundTemplatesToolStripMenuItem,
                this.toolStripSeparator3,
                this.mailSetupToolStripMenuItem,
                this.mailScheduleToolStripMenuItem,
                this.mailListsToolStripMenuItem,
                this.toolStripSeparator13,
                this.optionsToolStripMenuItem
            });
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.serialPortSettingsToolStripMenuItem.Name = "serialPortSettingsToolStripMenuItem";
            this.serialPortSettingsToolStripMenuItem.Size = new Size(181, 22);
            this.serialPortSettingsToolStripMenuItem.Text = "Serial Port Settings...";
            this.serialPortSettingsToolStripMenuItem.Click += new EventHandler(this.serialPortSettingsToolStripMenuItem_Click);
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new Size(181, 22);
            this.equipmentToolStripMenuItem.Text = "Equipment";
            this.equipmentToolStripMenuItem.Click += new EventHandler(this.equipmentToolStripMenuItem_Click);
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new Size(178, 6);
            this.soundsToolStripMenuItem.Name = "soundsToolStripMenuItem";
            this.soundsToolStripMenuItem.Size = new Size(181, 22);
            this.soundsToolStripMenuItem.Text = "Sounds";
            this.soundsToolStripMenuItem.Click += new EventHandler(this.soundsToolStripMenuItem_Click);
            this.soundTemplatesToolStripMenuItem.Name = "soundTemplatesToolStripMenuItem";
            this.soundTemplatesToolStripMenuItem.Size = new Size(181, 22);
            this.soundTemplatesToolStripMenuItem.Text = "Sound Templates";
            this.soundTemplatesToolStripMenuItem.Click += new EventHandler(this.soundTemplatesToolStripMenuItem_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(178, 6);
            this.mailSetupToolStripMenuItem.Name = "mailSetupToolStripMenuItem";
            this.mailSetupToolStripMenuItem.Size = new Size(181, 22);
            this.mailSetupToolStripMenuItem.Text = "Mail Setup";
            this.mailSetupToolStripMenuItem.Click += new EventHandler(this.mailSetupToolStripMenuItem_Click);
            this.mailScheduleToolStripMenuItem.Name = "mailScheduleToolStripMenuItem";
            this.mailScheduleToolStripMenuItem.Size = new Size(181, 22);
            this.mailScheduleToolStripMenuItem.Text = "Mail Schedule";
            this.mailScheduleToolStripMenuItem.Click += new EventHandler(this.mailScheduleToolStripMenuItem_Click);
            this.mailListsToolStripMenuItem.Name = "mailListsToolStripMenuItem";
            this.mailListsToolStripMenuItem.Size = new Size(181, 22);
            this.mailListsToolStripMenuItem.Text = "Mail Lists";
            this.mailListsToolStripMenuItem.Click += new EventHandler(this.mailListsToolStripMenuItem_Click);
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new Size(178, 6);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new Size(181, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new EventHandler(this.optionsToolStripMenuItem_Click);
            this.systemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.configManagerToolStripMenuItem,
                this.toolStripMenuItemConfigEvent,
                this.servicesToolStripMenuItem,
                this.productsToolStripMenuItem,
                this.toolStripSeparator5,
                this.departmentsToolStripMenuItem,
                this.jobsToolStripMenuItem,
                this.toolStripSeparator4,
                this.employeesManagerToolStripMenuItem,
                this.hospitalPropertiesToolStripMenuItem,
                this.toolStripSeparator8,
                this.shiftToolStripMenuItem,
                this.workShiftToolStripMenuItem,
                this.toolStripSeparator9,
                this.usersToolStripMenuItem,
                this.userBedCallToolStripMenuItem,
                this.toolStripSeparator12,
                this.rightsToolStripMenuItem,
                this.functionsToolStripMenuItem,
                this.rightFunctionToolStripMenuItem
            });
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            this.configManagerToolStripMenuItem.Name = "configManagerToolStripMenuItem";
            this.configManagerToolStripMenuItem.Size = new Size(183, 22);
            this.configManagerToolStripMenuItem.Text = "Config Manager...";
            this.configManagerToolStripMenuItem.Click += new EventHandler(this.configManagerToolStripMenuItem_Click);
            this.toolStripMenuItemConfigEvent.Name = "toolStripMenuItemConfigEvent";
            this.toolStripMenuItemConfigEvent.Size = new Size(183, 22);
            this.toolStripMenuItemConfigEvent.Text = "Config Event";
            this.toolStripMenuItemConfigEvent.Click += new EventHandler(this.toolStripMenuItemConfigEvent_Click);
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new Size(183, 22);
            this.servicesToolStripMenuItem.Text = "Services";
            this.servicesToolStripMenuItem.Click += new EventHandler(this.servicesToolStripMenuItem_Click);
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new Size(183, 22);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new EventHandler(this.productsToolStripMenuItem_Click);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new Size(180, 6);
            this.departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            this.departmentsToolStripMenuItem.Size = new Size(183, 22);
            this.departmentsToolStripMenuItem.Text = "Departments";
            this.departmentsToolStripMenuItem.Click += new EventHandler(this.departmentsToolStripMenuItem_Click);
            this.jobsToolStripMenuItem.Name = "jobsToolStripMenuItem";
            this.jobsToolStripMenuItem.Size = new Size(183, 22);
            this.jobsToolStripMenuItem.Text = "Jobs";
            this.jobsToolStripMenuItem.Click += new EventHandler(this.jobsToolStripMenuItem_Click);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(180, 6);
            this.employeesManagerToolStripMenuItem.Name = "employeesManagerToolStripMenuItem";
            this.employeesManagerToolStripMenuItem.Size = new Size(183, 22);
            this.employeesManagerToolStripMenuItem.Text = "Employees Manager";
            this.employeesManagerToolStripMenuItem.Click += new EventHandler(this.employeesManagerToolStripMenuItem_Click);
            this.hospitalPropertiesToolStripMenuItem.Name = "hospitalPropertiesToolStripMenuItem";
            this.hospitalPropertiesToolStripMenuItem.Size = new Size(183, 22);
            this.hospitalPropertiesToolStripMenuItem.Text = "Hospital Properties...";
            this.hospitalPropertiesToolStripMenuItem.Click += new EventHandler(this.hospitalToolStripMenuItem_Click);
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new Size(180, 6);
            this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            this.shiftToolStripMenuItem.Size = new Size(183, 22);
            this.shiftToolStripMenuItem.Text = "Shift";
            this.shiftToolStripMenuItem.Click += new EventHandler(this.shiftToolStripMenuItem_Click);
            this.workShiftToolStripMenuItem.Name = "workShiftToolStripMenuItem";
            this.workShiftToolStripMenuItem.Size = new Size(183, 22);
            this.workShiftToolStripMenuItem.Text = "Work shift";
            this.workShiftToolStripMenuItem.Click += new EventHandler(this.workShiftToolStripMenuItem_Click);
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new Size(180, 6);
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new Size(183, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new EventHandler(this.usersToolStripMenuItem_Click);

            this.userBedCallToolStripMenuItem.Name = "userBedCallToolStripMenuItem";
            this.userBedCallToolStripMenuItem.Size = new Size(183, 22);
            this.userBedCallToolStripMenuItem.Text = "Users Bed Call";
            this.userBedCallToolStripMenuItem.Click += new EventHandler(this.userBedCallToolStripMenuItem_Click);

            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new Size(180, 6);
            this.rightsToolStripMenuItem.Name = "rightsToolStripMenuItem";
            this.rightsToolStripMenuItem.Size = new Size(183, 22);
            this.rightsToolStripMenuItem.Text = "Rights";
            this.rightsToolStripMenuItem.Click += new EventHandler(this.rightsToolStripMenuItem_Click);
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new Size(183, 22);
            this.functionsToolStripMenuItem.Text = "Functions";
            this.functionsToolStripMenuItem.Click += new EventHandler(this.functionsToolStripMenuItem_Click);
            this.rightFunctionToolStripMenuItem.Name = "rightFunctionToolStripMenuItem";
            this.rightFunctionToolStripMenuItem.Size = new Size(183, 22);
            this.rightFunctionToolStripMenuItem.Text = "Right Function";
            this.rightFunctionToolStripMenuItem.Click += new EventHandler(this.rightFunctionToolStripMenuItem_Click);
            this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.aboutToolStripMenuItem,
                this.testToolStripMenuItem,
                this.clearAllCallToolStripMenuItem
            });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new Size(116, 22);
            this.testToolStripMenuItem.Text = "Test Form";
            this.testToolStripMenuItem.Click += new EventHandler(this.testToolStripMenuItem_Click);
            this.clearAllCallToolStripMenuItem.Name = "clearAllCallToolStripMenuItem";
            this.clearAllCallToolStripMenuItem.Size = new Size(116, 22);
            this.clearAllCallToolStripMenuItem.Text = "Test Form";
            this.clearAllCallToolStripMenuItem.Click += new EventHandler(this.clearAllCallToolStripMenuItem_Click);
            this.statusStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.serialPortStatusToolStripStatusLabel,
                this.tssDataSend,
                this.statusToolStripStatusLabel,
                this.clockToolStripStatusLabel
            });
            this.statusStrip1.Location = new Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(677, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.serialPortStatusToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
            this.serialPortStatusToolStripStatusLabel.Name = "serialPortStatusToolStripStatusLabel";
            this.serialPortStatusToolStripStatusLabel.Size = new Size(44, 19);
            this.serialPortStatusToolStripStatusLabel.Text = "COM?";
            this.tssDataSend.AutoSize = false;
            this.tssDataSend.BorderSides = ToolStripStatusLabelBorderSides.Right;
            this.tssDataSend.Name = "tssDataSend";
            this.tssDataSend.Size = new Size(150, 19);
            this.tssDataSend.Text = "Data Send";
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new Size(341, 19);
            this.statusToolStripStatusLabel.Spring = true;
            this.clockToolStripStatusLabel.Name = "clockToolStripStatusLabel";
            this.clockToolStripStatusLabel.Size = new Size(127, 19);
            this.clockToolStripStatusLabel.Text = "00/00/0000 00:00:00 TT";
            this.toolStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.toolStripButton1,
                this.toolStripButton2,
                this.toolStripSeparator1,
                this.serialPortToolStripLabel,
                this.serialPortToolStripSplitButton,
                this.toolStripSeparator2,
                this.helpToolStripButton
            });
            this.toolStrip1.Location = new Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(677, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = (Image)componentResourceManager.GetObject("toolStripButton1.Image");
            this.toolStripButton1.ImageTransparentColor = Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
            this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = (Image)componentResourceManager.GetObject("toolStripButton2.Image");
            this.toolStripButton2.ImageTransparentColor = Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 25);
            this.serialPortToolStripLabel.Name = "serialPortToolStripLabel";
            this.serialPortToolStripLabel.Size = new Size(40, 22);
            this.serialPortToolStripLabel.Text = "COM?";
            this.serialPortToolStripSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.serialPortToolStripSplitButton.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.openToolStripMenuItem,
                this.closeToolStripMenuItem
            });
            this.serialPortToolStripSplitButton.Image = (Image)componentResourceManager.GetObject("serialPortToolStripSplitButton.Image");
            this.serialPortToolStripSplitButton.ImageTransparentColor = Color.Magenta;
            this.serialPortToolStripSplitButton.Name = "serialPortToolStripSplitButton";
            this.serialPortToolStripSplitButton.Size = new Size(32, 22);
            this.serialPortToolStripSplitButton.Text = "toolStripSplitButton1";
            this.openToolStripMenuItem.Image = (Image)componentResourceManager.GetObject("openToolStripMenuItem.Image");
            this.openToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
            this.closeToolStripMenuItem.Image = (Image)componentResourceManager.GetObject("closeToolStripMenuItem.Image");
            this.closeToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new EventHandler(this.closeToolStripMenuItem_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 25);
            this.helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = (Image)componentResourceManager.GetObject("helpToolStripButton.Image");
            this.helpToolStripButton.ImageTransparentColor = Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new Size(23, 22);
            this.helpToolStripButton.Text = "Help";
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.c1TrueDBGrid1);
            this.splitContainer1.Panel2.Controls.Add(this.mainPanel);
            this.splitContainer1.Panel2.Controls.Add(this.mainVScrollBar);
            this.splitContainer1.Panel2.Controls.Add(this.headerPanel);
            this.splitContainer1.Size = new Size(677, 365);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 3;
            this.c1TrueDBGrid1.CaptionHeight = 17;
            this.c1TrueDBGrid1.Dock = DockStyle.Fill;
            this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
            this.c1TrueDBGrid1.Location = new Point(0, 0);
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
            this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
            this.c1TrueDBGrid1.RowHeight = 15;
            this.c1TrueDBGrid1.Size = new Size(177, 365);
            this.c1TrueDBGrid1.TabIndex = 0;
            this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.MouseDown += new MouseEventHandler(this.c1TrueDBGrid1_MouseDown);
            this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Location = new Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new Size(476, 337);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Resize += new EventHandler(this.mainPanel_Resize);
            this.mainVScrollBar.Dock = DockStyle.Right;
            this.mainVScrollBar.LargeChange = 48;
            this.mainVScrollBar.Location = new Point(476, 28);
            this.mainVScrollBar.Name = "mainVScrollBar";
            this.mainVScrollBar.Size = new Size(20, 337);
            this.mainVScrollBar.SmallChange = 12;
            this.mainVScrollBar.TabIndex = 1;
            this.mainVScrollBar.ValueChanged += new EventHandler(this.mainVScrollBar_ValueChanged);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Location = new Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new Size(496, 28);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.Paint += new PaintEventHandler(this.headerPanel_Paint);
            this.tmerResetDateTime.Interval = 1000;
            this.tmerResetDateTime.Tick += new EventHandler(this.tmerResetDateTime_Tick);
            this.bedContextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                this.callBedToolStripMenuItem,
                this.stopBedToolStripMenuItem,
                this.toolStripSeparator6,
                this.bedDetailsToolStripMenuItem
            });
            this.bedContextMenuStrip.Name = "bedContextMenuStrip";
            this.bedContextMenuStrip.Size = new Size(153, 98);
            this.bedContextMenuStrip.MouseClick += new MouseEventHandler(this.bedContextMenuStrip_MouseClick);
            this.bedContextMenuStrip.Closing += new ToolStripDropDownClosingEventHandler(this.bedContextMenuStrip_Closing);
            this.callBedToolStripMenuItem.Enabled = false;
            this.callBedToolStripMenuItem.Name = "callBedToolStripMenuItem";
            this.callBedToolStripMenuItem.Size = new Size(152, 22);
            this.callBedToolStripMenuItem.Text = "Call...";
            this.stopBedToolStripMenuItem.Name = "stopBedToolStripMenuItem";
            this.stopBedToolStripMenuItem.Size = new Size(152, 22);
            this.stopBedToolStripMenuItem.Text = "Stop";
            this.stopBedToolStripMenuItem.Click += new EventHandler(this.stopBedToolStripMenuItem_Click);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new Size(149, 6);
            this.bedDetailsToolStripMenuItem.Enabled = false;
            this.bedDetailsToolStripMenuItem.Name = "bedDetailsToolStripMenuItem";
            this.bedDetailsToolStripMenuItem.Size = new Size(152, 22);
            this.bedDetailsToolStripMenuItem.Text = "Details...";
            this.roomContextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                this.callRoomToolStripMenuItem,
                this.roomPropertiesToolStripSeparator,
                this.roomDetailsToolStripMenuItem
            });
            this.roomContextMenuStrip.Name = "bedContextMenuStrip";
            this.roomContextMenuStrip.Size = new Size(119, 54);
            this.callRoomToolStripMenuItem.Name = "callRoomToolStripMenuItem";
            this.callRoomToolStripMenuItem.Size = new Size(118, 22);
            this.callRoomToolStripMenuItem.Text = "Call...";
            this.roomPropertiesToolStripSeparator.Name = "roomPropertiesToolStripSeparator";
            this.roomPropertiesToolStripSeparator.Size = new Size(115, 6);
            this.roomDetailsToolStripMenuItem.Name = "roomDetailsToolStripMenuItem";
            this.roomDetailsToolStripMenuItem.Size = new Size(118, 22);
            this.roomDetailsToolStripMenuItem.Text = "Details...";
            this.regionContextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                this.callRegionToolStripMenuItem,
                this.toolStripSeparator7,
                this.regionDetailsToolStripMenuItem
            });
            this.regionContextMenuStrip.Name = "bedContextMenuStrip";
            this.regionContextMenuStrip.Size = new Size(119, 54);
            this.callRegionToolStripMenuItem.Name = "callRegionToolStripMenuItem";
            this.callRegionToolStripMenuItem.Size = new Size(118, 22);
            this.callRegionToolStripMenuItem.Text = "Call...";
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new Size(115, 6);
            this.regionDetailsToolStripMenuItem.Name = "regionDetailsToolStripMenuItem";
            this.regionDetailsToolStripMenuItem.Size = new Size(118, 22);
            this.regionDetailsToolStripMenuItem.Text = "Details...";
            this.timer2.Interval = 5000;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            this.tmerQuetRepeatSound.Interval = 1000;
            this.tmerQuetRepeatSound.Tick += new EventHandler(this.tmerQuetRepeatSound_Tick);
            this.tmerCheckSendMail.Interval = 1000;
            this.tmerCheckSendMail.Tick += new EventHandler(this.tmerCheckSendMail_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(677, 438);
            base.Controls.Add(this.splitContainer1);
            base.Controls.Add(this.toolStrip1);
            base.Controls.Add(this.statusStrip1);
            base.Controls.Add(this.menuStrip1);


            tmerFindSound = new System.Windows.Forms.Timer();
            tmerFindSound.Enabled = false;
            tmerFindSound.Interval = 1000;
            tmerFindSound.Tick += new EventHandler(this.tmerFindSound_Tick);


            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "FMAIN";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "F1- Nurse Call System";
            base.Load += new EventHandler(this.FMAIN_Load);
            base.Activated += new EventHandler(this.FMAIN_Activated);
            base.FormClosing += new FormClosingEventHandler(this.FMAIN_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
            this.bedContextMenuStrip.ResumeLayout(false);
            this.roomContextMenuStrip.ResumeLayout(false);
            this.regionContextMenuStrip.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();

        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.blnSendData = false;
            base.Invoke(new EventHandler(this.ProcessData));
        }
        private void ProcessData(object s, EventArgs e)
        {
            int bytesToRead = this.comport.BytesToRead;
            byte[] array = new byte[bytesToRead];
            this.comport.Read(array, 0, bytesToRead);
            if (array.Length > 0)
            {
                this.strRev = this.strRev + BitConverter.ToString(array) + "-";
            }
            int num = this.strRev.IndexOf("02");
            if (num > 0)
            {
                this.strRev = this.strRev.Substring(num, this.strRev.Length - num);
            }
            num = this.strRev.IndexOf("02");
            int num2 = this.strRev.IndexOf("03");
            if (this.strRev.Contains("02") && this.strRev.Contains("03") && num < num2)
            {
                string sCommand = this.strRev;
                this.strRev = this.strRev.Substring(num2 + 3, this.strRev.Length - (num2 + 3));
                this.ParseToCommand(sCommand);
            }
            this.blnSendData = true;
        }

        private void OnTimedSendDataEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                if (this.blnSendData && this.comport.IsOpen && this.giRegion <= this.MyRs.Count - 1)
                {
                    if (this.giRegion < 0)
                        this.giRegion = 0;

                    string text = "0" + this.MyRs[this.giRegion].iRegionID.ToString();
                    text = text.Substring(text.Length - 2, 2);
                    string text2 = text + ",4,";
                    text2 += clsString.XOR(text2);
                    text2 = "02 " + clsString.Ascii2HexStringNull(text2) + " 03";
                    this.tssDataSend.Text = text2;
                    byte[] array = this.HexStringToByteArray(text2);
                    this.comport.Write(array, 0, array.Length);
                    this.giRegion++;
                    if (this.giRegion == this.MyRs.Count)
                        this.giRegion = 0;
                }
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "OnTimedSendDataEvent Error: " + ex.Message;
            }
        }

    }
}
