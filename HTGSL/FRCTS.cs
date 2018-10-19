using C1.C1Report;
using C1.Win.C1List;
using C1.Win.C1Preview;
using  Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
	public class FRCTS : Form
	{
		private DataProvider provider = new DataProvider();
		private SqlConnection conn;
		private string strConnString;
		private string strConnStringDefault = "data source=Localhost;initial catalog=ErrorSystem;integrated security=SSPI;";
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
		public FRCTS()
		{
			this.InitializeComponent();
		}
		private void FRCBT_Load(object sender, EventArgs e)
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
				string sqlString = "SELECT [SHIFT_ID],[SHIFT_NAME] FROM  [dbo].[SHIFTS]";
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
			this.c1Combo1.ValueMember = "SHIFT_ID";
			this.c1Combo1.DisplayMember = "SHIFT_NAME";
			this.c1Combo1.DropDownWidth = 250;
			this.c1Combo1.DropMode = DropModeEnum.Manual;
			this.c1Combo1.RowDivider.Color = Color.DarkGray;
			this.c1Combo1.RowDivider.Style = LineStyleEnum.Single;
			this.c1Combo1.Splits[0].DisplayColumns["SHIFT_ID"].Width = 80;
			this.c1Combo1.Splits[0].DisplayColumns["SHIFT_NAME"].Width = 140;
			this.c1Combo1.Columns["SHIFT_ID"].Caption = "Mã ca";
			this.c1Combo1.Columns["SHIFT_NAME"].Caption = "Tên ca";
			this.c1Combo1.AutoCompletion = true;
			this.c1Combo1.AutoDropDown = true;
			this.c1Combo1.AutoSelect = true;
			this.c1Combo1.LimitToList = true;
		}
		private void LoadCaptionForControls()
		{
			this.Text = Resources.CallbyShift;
			this.okButton.Text = Resources.OK;
			this.cancelButton.Text = Resources.Cancel;
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
				SqlCommand sqlCommand = new SqlCommand("sp_call_by_shift", this.conn);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = this.dateTimePicker1.Value;
				sqlCommand.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = this.dateTimePicker2.Value;
				sqlCommand.Parameters.Add("@iShiftID", SqlDbType.Int).Value = int.Parse(this.c1Combo1.SelectedValue.ToString());
				sqlCommand.ExecuteNonQuery();
				string fileName = Application.StartupPath + "\\Reports\\CallbyShift.xml";
				this.c1Report1.Load(fileName, "CallbyShift");
				this.c1Report1.DataSource.ConnectionString = this.GetStringConnectFull();
				this.c1Report1.DataSource.RecordSource = "v_call_by_shift";
				if (this.dateTimePicker1.Value.ToString("dd/MM/yyyy") != this.dateTimePicker2.Value.ToString("dd/MM/yyyy"))
				{
					this.c1Report1.Fields["DateFromTo"].Text = "Từ ngày: " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " đến ngày: " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy");
				}
				else
				{
					this.c1Report1.Fields["DateFromTo"].Text = "Ngày: " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy");
				}
				using (C1PrintPreviewDialog c1PrintPreviewDialog = new C1PrintPreviewDialog())
				{
					c1PrintPreviewDialog.Document = this.c1Report1;
					c1PrintPreviewDialog.PrintPreviewControl.PreviewNavigationPanel.Visible = false;
					c1PrintPreviewDialog.PrintPreviewControl.ToolBars.File.Open.Visible = false;
					c1PrintPreviewDialog.PrintPreviewControl.ToolBars.File.Save.Visible = true;
					c1PrintPreviewDialog.Text = Resources.CallbyTime;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FRCTS));
			this.cancelButton = new Button();
			this.okButton = new Button();
			this.dateTimePicker1 = new DateTimePicker();
			this.dateTimePicker2 = new DateTimePicker();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.c1Report1 = new C1Report();
			this.c1Combo1 = new C1Combo();
			((ISupportInitialize)this.c1Report1).BeginInit();
			((ISupportInitialize)this.c1Combo1).BeginInit();
			base.SuspendLayout();
			this.cancelButton.DialogResult = DialogResult.Cancel;
			this.cancelButton.Location = new Point(159, 108);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new Size(95, 25);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
			this.okButton.Location = new Point(58, 108);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(95, 25);
			this.okButton.TabIndex = 8;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new EventHandler(this.okButton_Click);
			this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new Point(103, 13);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new Size(159, 21);
			this.dateTimePicker1.TabIndex = 10;
			this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new Point(103, 45);
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
			this.label2.Location = new Point(13, 45);
			this.label2.Name = "label2";
			this.label2.Size = new Size(62, 15);
			this.label2.TabIndex = 12;
			this.label2.Text = "Đến ngày:";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(13, 76);
			this.label3.Name = "label3";
			this.label3.Size = new Size(70, 15);
			this.label3.TabIndex = 13;
			this.label3.Text = "Ca làm việc";
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
			this.c1Combo1.Location = new Point(103, 76);
			this.c1Combo1.MatchEntryTimeout = 2000L;
			this.c1Combo1.MaxDropDownItems = 5;
			this.c1Combo1.MaxLength = 32767;
			this.c1Combo1.MouseCursor = Cursors.Default;
			this.c1Combo1.Name = "c1Combo1";
			this.c1Combo1.RowSubDividerColor = Color.DarkGray;
			this.c1Combo1.Size = new Size(159, 21);
			this.c1Combo1.TabIndex = 14;
			this.c1Combo1.PropBag = componentResourceManager.GetString("c1Combo1.PropBag");
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(289, 141);
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
			base.Name = "FRCTS";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "FRCTS";
			base.Load += new EventHandler(this.FRCBT_Load);
			((ISupportInitialize)this.c1Report1).EndInit();
			((ISupportInitialize)this.c1Combo1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
