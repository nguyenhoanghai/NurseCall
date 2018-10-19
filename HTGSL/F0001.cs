//using HTGSL.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Properties;
namespace HTGSL
{
	public class F0001 : Form
	{
		private IContainer components = null;
		private Label AutoOpenComport;
		private Label TimeRefreshData;
		private TextBox txtTimeRefreshData;
		private GroupBox grpHeight;
		private TextBox txtBedHeight;
		private Label BedHeight;
		private TextBox txtRoomHeight;
		private Label RoomHeight;
		private TextBox txtRegionHeight;
		private Label RegionHeight;
		private TextBox txtBedsPerRow;
		private Label BedsPerRow;

        private TextBox txtTimeSleepAfterSendACK;
        private Label lbTimeSleepAfterSendACK;
        private TextBox txtTimesRepeatSendACK;
        private Label lbTimesRepeatSendACK;

		private Button butSave;
		private ComboBox cmbAutoOpenComport;
		private TextBox txtSoundTemplate;
		private Label SoundTemplate;
		private Label TimeReadSound;
		private TextBox txtTimeReadSound;
		private Label lblAllowDoubleCall;
		private Label lblEndAllCall;
		private ComboBox cmbAllowDoubleCall;
		private ComboBox cmbEndAllCall;
		private ComboBox cmbProcessTime;
		private Label lblProcessTime;
		private Label lblTimeSendData;
		private TextBox txtTimeSendData;
		public F0001()
		{
			this.InitializeComponent();
		}
		private void F0001_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.InitializeControlValues();
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
		}
		private void LoadCaptionForControls()
		{
			this.Text = Properties.Resources.F0001;
			this.AutoOpenComport.Text = Properties.Resources.AutoOpenComport + ":";
			this.TimeRefreshData.Text = Properties.Resources.TimeRefreshData + ":";
			this.TimeReadSound.Text = Properties.Resources.TimeReadSound + ":";
			this.SoundTemplate.Text = Properties.Resources.SoundTemplates + ":";
			this.lblAllowDoubleCall.Text = Properties.Resources.AllowDoubleCall + ":";
			this.lblEndAllCall.Text = Properties.Resources.EndAllCall + ":";
			this.lblProcessTime.Text = Properties.Resources.ProcessTime + ":";
			this.lblTimeSendData.Text = Properties.Resources.TimeSendData + ":";
			this.grpHeight.Text = Properties.Resources.grpHeight;
			this.RegionHeight.Text = Properties.Resources.RegionHeight + ":";
			this.RoomHeight.Text = Properties.Resources.RoomHeight + ":";
			this.BedHeight.Text = Properties.Resources.BedHeight + ":";
			this.BedsPerRow.Text = Properties.Resources.BedsPerRow + ":";
			this.butSave.Text = Properties.Resources.butSave;
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
				Settings.Default.Save();
				MessageBox.Show("Đã lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "butSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F0001));
			this.AutoOpenComport = new Label();
			this.TimeRefreshData = new Label();
			this.txtTimeRefreshData = new TextBox();
			this.grpHeight = new GroupBox();
			this.txtBedsPerRow = new TextBox();
			this.BedsPerRow = new Label();
			this.txtBedHeight = new TextBox();
			this.BedHeight = new Label();
			this.txtRoomHeight = new TextBox();
			this.RoomHeight = new Label();
			this.txtRegionHeight = new TextBox();
			this.RegionHeight = new Label();
			this.butSave = new Button();
			this.cmbAutoOpenComport = new ComboBox();
			this.txtSoundTemplate = new TextBox();
			this.SoundTemplate = new Label();
			this.TimeReadSound = new Label();
			this.txtTimeReadSound = new TextBox();
			this.lblAllowDoubleCall = new Label();
			this.lblEndAllCall = new Label();
			this.cmbAllowDoubleCall = new ComboBox();
			this.cmbEndAllCall = new ComboBox();
			this.cmbProcessTime = new ComboBox();
			this.lblProcessTime = new Label();
			this.lblTimeSendData = new Label();
			this.txtTimeSendData = new TextBox();

            this.lbTimeSleepAfterSendACK = new Label();
            this.txtTimeSleepAfterSendACK = new TextBox();
            this.lbTimesRepeatSendACK = new Label();
            this.txtTimesRepeatSendACK = new TextBox();

			this.grpHeight.SuspendLayout();
			base.SuspendLayout();
			this.AutoOpenComport.AutoSize = true;
			this.AutoOpenComport.Location = new Point(12, 18);
			this.AutoOpenComport.Name = "AutoOpenComport";
			this.AutoOpenComport.Size = new Size(94, 13);
			this.AutoOpenComport.TabIndex = 0;
			this.AutoOpenComport.Text = "AutoOpenComport";
			this.TimeRefreshData.AutoSize = true;
			this.TimeRefreshData.Location = new Point(12, 46);
			this.TimeRefreshData.Name = "TimeRefreshData";
			this.TimeRefreshData.Size = new Size(90, 13);
			this.TimeRefreshData.TabIndex = 2;
			this.TimeRefreshData.Text = "TimeRefreshData";
			this.txtTimeRefreshData.Location = new Point(192, 43);
			this.txtTimeRefreshData.Name = "txtTimeRefreshData";
			this.txtTimeRefreshData.Size = new Size(190, 20);
			this.txtTimeRefreshData.TabIndex = 3;
			this.grpHeight.Controls.Add(this.txtBedsPerRow);
			this.grpHeight.Controls.Add(this.BedsPerRow);
			this.grpHeight.Controls.Add(this.txtBedHeight);
			this.grpHeight.Controls.Add(this.BedHeight);
			this.grpHeight.Controls.Add(this.txtRoomHeight);
			this.grpHeight.Controls.Add(this.RoomHeight);
			this.grpHeight.Controls.Add(this.txtRegionHeight);
			this.grpHeight.Controls.Add(this.RegionHeight);
			this.grpHeight.Location = new Point(12, 235);
			this.grpHeight.Name = "grpHeight";
			this.grpHeight.Size = new Size(392, 151);
			this.grpHeight.TabIndex = 4;
			this.grpHeight.TabStop = false;
			this.grpHeight.Text = "Height";
			this.txtBedsPerRow.Location = new Point(180, 116);
			this.txtBedsPerRow.Name = "txtBedsPerRow";
			this.txtBedsPerRow.Size = new Size(190, 20);
			this.txtBedsPerRow.TabIndex = 3;
			this.BedsPerRow.AutoSize = true;
			this.BedsPerRow.Location = new Point(21, 119);
			this.BedsPerRow.Name = "BedsPerRow";
			this.BedsPerRow.Size = new Size(69, 13);
			this.BedsPerRow.TabIndex = 2;
			this.BedsPerRow.Text = "BedsPerRow";
			this.txtBedHeight.Location = new Point(180, 85);
			this.txtBedHeight.Name = "txtBedHeight";
			this.txtBedHeight.Size = new Size(190, 20);
			this.txtBedHeight.TabIndex = 2;
			this.BedHeight.AutoSize = true;
			this.BedHeight.Location = new Point(21, 88);
			this.BedHeight.Name = "BedHeight";
			this.BedHeight.Size = new Size(57, 13);
			this.BedHeight.TabIndex = 2;
			this.BedHeight.Text = "BedHeight";
			this.txtRoomHeight.Location = new Point(180, 54);
			this.txtRoomHeight.Name = "txtRoomHeight";
			this.txtRoomHeight.Size = new Size(190, 20);
			this.txtRoomHeight.TabIndex = 1;
			this.RoomHeight.AutoSize = true;
			this.RoomHeight.Location = new Point(21, 57);
			this.RoomHeight.Name = "RoomHeight";
			this.RoomHeight.Size = new Size(66, 13);
			this.RoomHeight.TabIndex = 2;
			this.RoomHeight.Text = "RoomHeight";
			this.txtRegionHeight.Location = new Point(180, 23);
			this.txtRegionHeight.Name = "txtRegionHeight";
			this.txtRegionHeight.Size = new Size(190, 20);
			this.txtRegionHeight.TabIndex = 0;
			this.RegionHeight.AutoSize = true;
			this.RegionHeight.Location = new Point(21, 26);
			this.RegionHeight.Name = "RegionHeight";
			this.RegionHeight.Size = new Size(72, 13);
			this.RegionHeight.TabIndex = 2;
			this.RegionHeight.Text = "RegionHeight";
			this.butSave.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.butSave.Image = (Image)componentResourceManager.GetObject("butSave.Image");
			this.butSave.ImageAlign = ContentAlignment.MiddleLeft;
			this.butSave.ImeMode = ImeMode.NoControl;
			this.butSave.Location = new Point(158, 391);
			this.butSave.Name = "butSave";
			this.butSave.Size = new Size(101, 28);
			this.butSave.TabIndex = 5;
			this.butSave.Text = "      &Save";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new EventHandler(this.butSave_Click);
			this.cmbAutoOpenComport.FormattingEnabled = true;
			this.cmbAutoOpenComport.Location = new Point(192, 15);
			this.cmbAutoOpenComport.Name = "cmbAutoOpenComport";
			this.cmbAutoOpenComport.Size = new Size(190, 21);
			this.cmbAutoOpenComport.TabIndex = 1;
			this.txtSoundTemplate.Location = new Point(192, 97);
			this.txtSoundTemplate.Name = "txtSoundTemplate";
			this.txtSoundTemplate.Size = new Size(190, 20);
			this.txtSoundTemplate.TabIndex = 3;
			this.SoundTemplate.AutoSize = true;
			this.SoundTemplate.Location = new Point(12, 101);
			this.SoundTemplate.Name = "SoundTemplate";
			this.SoundTemplate.Size = new Size(82, 13);
			this.SoundTemplate.TabIndex = 2;
			this.SoundTemplate.Text = "SoundTemplate";
			this.TimeReadSound.AutoSize = true;
			this.TimeReadSound.Location = new Point(12, 72);
			this.TimeReadSound.Name = "TimeReadSound";
			this.TimeReadSound.Size = new Size(87, 13);
			this.TimeReadSound.TabIndex = 6;
			this.TimeReadSound.Text = "TimeReadSound";
			this.txtTimeReadSound.Location = new Point(192, 70);
			this.txtTimeReadSound.Name = "txtTimeReadSound";
			this.txtTimeReadSound.Size = new Size(190, 20);
			this.txtTimeReadSound.TabIndex = 7;
			this.lblAllowDoubleCall.AutoSize = true;
			this.lblAllowDoubleCall.Location = new Point(12, 127);
			this.lblAllowDoubleCall.Name = "lblAllowDoubleCall";
			this.lblAllowDoubleCall.Size = new Size(83, 13);
			this.lblAllowDoubleCall.TabIndex = 2;
			this.lblAllowDoubleCall.Text = "AllowDoubleCall";
			this.lblEndAllCall.AutoSize = true;
			this.lblEndAllCall.Location = new Point(12, 153);
			this.lblEndAllCall.Name = "lblEndAllCall";
			this.lblEndAllCall.Size = new Size(54, 13);
			this.lblEndAllCall.TabIndex = 2;
			this.lblEndAllCall.Text = "EndAllCall";
			this.cmbAllowDoubleCall.FormattingEnabled = true;
			this.cmbAllowDoubleCall.Location = new Point(192, 124);
			this.cmbAllowDoubleCall.Name = "cmbAllowDoubleCall";
			this.cmbAllowDoubleCall.Size = new Size(190, 21);
			this.cmbAllowDoubleCall.TabIndex = 1;
			this.cmbEndAllCall.FormattingEnabled = true;
			this.cmbEndAllCall.Location = new Point(192, 152);
			this.cmbEndAllCall.Name = "cmbEndAllCall";
			this.cmbEndAllCall.Size = new Size(190, 21);
			this.cmbEndAllCall.TabIndex = 1;
			this.cmbProcessTime.FormattingEnabled = true;
			this.cmbProcessTime.Location = new Point(192, 179);
			this.cmbProcessTime.Name = "cmbProcessTime";
			this.cmbProcessTime.Size = new Size(190, 21);
			this.cmbProcessTime.TabIndex = 8;
			this.lblProcessTime.AutoSize = true;
			this.lblProcessTime.Location = new Point(12, 179);
			this.lblProcessTime.Name = "lblProcessTime";
			this.lblProcessTime.Size = new Size(68, 13);
			this.lblProcessTime.TabIndex = 9;
			this.lblProcessTime.Text = "ProcessTime";
			
            this.lblTimeSendData.AutoSize = true;
			this.lblTimeSendData.Location = new Point(12, 209);
			this.lblTimeSendData.Name = "lblTimeSendData";
			this.lblTimeSendData.Size = new Size(78, 13);
			this.lblTimeSendData.TabIndex = 10;
			this.lblTimeSendData.Text = "TimeSendData";
			this.txtTimeSendData.Location = new Point(192, 206);
			this.txtTimeSendData.Name = "txtTimeSendData";
			this.txtTimeSendData.Size = new Size(190, 20);
            this.txtTimeSendData.TabIndex = 11;

            this.lbTimeSleepAfterSendACK.AutoSize = true;
            this.lbTimeSleepAfterSendACK.Location = new Point(12, 219);
            this.lbTimeSleepAfterSendACK.Name = "lb1";
            this.lbTimeSleepAfterSendACK.Size = new Size(78, 13);
            this.lbTimeSleepAfterSendACK.TabIndex = 10;
            this.lbTimeSleepAfterSendACK.Text = "TimeSleepAfterSendACK";
            this.txtTimeSendData.Location = new Point(192, 216);
            this.txtTimeSendData.Name = "txt1";
            this.txtTimeSendData.Size = new Size(190, 20);
            this.txtTimeSendData.TabIndex = 11;

            this.lbTimesRepeatSendACK.AutoSize = true;
            this.lbTimesRepeatSendACK.Location = new Point(12, 239);
            this.lbTimesRepeatSendACK.Name = "lb2";
            this.lbTimesRepeatSendACK.Size = new Size(78, 13);
            this.lbTimesRepeatSendACK.TabIndex = 10;
            this.lbTimesRepeatSendACK.Text = "TimesRepeatSendACK";
            this.txtTimeSendData.Location = new Point(192, 226);
            this.txtTimeSendData.Name = "txt2";
            this.txtTimeSendData.Size = new Size(190, 20);
            this.txtTimeSendData.TabIndex = 11;



			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(419, 423);
			base.Controls.Add(this.lblTimeSendData);
			base.Controls.Add(this.txtTimeSendData);

            base.Controls.Add(this.lbTimeSleepAfterSendACK);
            base.Controls.Add(this.txtTimeSleepAfterSendACK);
            base.Controls.Add(this.lbTimesRepeatSendACK);
            base.Controls.Add(this.txtTimesRepeatSendACK);

			base.Controls.Add(this.lblProcessTime);
			base.Controls.Add(this.cmbProcessTime);
			base.Controls.Add(this.TimeReadSound);
			base.Controls.Add(this.txtTimeReadSound);
			base.Controls.Add(this.cmbEndAllCall);
			base.Controls.Add(this.cmbAllowDoubleCall);
			base.Controls.Add(this.cmbAutoOpenComport);
			base.Controls.Add(this.butSave);
			base.Controls.Add(this.grpHeight);
			base.Controls.Add(this.lblEndAllCall);
			base.Controls.Add(this.lblAllowDoubleCall);
			base.Controls.Add(this.SoundTemplate);
			base.Controls.Add(this.TimeRefreshData);
			base.Controls.Add(this.txtSoundTemplate);
			base.Controls.Add(this.txtTimeRefreshData);
			base.Controls.Add(this.AutoOpenComport);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "F0001";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F0001 - Options";
			base.Load += new EventHandler(this.F0001_Load);
			this.grpHeight.ResumeLayout(false);
			this.grpHeight.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
