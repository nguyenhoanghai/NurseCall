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
	public class F9004 : Form
	{
		private SqlConnection conn;
		private DataSet ds;
		private SqlDataAdapter da;
		private SqlDataAdapter da2;
		private string strSql;
		private IContainer components = null;
		private C1TrueDBGrid c1TrueDBGrid1;
		private Button butSave;
		private GroupBox groupBox1;
		private C1TrueDBDropdown c1TrueDBDropdown1;
		public F9004()
		{
			this.InitializeComponent();
		}
		private void F9004_Load(object sender, EventArgs e)
		{
			try
			{
				this.LoadData();
				this.TrueDBGridFormat();
				this.TrueDBDropDownFormat();
				this.c1TrueDBGrid1.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "F9004_Load", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
			this.strSql = "SELECT [id],[mail_type],[host],[port],[fromaddress],[displayname],[frompassword],[subject],[body],[note],[active] FROM  [dbo].[MAIL_SETUP] ORDER BY id";
			this.da = new SqlDataAdapter(this.strSql, this.conn);
			this.da.Fill(this.ds, "MAIL_SETUP");
			this.c1TrueDBGrid1.DataSource = this.ds.Tables["MAIL_SETUP"];
			this.strSql = "SELECT [id],[mail_type] FROM  [dbo].[MAIL_TYPE] WHERE [ACTIVE] = 1";
			this.da2 = new SqlDataAdapter(this.strSql, this.conn);
			this.da2.Fill(this.ds, "MAIL_TYPE");
			this.c1TrueDBDropdown1.SetDataBinding(this.ds, "MAIL_TYPE", false);
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
			this.c1TrueDBGrid1.Columns["mail_type"].Caption = "Loại mail";
			this.c1TrueDBGrid1.Columns["host"].Caption = "Host";
			this.c1TrueDBGrid1.Columns["port"].Caption = "Port";
			this.c1TrueDBGrid1.Columns["fromaddress"].Caption = "Người gửi";
			this.c1TrueDBGrid1.Columns["displayname"].Caption = "Tên đại diện";
			this.c1TrueDBGrid1.Columns["frompassword"].Caption = "Mật khẩu";
			this.c1TrueDBGrid1.Columns["subject"].Caption = "Tiêu đề mail";
			this.c1TrueDBGrid1.Columns["body"].Caption = "Nội dung mail";
			this.c1TrueDBGrid1.Columns["note"].Caption = "ghi chú";
			this.c1TrueDBGrid1.Columns["active"].Caption = "Trạng thái";
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["mail_type"].Width = 80;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["host"].Width = 130;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["port"].Width = 60;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["fromaddress"].Width = 150;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["fromaddress"].Width = 150;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["displayname"].Width = 120;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["subject"].Width = 150;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["body"].Width = 150;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["note"].Width = 150;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["active"].Width = 130;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["mail_type"].AutoDropDown = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["mail_type"].AutoComplete = true;
			this.c1TrueDBGrid1.Columns["mail_type"].DropDown = this.c1TrueDBDropdown1;
			this.c1TrueDBGrid1.Columns["mail_type"].ValueItems.Translate = true;
			this.CountFooterMaster();
		}
		private void TrueDBDropDownFormat()
		{
			this.c1TrueDBDropdown1.Width = 254;
			this.c1TrueDBDropdown1.DisplayColumns["id"].Width = 100;
			this.c1TrueDBDropdown1.DisplayColumns["mail_type"].Width = 130;
			this.c1TrueDBDropdown1.AlternatingRows = true;
			this.c1TrueDBDropdown1.ExtendRightColumn = false;
			this.c1TrueDBDropdown1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBDropdown1.HeadingStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
			this.c1TrueDBDropdown1.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
			this.c1TrueDBDropdown1.Height = 147;
			this.c1TrueDBDropdown1.RowHeight = 20;
			this.c1TrueDBDropdown1.ColumnCaptionHeight = 25;
			this.c1TrueDBDropdown1.Columns["id"].Caption = "Mã mail";
			this.c1TrueDBDropdown1.Columns["mail_type"].Caption = "Tên loại mail";
			this.c1TrueDBDropdown1.ValueTranslate = true;
			this.c1TrueDBDropdown1.DisplayMember = "mail_type";
			this.c1TrueDBDropdown1.ValueMember = "id";
		}
		private void CountFooterMaster()
		{
			this.c1TrueDBGrid1.Columns["mail_type"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
		}
		private void butSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.CheckOnlyRecord())
				{
					MessageBox.Show("Chỉ cho phép 01 dòng dữ liệu Active", "butSave_Click");
				}
				else
				{
					this.conn.Open();
					SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
					this.c1TrueDBGrid1.UpdateData();
					this.da.Update(this.ds.Tables["MAIL_SETUP"]);
					if (this.conn.State == ConnectionState.Open)
					{
						this.conn.Close();
					}
					MessageBox.Show("Đã lưu dữ liệu thành công", "butSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "butSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
				MessageBox.Show(ex.Message, "c1TrueDBGrid1_OnAddNew", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void c1TrueDBGrid1_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "c1TrueDBGrid1_BeforeUpdate", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		private bool CheckOnlyRecord()
		{
			bool result;
			try
			{
				int num = 0;
				for (int i = 0; i < this.c1TrueDBGrid1.RowCount; i++)
				{
					if (this.c1TrueDBGrid1[i, 10].ToString() == "True")
					{
						num++;
					}
				}
				if (num > 1)
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = this.CheckOnlyRecord();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F9004));
			Style captionStyle = new Style();
			Style evenRowStyle = new Style();
			Style footerStyle = new Style();
			Style headingStyle = new Style();
			Style highLightRowStyle = new Style();
			Style oddRowStyle = new Style();
			Style recordSelectorStyle = new Style();
			Style style = new Style();
			this.c1TrueDBGrid1 = new C1TrueDBGrid();
			this.butSave = new Button();
			this.groupBox1 = new GroupBox();
			this.c1TrueDBDropdown1 = new C1TrueDBDropdown();
			((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
			((ISupportInitialize)this.c1TrueDBDropdown1).BeginInit();
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
			this.c1TrueDBGrid1.Size = new Size(650, 258);
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
			this.butSave.Location = new Point(562, 295);
			this.butSave.Name = "butSave";
			this.butSave.Size = new Size(101, 28);
			this.butSave.TabIndex = 19;
			this.butSave.Text = "      &Lưu dữ liệu";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new EventHandler(this.butSave_Click);
			this.groupBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(13, 278);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(650, 9);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.c1TrueDBDropdown1.AllowColMove = true;
			this.c1TrueDBDropdown1.AllowColSelect = true;
			this.c1TrueDBDropdown1.AllowRowSizing = RowSizingEnum.AllRows;
			this.c1TrueDBDropdown1.AlternatingRows = false;
			this.c1TrueDBDropdown1.CaptionStyle = captionStyle;
			this.c1TrueDBDropdown1.ColumnCaptionHeight = 17;
			this.c1TrueDBDropdown1.ColumnFooterHeight = 17;
			this.c1TrueDBDropdown1.EvenRowStyle = evenRowStyle;
			this.c1TrueDBDropdown1.FetchRowStyles = false;
			this.c1TrueDBDropdown1.FooterStyle = footerStyle;
			this.c1TrueDBDropdown1.HeadingStyle = headingStyle;
			this.c1TrueDBDropdown1.HighLightRowStyle = highLightRowStyle;
			this.c1TrueDBDropdown1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBDropdown1.Images"));
			this.c1TrueDBDropdown1.Location = new Point(197, 58);
			this.c1TrueDBDropdown1.Name = "c1TrueDBDropdown1";
			this.c1TrueDBDropdown1.OddRowStyle = oddRowStyle;
			this.c1TrueDBDropdown1.RecordSelectorStyle = recordSelectorStyle;
			this.c1TrueDBDropdown1.RowDivider.Color = Color.DarkGray;
			this.c1TrueDBDropdown1.RowDivider.Style = LineStyleEnum.Single;
			this.c1TrueDBDropdown1.RowSubDividerColor = Color.DarkGray;
			this.c1TrueDBDropdown1.ScrollTips = false;
			this.c1TrueDBDropdown1.Size = new Size(100, 150);
			this.c1TrueDBDropdown1.Style = style;
			this.c1TrueDBDropdown1.TabIndex = 20;
			this.c1TrueDBDropdown1.Text = "c1TrueDBDropdown1";
			this.c1TrueDBDropdown1.Visible = false;
			this.c1TrueDBDropdown1.PropBag = componentResourceManager.GetString("c1TrueDBDropdown1.PropBag");
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(679, 332);
			base.Controls.Add(this.c1TrueDBDropdown1);
			base.Controls.Add(this.butSave);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.c1TrueDBGrid1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "F9004";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F9004 - Thiết lập thông số mail";
			base.Load += new EventHandler(this.F9004_Load);
			((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
			((ISupportInitialize)this.c1TrueDBDropdown1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
