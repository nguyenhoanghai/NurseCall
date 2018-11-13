 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Text; 
using System.Windows.Forms;
//using HTGSL.Properties;
using  Properties;

namespace HTGSL
{
    public partial class FConfig : Form
    {
        public FConfig()
        {
            InitializeComponent();
        }

        private void FConfig_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.F0001;
            this.label1.Text = Properties.Resources.AutoOpenComport + ":";
            this.label2.Text = Properties.Resources.TimeRefreshData + ":";
            this.label3.Text = Properties.Resources.TimeReadSound + ":";
            this.label4.Text = Properties.Resources.SoundTemplates + ":";
            this.label5.Text = Properties.Resources.AllowDoubleCall + ":";
            this.label6.Text = Properties.Resources.EndAllCall + ":";
            this.label7.Text = Properties.Resources.ProcessTime + ":";
            this.label8.Text = Properties.Resources.TimeSendData + ":";
   
         //   this.label9.Text = Properties.Resources.RegionHeight + ":";
        //    this.label10.Text = Properties.Resources.RoomHeight + ":";
            this.label9.Text =   "Time Slep After Send ACK :";
            this.label10.Text =  "Times Repeat Send ACK :";

            this.groupBox1.Text = Properties.Resources.grpHeight;

            this.label11.Text = Properties.Resources.RegionHeight + ":";
            this.label12.Text = Properties.Resources.RoomHeight + ":";
            this.label13.Text = Properties.Resources.BedHeight + ":";
            this.label14.Text = Properties.Resources.BedsPerRow + ":";

            this.groupBox2.Text = Properties.Resources.MailGroupbox;
            this.label15.Text = Properties.Resources.MailSend + ":";
            this.label16.Text = Properties.Resources.MailSendPassword + ":";
            this.label17.Text = Properties.Resources.MailRecieve + ":";
            this.label18.Text = Properties.Resources.SendTime + ":";
            this.label19.Text = Properties.Resources.StartDate + ":";
            this.label20.Text = Properties.Resources.EndDate + ":";
            this.label21.Text = Properties.Resources.SendMail + ":";

            this.butSave.Text = Properties.Resources.butSave;
            this.btnBrowseFile.Text = Properties.Resources.BrowseSoundDirectory;
            InitializeControlValues();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.AutoOpenSerialPort = bool.Parse(this.cmbAutoOpenComport.Text);
                Settings.Default.TimeRefreshData = int.Parse(this.txtTimeRefreshData.Text);
                Settings.Default.TimeReadSound = int.Parse(this.txtTimeReadSound.Text);
                Settings.Default.TemplateCode = this.txtSoundTemplate.Text;
                Settings.Default.AllowDoubleCall = bool.Parse(this.cmbAllowDoubleCall.Text);
                Settings.Default.EndAllCall = bool.Parse(this.cmbEndAllCall.Text);
                Settings.Default.ProcessTime = bool.Parse(this.cmbProcessTime.Text);
                Settings.Default.TimeSendData = int.Parse(this.txtTimeSendData.Text);
                Settings.Default.TimeSleepAfterSendACK = int.Parse(this.txtTimeSleepAfterSendACK.Text);
                Settings.Default.TimeRepeatSendACK = int.Parse(this.txtTimesRepeatSendACK.Text);
                Settings.Default.RegionHeight = int.Parse(this.txtRegionHeight.Text);
                Settings.Default.RoomHeight = int.Parse(this.txtRoomHeight.Text);
                Settings.Default.BedHeight = int.Parse(this.txtBedHeight.Text);
                Settings.Default.BedsPerRow = int.Parse(this.txtBedsPerRow.Text);
                Settings.Default.SoundPath =  this.txtSoundPath.Text ;

                Settings.Default.MailSend = this.txtMailSend.Text;
                Settings.Default.Password = this.txtPass.Text;
                Settings.Default.MailRecieve = this.txtMailRecieve.Text;
                Settings.Default.TimeSend = this.txtTimeSend.Text;
                Settings.Default.StartDate = (int)this.txtStartDate.Value;
                Settings.Default.EndDate = (int)this.txtEndDate.Value; 
                Settings.Default.SendMail =  this.chbkSendMail.Checked;

                Settings.Default.Save();
                MessageBox.Show(Properties.Resources.SaveSuccess  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "butSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void InitializeControlValues()
        {
            this.cmbAutoOpenComport.Items.Clear();
            this.cmbAutoOpenComport.Items.Add("False");
            this.cmbAutoOpenComport.Items.Add("True");
            if (this.cmbAutoOpenComport.Items.Contains(Settings.Default.AutoOpenSerialPort.ToString()))
            {
                this.cmbAutoOpenComport.Text = Settings.Default.AutoOpenSerialPort.ToString();
            }
            else
            {
                if (this.cmbAutoOpenComport.Items.Count > 0)
                {
                    this.cmbAutoOpenComport.SelectedIndex = 0;
                }
                else
                {
                    this.cmbAutoOpenComport.Text = "";
                }
            }
            this.cmbAllowDoubleCall.Items.Clear();
            this.cmbAllowDoubleCall.Items.Add("False");
            this.cmbAllowDoubleCall.Items.Add("True");
            if (this.cmbAllowDoubleCall.Items.Contains(Settings.Default.AllowDoubleCall.ToString()))
            {
                this.cmbAllowDoubleCall.Text = Settings.Default.AllowDoubleCall.ToString();
            }
            else
            {
                if (this.cmbAllowDoubleCall.Items.Count > 0)
                {
                    this.cmbAllowDoubleCall.SelectedIndex = 0;
                }
                else
                {
                    this.cmbAllowDoubleCall.Text = "";
                }
            }
            this.cmbEndAllCall.Items.Clear();
            this.cmbEndAllCall.Items.Add("False");
            this.cmbEndAllCall.Items.Add("True");
            if (this.cmbEndAllCall.Items.Contains(Settings.Default.EndAllCall.ToString()))
            {
                this.cmbEndAllCall.Text = Settings.Default.EndAllCall.ToString();
            }
            else
            {
                if (this.cmbEndAllCall.Items.Count > 0)
                {
                    this.cmbEndAllCall.SelectedIndex = 0;
                }
                else
                {
                    this.cmbEndAllCall.Text = "";
                }
            }
            this.cmbProcessTime.Items.Clear();
            this.cmbProcessTime.Items.Add("False");
            this.cmbProcessTime.Items.Add("True");
            if (this.cmbProcessTime.Items.Contains(Settings.Default.ProcessTime.ToString()))
            {
                this.cmbProcessTime.Text = Settings.Default.ProcessTime.ToString();
            }
            else
            {
                if (this.cmbProcessTime.Items.Count > 0)
                {
                    this.cmbProcessTime.SelectedIndex = 0;
                }
                else
                {
                    this.cmbProcessTime.Text = "";
                }
            }
            this.txtTimeRefreshData.Text = Settings.Default.TimeRefreshData.ToString();
            this.txtTimeReadSound.Text = Settings.Default.TimeReadSound.ToString();
            this.txtSoundTemplate.Text = Settings.Default.TemplateCode.ToString();
            this.txtRegionHeight.Text = Settings.Default.RegionHeight.ToString();
            this.txtRoomHeight.Text = Settings.Default.RoomHeight.ToString();
            this.txtBedHeight.Text = Settings.Default.BedHeight.ToString();
            this.txtBedsPerRow.Text = Settings.Default.BedsPerRow.ToString();
            this.txtTimeSendData.Text = Settings.Default.TimeSendData.ToString();
            this.txtTimeSleepAfterSendACK.Text = Settings.Default.TimeSleepAfterSendACK.ToString();
            this.txtTimesRepeatSendACK.Text = Settings.Default.TimeRepeatSendACK.ToString();
            this.txtSoundPath.Text = Settings.Default.SoundPath.ToString();

            this.txtMailSend.Text = Settings.Default.MailSend.ToString();
            this.txtPass.Text = Settings.Default.Password.ToString();
            this.txtMailRecieve.Text = Settings.Default.MailRecieve.ToString();
            this.txtTimeSend.Text = Settings.Default.TimeSend.ToString();
            this.txtStartDate.Value = Settings.Default.StartDate ;
            this.txtEndDate.Value = Settings.Default.EndDate ;  
            this.chbkSendMail.Checked = Settings.Default.SendMail;
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog(); 
            if ( folderDlg.ShowDialog() == DialogResult.OK)
              txtSoundPath.Text = folderDlg.SelectedPath; 
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
