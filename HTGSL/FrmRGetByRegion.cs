using HTGSL.Models;
//using HTGSL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace HTGSL
{
    public partial class FrmRGetByRegion : Form
    {
        private DataProvider provider = new DataProvider();
        private SqlConnection conn;
        private string strConnString;
        private string strConnStringDefault = "data source=Localhost;initial catalog=ErrorSystem;integrated security=SSPI;";
     
        public FrmRGetByRegion()
        {
            InitializeComponent();
        }

        private void FrmRGetByRegion_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
              
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
                this.c1Combo1.ValueMember = "region_id";
                this.c1Combo1.DisplayMember = "region_name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void LoadCaptionForControls()
        {
            this.Text =   Properties.Resources.CallbyRegion;
            this.okButton.Text = Properties.Resources.OK;
           // this.btnReport.Text = Properties.Resources.repo;
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

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                #region Create View

                conn = new SqlConnection(strConnString == "" ? strConnStringDefault : strConnString);//DataProvider.ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("sp_call_detail_view_hai", this.conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = this.dateTimePicker1.Value;
                sqlCommand.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = this.dateTimePicker2.Value;
                sqlCommand.Parameters.Add("@iRegionID", SqlDbType.Int).Value = int.Parse(this.c1Combo1.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();

                SqlDataReader rdr = sqlCommand.ExecuteReader();
                if (rdr.HasRows)
                {
                    fmGview.Visible = true;
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Load(rdr);
                    List<ReportModel> models = new List<ReportModel>();
                    if (dt.Rows.Count > 0)
                    {
                        ReportModel obj;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            obj = new ReportModel();
                            obj.Date = dt.Rows[i]["transaction_date"].ToString();
                            obj.Shift = dt.Rows[i]["shift_name"].ToString();
                            obj.Area = dt.Rows[i]["region_note"].ToString();
                            obj.Room = dt.Rows[i]["room_note"].ToString();
                            obj.Bed = dt.Rows[i]["bed_note"].ToString();
                            obj.User = dt.Rows[i]["user"].ToString();
                            obj.Start = dt.Rows[i]["start_call"].ToString();
                            obj.End = dt.Rows[i]["end_call"].ToString();
                            obj.ProcessTime = dt.Rows[i]["time_interval"].ToString();
                            models.Add(obj);
                        }
                    }
                    //   MessageBox.Show(dt.ToString());
                    fmGview.DataSource = models;
                }
                rdr.Close();
                // Excute Query
                // cmd.ExecuteNonQuery();

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "okButton_Click");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                if (conn.State == ConnectionState.Open) conn.Close();
                //   this.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                string templatePath = System.Windows.Forms.Application.StartupPath + @"\Reports\DtoD.xlsx";
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook; 
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Open(templatePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlBook.CheckCompatibility = false;
                xlBook.DoNotPromptForConvert = true;
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;

                xlSheet.Cells[1, 1] = "DANH SÁCH CÁC CUỘC GỌI THEO KHU VỰC " + c1Combo1.SelectedText.ToUpper() ;
                if (dateTimePicker1.Value == null && dateTimePicker2.Value != null)
                    xlSheet.Cells[2, 2] = "Từ  ?  Đến  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy");
                else if (dateTimePicker1.Value != null && dateTimePicker2.Value == null)
                    xlSheet.Cells[2, 2] = "Từ  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy") + "  Đến  ? ";
                else
                    xlSheet.Cells[2, 2] = "Từ  " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "  Đến  " +  dateTimePicker2.Value.ToString("dd/MM/yyyy");

                int row = 5;
                int cell = 1;

                for (int i = 0; i < fmGview.Rows.Count; i++)
                {
                    for (int j = 0; j < fmGview.Columns.Count; j++)
                    {
                        xlSheet.Cells[row, cell] = fmGview.Rows[i].Cells[j].Value.ToString();
                        cell++;
                    }
                    cell = 1;
                    row++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xlBook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
