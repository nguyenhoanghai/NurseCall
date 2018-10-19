using HTGSL.Models;
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
    public partial class FrmRDateToDate : Form
    {
        public FrmRDateToDate()
        {
            InitializeComponent();
        }

        private SqlConnection conn;
        private string strConnString;
        private string strConnStringDefault = "data source=Localhost;initial catalog=NurseCall;integrated security=SSPI;";


        private void FrmRDateToDate_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.CallbyTime; 
            this.okButton.Text = Properties.Resources.OK;
            this.cancelButton.Text = Properties.Resources.Cancel;
            this.btnsave.Text = Properties.Resources.Export;
            strConnString = GetStringConnect();
        }

        private string GetStringConnect()
        {
            try
            {
                // Nạp tài liệu.
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Windows.Forms.Application.StartupPath + "\\DATA.XML");

                // Thu lấy tất cả các kết nối.
                XmlNodeList sqlserver = doc.GetElementsByTagName("SQLServer");
                string sServer_Name = "";
                string sDatabase = "";
                string sUser_ID = "";
                string sPwd = "";

                //foreach (XmlNode node in sqlserver)
                //{
                //    sServer_Name = node.ChildNodes[0].InnerText;
                //    sDatabase = node.ChildNodes[1].InnerText;
                //    sUser_ID = node.ChildNodes[2].InnerText;
                //    sPwd = node.ChildNodes[3].InnerText;
                //}

                sServer_Name = sqlserver.Item(0).ChildNodes[0].InnerText;
                sDatabase = sqlserver.Item(0).ChildNodes[1].InnerText;
                sUser_ID = sqlserver.Item(0).ChildNodes[2].InnerText;
                sPwd = sqlserver.Item(0).ChildNodes[3].InnerText;

                // Gan bien toàn cục
                //gstrServerName = sServer_Name;
                //gstrDatabase = sDatabase;
                //gstrUserID = sUser_ID;
                //gstrPassword = sPwd;
                return "Server=" + sServer_Name + ";Database=" + sDatabase + ";uid=" + sUser_ID + ";pwd=" + sPwd;

            }
            catch (Exception)
            {
                return "";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

                SqlCommand cmd = new SqlCommand("hai_test", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Set Parameters            
                cmd.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = dateTimePicker2.Value;

                SqlDataReader rdr = cmd.ExecuteReader();
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string templatePath = System.Windows.Forms.Application.StartupPath + @"\Reports\DtoD.xlsx";
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                Excel.Range oRng;
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

                if (dateTimePicker1.Value == null && dateTimePicker2.Value != null)
                    xlSheet.Cells[2, 2] = "Từ  ?  Đến  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy");
                else if (dateTimePicker1.Value != null && dateTimePicker2.Value == null)
                    xlSheet.Cells[2, 2] = "Từ  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy") + "  Đến  ? ";
                else
                    xlSheet.Cells[2, 2] = "Từ  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy") + "  Đến  " + Convert.ToDateTime(dateTimePicker2.Value).ToString("dd/MM/yyyy");

                int row = 5;
                int cell = 1;

                for (int i = 0; i < fmGview.Rows.Count  ; i++)
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
