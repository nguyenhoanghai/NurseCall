using C1.Win.C1TrueDBGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace HTGSL
{
	public class F9001 : Form
	{
		private IContainer components = null;
		private GroupBox groupBox1;
		private C1TrueDBGrid c1TrueDBGrid1;
		private Button butSave;
		private ComboBox cmbTypeView;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F9001));
			this.groupBox1 = new GroupBox();
			this.c1TrueDBGrid1 = new C1TrueDBGrid();
			this.butSave = new Button();
			this.cmbTypeView = new ComboBox();
			((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Location = new Point(12, 453);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(762, 8);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
			this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
			this.c1TrueDBGrid1.Location = new Point(12, 12);
			this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
			this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
			this.c1TrueDBGrid1.Size = new Size(762, 435);
			this.c1TrueDBGrid1.TabIndex = 8;
			this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
			this.butSave.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.butSave.Image = (Image)componentResourceManager.GetObject("butSave.Image");
			this.butSave.ImageAlign = ContentAlignment.MiddleLeft;
			this.butSave.ImeMode = ImeMode.NoControl;
			this.butSave.Location = new Point(673, 466);
			this.butSave.Name = "butSave";
			this.butSave.Size = new Size(101, 28);
			this.butSave.TabIndex = 10;
			this.butSave.Text = "      &Lưu dữ liệu";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new EventHandler(this.butSave_Click);
			this.cmbTypeView.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cmbTypeView.FormattingEnabled = true;
			this.cmbTypeView.Items.AddRange(new object[]
			{
				"Normal",
				"Inverted",
				"Form",
				"GroupBy",
				"MultipleLines"
			});
			this.cmbTypeView.Location = new Point(12, 471);
			this.cmbTypeView.Name = "cmbTypeView";
			this.cmbTypeView.Size = new Size(171, 23);
			this.cmbTypeView.TabIndex = 11;
			this.cmbTypeView.SelectedIndexChanged += new EventHandler(this.cmbTypeView_SelectedIndexChanged);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(786, 506);
			base.Controls.Add(this.cmbTypeView);
			base.Controls.Add(this.butSave);
			base.Controls.Add(this.c1TrueDBGrid1);
			base.Controls.Add(this.groupBox1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "F9001";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F9001-Thông tin bãi xe";
			base.Load += new EventHandler(this.F9001_Load);
			((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
			base.ResumeLayout(false);
		}
		public F9001()
		{
			this.InitializeComponent();
		}
		private void F9001_Load(object sender, EventArgs e)
		{
			base.Width = 794;
			base.Height = 540;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.MinimizeBox = false;
			base.MaximizeBox = false;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.LoadData();
			this.TrueDBGridFormat();
			this.c1TrueDBGrid1.DataView = DataViewEnum.Normal;
			this.cmbTypeView.SelectedIndex = 0;
			this.c1TrueDBGrid1.Focus();
		}
		private void LoadData()
		{
			try
			{
				this.conn = new SqlConnection(clsDatabase.gstrcnn);
				this.conn.Open();
				this.ds = new DataSet();
				this.strSql = "SELECT [BAI_XE_ID]      ,[TEN_BAI_XE]      ,[CHIEU_DAI]      ,[CHIEU_RONG]      ,[SO_DAY]      ,[SO_XE_TOI_DA]   ,[ACTIVE]    ,[NGUOI_TAO]      ,[NGAY_TAO]      ,[NGUOI_SUA]      ,[NGAY_SUA]FROM [QLBX].[dbo].[BAI_XE] WHERE [ACTIVE] = 1";
				this.da = new SqlDataAdapter(this.strSql, this.conn);
				this.da.Fill(this.ds, "BAI_XE");
				this.c1TrueDBGrid1.DataSource = this.ds.Tables["BAI_XE"];
				this.conn.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
			this.c1TrueDBGrid1.AllowUpdate = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["BAI_XE_ID"].Visible = false;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["NGUOI_TAO"].Visible = false;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["NGAY_TAO"].Visible = false;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["NGUOI_SUA"].Visible = false;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["NGAY_SUA"].Visible = false;
			this.c1TrueDBGrid1.Columns["TEN_BAI_XE"].Caption = "Tên bãi xe";
			this.c1TrueDBGrid1.Columns["CHIEU_DAI"].Caption = "Chiều dài";
			this.c1TrueDBGrid1.Columns["CHIEU_RONG"].Caption = "Chiều rộng";
			this.c1TrueDBGrid1.Columns["SO_DAY"].Caption = "Số dãy";
			this.c1TrueDBGrid1.Columns["SO_XE_TOI_DA"].Caption = "Số xe tối đa";
			this.c1TrueDBGrid1.Columns["ACTIVE"].Caption = "Trạng thái";
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["TEN_BAI_XE"].Width = 210;
		}
		private void butSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.conn.Open();
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
				this.c1TrueDBGrid1.UpdateData();
				this.da.Update(this.ds.Tables["BAI_XE"]);
				this.conn.Close();
				MessageBox.Show("Đã lưu dữ liệu thành công", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void butExit_Click(object sender, EventArgs e)
		{
			try
			{
				base.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void cmbTypeView_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = this.cmbTypeView.SelectedItem.ToString();
			if (text != null)
			{
				if (!(text == "Normal"))
				{
					if (!(text == "Inverted"))
					{
						if (!(text == "Form"))
						{
							if (!(text == "GroupBy"))
							{
								if (text == "MultipleLines")
								{
									this.c1TrueDBGrid1.DataView = DataViewEnum.MultipleLines;
								}
							}
							else
							{
								this.c1TrueDBGrid1.DataView = DataViewEnum.GroupBy;
							}
						}
						else
						{
							this.c1TrueDBGrid1.DataView = DataViewEnum.Form;
						}
					}
					else
					{
						this.c1TrueDBGrid1.DataView = DataViewEnum.Inverted;
					}
				}
				else
				{
					this.c1TrueDBGrid1.DataView = DataViewEnum.Normal;
				}
			}
		}
	}
}
