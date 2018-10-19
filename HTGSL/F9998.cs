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
	public class F9998 : Form
	{
		private SqlConnection conn;
		private DataSet ds;
		private SqlDataAdapter da;
		private SqlDataAdapter da2;
		private SqlDataAdapter da3;
		private string strSql;
		private IContainer components = null;
		private C1TrueDBDropdown c1TrueDBDropdown1;
		private C1TrueDBGrid c1TrueDBGrid1;
		private Button butSave;
		private GroupBox groupBox1;
		private C1TrueDBDropdown c1TrueDBDropdown2;
		public F9998()
		{
			this.InitializeComponent();
		}
		private void F9998_Load(object sender, EventArgs e)
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
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void F0004_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.F11)
				{
					this.ShowUser();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void LoadData()
		{
			this.conn = new SqlConnection(this.GetStringConnect());
			this.conn.Open();
			this.ds = new DataSet();
			this.strSql = "SELECT [user_id],[user_name],[password], [password_check], [employee_id], [user_right], [active] FROM  [dbo].[USERS]";
			this.da = new SqlDataAdapter(this.strSql, this.conn);
			this.da.Fill(this.ds, "users");
			this.c1TrueDBGrid1.DataSource = this.ds.Tables["users"];
			this.strSql = "SELECT [employee_id] ,[first_name] + ' ' + [last_name] full_name FROM  [dbo].[EMPLOYEES]";
			this.da2 = new SqlDataAdapter(this.strSql, this.conn);
			this.da2.Fill(this.ds, "employees");
			this.c1TrueDBDropdown1.SetDataBinding(this.ds, "employees", false);
			this.strSql = "SELECT [right_id] ,[right_name] FROM  [dbo].[RIGHTS] Order by [right_id]";
			this.da3 = new SqlDataAdapter(this.strSql, this.conn);
			this.da3.Fill(this.ds, "rights");
			this.c1TrueDBDropdown2.SetDataBinding(this.ds, "rights", false);
			this.conn.Close();
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
			this.c1TrueDBGrid1.AllowUpdate = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["user_id"].Visible = false;
			this.c1TrueDBGrid1.Columns["user_name"].Caption = "Người dùng";
			this.c1TrueDBGrid1.Columns["password"].Caption = "Mật khẩu";
			this.c1TrueDBGrid1.Columns["password_check"].Caption = "Kiểm tra mật khẩu";
			this.c1TrueDBGrid1.Columns["employee_id"].Caption = "Nhân viên";
			this.c1TrueDBGrid1.Columns["user_right"].Caption = "Quyền hạn";
			this.c1TrueDBGrid1.Columns["active"].Caption = "Thạng thái";
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["user_name"].Width = 80;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["user_name"].Frozen = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["password"].Width = 120;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["password_check"].Width = 120;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["employee_id"].Width = 140;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["user_right"].Width = 100;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["employee_id"].AutoDropDown = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["employee_id"].AutoComplete = true;
			this.c1TrueDBGrid1.Columns["employee_id"].DropDown = this.c1TrueDBDropdown1;
			this.c1TrueDBGrid1.Columns["employee_id"].ValueItems.Translate = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["user_right"].AutoDropDown = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["user_right"].AutoComplete = true;
			this.c1TrueDBGrid1.Columns["user_right"].DropDown = this.c1TrueDBDropdown2;
			this.c1TrueDBGrid1.Columns["user_right"].ValueItems.Translate = true;
			this.CountFooterMaster();
		}
		private void TrueDBDropDownFormat()
		{
			this.c1TrueDBDropdown1.Width = 251;
			this.c1TrueDBDropdown1.DisplayColumns["employee_id"].Width = 100;
			this.c1TrueDBDropdown1.DisplayColumns["full_name"].Width = 130;
			this.c1TrueDBDropdown1.AlternatingRows = true;
			this.c1TrueDBDropdown1.ExtendRightColumn = false;
			this.c1TrueDBDropdown1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBDropdown1.HeadingStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
			this.c1TrueDBDropdown1.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
			this.c1TrueDBDropdown1.Height = 147;
			this.c1TrueDBDropdown1.RowHeight = 20;
			this.c1TrueDBDropdown1.Columns["employee_id"].Caption = "Mã nhân viên";
			this.c1TrueDBDropdown1.Columns["full_name"].Caption = "Họ Tên";
			this.c1TrueDBDropdown1.ValueTranslate = true;
			this.c1TrueDBDropdown1.DisplayMember = "full_name";
			this.c1TrueDBDropdown1.ValueMember = "employee_id";
			this.c1TrueDBDropdown2.Width = 251;
			this.c1TrueDBDropdown2.DisplayColumns["right_id"].Width = 100;
			this.c1TrueDBDropdown2.DisplayColumns["right_name"].Width = 130;
			this.c1TrueDBDropdown2.AlternatingRows = true;
			this.c1TrueDBDropdown2.ExtendRightColumn = false;
			this.c1TrueDBDropdown2.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBDropdown2.HeadingStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
			this.c1TrueDBDropdown2.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
			this.c1TrueDBDropdown2.Height = 147;
			this.c1TrueDBDropdown2.RowHeight = 20;
			this.c1TrueDBDropdown2.Columns["right_id"].Caption = "Mã quyền";
			this.c1TrueDBDropdown2.Columns["right_name"].Caption = "Tên quyền";
			this.c1TrueDBDropdown2.ValueTranslate = true;
			this.c1TrueDBDropdown2.DisplayMember = "right_name";
			this.c1TrueDBDropdown2.ValueMember = "right_id";
		}
		private void CountFooterMaster()
		{
			this.c1TrueDBGrid1.Columns["user_name"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
		}
		private void butSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.conn.Open();
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
				this.c1TrueDBGrid1.UpdateData();
				this.da.Update(this.ds.Tables["users"]);
				if (this.conn.State == ConnectionState.Open)
				{
					this.conn.Close();
				}
				MessageBox.Show("Đã lưu dữ liệu thành công", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				if (this.conn.State == ConnectionState.Open)
				{
					this.conn.Close();
				}
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
				if (this.c1TrueDBGrid1.Columns["password"].Text == "")
				{
					MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					e.Cancel = true;
				}
				else
				{
					if (this.c1TrueDBGrid1.Columns["password"].Text != this.c1TrueDBGrid1.Columns["password_check"].Text)
					{
						MessageBox.Show("Mật khẩu xác nhận không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						e.Cancel = true;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void ShowUser()
		{
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
			Style captionStyle = new Style();
			Style evenRowStyle = new Style();
			Style footerStyle = new Style();
			Style headingStyle = new Style();
			Style highLightRowStyle = new Style();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F9998));
			Style oddRowStyle = new Style();
			Style recordSelectorStyle = new Style();
			Style style = new Style();
			Style captionStyle2 = new Style();
			Style evenRowStyle2 = new Style();
			Style footerStyle2 = new Style();
			Style headingStyle2 = new Style();
			Style highLightRowStyle2 = new Style();
			Style oddRowStyle2 = new Style();
			Style recordSelectorStyle2 = new Style();
			Style style2 = new Style();
			this.c1TrueDBDropdown1 = new C1TrueDBDropdown();
			this.c1TrueDBGrid1 = new C1TrueDBGrid();
			this.butSave = new Button();
			this.groupBox1 = new GroupBox();
			this.c1TrueDBDropdown2 = new C1TrueDBDropdown();
			((ISupportInitialize)this.c1TrueDBDropdown1).BeginInit();
			((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
			((ISupportInitialize)this.c1TrueDBDropdown2).BeginInit();
			base.SuspendLayout();
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
			this.c1TrueDBDropdown1.Location = new Point(138, 162);
			this.c1TrueDBDropdown1.Name = "c1TrueDBDropdown1";
			this.c1TrueDBDropdown1.OddRowStyle = oddRowStyle;
			this.c1TrueDBDropdown1.RecordSelectorStyle = recordSelectorStyle;
			this.c1TrueDBDropdown1.RowDivider.Color = Color.DarkGray;
			this.c1TrueDBDropdown1.RowDivider.Style = LineStyleEnum.Single;
			this.c1TrueDBDropdown1.RowSubDividerColor = Color.DarkGray;
			this.c1TrueDBDropdown1.ScrollTips = false;
			this.c1TrueDBDropdown1.Size = new Size(98, 90);
			this.c1TrueDBDropdown1.Style = style;
			this.c1TrueDBDropdown1.TabIndex = 34;
			this.c1TrueDBDropdown1.Text = "c1TrueDBDropdown1";
			this.c1TrueDBDropdown1.Visible = false;
			this.c1TrueDBDropdown1.PropBag = componentResourceManager.GetString("c1TrueDBDropdown1.PropBag");
			this.c1TrueDBGrid1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
			this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
			this.c1TrueDBGrid1.Location = new Point(11, 12);
			this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
			this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
			this.c1TrueDBGrid1.Size = new Size(706, 356);
			this.c1TrueDBGrid1.TabIndex = 33;
			this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.c1TrueDBGrid1_BeforeUpdate);
			this.c1TrueDBGrid1.OnAddNew += new EventHandler(this.c1TrueDBGrid1_OnAddNew);
			this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
			this.butSave.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.butSave.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.butSave.Image = (Image)componentResourceManager.GetObject("butSave.Image");
			this.butSave.ImageAlign = ContentAlignment.MiddleLeft;
			this.butSave.ImeMode = ImeMode.NoControl;
			this.butSave.Location = new Point(616, 392);
			this.butSave.Name = "butSave";
			this.butSave.Size = new Size(101, 28);
			this.butSave.TabIndex = 32;
			this.butSave.Text = "      &Lưu dữ liệu";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new EventHandler(this.butSave_Click);
			this.groupBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(11, 372);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(706, 9);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.c1TrueDBDropdown2.AllowColMove = true;
			this.c1TrueDBDropdown2.AllowColSelect = true;
			this.c1TrueDBDropdown2.AllowRowSizing = RowSizingEnum.AllRows;
			this.c1TrueDBDropdown2.AlternatingRows = false;
			this.c1TrueDBDropdown2.CaptionStyle = captionStyle2;
			this.c1TrueDBDropdown2.ColumnCaptionHeight = 17;
			this.c1TrueDBDropdown2.ColumnFooterHeight = 17;
			this.c1TrueDBDropdown2.EvenRowStyle = evenRowStyle2;
			this.c1TrueDBDropdown2.FetchRowStyles = false;
			this.c1TrueDBDropdown2.FooterStyle = footerStyle2;
			this.c1TrueDBDropdown2.HeadingStyle = headingStyle2;
			this.c1TrueDBDropdown2.HighLightRowStyle = highLightRowStyle2;
			this.c1TrueDBDropdown2.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBDropdown2.Images"));
			this.c1TrueDBDropdown2.Location = new Point(243, 162);
			this.c1TrueDBDropdown2.Name = "c1TrueDBDropdown2";
			this.c1TrueDBDropdown2.OddRowStyle = oddRowStyle2;
			this.c1TrueDBDropdown2.RecordSelectorStyle = recordSelectorStyle2;
			this.c1TrueDBDropdown2.RowDivider.Color = Color.DarkGray;
			this.c1TrueDBDropdown2.RowDivider.Style = LineStyleEnum.Single;
			this.c1TrueDBDropdown2.RowSubDividerColor = Color.DarkGray;
			this.c1TrueDBDropdown2.ScrollTips = false;
			this.c1TrueDBDropdown2.Size = new Size(100, 90);
			this.c1TrueDBDropdown2.Style = style2;
			this.c1TrueDBDropdown2.TabIndex = 35;
			this.c1TrueDBDropdown2.Text = "c1TrueDBDropdown2";
			this.c1TrueDBDropdown2.Visible = false;
			this.c1TrueDBDropdown2.PropBag = componentResourceManager.GetString("c1TrueDBDropdown2.PropBag");
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(729, 429);
			base.Controls.Add(this.c1TrueDBDropdown2);
			base.Controls.Add(this.c1TrueDBDropdown1);
			base.Controls.Add(this.c1TrueDBGrid1);
			base.Controls.Add(this.butSave);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "F9998";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F9998 - Danh sách người dùng";
			base.Load += new EventHandler(this.F9998_Load);
			base.KeyDown += new KeyEventHandler(this.F0004_KeyDown);
			((ISupportInitialize)this.c1TrueDBDropdown1).EndInit();
			((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
			((ISupportInitialize)this.c1TrueDBDropdown2).EndInit();
			base.ResumeLayout(false);
		}
	}
}
