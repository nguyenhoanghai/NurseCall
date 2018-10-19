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
    public partial class FrmRShift : Form
    { 

        DataProvider provider = new DataProvider();
        private SqlConnection conn;
        private string strConnString;
        private string strConnStringDefault = "data source=Localhost;initial catalog=NurseCall;integrated security=SSPI;";

        public FrmRShift()
        {
            InitializeComponent();
        }

        private void FrmRShift_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.CallbyShift;
            //this.departmentInfoGroupBox.Text = Properties.Resources.DepartmentInfo;
            //this.departmentLabel.Text = Properties.Resources.Department + ":";
            //this.noteLabel.Text = Properties.Resources.Note + ":";
            this.okButton.Text = Properties.Resources.OK;
            this.btnexport.Text = Properties.Resources.Export;
            strConnString = GetStringConnect();
            LoadData();
            FormatCombobox();
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

                sServer_Name = sqlserver.Item(0).ChildNodes[0].InnerText;
                sDatabase = sqlserver.Item(0).ChildNodes[1].InnerText;
                sUser_ID = sqlserver.Item(0).ChildNodes[2].InnerText;
                sPwd = sqlserver.Item(0).ChildNodes[3].InnerText;
                return "Server=" + sServer_Name + ";Database=" + sDatabase + ";uid=" + sUser_ID + ";pwd=" + sPwd;

            }
            catch (Exception)
            {
                return "";
            }
        }

        private void LoadData()
        {
            try
            {
                #region Combobox
                string strSQL = "SELECT [SHIFT_ID],[SHIFT_NAME] FROM   [dbo].[SHIFTS]";
                this.c1Combo1.DataSource = provider.execute(strSQL).Tables[0];//ds.Tables["LOAI_XE"];
                #endregion

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void FormatCombobox()
        {
            #region Shift
            //this.c1Combo1.AlternatingRows = true;
            //this.c1Combo1.ExtendRightColumn = false;
            //this.c1Combo1.EvenRowStyle.BackColor = Color.FromArgb(240, 248, 255);

            //this.c1Combo1.HeadingStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            //this.c1Combo1.HeadingStyle.ForeColor = Color.FromArgb(0, 64, 128);
            //this.c1Combo1.Font = new Font("Arial", 10, FontStyle.Regular);
            //this.c1Combo1.Height = 250; //bằng số (row + 2) * 15 - 3/4
            //this.c1Combo1.ItemHeight = 20;
            //this.c1Combo1.ColumnCaptionHeight = 20;

             this.c1Combo1.ValueMember = "SHIFT_ID";
            this.c1Combo1.DisplayMember = "SHIFT_NAME";

            //this.c1Combo1.DropDownWidth = 250; //collums + 30
            //this.c1Combo1.DropMode = C1.Win.C1List.DropModeEnum.Manual;
            ////this.cmbBaiXe.DroppedDown = false;

            //// Grid's color
            //this.c1Combo1.RowDivider.Color = Color.DarkGray;
            //this.c1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.Single;

            ////Hide Columns       
            ////this.cmbBaiXe.Splits[0].DisplayColumns["PRINT_BARCODE"].Visible = false;
            ////this.cmbBaiXe.Splits[0].DisplayColumns["TEN_LOAI_XE"].Visible = false;

            //// Width
            //this.c1Combo1.Splits[0].DisplayColumns["SHIFT_ID"].Width = 80;
            //this.c1Combo1.Splits[0].DisplayColumns["SHIFT_NAME"].Width = 140;

            //// Set Caption
            //this.c1Combo1.Columns["SHIFT_ID"].Caption = "Mã ca";
            //this.c1Combo1.Columns["SHIFT_NAME"].Caption = "Tên ca";

            //this.c1Combo1.AutoCompletion = true;
            //this.c1Combo1.AutoDropDown = true;
            //this.c1Combo1.AutoSelect = true;

            ////prevent MisMatch
            //this.c1Combo1.LimitToList = true;
            ////this.cmbBaiXe.AutoCompletion = true;
            ////this.cmbBaiXe.SuperBack = true;
            #endregion
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

                SqlCommand cmd = new SqlCommand("sp_call_by_shift_h", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Set Parameters            
                cmd.Parameters.Add("@dTimeFrom", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@dTimeTo", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                cmd.Parameters.Add("@iShiftID", SqlDbType.Int).Value = int.Parse(this.c1Combo1.SelectedValue.ToString());

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

        private void btnexport_Click(object sender, EventArgs e)
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
                xlSheet.Cells[1, 1] = "DANH SÁCH CÁC CUỘC GỌI CA " + this.c1Combo1.Text;
                if (dateTimePicker1.Value == null && dateTimePicker2.Value != null)
                    xlSheet.Cells[2, 2] = "Từ  ?  Đến  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy");
                else if (dateTimePicker1.Value != null && dateTimePicker2.Value == null)
                    xlSheet.Cells[2, 2] = "Từ  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy") + "  Đến  ? ";
                else
                    xlSheet.Cells[2, 2] = "Từ  " + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy") + "  Đến  " + Convert.ToDateTime(dateTimePicker2.Value).ToString("dd/MM/yyyy");

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
