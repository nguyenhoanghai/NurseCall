using C1.C1Report;
using C1.Win.C1List;
using C1.Win.C1Preview;
//using HTGSL.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
    public class FRCTR : Form
    {
        private IContainer components = null;
        private Button cancelButton;
        private Button okButton;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private Label label3;
        private C1Report c1Report1;
        private C1Combo c1Combo1;
        private TextBox txtTGCT;
        private TextBox txtDonGia;
        private Label label4;
        private Label label5;
        private DataProvider provider = new DataProvider();
        private SqlConnection conn;
        private string strConnString;
        private string strConnStringDefault = "data source=Localhost;initial catalog=ErrorSystem;integrated security=SSPI;";
        private C1Report c1Report_sub;
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FRCTR));
            this.cancelButton = new Button();
            this.okButton = new Button();
            this.dateTimePicker1 = new DateTimePicker();
            this.dateTimePicker2 = new DateTimePicker();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.c1Report1 = new C1Report();
            this.c1Combo1 = new C1Combo();
            this.txtTGCT = new TextBox();
            this.txtDonGia = new TextBox();
            this.label4 = new Label();
            this.label5 = new Label();
            ((ISupportInitialize)this.c1Report1).BeginInit();
            ((ISupportInitialize)this.c1Combo1).BeginInit();
            base.SuspendLayout();
            this.cancelButton.DialogResult = DialogResult.Cancel;
            this.cancelButton.Location = new Point(159, 163);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(95, 25);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
            this.okButton.Location = new Point(58, 163);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(95, 25);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new EventHandler(this.okButton_Click);
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new Point(120, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(159, 21);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new Point(120, 43);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(159, 21);
            this.dateTimePicker2.TabIndex = 11;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Từ ngày:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new Size(62, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Đến ngày:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new Size(50, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Khu vực";
            this.c1Report1.ReportDefinition = componentResourceManager.GetString("c1Report1.ReportDefinition");
            this.c1Report1.ReportName = "c1Report1";
            this.c1Combo1.AddItemSeparator = ';';
            this.c1Combo1.Caption = "";
            this.c1Combo1.CaptionHeight = 17;
            this.c1Combo1.CharacterCasing = CharacterCasing.Normal;
            this.c1Combo1.ColumnCaptionHeight = 17;
            this.c1Combo1.ColumnFooterHeight = 17;
            this.c1Combo1.ContentHeight = 15;
            this.c1Combo1.DeadAreaBackColor = Color.Empty;
            this.c1Combo1.EditorBackColor = SystemColors.Window;
            this.c1Combo1.EditorFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.c1Combo1.EditorForeColor = SystemColors.WindowText;
            this.c1Combo1.EditorHeight = 15;
            this.c1Combo1.Images.Add((Image)componentResourceManager.GetObject("c1Combo1.Images"));
            this.c1Combo1.ItemHeight = 15;
            this.c1Combo1.Location = new Point(120, 73);
            this.c1Combo1.MatchEntryTimeout = 2000L;
            this.c1Combo1.MaxDropDownItems = 5;
            this.c1Combo1.MaxLength = 32767;
            this.c1Combo1.MouseCursor = Cursors.Default;
            this.c1Combo1.Name = "c1Combo1";
            this.c1Combo1.RowSubDividerColor = Color.DarkGray;
            this.c1Combo1.Size = new Size(159, 21);
            this.c1Combo1.TabIndex = 14;
            this.c1Combo1.PropBag = componentResourceManager.GetString("c1Combo1.PropBag");
            this.txtTGCT.Location = new Point(120, 103);
            this.txtTGCT.Name = "txtTGCT";
            this.txtTGCT.Size = new Size(159, 20);
            this.txtTGCT.TabIndex = 15;
            this.txtDonGia.Location = new Point(119, 132);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new Size(159, 20);
            this.txtDonGia.TabIndex = 16;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(13, 103);
            this.label4.Name = "label4";
            this.label4.Size = new Size(101, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Thời gian chế tạo";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(13, 133);
            this.label5.Name = "label5";
            this.label5.Size = new Size(50, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Đơn giá";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(306, 197);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.txtDonGia);
            base.Controls.Add(this.txtTGCT);
            base.Controls.Add(this.c1Combo1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.dateTimePicker2);
            base.Controls.Add(this.dateTimePicker1);
            base.Controls.Add(this.cancelButton);
            base.Controls.Add(this.okButton);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FRCTR";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "FRCBR";
            base.Load += new EventHandler(this.FRCTR_Load);
            ((ISupportInitialize)this.c1Report1).EndInit();
            ((ISupportInitialize)this.c1Combo1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
        public FRCTR()
        {
            this.InitializeComponent();
        }
        private void FRCTR_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
                this.FormatCombobox();
                this.LoadCaptionForControls();
                this.strConnString = this.GetStringConnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void LoadData()
        {
            try
            {
                string sqlString = "SELECT 0 as [region_id], N'Tất cả' as [region_name] UNION SELECT [region_id],[region_name] FROM  [dbo].[REGIONS]";
                this.c1Combo1.DataSource = this.provider.execute(sqlString).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void FormatCombobox()
        {
            this.c1Combo1.AlternatingRows = true;
            this.c1Combo1.ExtendRightColumn = false;
            this.c1Combo1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);
            this.c1Combo1.HeadingStyle.Font = new Font("Arial", 10f, FontStyle.Regular);
            this.c1Combo1.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
            this.c1Combo1.Font = new Font("Arial", 10f, FontStyle.Regular);
            this.c1Combo1.Height = 250;
            this.c1Combo1.ItemHeight = 20;
            this.c1Combo1.ColumnCaptionHeight = 20;
            this.c1Combo1.ValueMember = "region_id";
            this.c1Combo1.DisplayMember = "region_name";
            this.c1Combo1.DropDownWidth = 250;
            this.c1Combo1.DropMode = DropModeEnum.Manual;
            this.c1Combo1.RowDivider.Color = Color.DarkGray;
            this.c1Combo1.RowDivider.Style = LineStyleEnum.Single;
            this.c1Combo1.Splits[0].DisplayColumns["region_id"].Width = 80;
            this.c1Combo1.Splits[0].DisplayColumns["region_name"].Width = 140;
            this.c1Combo1.Columns["region_id"].Caption = "Mã khu vực";
            this.c1Combo1.Columns["region_name"].Caption = "Tên khu vực";
            this.c1Combo1.AutoCompletion = true;
            this.c1Combo1.AutoDropDown = true;
            this.c1Combo1.AutoSelect = true;
            this.c1Combo1.LimitToList = true;
        }
        private void LoadCaptionForControls()
        {
            this.Text = "RCTR - " + Properties.Resources.CallbyRegion;
            this.okButton.Text = Properties.Resources.OK;
            this.cancelButton.Text = Properties.Resources.Cancel;
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.conn = new SqlConnection((this.strConnString == "") ? this.strConnStringDefault : this.strConnString);
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("sp_call_detail_view", this.conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = this.dateTimePicker1.Value;
                sqlCommand.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = this.dateTimePicker2.Value;
                sqlCommand.Parameters.Add("@iRegionID", SqlDbType.Int).Value = int.Parse(this.c1Combo1.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();
                string fileName = Application.StartupPath + "\\Reports\\ErrorsbyRegion.xml";
                this.c1Report1.Load(fileName, "ErrorsbyRegion");
                this.c1Report1.DataSource.ConnectionString = this.GetStringConnectFull();
                this.c1Report1.DataSource.RecordSource = "v_call_detail_view";
                this.c1Report1.Fields["Field6"].Subreport.DataSource.ConnectionString = this.GetStringConnectFull();
                this.c1Report1.Fields["Field6"].Subreport.DataSource.RecordSource = "v_call_detail_view";
                if (this.dateTimePicker1.Value.ToString("dd/MM/yyyy") != this.dateTimePicker2.Value.ToString("dd/MM/yyyy"))
                    this.c1Report1.Fields["DateFromTo"].Text = "Từ ngày: " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " đến ngày: " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy");
                else
                    this.c1Report1.Fields["DateFromTo"].Text = "Ngày: " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy");

                using (C1PrintPreviewDialog c1PrintPreviewDialog = new C1PrintPreviewDialog())
                {
                    c1PrintPreviewDialog.Document = this.c1Report1;
                    c1PrintPreviewDialog.PrintPreviewControl.PreviewNavigationPanel.Visible = false;
                    c1PrintPreviewDialog.PrintPreviewControl.ToolBars.File.Open.Visible = false;
                    c1PrintPreviewDialog.PrintPreviewControl.ToolBars.File.Save.Visible = true;
                    c1PrintPreviewDialog.Text = Properties.Resources.CallbyTime;
                    c1PrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "okButton_Click");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
                base.Close();
            }
        }
        private string GetStringConnectFull()
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
					"Provider=SQLOLEDB;Password=",
					innerText4,
					";Persist Security Info=True;User ID=",
					innerText3,
					";Initial Catalog=",
					innerText2,
					";Data Source=",
					innerText
				});
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
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
        private void cancelButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
