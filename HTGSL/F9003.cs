using C1.Win.C1TrueDBGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
	public class F9003 : Form
	{
		private IContainer components = null;
		private C1TrueDBGrid c1TrueDBGrid1;
		private Button butSave;
		private GroupBox groupBox1;
		private SqlConnection conn;
		private DataSet ds;
		private SqlDataAdapter da;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F9003));
			this.c1TrueDBGrid1 = new C1TrueDBGrid();
			this.butSave = new Button();
			this.groupBox1 = new GroupBox();
			((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
			base.SuspendLayout();
			this.c1TrueDBGrid1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
			this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
			this.c1TrueDBGrid1.Location = new Point(13, 16);
			this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
			this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
			this.c1TrueDBGrid1.Size = new Size(627, 273);
			this.c1TrueDBGrid1.TabIndex = 0;
			this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.AfterFilter += new FilterEventHandler(this.c1TrueDBGrid1_AfterFilter);
			this.c1TrueDBGrid1.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.c1TrueDBGrid1_BeforeUpdate);
			this.c1TrueDBGrid1.OnAddNew += new EventHandler(this.c1TrueDBGrid1_OnAddNew);
			this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
			this.butSave.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.butSave.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.butSave.Image = (Image)componentResourceManager.GetObject("butSave.Image");
			this.butSave.ImageAlign = ContentAlignment.MiddleLeft;
			this.butSave.ImeMode = ImeMode.NoControl;
			this.butSave.Location = new Point(539, 310);
			this.butSave.Name = "butSave";
			this.butSave.Size = new Size(101, 28);
			this.butSave.TabIndex = 19;
			this.butSave.Text = "      &Lưu dữ liệu";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new EventHandler(this.butSave_Click);
			this.groupBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(13, 293);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(627, 9);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(656, 347);
			base.Controls.Add(this.butSave);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.c1TrueDBGrid1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "F9003";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F9003 - Khai báo danh sách gửi mail";
			base.Load += new EventHandler(this.F9003_Load);
			((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
			base.ResumeLayout(false);
		}
		public F9003()
		{
			this.InitializeComponent();
		}
		private void F9003_Load(object sender, EventArgs e)
		{
			try
			{
				this.LoadData();
				this.TrueDBGridFormat();
				this.c1TrueDBGrid1.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void F9994_KeyDown(object sender, KeyEventArgs e)
		{
		}
		private void LoadData()
		{
			this.conn = new SqlConnection(clsUtl.CONNECT_STRING);
			this.conn.Open();
			this.ds = new DataSet();
			this.strSql = "SELECT [id],[fullname],[email],[note],[active] FROM  [dbo].[MAIL_LISTS] WHERE [active] = 1";
			this.da = new SqlDataAdapter(this.strSql, this.conn);
			this.da.Fill(this.ds, "MAIL_LISTS");
			this.c1TrueDBGrid1.DataSource = this.ds.Tables["MAIL_LISTS"];
			if (this.conn.State == ConnectionState.Open)
			{
				this.conn.Close();
			}
		}
		private void TrueDBGridFormat()
		{
			this.c1TrueDBGrid1.AlternatingRows = true;
			this.c1TrueDBGrid1.BorderStyle = BorderStyle.Fixed3D;
			this.c1TrueDBGrid1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBGrid1.Font = new Font("Arial", 10f, FontStyle.Regular);
			this.c1TrueDBGrid1.HeadingStyle.Font = new Font("Arial", 10f, FontStyle.Regular);
			this.c1TrueDBGrid1.ColumnFooters = true;
			this.c1TrueDBGrid1.ExtendRightColumn = false;
			this.c1TrueDBGrid1.EmptyRows = true;
			this.c1TrueDBGrid1.RowHeight = 20;
			this.c1TrueDBGrid1.Splits[0].ColumnCaptionHeight = 25;
			this.c1TrueDBGrid1.FilterBar = true;
			this.c1TrueDBGrid1.AllowFilter = true;
			this.c1TrueDBGrid1.AllowAddNew = true;
			this.c1TrueDBGrid1.AllowDelete = true;
			this.c1TrueDBGrid1.AllowUpdate = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["id"].Visible = false;
			this.c1TrueDBGrid1.Columns["fullname"].Caption = "Họ và tên";
			this.c1TrueDBGrid1.Columns["email"].Caption = "E-mail";
			this.c1TrueDBGrid1.Columns["note"].Caption = "Ghi chú";
			this.c1TrueDBGrid1.Columns["active"].Caption = "Thạng thái";
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["fullname"].Width = 170;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["email"].Width = 160;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["Note"].Width = 150;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["active"].Width = 100;
			this.CountFooterMaster();
		}
		private void CountFooterMaster()
		{
			this.c1TrueDBGrid1.Columns["fullname"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
		}
		private void butSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.conn.Open();
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
				this.c1TrueDBGrid1.UpdateData();
				this.da.Update(this.ds.Tables["MAIL_LISTS"]);
				if (this.conn.State == ConnectionState.Open)
				{
					this.conn.Close();
				}
				MessageBox.Show("Đã lưu dữ liệu thành công", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void butExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void c1TrueDBGrid1_OnAddNew(object sender, EventArgs e)
		{
			try
			{
				this.c1TrueDBGrid1.Columns["active"].Value = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void c1TrueDBGrid1_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void ShowUser()
		{
		}
		private void c1TrueDBGrid1_AfterFilter(object sender, FilterEventArgs e)
		{
			this.CountFooterMaster();
		}
		private string GetStringConnect()
		{
			string result;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Application.StartupPath + "\\DATA.XML");
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("SQLServer");
				string innerText = elementsByTagName.Item(0).ChildNodes[0].InnerText;
				string innerText2 = elementsByTagName.Item(0).ChildNodes[1].InnerText;
				string innerText3 = elementsByTagName.Item(0).ChildNodes[2].InnerText;
				string innerText4 = elementsByTagName.Item(0).ChildNodes[3].InnerText;
				result = string.Concat(new string[]
				{
					"Server=",
					innerText,
					";Database=",
					innerText2,
					";uid=",
					innerText3,
					";pwd=",
					innerText4
				});
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
	}
}
