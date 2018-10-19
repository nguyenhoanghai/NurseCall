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
	public class F9995 : Form
	{
		private SqlConnection conn;
		private DataSet ds;
		private SqlDataAdapter da;
		private string strSQL = "";
		private DataProvider provider = new DataProvider();
		private IContainer components = null;
		private GroupBox groupBox1;
		private Button butSave;
		private C1TrueDBGrid c1TrueDBGrid1;
		private C1TrueDBDropdown c1TrueDBDropdown1;
		private C1TrueDBDropdown c1TrueDBDropdown2;
		public F9995()
		{
			this.InitializeComponent();
		}
		private void F9995_Load(object sender, EventArgs e)
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
		private void LoadData()
		{
			try
			{
				this.conn = new SqlConnection(clsUtl.CONNECT_STRING);
				this.conn.Open();
				this.ds = new DataSet();
				this.strSQL = "SELECT [id], [right_id],[function_id],[active] FROM  [dbo].[RIGHT_FUNCTIONS]  ORDER BY [right_id], [function_id]";
				this.da = new SqlDataAdapter(this.strSQL, this.conn);
				this.da.Fill(this.ds, "RIGHT_FUNCTIONS");
				this.c1TrueDBGrid1.DataSource = this.ds.Tables["RIGHT_FUNCTIONS"];
				if (this.conn.State == ConnectionState.Open)
				{
					this.conn.Close();
				}
				this.strSQL = "SELECT [right_id],[right_name] FROM  [dbo].[RIGHTS] WHERE [active] = 1 ORDER BY [right_id]";
				this.c1TrueDBDropdown1.SetDataBinding(this.provider.execute(this.strSQL, "RIGHTS"), "RIGHTS", false);
				this.strSQL = "SELECT [function_id],[function_name_vn] FROM  [dbo].[FUNCTIONS] WHERE [active] = 1 ORDER BY [function_id]";
				this.c1TrueDBDropdown2.SetDataBinding(this.provider.execute(this.strSQL, "FUNCTIONS"), "FUNCTIONS", false);
				this.CountFooterMaster();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "LoadData", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
			this.c1TrueDBGrid1.Columns["right_id"].Caption = "Tên quyền";
			this.c1TrueDBGrid1.Columns["function_id"].Caption = "Tên chức năng";
			this.c1TrueDBGrid1.Columns["active"].Caption = "Trạng thái";
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["right_id"].Width = 160;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["right_id"].Locked = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["right_id"].Merge = ColumnMergeEnum.Restricted;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["function_id"].Width = 350;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["function_id"].Locked = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["active"].Width = 110;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["right_id"].AutoDropDown = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["right_id"].AutoComplete = true;
			this.c1TrueDBGrid1.Columns["right_id"].DropDown = this.c1TrueDBDropdown1;
			this.c1TrueDBGrid1.Columns["right_id"].ValueItems.Translate = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["function_id"].AutoDropDown = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["function_id"].AutoComplete = true;
			this.c1TrueDBGrid1.Columns["function_id"].DropDown = this.c1TrueDBDropdown2;
			this.c1TrueDBGrid1.Columns["function_id"].ValueItems.Translate = true;
		}
		private void butSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.conn.Open();
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
				this.c1TrueDBGrid1.UpdateData();
				this.da.Update(this.ds.Tables["RIGHT_FUNCTIONS"]);
				this.conn.Close();
				MessageBox.Show("Đã lưu dữ liệu thành công", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				if (this.conn.State == ConnectionState.Open)
				{
					this.conn.Close();
				}
				MessageBox.Show(ex.Message, "butSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void TrueDBDropDownFormat()
		{
			this.c1TrueDBDropdown1.Width = 254;
			this.c1TrueDBDropdown1.DisplayColumns["right_id"].Width = 100;
			this.c1TrueDBDropdown1.DisplayColumns["right_name"].Width = 130;
			this.c1TrueDBDropdown1.AlternatingRows = true;
			this.c1TrueDBDropdown1.ExtendRightColumn = false;
			this.c1TrueDBDropdown1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBDropdown1.HeadingStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
			this.c1TrueDBDropdown1.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
			this.c1TrueDBDropdown1.Height = 147;
			this.c1TrueDBDropdown1.RowHeight = 20;
			this.c1TrueDBDropdown1.ColumnCaptionHeight = 25;
			this.c1TrueDBDropdown1.Columns["right_id"].Caption = "Mã quyền";
			this.c1TrueDBDropdown1.Columns["right_name"].Caption = "Tên quyền";
			this.c1TrueDBDropdown1.ValueTranslate = true;
			this.c1TrueDBDropdown1.DisplayMember = "right_name";
			this.c1TrueDBDropdown1.ValueMember = "right_id";
			this.c1TrueDBDropdown2.Width = 254;
			this.c1TrueDBDropdown2.DisplayColumns["function_id"].Width = 100;
			this.c1TrueDBDropdown2.DisplayColumns["function_name_vn"].Width = 130;
			this.c1TrueDBDropdown2.AlternatingRows = true;
			this.c1TrueDBDropdown2.ExtendRightColumn = false;
			this.c1TrueDBDropdown2.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBDropdown2.HeadingStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
			this.c1TrueDBDropdown2.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
			this.c1TrueDBDropdown2.Height = 147;
			this.c1TrueDBDropdown2.RowHeight = 20;
			this.c1TrueDBDropdown2.ColumnCaptionHeight = 25;
			this.c1TrueDBDropdown2.Columns["function_name_vn"].Caption = "Tên chức năng";
			this.c1TrueDBDropdown2.Columns["function_id"].Caption = "Mã chức năng";
			this.c1TrueDBDropdown2.ValueTranslate = true;
			this.c1TrueDBDropdown2.DisplayMember = "function_name_vn";
			this.c1TrueDBDropdown2.ValueMember = "function_id";
		}
		private void c1TrueDBGrid1_OnAddNew(object sender, EventArgs e)
		{
			this.c1TrueDBGrid1.Columns["active"].Value = true;
		}
		private void c1TrueDBGrid1_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
		{
		}
		private void CountFooterMaster()
		{
			this.c1TrueDBGrid1.Columns["right_id"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F9995));
			Style captionStyle = new Style();
			Style evenRowStyle = new Style();
			Style footerStyle = new Style();
			Style headingStyle = new Style();
			Style highLightRowStyle = new Style();
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
			this.groupBox1 = new GroupBox();
			this.butSave = new Button();
			this.c1TrueDBGrid1 = new C1TrueDBGrid();
			this.c1TrueDBDropdown1 = new C1TrueDBDropdown();
			this.c1TrueDBDropdown2 = new C1TrueDBDropdown();
			((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
			((ISupportInitialize)this.c1TrueDBDropdown1).BeginInit();
			((ISupportInitialize)this.c1TrueDBDropdown2).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Location = new Point(12, 377);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(661, 8);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.butSave.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.butSave.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.butSave.Image = (Image)componentResourceManager.GetObject("butSave.Image");
			this.butSave.ImageAlign = ContentAlignment.MiddleLeft;
			this.butSave.ImeMode = ImeMode.NoControl;
			this.butSave.Location = new Point(572, 391);
			this.butSave.Name = "butSave";
			this.butSave.Size = new Size(101, 28);
			this.butSave.TabIndex = 8;
			this.butSave.Text = "      &Lưu dữ liệu";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new EventHandler(this.butSave_Click);
			this.c1TrueDBGrid1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
			this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
			this.c1TrueDBGrid1.Location = new Point(12, 12);
			this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
			this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
			this.c1TrueDBGrid1.Size = new Size(661, 359);
			this.c1TrueDBGrid1.TabIndex = 9;
			this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.AfterFilter += new FilterEventHandler(this.c1TrueDBGrid1_AfterFilter);
			this.c1TrueDBGrid1.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.c1TrueDBGrid1_BeforeUpdate);
			this.c1TrueDBGrid1.OnAddNew += new EventHandler(this.c1TrueDBGrid1_OnAddNew);
			this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
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
			this.c1TrueDBDropdown1.Location = new Point(214, 207);
			this.c1TrueDBDropdown1.Name = "c1TrueDBDropdown1";
			this.c1TrueDBDropdown1.OddRowStyle = oddRowStyle;
			this.c1TrueDBDropdown1.RecordSelectorStyle = recordSelectorStyle;
			this.c1TrueDBDropdown1.RowDivider.Color = Color.DarkGray;
			this.c1TrueDBDropdown1.RowDivider.Style = LineStyleEnum.Single;
			this.c1TrueDBDropdown1.RowSubDividerColor = Color.DarkGray;
			this.c1TrueDBDropdown1.ScrollTips = false;
			this.c1TrueDBDropdown1.Size = new Size(95, 99);
			this.c1TrueDBDropdown1.Style = style;
			this.c1TrueDBDropdown1.TabIndex = 10;
			this.c1TrueDBDropdown1.Text = "c1TrueDBDropdown1";
			this.c1TrueDBDropdown1.Visible = false;
			this.c1TrueDBDropdown1.PropBag = componentResourceManager.GetString("c1TrueDBDropdown1.PropBag");
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
			this.c1TrueDBDropdown2.Location = new Point(331, 207);
			this.c1TrueDBDropdown2.Name = "c1TrueDBDropdown2";
			this.c1TrueDBDropdown2.OddRowStyle = oddRowStyle2;
			this.c1TrueDBDropdown2.RecordSelectorStyle = recordSelectorStyle2;
			this.c1TrueDBDropdown2.RowDivider.Color = Color.DarkGray;
			this.c1TrueDBDropdown2.RowDivider.Style = LineStyleEnum.Single;
			this.c1TrueDBDropdown2.RowSubDividerColor = Color.DarkGray;
			this.c1TrueDBDropdown2.ScrollTips = false;
			this.c1TrueDBDropdown2.Size = new Size(100, 99);
			this.c1TrueDBDropdown2.Style = style2;
			this.c1TrueDBDropdown2.TabIndex = 11;
			this.c1TrueDBDropdown2.Text = "c1TrueDBDropdown2";
			this.c1TrueDBDropdown2.Visible = false;
			this.c1TrueDBDropdown2.PropBag = componentResourceManager.GetString("c1TrueDBDropdown2.PropBag");
			base.AcceptButton = this.butSave;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(685, 431);
			base.Controls.Add(this.c1TrueDBDropdown2);
			base.Controls.Add(this.c1TrueDBDropdown1);
			base.Controls.Add(this.c1TrueDBGrid1);
			base.Controls.Add(this.butSave);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "F9995";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F9995 - Gán quyền theo chức năng";
			base.Load += new EventHandler(this.F9995_Load);
			((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
			((ISupportInitialize)this.c1TrueDBDropdown1).EndInit();
			((ISupportInitialize)this.c1TrueDBDropdown2).EndInit();
			base.ResumeLayout(false);
		}
	}
}
