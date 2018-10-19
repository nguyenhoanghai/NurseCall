using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HTGSL
{
    public partial class FrmTestform : Form
    {
      //  private FrmTestform.DataMode CurrentDataMode = FTEST.DataMode.Hex;
        FMAIN fmain;

        private string strSQL,
         sRegion = "",
        sRoom = "",
         sEquipment = "",
         sBed = "",
         sType_Request = "",
        sCheck_Sum = "",
         strRev = "";
        public FrmTestform(FMAIN _main)
        {
            this.InitializeComponent();
            fmain = _main;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = clsUtl.CONNECT_STATUS.ToString();
        }
         

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ParseStringCallRequest("02 01, 01, 301, 4, Z 03");
            clsSound cS = new clsSound();
            //using (clsSound cS = new clsSound())
            //{
            cS.SetSoundTemplate("003");
            cS.PlaySoundWav("01", "112", "01");
            //cS.Close();
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.textBox5.Text = clsString.ConvertHexToString("20 31 2C 20 31 31 32 2C 20 30 30 31 2C 20 34 2C 20 33 30 31 2C 20", System.Text.Encoding.Unicode);
            // byte[] data = clsString.FromHex("20 31 2C 20 31 31 32 2C 20 30 30 31 2C 20 34 2C 20 33 30 31 2C 20");
            //this.textBox5.Text = Encoding.ASCII.GetString(data);
            //this.textBox5.Text = clsString.HexString2Ascii(this.textBox3.Text);
        }

        private void btnReadsound_Click(object sender, EventArgs e)
        {
            //    clsSound clsSound = new clsSound();
            //    clsSound.SetSoundTemplate("002");
            ////	clsSound.PlaySoundWav("1", "002", "2");

            //    string str = clsSound.GetSoundToPlay("01", "002", "2");
            //    if (!string.IsNullOrEmpty(str))
            //        FMAIN.playList.AddRange(str.Split('|'));

            fmain.InsertCallRequire("01", "002", "2");
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = clsUtl.CONNECT_STATUS.ToString();
        }

        private void btnSetConnect_Click(object sender, EventArgs e)
        {
            clsUtl.CONNECT_STRING = "data source=Localhost;initial catalog=NurseCall;integrated security=SSPI;";
        }

        private void btnGetConnect_Click(object sender, EventArgs e)
        {
            this.textBox5.Text = clsUtl.CONNECT_STRING;
        }
         

        private void btnGetPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath + "\\sounds";
            openFileDialog.DefaultExt = "wav";
            openFileDialog.Filter = "Wave|*.wav";
            openFileDialog.ShowDialog();
            string[] fileNames = openFileDialog.FileNames;
        }
 
        

        private void btnToHexString_Click(object sender, EventArgs e)
        {

        }

        private void btnXOR_Click(object sender, EventArgs e)
        {

        }

        private void btncall_Click(object sender, EventArgs e)
        {
            fmain.ParseToCommand_frmTest(txtRegion.Text + "," + txtroom.Text + "," + "4," + txtbed.Text + ",01");
        }

        private void btnprocess_Click(object sender, EventArgs e)
        {
            fmain.ParseToCommand_frmTest(txtRegion.Text + "," + txtroom.Text + "," + "9," + txtbed.Text + ",01");
        }

        private void btnend_Click(object sender, EventArgs e)
        {
            fmain.ParseToCommand_frmTest(txtRegion.Text + "," + txtroom.Text + "," + "8," + txtbed.Text + ",01");
        }

       
    }
}
