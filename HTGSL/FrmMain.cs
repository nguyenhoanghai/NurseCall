using C1.Win.C1TrueDBGrid;
//using HTGSL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using Properties;

namespace HTGSL
{
    public partial class FrmMain : Form
    {
        private C1TrueDBGrid c1TrueDBGrid1;
        private string strExecutingAssembly,
            strConnString = "",
            strConnStringDefault = "data source=Localhost;initial catalog=NurseCall;integrated security=SSPI;",
            sACK = clsString.HexString2Ascii("06"),
            sNAK = clsString.HexString2Ascii("15"),
            gsEquipment = "",
            strHospitalName = "";



        private int iAction = 9,
            iShift = 1,
            iUser = 1,
            iAllowDouble = 0,
            giRegion = 0,
iRegionHeight = 0,
        iRoomHeight = 0,
          iBedHeight = 0,
         iBedsPerRow = 0,
         iTimeRefreshData = 0,
        iTimeReadSound = 0;

        private SqlConnection MySqlConnect;
        private MySqlDataClass SqlData;
        private HospitalInfo MyHi = new HospitalInfo();
        private RegionExArray MyRs = new RegionExArray();
        private BedsArray MyBeds = new BedsArray();
        // Comport
        public enum DataMode { Text, Hex };
        public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
        private string strPortName,
            strStopBits,
            strDataBits,
            strParity,
            strBaudRate,
            strRev = "",
            strMailShedule = "",
      strFileAttactment1 = "",
        strFileAttactment2 = "";

        private bool bAutoOpenSerialPort = false,
            blnSendData = true,
            First_Open = false;

        // Parse Varibles
        private string sRegion = "",
       sRoom = "",
         sEquipment = "",
         sBed = "",
         sType_Request = "",
         sCheck_Sum = "";


        // New 19/02/2012
        private SqlConnection conn;
        private DataSet ds;
        private SqlDataAdapter da;
        private string strSQL;
        private DateTime loginTime = DateTime.Now;
        DataProvider provider = new DataProvider();

        //HoangHai 
        public static List<string> playList = new List<string>();
        SoundPlayer player;
        bool isFinishRead = true;
        Thread playThread;
        public FrmMain()
        {
            InitializeComponent();
            this.c1TrueDBGrid1 = new C1TrueDBGrid();
            this.c1TrueDBGrid1.CaptionHeight = 17;
            this.c1TrueDBGrid1.Dock = DockStyle.Fill;
            this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
            //  this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
            this.c1TrueDBGrid1.Location = new Point(0, 0);
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
            //  this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
            this.c1TrueDBGrid1.RowHeight = 15;
            this.c1TrueDBGrid1.Size = new Size(177, 365);
            this.c1TrueDBGrid1.TabIndex = 0;
            this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.MouseDown += new MouseEventHandler(this.c1TrueDBGrid1_MouseDown);
            //  this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
            this.panel1.Controls.Add(this.c1TrueDBGrid1);
            ((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
        }

        private void c1TrueDBGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tmerRefreshData.Stop();
                int x = e.X;
                int y = e.Y;
                this.bedContextMenuStrip.Show(x, y);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (SingleInstanceApplication.AlreadyExists)
                MyMsgBox.MsgAsterisk("The is an instance that was started with the /new command line");

            SingleInstanceApplication.NewInstanceMessage += new NewInstanceMessageEventHandler(SingleInstanceApplication_NewInstanceMessage);
            Assembly asm = Assembly.GetExecutingAssembly();
            this.strExecutingAssembly = asm.GetName().Name + ", Version=" + asm.GetName().Version.ToString();


            // Test Server Information
            if (!clsUtl.CONNECT_STATUS)
            {
                Form f = new FrmDBConnect();// F0002();
                f.ShowDialog();
            }

            // Set connect string
            strConnString = GetStringConnect();
            clsUtl.CONNECT_STRING = strConnString;

            // Set ngon ngu cho control
            this.LoadCaptionForControls();
            this.btnEnglish.Checked = (Settings.Default.Language == "en-US");
            this.btnVietNam.Checked = (Settings.Default.Language != "en-US");

            // Default Open Port
            this.InitSerialPort();
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

                //Control.CheckForIllegalCrossThreadCalls = false;
                tmerDateTime.Enabled = true;

                tmerRefreshData.Interval = this.iTimeRefreshData;
                tmerRefreshData.Enabled = true;
                string folderName = Application.StartupPath + "\\Outputs";
                this.ClearFolder(folderName);

                //this.timer3.Interval = this.iTimeReadSound;
                //this.timer3.Enabled = true;

                //this.timer4.Enabled = true;
                
                 tiSendData.Interval = Settings.Default.TimeSendData;
                 tiSendData.Enabled = true;

                 userNameToolStripMenuItem.Text = clsUtl.USER_NAME;

                //HoangHai
                player = new SoundPlayer();
                //  PlaySound("1", "001", "1");
                tmerFindSound.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FMAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
            }



            TrueDBGridFormat();
        }




        /// <summary>
        /// Cai dat ngon ngu cho control
        /// </summary>
        private void LoadCaptionForControls()
        {
            // this.Text = Properties.Resources.String1;

            // File
            this.fileToolStripMenuItem.Text = Properties.Resources.File;
            this.btnDatabase.Text = Properties.Resources.SetConnect;
            this.logoutToolStripMenuItem.Text = Properties.Resources.Login;
            this.exitToolStripMenuItem.Text = Properties.Resources.Exit;

            // View
            this.viewToolStripMenuItem.Text = Properties.Resources.View;
            this.languageToolStripMenuItem.Text = Properties.Resources.Language;
            this.btnEnglish.Text = Properties.Resources.English;
            this.btnVietNam.Text = Properties.Resources.Vietnamese;

            // Statistics
            this.statisticToolStripMenuItem.Text = Properties.Resources.Statistic;
            this.btnRCallbytime.Text = Properties.Resources.CallbyTime;
            this.btnRCalltopN.Text = Properties.Resources.CallTopN;
            this.btnRCallOver.Text = Properties.Resources.CallWaitOver;
            this.btnRCallshift.Text = Properties.Resources.CallbyShift;

            // Tools
            this.toolsToolStripMenuItem.Text = Properties.Resources.Tools;
            this.btnSerialport.Text = Properties.Resources.SerialPortSettings + "...";
            this.optionsToolStripMenuItem.Text = Properties.Resources.Options + "...";
            this.btnSounds.Text = Properties.Resources.Sounds;
            this.btnSoundTem.Text = Properties.Resources.SoundTemplates;

            // System
            this.systemToolStripMenuItem.Text = Properties.Resources.System;
            this.btnConfigManager.Text = Properties.Resources.ConfigManager;
            this.btnDepartment.Text = Properties.Resources.Departments;
            this.btnJob.Text = Properties.Resources.Jobs;
            this.btnEmployee.Text = Properties.Resources.EmployeesManager;
            this.btnHospitalProp.Text = Properties.Resources.HospitalProperties + "...";

            this.btnUser.Text = Properties.Resources.Users;
            this.btnShift.Text = Properties.Resources.Shifts;
            this.btnWorkShift.Text = Properties.Resources.WorkShifts;

            this.btnRight.Text = Properties.Resources.Rights;
            this.btnFunction.Text = Properties.Resources.Functions;
            this.btnRightFunc.Text = Properties.Resources.Right_Function;

            // Help
            this.helpToolStripMenuItem.Text = Properties.Resources.Help_;
            this.btnAbout.Text = Properties.Resources.About + " " + this.strExecutingAssembly;

            // Tool Bar
            this.serialPortToolStripSplitButton.Text = Properties.Resources.SerialPort;
            this.openToolStripMenuItem.Text = Properties.Resources.Open;
            this.closeToolStripMenuItem.Text = Properties.Resources.Close;
            this.helpToolStripButton.Text = Properties.Resources.Help_;

            // Popup menu
            this.callRegionToolStripMenuItem.Text = Properties.Resources.Call + "...";
            this.regionDetailsToolStripMenuItem.Text = Properties.Resources.Details + "...";

            this.callRoomToolStripMenuItem.Text = Properties.Resources.Call + "...";
            this.roomDetailsToolStripMenuItem.Text = Properties.Resources.Details + "...";

            this.callBedToolStripMenuItem.Text = Properties.Resources.Call + "...";
            this.stopBedToolStripMenuItem.Text = Properties.Resources.Stop_;
            this.bedDetailsToolStripMenuItem.Text = Properties.Resources.Details + "...";

        }


        #region Database connection
        private string GetStringConnect()
        {
            try
            {
                // Nạp tài liệu.
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "\\DATA.XML");

                // Thu lấy tất cả các kết nối.
                XmlNodeList sqlserver = doc.GetElementsByTagName("SQLServer");
                string sServer_Name = "";
                string sDatabase = "";
                string sUser_ID = "";
                string sPwd = "";

                //foreach (XmlNode node in sqlserver)
                //{
                //    sServer_Name = node.ChildNodes[0].InnerText;
                //    sDatabase = node.ChildNodes[1].InnerText;
                //    sUser_ID = node.ChildNodes[2].InnerText;
                //    sPwd = node.ChildNodes[3].InnerText;
                //}

                sServer_Name = sqlserver.Item(0).ChildNodes[0].InnerText;
                sDatabase = sqlserver.Item(0).ChildNodes[1].InnerText;
                sUser_ID = sqlserver.Item(0).ChildNodes[2].InnerText;
                sPwd = sqlserver.Item(0).ChildNodes[3].InnerText;

                // Gan bien toàn cục
                //gstrServerName = sServer_Name;
                //gstrDatabase = sDatabase;
                //gstrUserID = sUser_ID;
                //gstrPassword = sPwd;
                return "Server=" + sServer_Name + ";Database=" + sDatabase + ";uid=" + sUser_ID + ";pwd=" + sPwd;

            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion

        #region SerialPort
        private void InitSerialPort()
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
                    //hai
                    for (int i = 0; i < Settings.Default.TimeRepeatSendACK; i++)
                    {
                        this.WriteData2Comport(this.sRegion, this.sACK);
                        Thread.Sleep(Settings.Default.TimeSleepAfterSendACK);
                    }
                    //

                    if (this.ParseStringCallRequest(text))
                    {
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
                                                this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): đã xử lý." });
                                        }
                                }
                                else
                                {
                                    if (Settings.Default.ProcessTime)
                                    {
                                        string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 2);
                                        if (a2 == "Y")
                                            this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): kết thúc." });
                                    }
                                    else
                                    {
                                        string a2 = this.SaveData(int.Parse(this.sRegion), this.sRoom, this.sEquipment, this.sBed, this.iShift, this.iUser, 5);
                                        if (a2 == "Y")
                                            this.statusToolStripStatusLabel.Text = string.Concat(new string[] { "(", this.sRegion, ", ", this.sRoom, ", ", this.sBed, "): kết thúc." });
                                    }
                                    int num3 = this.ExistCallRequest();
                                    if (num3 <= 0)
                                        this.WriteData2Comport(this.gsEquipment, "10");
                                }
                            }
                            else
                            {
                                this.WriteData2Comport(this.gsEquipment, "07");
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
                    this.WriteData2Comport(this.sRegion, this.sNAK);
                }
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
                clsSound clsSound = new clsSound();
                clsSound.SetSoundTemplate(sRoom);
                string soundStr = clsSound.GetSoundToPlay(sRegion, sRoom, sBed);
                if (!string.IsNullOrEmpty(soundStr))
                {
                    string str = (int.Parse(sRegion) + "|" + int.Parse(sRoom) + "|" + int.Parse(sBed));
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
                            else
                                sql += "INSERT INTO [dbo].[N_CallRequires]([UserId],[Content],[CreatedDate])VALUES(" + table.Rows[i][0].ToString() + ",N'" + soundStr + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                        }
                        if (hasMe)
                            playList.AddRange(soundStr.Split('|'));

                        provider.excuteNonQuery(sql);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PlaySound");
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
        private bool ParseStringCallRequest(string strInput)
        {
            bool result;
            try
            {
                int num = strInput.IndexOf(",");
                this.sRegion = strInput.Substring(0, num);
                int length = strInput.Length;
                strInput = strInput.Substring(num + 1, length - num - 1);
                int num2 = strInput.IndexOf(",");
                this.sRoom = strInput.Substring(0, num2);
                length = strInput.Length;
                strInput = strInput.Substring(num2 + 1, length - num2 - 1);
                int num3 = strInput.IndexOf(",");
                this.sType_Request = strInput.Substring(0, num3);
                length = strInput.Length;
                strInput = strInput.Substring(num3 + 1, strInput.Length - num3 - 1);
                int num4 = strInput.IndexOf(",");
                this.sBed = strInput.Substring(0, num4);
                length = strInput.Length;
                strInput = strInput.Substring(num4 + 1, length - num4 - 1);
                this.sCheck_Sum = strInput.Trim();
                result = true;
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
        private string SaveData(int iRegion, string sRoom, string sEquip, string sBed, int iShift, int iUser, int iAction)
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





        #endregion


        void SingleInstanceApplication_NewInstanceMessage(object sender, object message)
        {
            int processId = (int)message;
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
        }
        private void Restart(FrmMain frmMain)
        {
            string strPathMyProgram = Path.Combine(Application.ExecutablePath, "");
            frmMain.Close();
            frmMain.Dispose();
            Process newProc = Process.Start(strPathMyProgram);
        }

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



        private void btnVietNam_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Language != "vi-VN")
            {
                Settings.Default.Language = "vi-VN";
                Settings.Default.Save();
                MyMsgBox.MsgInformation(Properties.Resources.ConfirmMessage, Properties.Resources.ConfirmTitle);
                Restart(this);
            }
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Language != "en-US")
            {
                Settings.Default.Language = "en-US";
                Settings.Default.Save();
                MyMsgBox.MsgInformation(Properties.Resources.ConfirmMessage, Properties.Resources.ConfirmTitle);
                Restart(this);
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

        #region Draw c1 component
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
                    string s_Bed_id = sqlDataReader["bed_id"].ToString();
                    int i_event_type = int.Parse(sqlDataReader["event_type"].ToString());
                    int i_max_times = int.Parse(sqlDataReader["max_times"].ToString());
                    BedInfor si = new BedInfor(s_Bed_id, i_event_type, i_max_times);
                    bedsArray.Add(si);
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
        private void CountFooterMaster()
        {
            this.c1TrueDBGrid1.Columns["bed_call"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
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

        #endregion

        private void btnSerialport_Click(object sender, EventArgs e)
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
        private void SaveSerialPortSettings()
        {
            Settings.Default.PortName = this.strPortName;
            Settings.Default.BaudRate = int.Parse(this.strBaudRate);
            Settings.Default.DataBits = int.Parse(this.strDataBits);
            Settings.Default.Parity = (Parity)Enum.Parse(typeof(Parity), this.strParity);
            Settings.Default.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.strStopBits);
            Settings.Default.Save();
        }
        private void OnTimedEvent(object source, EventArgs e)
        {
            try
            {
                this.RefreshData();
                this.CountFooterMaster();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - timerRefreshData_Tick: " + ex.Message;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Default.EndAllCall)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa tất cả sự kiện ?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.conn = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                    if (this.conn.State == ConnectionState.Closed)
                    {
                        this.conn.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand("sp_end_all_call", this.conn);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = DateTime.Now;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            if (this.MySqlConnect != null)
            {
                this.MySqlConnect.Close();
                this.tmerDateTime.Enabled = false;
                this.timer2.Enabled = false;
                if (this.comport.IsOpen)
                {
                    this.comport.Close();
                }
            }
        }

        private void tmerDateTime_Tick(object sender, EventArgs e)
        {
            this.clockToolStripStatusLabel.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void tiSendData_Tick(object sender, EventArgs e)
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
                    {
                        this.giRegion = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "OnTimedSendDataEvent Error: " + ex.Message;
            }
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

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            Form form = new FrmDBConnect();//F0002();
            form.ShowDialog();
        } 

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnRCallbytime_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new FrmRDateToDate();
                form.Show();
            }
            catch (Exception ex)
            {
                this.statusToolStripStatusLabel.Text = "Error - CallByDateTimeToolStripMenuItem_Click: " + ex.Message;
            }
        }

        private void btnRCalltopN_Click(object sender, EventArgs e)
        {

        }

        private void btnRCallOver_Click(object sender, EventArgs e)
        {

        }

        private void btnRCallshift_Click(object sender, EventArgs e)
        {

        }
      


    }
}
