using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
	public class F0002 : Form
	{
		private IContainer components = null;
		private GroupBox groupBox1;
		private TextBox txtPassword;
		private TextBox txtUserName;
		private TextBox txtServerName;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private Button btnConnect;
		private ComboBox cbbDatabaseName;
		private SqlConnection conn;
		private SqlDataAdapter da;
		private DataSet ds;
		private string strSql;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F0002));
			this.groupBox1 = new GroupBox();
			this.cbbDatabaseName = new ComboBox();
			this.txtPassword = new TextBox();
			this.txtUserName = new TextBox();
			this.txtServerName = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.btnConnect = new Button();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.cbbDatabaseName);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.txtUserName);
			this.groupBox1.Controls.Add(this.txtServerName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new Point(14, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(292, 127);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.cbbDatabaseName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbbDatabaseName.FormattingEnabled = true;
			this.cbbDatabaseName.Location = new Point(137, 95);
			this.cbbDatabaseName.Name = "cbbDatabaseName";
			this.cbbDatabaseName.Size = new Size(137, 23);
			this.cbbDatabaseName.TabIndex = 4;
			this.cbbDatabaseName.Enter += new EventHandler(this.cbbDatabaseName_Enter);
			this.txtPassword.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtPassword.Location = new Point(137, 69);
			this.txtPassword.Margin = new Padding(2);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new Size(137, 21);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtUserName.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtUserName.Location = new Point(137, 44);
			this.txtUserName.Margin = new Padding(2);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new Size(137, 21);
			this.txtUserName.TabIndex = 2;
			this.txtServerName.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtServerName.Location = new Point(137, 19);
			this.txtServerName.Margin = new Padding(2);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.Size = new Size(137, 21);
			this.txtServerName.TabIndex = 1;
			this.label4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.Transparent;
			this.label4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(5, 99);
			this.label4.Margin = new Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(107, 15);
			this.label4.TabIndex = 12;
			this.label4.Text = "Tên cơ sở dữ liệu:";
			this.label3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.Transparent;
			this.label3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(5, 47);
			this.label3.Margin = new Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(61, 15);
			this.label3.TabIndex = 11;
			this.label3.Text = "Tên User:";
			this.label2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Transparent;
			this.label2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(5, 72);
			this.label2.Margin = new Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(104, 15);
			this.label2.TabIndex = 10;
			this.label2.Text = "Mật khẩu truy cập:";
			this.label1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(5, 22);
			this.label1.Margin = new Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(122, 15);
			this.label1.TabIndex = 9;
			this.label1.Text = "Máy chủ SQL Server :";
			this.btnConnect.Location = new Point(113, 147);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new Size(99, 28);
			this.btnConnect.TabIndex = 5;
			this.btnConnect.Text = "&Lưu thông tin";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new EventHandler(this.btnConnect_Click);
			base.AutoScaleDimensions = new SizeF(7f, 15f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(318, 187);
			base.Controls.Add(this.btnConnect);
			base.Controls.Add(this.groupBox1);
			this.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "F0002";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F0002";
			base.Load += new EventHandler(this.F0002_Load);
			base.FormClosed += new FormClosedEventHandler(this.F0002_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}
		public F0002()
		{
			this.InitializeComponent();
			base.AcceptButton = this.btnConnect;
		}
		private void F0002_Load(object sender, EventArgs e)
		{
			this.Text = "Kết nối cơ sở dữ liệu";
			this.ReadData();
		}
		private void cbbDatabaseName_Enter(object sender, EventArgs e)
		{
			if (this.cbbDatabaseName.Text == "")
			{
				this.LoadDatabaseName();
			}
		}
		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (this.txtServerName.Text != "")
			{
				if (this.txtUserName.Text != "")
				{
					if (this.txtPassword.Text != "")
					{
						if (this.cbbDatabaseName.Text != "")
						{
							this.CreatNewXMLFile(this.txtServerName.Text, this.txtUserName.Text, this.txtPassword.Text, this.cbbDatabaseName.Text);
							base.Close();
						}
						else
						{
							MessageBox.Show("Chọn cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Nhập mật khẩu truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Nhập tên user", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Nhập tên máy chủ SQL server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void F0002_FormClosed(object sender, FormClosedEventArgs e)
		{
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
	}
}
