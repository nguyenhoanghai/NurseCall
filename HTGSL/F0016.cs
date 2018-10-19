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
	public class F0016 : Form
	{
		private IContainer components = null;
		private Button butSave;
		private GroupBox groupBox1;
		private C1TrueDBGrid c1TrueDBGrid1;
		private TextBox txtPath;
		private Label label1;
		private Button butUpdatePath;
		private SqlConnection conn;
		private DataSet ds;
		private SqlDataAdapter da;
		private string strSQL = "";
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(F0016));
			this.butSave = new Button();
			this.groupBox1 = new GroupBox();
			this.c1TrueDBGrid1 = new C1TrueDBGrid();
			this.txtPath = new TextBox();
			this.label1 = new Label();
			this.butUpdatePath = new Button();
			((ISupportInitialize)this.c1TrueDBGrid1).BeginInit();
			base.SuspendLayout();
			this.butSave.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.butSave.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.butSave.Image = (Image)componentResourceManager.GetObject("butSave.Image");
			this.butSave.ImageAlign = ContentAlignment.MiddleLeft;
			this.butSave.ImeMode = ImeMode.NoControl;
			this.butSave.Location = new Point(611, 415);
			this.butSave.Name = "butSave";
			this.butSave.Size = new Size(101, 28);
			this.butSave.TabIndex = 26;
			this.butSave.Text = "      &Lưu dữ liệu";
			this.butSave.UseVisualStyleBackColor = true;
			this.butSave.Click += new EventHandler(this.butSave_Click);
			this.groupBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(12, 395);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(700, 9);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.c1TrueDBGrid1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
			this.c1TrueDBGrid1.Images.Add((Image)componentResourceManager.GetObject("c1TrueDBGrid1.Images"));
			this.c1TrueDBGrid1.Location = new Point(12, 12);
			this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.PreviewInfo.Location = new Point(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.Size = new Size(0, 0);
			this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0;
			this.c1TrueDBGrid1.PrintInfo.PageSettings = (PageSettings)componentResourceManager.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings");
			this.c1TrueDBGrid1.Size = new Size(700, 381);
			this.c1TrueDBGrid1.TabIndex = 24;
			this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
			this.c1TrueDBGrid1.DoubleClick += new EventHandler(this.c1TrueDBGrid1_DoubleClick);
			this.c1TrueDBGrid1.OnAddNew += new EventHandler(this.c1TrueDBGrid1_OnAddNew);
			this.c1TrueDBGrid1.PropBag = componentResourceManager.GetString("c1TrueDBGrid1.PropBag");
			this.txtPath.AcceptsReturn = true;
			this.txtPath.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.txtPath.Location = new Point(82, 415);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new Size(404, 21);
			this.txtPath.TabIndex = 27;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 417);
			this.label1.Name = "label1";
			this.label1.Size = new Size(63, 13);
			this.label1.TabIndex = 28;
			this.label1.Text = "Đường dẫn:";
			this.butUpdatePath.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.butUpdatePath.Location = new Point(500, 415);
			this.butUpdatePath.Name = "butUpdatePath";
			this.butUpdatePath.Size = new Size(105, 28);
			this.butUpdatePath.TabIndex = 29;
			this.butUpdatePath.Text = "Cập nhật âm thanh";
			this.butUpdatePath.UseVisualStyleBackColor = true;
			this.butUpdatePath.Click += new EventHandler(this.butUpdatePath_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(725, 453);
			base.Controls.Add(this.butUpdatePath);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.txtPath);
			base.Controls.Add(this.butSave);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.c1TrueDBGrid1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "F0016";
			this.Text = "F0016 - Âm thanh";
			base.Load += new EventHandler(this.F0016_Load);
			((ISupportInitialize)this.c1TrueDBGrid1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public F0016()
		{
			this.InitializeComponent();
		}
		private void F0016_Load(object sender, EventArgs e)
		{
			try
			{
				this.LoadData();
				this.TrueDBGridFormat();
				this.c1TrueDBGrid1.Focus();
				string executablePath = Application.ExecutablePath;
				this.txtPath.Text = executablePath.Substring(0, executablePath.LastIndexOf("\\")) + "\\sounds";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private void LoadData()
		{
			this.conn = new SqlConnection(clsDatabase.gstrcnn);
			this.conn.Open();
			this.ds = new DataSet();
			this.strSQL = "SELECT [sound_id],[sound_code],[sound_path],[active]  FROM  [dbo].[SOUNDS]";
			this.da = new SqlDataAdapter(this.strSQL, this.conn);
			this.da.Fill(this.ds, "sounds");
			this.c1TrueDBGrid1.DataSource = this.ds.Tables["sounds"];
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
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["sound_id"].Visible = false;
			this.c1TrueDBGrid1.Columns["sound_code"].Caption = "Mã âm thanh";
			this.c1TrueDBGrid1.Columns["sound_path"].Caption = "File âm thanh";
			this.c1TrueDBGrid1.Columns["active"].Caption = "Thạng thái";
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["sound_code"].Width = 120;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["sound_code"].Frozen = true;
			this.c1TrueDBGrid1.Splits[0].DisplayColumns["sound_path"].Width = 435;
			this.CountFooterMaster();
		}
		private void CountFooterMaster()
		{
			this.c1TrueDBGrid1.Columns["sound_code"].FooterText = this.c1TrueDBGrid1.RowCount.ToString();
		}
		private void butSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.conn.Open();
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
				this.c1TrueDBGrid1.UpdateData();
				this.da.Update(this.ds.Tables["sounds"]);
				this.conn.Close();
				MessageBox.Show("Đã lưu dữ liệu thành công", "Th¤ng bÀo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
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
		private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Application.StartupPath + "\\sounds";
			openFileDialog.DefaultExt = "wav";
			openFileDialog.Filter = "Wave|*.wav";
			openFileDialog.ShowDialog();
			if (openFileDialog.FileName.Length > 0)
			{
				this.c1TrueDBGrid1.Columns["sound_path"].Value = openFileDialog.FileName;
				this.c1TrueDBGrid1.Columns["sound_code"].Value = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.Length - 4);
			}
		}
		private void butUpdatePath_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.c1TrueDBGrid1.RowCount; i++)
			{
				string text = this.c1TrueDBGrid1.Columns["sound_path"].Value.ToString();
				int startIndex = text.LastIndexOf("\\") + 1;
				string str = text.Substring(startIndex, text.Length - text.LastIndexOf("\\") - 1);
				this.c1TrueDBGrid1.Columns["sound_path"].Value = this.txtPath.Text + "\\" + str;
				this.c1TrueDBGrid1.MoveNext();
			}
		}
	}
}
