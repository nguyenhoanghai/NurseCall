//using HTGSL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HTGSL
{
    public partial class FrmUserBedCall : Form
    {
        DataProvider provider = new DataProvider();
        RegionExArray religons;
        int id = 0;
        public FrmUserBedCall(RegionExArray _MyRs)
        {
            InitializeComponent();
            religons = _MyRs;
        }

        private void FrmUserBedCall_Load(object sender, EventArgs e)
        {
            btnChkAll.Text = Properties.Resources.SelectAll;
            btnUncheck.Text = Properties.Resources.UnSelectAll;
            label3.Text = Properties.Resources.Account;
            label1.Text = Properties.Resources.Bed;
            btnSave.Text = Properties.Resources.butSave;
            this.Text = Properties.Resources.RegisterListenEventFromBed;

            GetBeds();
            GetAccounts(); 
        }
         

        private void btnrefreshUsers_Click(object sender, EventArgs e)
        {
            GetAccounts(); 
        }

        private void GetBeds()
        {
            try
            {
                chkList.Items.Clear();
                if (religons != null && religons.Count > 0)
                {
                    for (int i = 0; i < religons.Count; i++)
                        if (religons[i].Rooms.Count > 0)
                            for (int ii = 0; ii < religons[i].Rooms.Count; ii++)
                                if (religons[i].Rooms[ii].Beds.Count > 0)
                                    for (int iii = 0; iii < religons[i].Rooms[ii].Beds.Count; iii++)
                                        chkList.Items.Add(new User() { Name = (religons[i].strRegionName + " - " + religons[i].Rooms[ii].strRoomNote + " - " + religons[i].Rooms[ii].Beds[iii].strBedNote), BedIds = (religons[i].iRegionID + "|" + religons[i].Rooms[ii].strRoomName + "|" + religons[i].Rooms[ii].Beds[iii].iBedID) });
                }
                chkList.DisplayMember = "Name";
                chkList.ValueMember = "BedIds";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAccounts()
        {
            try
            {
                cbUser.Items.Clear();
                string strSQL = "SELECT [user_id] ,[user_name] ,bedids  FROM [dbo].[users]";
                var source = provider.execute(strSQL).Tables[0];
                if (source.Rows.Count > 0)
                    for (int i = 0; i < source.Rows.Count; i++)
                        cbUser.Items.Add(new User() { Id = Convert.ToInt32(source.Rows[i][0].ToString()), Name = source.Rows[i][1].ToString(), BedIds = source.Rows[i][2].ToString() });

                cbUser.DisplayMember = "Name";
                cbUser.ValueMember = "Id";
                cbUser.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = (User)cbUser.SelectedItem;
            if (obj != null)
            {
                id = obj.Id;
                string[] arr = obj.BedIds.Split(',');
                List<string> userb = new List<string>();
                if (arr != null && arr.Length > 0)
                {
                    for (int i = 0; i < arr.Length; i++)
                        userb.Add(arr[i]);
                }

                string vl = string.Empty;
                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    if (userb.Contains((chkList.Items[i] as User).BedIds))
                        chkList.SetItemChecked(i, true);
                    else
                        chkList.SetItemChecked(i, false);
                }
            }
        }

        private void btnChkAll_Click(object sender, EventArgs e)
        {
            if (chkList.Items.Count > 0)
                for (int i = 0; i < chkList.Items.Count; i++)
                    chkList.SetItemChecked(i, true);
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            if (chkList.Items.Count > 0)
                for (int i = 0; i < chkList.Items.Count; i++)
                    chkList.SetItemChecked(i, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string vl = "";
                if (chkList.Items.Count > 0 && chkList.CheckedItems.Count > 0)
                    for (int i = 0; i < chkList.CheckedItems.Count; i++)
                        vl += (chkList.CheckedItems[i] as User).BedIds + ",";

                if (vl.Length > 0)
                    vl = vl.Substring(0, vl.Length - 1);
                string strSQL = "update [dbo].[users] set  bedids ='" + vl + "'  where user_id = " + id;
                SqlDataReader ad = provider.excuteQuery(strSQL);
                ad.Dispose();                
                MessageBox.Show("Lưu thành công !...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnUncheck_Click(sender, e);
                GetAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BedIds { get; set; }

    }
}
