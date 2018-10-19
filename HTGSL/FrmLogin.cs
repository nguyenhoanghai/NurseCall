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
    public partial class FrmLogin : Form
    {
        #region Disables X-Close button
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int GetSystemMenu(IntPtr hwnd, int bRevert);
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int RemoveMenu(int hMenu, int nPosition, int wFlags);
        public const int SC_CLOSE = 61536;
        public const int MF_BYCOMMAND = 0;
        #endregion
        private string XMLFilename = Application.StartupPath + "\\DATA.XML";
        DataProvider provider = new DataProvider();
        public FrmLogin()
        {
            InitializeComponent();
            RemoveXButton(this.Handle);
        }

        private int RemoveXButton(IntPtr iHWND)
        {
            int iSysMenu;
            iSysMenu = GetSystemMenu(iHWND, 0);
            return RemoveMenu(iSysMenu, SC_CLOSE, MF_BYCOMMAND);
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // Load Data
                LoadData(); 

                // Check File
                if (!System.IO.File.Exists(XMLFilename))
                CreatNewXMLFile(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                #region Combobox
                string strSQL = "SELECT [SHIFT_ID],[SHIFT_NAME] FROM  [dbo].[SHIFTS]"; 
                this.comboBox1.DataSource = provider.execute(strSQL).Tables[0];//ds.Tables["LOAI_XE"];
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        private void CreatNewXMLFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            // Tạo và chèn một phần tử mới.
            XmlNode productsNode = doc.CreateElement("String_Connect");
            doc.AppendChild(productsNode);

            // Tạo một phần tử lồng bên trong (cùng với một đặc tính).
            XmlNode productNode = doc.CreateElement("SQLServer");
            XmlAttribute productAttribute = doc.CreateAttribute("id");
            productAttribute.Value = "1";
            productNode.Attributes.Append(productAttribute);
            productsNode.AppendChild(productNode);

            // Tạo và thêm các phần tử con cho nút product này
            // (cùng với dữ liệu text).
            XmlNode nameNode = doc.CreateElement("Server_Name");
            nameNode.AppendChild(doc.CreateTextNode("localhost"));
            productNode.AppendChild(nameNode);

            XmlNode dataNode = doc.CreateElement("Database");
            dataNode.AppendChild(doc.CreateTextNode("QLHS"));
            productNode.AppendChild(dataNode);

            XmlNode UserNode = doc.CreateElement("User");
            UserNode.AppendChild(doc.CreateTextNode("sa"));
            productNode.AppendChild(UserNode);

            XmlNode PwdNode = doc.CreateElement("Password");
            PwdNode.AppendChild(doc.CreateTextNode("@p1409"));
            productNode.AppendChild(PwdNode);

            //// Tạo và thêm một nút product khác.
            //productNode = doc.CreateElement("User");
            //productAttribute = doc.CreateAttribute("id");
            //productAttribute.Value = "2";
            //productNode.Attributes.Append(productAttribute);
            //productsNode.AppendChild(productNode);
            //nameNode = doc.CreateElement("UserName");
            //nameNode.AppendChild(doc.CreateTextNode("Admin"));
            //productNode.AppendChild(nameNode);
            //priceNode = doc.CreateElement("Password");
            //priceNode.AppendChild(doc.CreateTextNode("140977"));
            //productNode.AppendChild(priceNode);

            // Lưu tài liệu.
            doc.Save(XMLFilename);
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            // Check user and password
            string user = "";
            string pwd = "";
            int iShift_ID = 1;

            user = this.txtUser.Text;
            pwd = this.txtPwd.Text;
           iShift_ID = Convert.ToInt32(this.comboBox1.SelectedValue);  

            if (user.Length == 0)
            {
                MessageBox.Show("Không có tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUser.Focus();
                return;
            }

            if (pwd.Length == 0)
            {
                MessageBox.Show("Không có mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPwd.Focus();
                return;
            }

            switch (CheckUserPassword(user, pwd))
            {
                case 0:
                    clsUtl.USER_NAME = user;
                    clsUtl.PASSWORD = pwd;
                    clsUtl.SHIFT_ID = iShift_ID;
                    //FMAIN.Default.LockMenu(true,clsUtilities.QUYEN_HAN);
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show("User không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUser.Focus();
                    break;
                case 2:
                    MessageBox.Show("Password không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPwd.Focus();
                    break;
                default:
                    MessageBox.Show("Có lỗi xảy ra trong khi kiểm tra User và Password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        
        private int CheckUserPassword(string @User, string @Pwd)
        {
            // 1 - UserName fail; 2 - Password fail; 0 - OK; 3 - Function Fail
            try
            {
                clsDatabase clsdt = new clsDatabase();
                DataProvider.ConnectionString = clsdt.GetStringConnect();
                clsdt = null;

                SqlDataReader dr;
                // Set True DB Dropdown
                string strSQL = "select user_id, password, user_right, bedids from USERS where user_name = '" + User + "'";
                dr = provider.excuteQuery(strSQL);

                //Tạo DataReader nhận dữ liệu trả về

                int Result = 99;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (Pwd == dr["password"].ToString())
                        {
                            Result = 0;
                        }
                        else
                        {
                            Result = 2;
                        }

                        clsUtl.USER_ID = Convert.ToInt32(dr["user_id"].ToString());
                        clsUtl.RIGHT = Convert.ToInt32(dr["user_right"].ToString() == "" ? "0" : dr["user_right"].ToString());
                        if (!string.IsNullOrEmpty(dr["bedids"].ToString()))
                        {
                            var arr = dr["bedids"].ToString().Split(',');
                            if (arr != null && arr.Length > 0)
                                for (int i = 0; i < arr.Length; i++)
                                    clsUtl.UserBedIds.Add(arr[i]);
                        }
                    }
                }

                return Result;
            }
            catch (Exception)
            {
                return 3;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                butOK_Click(sender, e);
        }

        private void c1Combo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                butOK_Click(sender, e);
        }
    }
}
