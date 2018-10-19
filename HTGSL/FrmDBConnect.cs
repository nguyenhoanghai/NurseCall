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
    public partial class FrmDBConnect : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataSet ds;
        private string strSql;
        public FrmDBConnect()
        {
            InitializeComponent();
        }

        private void FrmDBConnect_Load(object sender, EventArgs e)
        {
            this.Text = "Kết nối cơ sở dữ liệu";
            this.ReadData();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.txtServerName.Text != "")
                if (this.txtUserName.Text != "")
                    if (this.txtPassword.Text != "")
                        if (this.cbbDatabaseName.Text != "")
                        {
                            this.CreatNewXMLFile(this.txtServerName.Text, this.txtUserName.Text, this.txtPassword.Text, this.cbbDatabaseName.Text);
                            base.Close();
                        }
                        else
                            MessageBox.Show("Chọn cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                        MessageBox.Show("Nhập mật khẩu truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else
                    MessageBox.Show("Nhập tên user", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
                MessageBox.Show("Nhập tên máy chủ SQL server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void cbbDatabaseName_Enter(object sender, EventArgs e)
        {
            if (this.cbbDatabaseName.Text == "")
                this.LoadDatabaseName();
        }
        private void LoadDatabaseName()
        {
            try
            {
                string connectionString = string.Concat(new string[]
				{
					"Server = ",
					this.txtServerName.Text,
					" ; Uid = ",
					this.txtUserName.Text,
					" ;Pwd= ",
					this.txtPassword.Text
				});
                this.conn = new SqlConnection(connectionString);
                this.conn.Open();
                this.ds = new DataSet();
                this.strSql = "select name from sysdatabases";
                this.da = new SqlDataAdapter(this.strSql, this.conn);
                this.da.Fill(this.ds, "databasenames");
                this.cbbDatabaseName.DataSource = this.ds.Tables["databasenames"];
                this.cbbDatabaseName.DisplayMember = "name";
            }
            catch
            {
                this.cbbDatabaseName.DataSource = null;
            }
        }

        private void CreatNewXMLFile(string sServer_Name, string sUser_Name, string sPassword, string sDatabase)
        {
            string filename = Application.StartupPath + "\\DATA.XML";
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(newChild);
            XmlNode xmlNode = xmlDocument.CreateElement("String_Connect");
            xmlDocument.AppendChild(xmlNode);
            XmlNode xmlNode2 = xmlDocument.CreateElement("SQLServer");
            XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("id");
            xmlAttribute.Value = "1";
            xmlNode2.Attributes.Append(xmlAttribute);
            xmlNode.AppendChild(xmlNode2);
            XmlNode xmlNode3 = xmlDocument.CreateElement("Server_Name");
            xmlNode3.AppendChild(xmlDocument.CreateTextNode(sServer_Name));
            xmlNode2.AppendChild(xmlNode3);
            XmlNode xmlNode4 = xmlDocument.CreateElement("Database");
            xmlNode4.AppendChild(xmlDocument.CreateTextNode(sDatabase));
            xmlNode2.AppendChild(xmlNode4);
            XmlNode xmlNode5 = xmlDocument.CreateElement("User");
            xmlNode5.AppendChild(xmlDocument.CreateTextNode(sUser_Name));
            xmlNode2.AppendChild(xmlNode5);
            XmlNode xmlNode6 = xmlDocument.CreateElement("Password");
            xmlNode6.AppendChild(xmlDocument.CreateTextNode(sPassword));
            xmlNode2.AppendChild(xmlNode6);
            xmlDocument.Save(filename);
        }

        private void ReadData()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Application.StartupPath + "\\DATA.XML");
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("SQLServer");
                this.txtServerName.Text = elementsByTagName.Item(0).ChildNodes[0].InnerText;
                this.txtUserName.Text = elementsByTagName.Item(0).ChildNodes[2].InnerText;
                this.txtPassword.Text = elementsByTagName.Item(0).ChildNodes[3].InnerText;
                this.LoadDatabaseName();
                string innerText = elementsByTagName.Item(0).ChildNodes[1].InnerText;
                this.cbbDatabaseName.Text = innerText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ReadData");
            }
        }
    }
}
