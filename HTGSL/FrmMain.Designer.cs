namespace HTGSL
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSerialport = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVietNam = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRCallbytime = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRCalltopN = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRCallOver = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRCallshift = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSounds = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSoundTem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfigManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJob = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHospitalProp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShift = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWorkShift = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserbedcall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRight = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRightFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTest = new System.Windows.Forms.ToolStripMenuItem();
            this.userNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.serialPortStatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDataSend = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.clockToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.serialPortToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.serialPortToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.mainVScrollBar = new System.Windows.Forms.VScrollBar();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tmerDateTime = new System.Windows.Forms.Timer(this.components);
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bedContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.callBedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.bedDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.callRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.roomDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.callRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.regionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tmerFindSound = new System.Windows.Forms.Timer(this.components);
            this.comport = new System.IO.Ports.SerialPort(this.components);
            this.tmerRefreshData = new System.Windows.Forms.Timer(this.components);
            this.tiSendData = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.bedContextMenuStrip.SuspendLayout();
            this.roomContextMenuStrip.SuspendLayout();
            this.regionContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.statisticToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.userNameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDatabase,
            this.btnSerialport});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnDatabase
            // 
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(204, 26);
            this.btnDatabase.Text = "Database Settings";
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // btnSerialport
            // 
            this.btnSerialport.Name = "btnSerialport";
            this.btnSerialport.Size = new System.Drawing.Size(204, 26);
            this.btnSerialport.Text = "SerialPort Settings";
            this.btnSerialport.Click += new System.EventHandler(this.btnSerialport_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnglish,
            this.btnVietNam});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // btnEnglish
            // 
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(151, 26);
            this.btnEnglish.Text = "English";
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnVietNam
            // 
            this.btnVietNam.Name = "btnVietNam";
            this.btnVietNam.Size = new System.Drawing.Size(151, 26);
            this.btnVietNam.Text = "Tiếng Việt";
            this.btnVietNam.Click += new System.EventHandler(this.btnVietNam_Click);
            // 
            // statisticToolStripMenuItem
            // 
            this.statisticToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRCallbytime,
            this.btnRCalltopN,
            this.btnRCallOver,
            this.btnRCallshift});
            this.statisticToolStripMenuItem.Name = "statisticToolStripMenuItem";
            this.statisticToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.statisticToolStripMenuItem.Text = "Statistic";
            // 
            // btnRCallbytime
            // 
            this.btnRCallbytime.Name = "btnRCallbytime";
            this.btnRCallbytime.Size = new System.Drawing.Size(174, 26);
            this.btnRCallbytime.Text = "Call by time";
            this.btnRCallbytime.Click += new System.EventHandler(this.btnRCallbytime_Click);
            // 
            // btnRCalltopN
            // 
            this.btnRCalltopN.Name = "btnRCalltopN";
            this.btnRCalltopN.Size = new System.Drawing.Size(174, 26);
            this.btnRCalltopN.Text = "Call top N";
            this.btnRCalltopN.Click += new System.EventHandler(this.btnRCalltopN_Click);
            // 
            // btnRCallOver
            // 
            this.btnRCallOver.Name = "btnRCallOver";
            this.btnRCallOver.Size = new System.Drawing.Size(174, 26);
            this.btnRCallOver.Text = "Call wait over";
            this.btnRCallOver.Click += new System.EventHandler(this.btnRCallOver_Click);
            // 
            // btnRCallshift
            // 
            this.btnRCallshift.Name = "btnRCallshift";
            this.btnRCallshift.Size = new System.Drawing.Size(174, 26);
            this.btnRCallshift.Text = "Call by shift";
            this.btnRCallshift.Click += new System.EventHandler(this.btnRCallshift_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSounds,
            this.btnSoundTem,
            this.toolStripSeparator1,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // btnSounds
            // 
            this.btnSounds.Name = "btnSounds";
            this.btnSounds.Size = new System.Drawing.Size(216, 26);
            this.btnSounds.Text = "Sounds";
            this.btnSounds.Click += new System.EventHandler(this.btnSounds_Click);
            // 
            // btnSoundTem
            // 
            this.btnSoundTem.Name = "btnSoundTem";
            this.btnSoundTem.Size = new System.Drawing.Size(216, 26);
            this.btnSoundTem.Text = "Sound Templates";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfigManager,
            this.toolStripSeparator3,
            this.btnDepartment,
            this.btnJob,
            this.toolStripSeparator4,
            this.btnEmployee,
            this.btnHospitalProp,
            this.toolStripSeparator5,
            this.btnShift,
            this.btnWorkShift,
            this.toolStripSeparator6,
            this.btnUser,
            this.btnUserbedcall,
            this.toolStripSeparator7,
            this.btnRight,
            this.btnFunction,
            this.btnRightFunc});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // btnConfigManager
            // 
            this.btnConfigManager.Name = "btnConfigManager";
            this.btnConfigManager.Size = new System.Drawing.Size(219, 26);
            this.btnConfigManager.Text = "Config Manager";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(216, 6);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(219, 26);
            this.btnDepartment.Text = "Departments";
            // 
            // btnJob
            // 
            this.btnJob.Name = "btnJob";
            this.btnJob.Size = new System.Drawing.Size(219, 26);
            this.btnJob.Text = "Jobs";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(216, 6);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(219, 26);
            this.btnEmployee.Text = "Employees Manager";
            // 
            // btnHospitalProp
            // 
            this.btnHospitalProp.Name = "btnHospitalProp";
            this.btnHospitalProp.Size = new System.Drawing.Size(219, 26);
            this.btnHospitalProp.Text = "Hospital Properties";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(216, 6);
            // 
            // btnShift
            // 
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(219, 26);
            this.btnShift.Text = "Shifts";
            // 
            // btnWorkShift
            // 
            this.btnWorkShift.Name = "btnWorkShift";
            this.btnWorkShift.Size = new System.Drawing.Size(219, 26);
            this.btnWorkShift.Text = "Work Shifts";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(216, 6);
            // 
            // btnUser
            // 
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(219, 26);
            this.btnUser.Text = "Users";
            // 
            // btnUserbedcall
            // 
            this.btnUserbedcall.Name = "btnUserbedcall";
            this.btnUserbedcall.Size = new System.Drawing.Size(219, 26);
            this.btnUserbedcall.Text = "Users bed call";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(216, 6);
            // 
            // btnRight
            // 
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(219, 26);
            this.btnRight.Text = "Rights";
            // 
            // btnFunction
            // 
            this.btnFunction.Name = "btnFunction";
            this.btnFunction.Size = new System.Drawing.Size(219, 26);
            this.btnFunction.Text = "Functions";
            // 
            // btnRightFunc
            // 
            this.btnRightFunc.Name = "btnRightFunc";
            this.btnRightFunc.Size = new System.Drawing.Size(219, 26);
            this.btnRightFunc.Text = "Right Functions";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbout,
            this.btnTest});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(148, 26);
            this.btnAbout.Text = "About";
            // 
            // btnTest
            // 
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(148, 26);
            this.btnTest.Text = "Test Form";
            // 
            // userNameToolStripMenuItem
            // 
            this.userNameToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.userNameToolStripMenuItem.Name = "userNameToolStripMenuItem";
            this.userNameToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.userNameToolStripMenuItem.Text = "UserName";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialPortStatusToolStripStatusLabel,
            this.tssDataSend,
            this.statusToolStripStatusLabel,
            this.clockToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 370);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(661, 29);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // serialPortStatusToolStripStatusLabel
            // 
            this.serialPortStatusToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.serialPortStatusToolStripStatusLabel.Name = "serialPortStatusToolStripStatusLabel";
            this.serialPortStatusToolStripStatusLabel.Size = new System.Drawing.Size(53, 24);
            this.serialPortStatusToolStripStatusLabel.Text = "COM?";
            // 
            // tssDataSend
            // 
            this.tssDataSend.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssDataSend.Name = "tssDataSend";
            this.tssDataSend.Size = new System.Drawing.Size(95, 24);
            this.tssDataSend.Text = "tssDataSend";
            // 
            // statusToolStripStatusLabel
            // 
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new System.Drawing.Size(335, 24);
            this.statusToolStripStatusLabel.Spring = true;
            // 
            // clockToolStripStatusLabel
            // 
            this.clockToolStripStatusLabel.Name = "clockToolStripStatusLabel";
            this.clockToolStripStatusLabel.Size = new System.Drawing.Size(163, 24);
            this.clockToolStripStatusLabel.Text = "00/00/0000 00:00:00 TT";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialPortToolStripLabel,
            this.serialPortToolStripSplitButton,
            this.toolStripSeparator8,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(661, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // serialPortToolStripLabel
            // 
            this.serialPortToolStripLabel.Name = "serialPortToolStripLabel";
            this.serialPortToolStripLabel.Size = new System.Drawing.Size(47, 24);
            this.serialPortToolStripLabel.Text = "Com?";
            // 
            // serialPortToolStripSplitButton
            // 
            this.serialPortToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.serialPortToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.serialPortToolStripSplitButton.Image = global::Properties.Resources.play;
            this.serialPortToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.serialPortToolStripSplitButton.Name = "serialPortToolStripSplitButton";
            this.serialPortToolStripSplitButton.Size = new System.Drawing.Size(39, 24);
            this.serialPortToolStripSplitButton.Text = "toolStripSplitButton1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Image = global::Properties.Resources.play;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Properties.Resources.stop;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = global::Properties.Resources.help;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.helpToolStripButton.Text = "Help";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(661, 315);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 315);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.headerPanel);
            this.splitContainer2.Panel1MinSize = 28;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.mainVScrollBar);
            this.splitContainer2.Panel2.Controls.Add(this.mainPanel);
            this.splitContainer2.Size = new System.Drawing.Size(496, 315);
            this.splitContainer2.SplitterDistance = 28;
            this.splitContainer2.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(496, 28);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
            // 
            // mainVScrollBar
            // 
            this.mainVScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainVScrollBar.Location = new System.Drawing.Point(479, 0);
            this.mainVScrollBar.Name = "mainVScrollBar";
            this.mainVScrollBar.Size = new System.Drawing.Size(17, 283);
            this.mainVScrollBar.TabIndex = 1;
            this.mainVScrollBar.ValueChanged += new System.EventHandler(this.mainVScrollBar_ValueChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(496, 283);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Resize += new System.EventHandler(this.mainPanel_Resize);
            // 
            // tmerDateTime
            // 
            this.tmerDateTime.Interval = 1000;
            this.tmerDateTime.Tick += new System.EventHandler(this.tmerDateTime_Tick);
            // 
            // bedContextMenuStrip
            // 
            this.bedContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bedContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callBedToolStripMenuItem,
            this.stopBedToolStripMenuItem,
            this.toolStripSeparator9,
            this.bedDetailsToolStripMenuItem});
            this.bedContextMenuStrip.Name = "bedContextMenuStrip";
            this.bedContextMenuStrip.Size = new System.Drawing.Size(125, 82);
            // 
            // callBedToolStripMenuItem
            // 
            this.callBedToolStripMenuItem.Enabled = false;
            this.callBedToolStripMenuItem.Name = "callBedToolStripMenuItem";
            this.callBedToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.callBedToolStripMenuItem.Text = "Call";
            // 
            // stopBedToolStripMenuItem
            // 
            this.stopBedToolStripMenuItem.Name = "stopBedToolStripMenuItem";
            this.stopBedToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.stopBedToolStripMenuItem.Text = "Stop";
            this.stopBedToolStripMenuItem.Click += new System.EventHandler(this.stopBedToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(121, 6);
            // 
            // bedDetailsToolStripMenuItem
            // 
            this.bedDetailsToolStripMenuItem.Enabled = false;
            this.bedDetailsToolStripMenuItem.Name = "bedDetailsToolStripMenuItem";
            this.bedDetailsToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.bedDetailsToolStripMenuItem.Text = "Details";
            // 
            // roomContextMenuStrip
            // 
            this.roomContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.roomContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callRoomToolStripMenuItem,
            this.toolStripSeparator10,
            this.roomDetailsToolStripMenuItem});
            this.roomContextMenuStrip.Name = "roomContextMenuStrip";
            this.roomContextMenuStrip.Size = new System.Drawing.Size(119, 58);
            // 
            // callRoomToolStripMenuItem
            // 
            this.callRoomToolStripMenuItem.Name = "callRoomToolStripMenuItem";
            this.callRoomToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.callRoomToolStripMenuItem.Text = "Call";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(115, 6);
            // 
            // roomDetailsToolStripMenuItem
            // 
            this.roomDetailsToolStripMenuItem.Name = "roomDetailsToolStripMenuItem";
            this.roomDetailsToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.roomDetailsToolStripMenuItem.Text = "Detail";
            // 
            // regionContextMenuStrip
            // 
            this.regionContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.regionContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callRegionToolStripMenuItem,
            this.toolStripSeparator11,
            this.regionDetailsToolStripMenuItem});
            this.regionContextMenuStrip.Name = "regionContextMenuStrip";
            this.regionContextMenuStrip.Size = new System.Drawing.Size(119, 58);
            // 
            // callRegionToolStripMenuItem
            // 
            this.callRegionToolStripMenuItem.Name = "callRegionToolStripMenuItem";
            this.callRegionToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.callRegionToolStripMenuItem.Text = "Call";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(115, 6);
            // 
            // regionDetailsToolStripMenuItem
            // 
            this.regionDetailsToolStripMenuItem.Name = "regionDetailsToolStripMenuItem";
            this.regionDetailsToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.regionDetailsToolStripMenuItem.Text = "Detail";
            // 
            // tmerFindSound
            // 
            this.tmerFindSound.Interval = 1000;
            // 
            // comport
            // 
            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // tmerRefreshData
            // 
            this.tmerRefreshData.Tick += new System.EventHandler(this.OnTimedEvent);
            // 
            // tiSendData
            // 
            this.tiSendData.Tick += new System.EventHandler(this.tiSendData_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 399);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F1- Nurse Call System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.bedContextMenuStrip.ResumeLayout(false);
            this.roomContextMenuStrip.ResumeLayout(false);
            this.regionContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDatabase;
        private System.Windows.Forms.ToolStripMenuItem btnSerialport;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnEnglish;
        private System.Windows.Forms.ToolStripMenuItem btnVietNam;
        private System.Windows.Forms.ToolStripMenuItem btnRCallbytime;
        private System.Windows.Forms.ToolStripMenuItem btnRCalltopN;
        private System.Windows.Forms.ToolStripMenuItem btnRCallOver;
        private System.Windows.Forms.ToolStripMenuItem btnRCallshift;
        private System.Windows.Forms.ToolStripMenuItem btnSounds;
        private System.Windows.Forms.ToolStripMenuItem btnSoundTem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnConfigManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnDepartment;
        private System.Windows.Forms.ToolStripMenuItem btnJob;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnEmployee;
        private System.Windows.Forms.ToolStripMenuItem btnHospitalProp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem btnShift;
        private System.Windows.Forms.ToolStripMenuItem btnWorkShift;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem btnUser;
        private System.Windows.Forms.ToolStripMenuItem btnUserbedcall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem btnRight;
        private System.Windows.Forms.ToolStripMenuItem btnFunction;
        private System.Windows.Forms.ToolStripMenuItem btnRightFunc;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.ToolStripMenuItem btnTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel serialPortToolStripLabel;
        private System.Windows.Forms.ToolStripSplitButton serialPortToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel serialPortStatusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssDataSend;
        private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel clockToolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer tmerDateTime;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.ContextMenuStrip bedContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem callBedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem bedDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip roomContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem callRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem roomDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip regionContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem callRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem regionDetailsToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem userNameToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.VScrollBar mainVScrollBar;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer tmerFindSound;
        private System.IO.Ports.SerialPort comport;
        private System.Windows.Forms.Timer tmerRefreshData;
        private System.Windows.Forms.Timer tiSendData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}