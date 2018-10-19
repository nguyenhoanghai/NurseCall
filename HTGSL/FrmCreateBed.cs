using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace HTGSL
{
    public partial class FrmCreateBed : Form
    {
        private SqlConnection conn;
        private DataSet ds;
        private SqlDataAdapter da;
        private string strSql;

        public bool bModify = false;

        private int the_iRegionID;
        public int The_iRegionID
        {
            get { return the_iRegionID; }
            set { the_iRegionID = value; }
        }

        private string the_strRegionName;
        public string The_strRegionName
        {
            get { return the_strRegionName; }
            set { the_strRegionName = value; }
        }

        private int the_iRoomID;
        public int The_iRoomID
        {
            get { return the_iRoomID; }
            set { the_iRoomID = value; }
        }

        private string the_strRoomName;
        public string The_strRoomName
        {
            get { return the_strRoomName; }
            set { the_strRoomName = value; }
        }

        private int the_iBedID;
        public int The_iBedID
        {
            get { return the_iBedID; }
            set { the_iBedID = value; }
        }

        private string the_strBedName;
        public string The_strBedName
        {
            get { return the_strBedName; }
            set { the_strBedName = value; }
        }

        private string the_strNote;
        public string The_strNote
        {
            get { return the_strNote; }
            set { the_strNote = value; }
        }

        private bool the_bInstall;
        public bool The_bInstall
        {
            get { return the_bInstall; }
            set { the_bInstall = value; }
        }

        private string the_curator;
        public string The_Curator
        {
            get { return the_curator; }
            set { the_curator = value; }
        }
        private int the_icurator;
        public int The_iCurator
        {
            get { return the_icurator; }
            set { the_icurator = value; }
        }
        public FrmCreateBed()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.LoadCaptionForControls();
            this.LoadUser();
            this.regionIdTextBox.Text = this.the_iRegionID.ToString();
            this.regionNameTextBox.Text = this.the_strRegionName;
            this.roomIdTextBox.Text = this.the_iRoomID.ToString();
            this.roomNameTextBox.Text = this.the_strRoomName;
            this.bedIdTextBox.ReadOnly = this.bModify;
            this.bedIdTextBox.TabStop = !this.bModify;
            this.bedIdTextBox.Text = this.the_iBedID.ToString();
            this.bedNameTextBox.Text = this.the_strBedName;
            this.noteTextBox.Text = this.the_strNote;
            this.cbuser.Text = this.the_curator.ToString();
            this.yesRadioButton.Checked = this.the_bInstall;
        }
        private void LoadUser()
        {
            conn = new SqlConnection(GetStringConnect());
            conn.Open();
            ds = new DataSet();

            // KIEU XE
            strSql = "SELECT [employee_id] ,[first_name] +' '+[last_name] as name   FROM [dbo].[EMPLOYEES]";
            da = new SqlDataAdapter(strSql, conn);
            da.Fill(ds, "employee");
            cbuser.ValueMember = "employee_id";
            cbuser.DisplayMember = "name";
            cbuser.DataSource = ds.Tables["employee"];
        }

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

                sServer_Name = sqlserver.Item(0).ChildNodes[0].InnerText;
                sDatabase = sqlserver.Item(0).ChildNodes[1].InnerText;
                sUser_ID = sqlserver.Item(0).ChildNodes[2].InnerText;
                sPwd = sqlserver.Item(0).ChildNodes[3].InnerText;
                return "Server=" + sServer_Name + ";Database=" + sDatabase + ";uid=" + sUser_ID + ";pwd=" + sPwd;
            }
            catch (Exception)
            {
                return "";
            }
        }


        private void LoadCaptionForControls()
        {
            this.Text = this.bModify ? "F6 - " + Properties.Resources.ModifyBed : "F6 - " + Properties.Resources.NewBed;
            this.bedInfoGroupBox.Text = Properties.Resources.BedInfo;
            this.regionLabel.Text = Properties.Resources.Region + ":";
            this.roomLabel.Text = Properties.Resources.Room + ":";
            this.bedLabel.Text = Properties.Resources.Bed + ":";
            this.noteLabel.Text = Properties.Resources.Note + ":";
            this.installLabel.Text = Properties.Resources.Install + ":";
            this.noRadioButton.Text = Properties.Resources.No;
            this.yesRadioButton.Text = Properties.Resources.Yes;
            this.okButton.Text = Properties.Resources.OK;
            this.cancelButton.Text = Properties.Resources.Cancel;
        }

        private void NumberChecked_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!this.bModify)
            {
                string strBedID_ = this.bedIdTextBox.Text.Trim();
                if (strBedID_ == string.Empty)
                {
                    MyMsgBox.MsgError(Properties.Resources.BedID + " " + Properties.Resources.IsNotEmpty + "!");
                    this.bedIdTextBox.Focus();
                    return;
                }
                if (!StringEx.IsStrNumber(strBedID_))
                {
                    MyMsgBox.MsgError(Properties.Resources.BedID + " " + Properties.Resources.IsNumber + "!");
                    this.bedIdTextBox.Focus();
                    return;
                }
                int iBedID_ = Int32.Parse(strBedID_);
                if (iBedID_ < 1)
                {
                    MyMsgBox.MsgError(Properties.Resources.BedID + " > 0 !");
                    this.bedIdTextBox.Focus();
                    return;
                }
            }
            if (this.bedNameTextBox.Text.Trim() == string.Empty)
            {
                MyMsgBox.MsgError(Properties.Resources.BedName + " " + Properties.Resources.IsNotEmpty + "!");
                this.bedNameTextBox.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                return;
            this.the_iRegionID = Int32.Parse(this.regionIdTextBox.Text);
            this.the_strRegionName = this.regionNameTextBox.Text;
            this.the_iRoomID = Int32.Parse(this.roomIdTextBox.Text);
            this.the_strRoomName = this.roomNameTextBox.Text;
            this.the_iBedID = Int32.Parse(this.bedIdTextBox.Text);
            this.the_strBedName = StringEx.CutBlanks(this.bedNameTextBox.Text);
            this.the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
            this.the_bInstall = this.yesRadioButton.Checked;
        }

        private void bedNameTextBox_Validated(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = StringEx.CutBlanks(tb.Text);
        }

        private void noteTextBox_Validated(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = StringEx.CutBlanks(tb.Text);
        }

        private void cbuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbuser.SelectedItem != null)
            {
                DataRowView drv = cbuser.SelectedItem as DataRowView;
                this.the_icurator = int.Parse(drv.Row["employee_id"].ToString());
                this.the_curator = drv.Row["name"].ToString();
            }
        }


    }
}
