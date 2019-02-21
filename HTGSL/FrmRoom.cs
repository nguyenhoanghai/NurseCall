using System;
using System.Windows.Forms;

namespace HTGSL
{
    public partial class FrmRoom : Form
    {
        #region decleare
        public bool bModify = false;
        private int 
            _the_iRegionID,
            _the_iRoomID,
            _the_iLabor ;
        private string 
            _the_strRegionName,
            _the_strRoomName,
            _the_strNote;

        public int The_iRegionID
        {
            get { return this._the_iRegionID; }
            set { this._the_iRegionID = value; }
        }
        public int The_iLabor
        {
            get { return this._the_iLabor; }
            set { this._the_iLabor = value; }
        }
        public int The_iRoomID
        {
            get { return this._the_iRoomID; }
            set { this._the_iRoomID = value; }
        }

        public string The_strRegionName
        {
            get { return this._the_strRegionName; }
            set { this._the_strRegionName = value; }
        }        
        public string The_strRoomName
        {
            get { return this._the_strRoomName; }
            set { this._the_strRoomName = value; }
        }
        public string The_strNote
        {
            get { return this._the_strNote; }
            set { this._the_strNote = value; }
        }
        #endregion

        public FrmRoom()
        {
            InitializeComponent();
        }

        private void noteTextBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = StringEx.CutBlanks(textBox.Text);
        }

        private void roomIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b');
        }

        private void roomNameTextBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = StringEx.CutBlanks(textBox.Text);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!this.bModify)
            {
                string text = this.roomIdTextBox.Text.Trim();
                if (text == string.Empty)
                {
                    MyMsgBox.MsgError(Properties.Resources.RoomID + " " + Properties.Resources.IsNotEmpty + "!");
                    this.roomIdTextBox.Focus();
                    return;
                }
                if (!StringEx.IsStrNumber(text))
                {
                    MyMsgBox.MsgError(Properties.Resources.RoomID + " " + Properties.Resources.IsNumber + "!");
                    this.roomIdTextBox.Focus();
                    return;
                }
                int num = int.Parse(text);
                if (num < 1)
                {
                    MyMsgBox.MsgError(Properties.Resources.RoomID + " > 0 !");
                    this.roomIdTextBox.Focus();
                    return;
                }
            }
            if (this.roomNameTextBox.Text.Trim() == string.Empty)
            {
                MyMsgBox.MsgError(Properties.Resources.RoomName + " " + Properties.Resources.IsNotEmpty + "!");
                this.roomNameTextBox.Focus();
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void FrmRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (base.DialogResult == DialogResult.OK)
            {
                this._the_iRegionID = int.Parse(this.regionIdTextBox.Text);
                this._the_strRegionName = this.regionNameTextBox.Text;
                this._the_iRoomID = int.Parse(this.roomIdTextBox.Text);
                this._the_strRoomName = StringEx.CutBlanks(this.roomNameTextBox.Text);
                this._the_strNote = StringEx.CutBlanks(this.noteTextBox.Text);
                this._the_iLabor =  (int)this.txtLabor.Value ;
            }
        }

        private void FrmRoom_Load(object sender, EventArgs e)
        {
            this.LoadCaptionForControls();
            this.regionIdTextBox.Text = this._the_iRegionID.ToString();
            this.regionNameTextBox.Text = this._the_strRegionName;
            this.roomIdTextBox.ReadOnly = this.bModify;
            this.roomIdTextBox.TabStop = !this.bModify;
            this.roomIdTextBox.Text = this._the_iRoomID.ToString();
            this.roomNameTextBox.Text = this._the_strRoomName;
            this.noteTextBox.Text = this._the_strNote;
            this.txtLabor.Value = this._the_iLabor;
        }

        private void LoadCaptionForControls()
        {
            this.Text = (this.bModify ? ("F5 - " + Properties.Resources.ModifyRoom) : ("F5 - " + Properties.Resources.NewRoom));
            this.roomInfoGroupBox.Text = Properties.Resources.RoomInfo;
            this.regionLabel.Text = Properties.Resources.Region + ":";
            this.roomLabel.Text = Properties.Resources.Room + ":";
            this.noteLabel.Text = Properties.Resources.Note + ":";
            this.laborLabel.Text = Properties.Resources.Labors + ":";
            this.okButton.Text = Properties.Resources.OK;
            this.cancelButton.Text = Properties.Resources.Cancel;
        } 
    }
}
