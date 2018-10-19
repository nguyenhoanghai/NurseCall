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
	public class F0018 : Form
	{
		private SqlConnection conn;
		private DataSet ds;
		private SqlDataAdapter da;
		private string strSQL = "";
		private DataProvider provider = new DataProvider();
		private IContainer components = null;
		private C1TrueDBGrid c1TrueDBGrid1;
		private DateTimePicker dateTimePicker1;
		private DateTimePicker dateTimePicker2;
		private Label label1;
		private Label label2;
		private Button butShow;
		private C1TrueDBDropdown c1TrueDBDropdown1;
		private C1TrueDBDropdown c1TrueDBDropdown2;
		public F0018()
		{
			this.InitializeComponent();
		}
		private void F9000_Load(object sender, EventArgs e)
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
				MessageBox.Show(ex.ToString(), "F9000_Load", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void LoadData()
		{
			try
			{
				this.conn = new SqlConnection(this.GetStringConnect());
				this.conn.Open();
				this.ds = new DataSet();
				this.strSQL = "SELECT [work_date],[shift_id],[employee_id] FROM  [dbo].[WORK_SHIFTS] where [shift_id] = 0";
				this.da = new SqlDataAdapter(this.strSQL, this.conn);
				this.da.Fill(this.ds, "work_shift");
				this.c1TrueDBGrid1.DataSource = this.ds.Tables["work_shift"];
				this.conn.Close();
				this.strSQL = "SELECT [shift_id],[shift_name] FROM  [dbo].[SHIFTS] WHERE [active] = 1 ORDER BY [shift_name]";
				this.c1TrueDBDropdown1.SetDataBinding(this.provider.execute(this.strSQL, "shift"), "shift", false);
				this.strSQL = "SELECT [employee_id] ,[first_name] + ' ' + [last_name] full_name FROM  [dbo].[employees]";
				this.c1TrueDBDropdown2.SetDataBinding(this.provider.execute(this.strSQL, "employees"), "employees", false);
				this.CountFooterMaster();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Load Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
			this.c1TrueDBGrid1.AllowAddNew = false;
			this.c1TrueDBGrid1.AllowDelete = false;
			this.c1TrueDBGrid1.AllowUpdate = false;
			this.c1TrueDBGrid1.Columns["work_date"].Caption = "Ngày";
			this.c1TrueDBGrid1.Columns["shift_id"].Caption = "Mã ca";
			this.c1TrueDBGrid1.Columns["employee_id"].Caption = "Nhân viên";
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["work_date"].Width = 120;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["work_date"].Merge = ColumnMergeEnum.Restricted;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["shift_id"].Width = 150;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["shift_id"].Merge = ColumnMergeEnum.Restricted;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["employee_id"].Width = 235;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["shift_id"].AutoDropDown = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["shift_id"].AutoComplete = true;
			this.c1TrueDBGrid1.Columns["shift_id"].DropDown = this.c1TrueDBDropdown1;
			this.c1TrueDBGrid1.Columns["shift_id"].ValueItems.Translate = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["employee_id"].AutoDropDown = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["employee_id"].AutoComplete = true;
			this.c1TrueDBGrid1.Columns["employee_id"].DropDown = this.c1TrueDBDropdown2;
			this.c1TrueDBGrid1.Columns["employee_id"].ValueItems.Translate = true;
		}
		private void butSave_Click(object sender, EventArgs e)
		{
		}
		private void TrueDBDropDownFormat()
		{
			this.c1TrueDBDropdown1.Width = 254;
			this.c1TrueDBDropdown1.DisplayColumns["shift_id"].Width = 100;
			this.c1TrueDBDropdown1.DisplayColumns["shift_name"].Width = 130;
			this.c1TrueDBDropdown1.AlternatingRows = true;
			this.c1TrueDBDropdown1.ExtendRightColumn = false;
			this.c1TrueDBDropdown1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBDropdown1.HeadingStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
			this.c1TrueDBDropdown1.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
			this.c1TrueDBDropdown1.Height = 147;
			this.c1TrueDBDropdown1.RowHeight = 20;
			this.c1TrueDBDropdown1.ColumnCaptionHeight = 25;
			this.c1TrueDBDropdown1.Columns["shift_id"].Caption = "Mã ca";
			this.c1TrueDBDropdown1.Columns["shift_name"].Caption = "Tên ca";
			this.c1TrueDBDropdown1.ValueTranslate = true;
			this.c1TrueDBDropdown1.DisplayMember = "shift_name";
			this.c1TrueDBDropdown1.ValueMember = "shift_id";
			this.c1TrueDBDropdown2.Width = 254;
			this.c1TrueDBDropdown2.DisplayColumns["full_name"].Width = 130;
			this.c1TrueDBDropdown2.DisplayColumns["employee_id"].Width = 100;
			this.c1TrueDBDropdown2.AlternatingRows = true;
			this.c1TrueDBDropdown2.ExtendRightColumn = false;
			this.c1TrueDBDropdown2.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
			this.c1TrueDBDropdown2.HeadingStyle.Font = new Font("Arial", 9f, FontStyle.Regular);
			this.c1TrueDBDropdown2.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
			this.c1TrueDBDropdown2.Height = 147;
			this.c1TrueDBDropdown2.RowHeight = 20;
			this.c1TrueDBDropdown2.ColumnCaptionHeight = 25;
			this.c1TrueDBDropdown2.Columns["full_name"].Caption = "Nhân viên";
			this.c1TrueDBDropdown2.Columns["employee_id"].Caption = "Mã nhân viên";
			this.c1TrueDBDropdown2.ValueTranslate = true;
			this.c1TrueDBDropdown2.DisplayMember = "full_name";
			this.c1TrueDBDropdown2.ValueMember = "employee_id";
		}
		private void c1TrueDBGrid1_OnAddNew(object sender, EventArgs e)
		{
		}
		private void c1TrueDBGrid1_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
		{
		}
		private void CountFooterMaster()
		{
			this.c1TrueDBGrid1.Columns["work_date"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
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
		private void butShow_Click(object sender, EventArgs e)
		{
			try
			{
				this.conn = new SqlConnection(this.GetStringConnect());
				this.conn.Open();
				this.ds = new DataSet();
				this.strSQL = string.Concat(new string[]
				{
					"SELECT [work_date],[shift_id],[employee_id] FROM  [dbo].[WORK_SHIFTS] where CONVERT(varchar(10),[work_date], 111) BETWEEN CONVERT(varchar(10),'",
					this.dateTimePicker1.Value.ToString("yyyy/MM/dd"),
					"',111) AND CONVERT(varchar(10), '",
					this.dateTimePicker2.Value.ToString("yyyy/MM/dd"),
					"',111)"
				});
				this.da = new SqlDataAdapter(this.strSQL, this.conn);
				this.da.Fill(this.ds, "work_shift");
				this.c1TrueDBGrid1.SetDataBinding(this.ds.Tables["work_shift"], "", true);
				this.conn.Close();
				this.CountFooterMaster();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "butShow_Click", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F0018));
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
			this.c1TrueDBGrid1 = new C1TrueDBGrid();
			this.dateTimePicker1 = new DateTimePicker();
			this.dateTimePicker2 = new DateTimePicker();
			this.label1 = new Label();
			this.label2 = new Label();
			this.butShow = new Button();
			this.c1TrueDBDropdown1 = new C1TrueDBDropdown();
			this.c1TrueDBDropdown2 = new C1TrueDBDropdown();
			((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
			((ISupportInitialize)this.c1TrueDBDropdown1).BeginInit();
			((ISupportInitialize)this.c1TrueDBDropdown2).BeginInit();
			base.SuspendLayout();
			this.c1TrueDBGrid1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
			this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
			this.c1TrueDBGrid1.Location = new Point(12, 41);
			this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
			this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
			this.c1TrueDBGrid1.Size = new Size(551, 378);
			this.c1TrueDBGrid1.TabIndex = 9;
			this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.AfterFilter += new FilterEventHandler(this.c1TrueDBGrid1_AfterFilter);
			this.c1TrueDBGrid1.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.c1TrueDBGrid1_BeforeUpdate);
			this.c1TrueDBGrid1.OnAddNew += new EventHandler(this.c1TrueDBGrid1_OnAddNew);
			this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
			this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new Point(82, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new Size(130, 20);
			this.dateTimePicker1.TabIndex = 10;
			this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new Point(314, 12);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new Size(130, 20);
			this.dateTimePicker2.TabIndex = 11;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new Size(49, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Từ ngày:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(235, 14);
			this.label2.Name = "label2";
			this.label2.Size = new Size(56, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Đến ngày:";
			this.butShow.Location = new Point(467, 10);
			this.butShow.Name = "butShow";
			this.butShow.Size = new Size(96, 23);
			this.butShow.TabIndex = 13;
			this.butShow.Text = "&Hiển thị";
			this.butShow.UseVisualStyleBackColor = true;
			this.butShow.Click += new EventHandler(this.butShow_Click);
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
			this.c1TrueDBDropdown1.Location = new Point(238, 247);
			this.c1TrueDBDropdown1.Name = "c1TrueDBDropdown1";
			this.c1TrueDBDropdown1.OddRowStyle = oddRowStyle;
			this.c1TrueDBDropdown1.RecordSelectorStyle = recordSelectorStyle;
			this.c1TrueDBDropdown1.RowDivider.Color = Color.DarkGray;
			this.c1TrueDBDropdown1.RowDivider.Style = LineStyleEnum.Single;
			this.c1TrueDBDropdown1.RowSubDividerColor = Color.DarkGray;
			this.c1TrueDBDropdown1.ScrollTips = false;
			this.c1TrueDBDropdown1.Size = new Size(100, 150);
			this.c1TrueDBDropdown1.Style = style;
			this.c1TrueDBDropdown1.TabIndex = 14;
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
			this.c1TrueDBDropdown2.Location = new Point(379, 247);
			this.c1TrueDBDropdown2.Name = "c1TrueDBDropdown2";
			this.c1TrueDBDropdown2.OddRowStyle = oddRowStyle2;
			this.c1TrueDBDropdown2.RecordSelectorStyle = recordSelectorStyle2;
			this.c1TrueDBDropdown2.RowDivider.Color = Color.DarkGray;
			this.c1TrueDBDropdown2.RowDivider.Style = LineStyleEnum.Single;
			this.c1TrueDBDropdown2.RowSubDividerColor = Color.DarkGray;
			this.c1TrueDBDropdown2.ScrollTips = false;
			this.c1TrueDBDropdown2.Size = new Size(100, 150);
			this.c1TrueDBDropdown2.Style = style2;
			this.c1TrueDBDropdown2.TabIndex = 15;
			this.c1TrueDBDropdown2.Text = "c1TrueDBDropdown2";
			this.c1TrueDBDropdown2.Visible = false;
			this.c1TrueDBDropdown2.PropBag = componentResourceManager.GetString("c1TrueDBDropdown2.PropBag");
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(575, 431);
			base.Controls.Add(this.c1TrueDBDropdown2);
			base.Controls.Add(this.c1TrueDBDropdown1);
			base.Controls.Add(this.butShow);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.dateTimePicker2);
			base.Controls.Add(this.dateTimePicker1);
			base.Controls.Add(this.c1TrueDBGrid1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "F0018";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F0018 - Chi tiết lịch làm việc";
			base.Load += new EventHandler(this.F9000_Load);
			((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
			((ISupportInitialize)this.c1TrueDBDropdown1).EndInit();
			((ISupportInitialize)this.c1TrueDBDropdown2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
