using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form10 : Form
	{
		public MySqlDataClass TheSqlData;
		private int iEmployeeID = 0;
		private string strEmployeeName;
		private EmployeeArray Employees = new EmployeeArray();
		private int iItem = -1;
		private IContainer components = null;
		private Panel panel1;
		private Label listOfEmployeesLabel;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ListView listView1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem newEmployeeToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem modifyEmployeeToolStripMenuItem;
		private ToolStripMenuItem deleteEmployeeToolStripMenuItem;
		private ToolStripMenuItem employeePropertiesToolStripMenuItem;
		private ImageList imageList1;
		private ToolStripSeparator toolStripSeparator2;
		public Form10()
		{
			this.InitializeComponent();
		}
		private void Form10_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.InitColumnsHeaderForListView(this.listView1);
			this.Employees = this.TheSqlData.ReaderEmployees();
			this.ShowEmployeesForListView(this.listView1, this.Employees);
		}
		private void LoadCaptionForControls()
		{
			this.Text = Properties.Resources.EmployeesManager;
			this.listOfEmployeesLabel.Text = Properties.Resources.ListOfEmployees + ":";
			this.newEmployeeToolStripMenuItem.Text = Properties.Resources.NewEmployee + "...";
			this.modifyEmployeeToolStripMenuItem.Text = Properties.Resources.ModifyEmployee + "...";
			this.deleteEmployeeToolStripMenuItem.Text = Properties.Resources.DeleteEmployee;
			this.employeePropertiesToolStripMenuItem.Text = Properties.Resources.EmployeeProperties + "...";
		}
		private void InitColumnsHeaderForListView(ListView lv)
		{
			lv.Columns.Add(new ColHeader(Properties.Resources.EmpID, 70, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.EmployeeName, 140, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Gender, 55, HorizontalAlignment.Center, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.BirthDate, 70, HorizontalAlignment.Center, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Title, 90, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Department, 120, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Job, 120, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.HireDate, 70, HorizontalAlignment.Center, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Address, 150, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.City, 100, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Phone, 100, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Note, 160, HorizontalAlignment.Left, true));
		}
		private void ShowEmployeesForListView(ListView lv, EmployeeArray Es)
		{
			if (Es != null)
			{
				lv.Items.Clear();
				for (int i = 0; i < Es.Count; i++)
				{
					EmployeeInfo employeeInfo = Es[i];
					ListViewItem listViewItem = new ListViewItem(new string[]
					{
						employeeInfo.iEmployeeID.ToString(),
						employeeInfo.strFirstName.Trim() + " " + employeeInfo.strLastName.Trim(),
						employeeInfo.bMenOrWomen ? Properties.Resources.Men : Properties.Resources.Women,
						employeeInfo.dtBirthDate.ToString("dd/MM/yyyy"),
						employeeInfo.strTitle,
						employeeInfo.strDepartmentName,
						employeeInfo.strJobName,
						employeeInfo.dtHireDate.ToString("dd/MM/yyyy"),
						employeeInfo.strAddress,
						employeeInfo.strCity,
						employeeInfo.strPhone,
						employeeInfo.strNote
					}, 0);
					listViewItem.Tag = employeeInfo.iEmployeeID.ToString("0000");
					lv.Items.Add(listViewItem);
				}
				this.toolStripStatusLabel1.Text = string.Concat(new string[]
				{
					Properties.Resources.Total,
					": ",
					Es.Count.ToString(),
					" ",
					Properties.Resources.Employee_s_,
					"."
				});
			}
		}
		private void SetListViewItemSelectFocus(ListView lv, int iItem)
		{
			if (iItem > -1 && iItem < lv.Items.Count)
			{
				lv.Items[iItem].Selected = true;
				lv.Items[iItem].EnsureVisible();
				lv.Focus();
			}
		}
		private void listView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ListViewItem itemAt = this.listView1.GetItemAt(e.X, e.Y);
				if (itemAt != null)
				{
					this.iItem = itemAt.Index;
					this.iEmployeeID = int.Parse(itemAt.Tag.ToString());
					this.strEmployeeName = itemAt.SubItems[1].Text;
				}
				this.newEmployeeToolStripMenuItem.Enabled = true;
				this.modifyEmployeeToolStripMenuItem.Enabled = (itemAt != null);
				this.employeePropertiesToolStripMenuItem.Enabled = (itemAt != null);
				this.deleteEmployeeToolStripMenuItem.Enabled = (itemAt != null);
				this.contextMenuStrip1.Show(this.listView1, e.X, e.Y);
			}
		}
		private void newEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			bool flag2 = true;
			int maxValueEmployeeID = this.TheSqlData.GetMaxValueEmployeeID();
			if (maxValueEmployeeID != -1)
			{
				int num = maxValueEmployeeID + 1;
				string text = "";
				string text2 = "";
				bool flag3 = false;
				DateTime the_dtBirthDate = new DateTime(1900, 1, 1);
				string text3 = "";
				DepartmentArray departmentArray = this.TheSqlData.ReaderDepartments();
				if (departmentArray.Count != 0)
				{
					string[] array = new string[departmentArray.Count];
					for (int i = 0; i < departmentArray.Count; i++)
					{
						array[i] = departmentArray[i].strDepartmentName;
					}
					int[] array2 = new int[departmentArray.Count];
					for (int i = 0; i < departmentArray.Count; i++)
					{
						array2[i] = departmentArray[i].iDepartmentID;
					}
					JobArray jobArray = this.TheSqlData.ReaderJobs();
					if (jobArray.Count != 0)
					{
						string[] array3 = new string[jobArray.Count];
						for (int i = 0; i < jobArray.Count; i++)
						{
							array3[i] = jobArray[i].strJobName;
						}
						int[] array4 = new int[jobArray.Count];
						for (int i = 0; i < jobArray.Count; i++)
						{
							array4[i] = jobArray[i].iJobID;
						}
						int num2 = 0;
						string the_strDepartmentName = "";
						int num3 = 0;
						string the_strJobName = "";
						DateTime the_dtHireDate = new DateTime(1900, 1, 1);
						string text4 = "";
						string text5 = "";
						string text6 = "";
						string text7 = "";
						while (!flag && flag2)
						{
							Form9 form = new Form9();
							form.bModify = false;
							form.The_DepartmentNames = array;
							form.The_DepartmentIDs = array2;
							form.The_JobNames = array3;
							form.The_JobIDs = array4;
							form.The_iEmployeeID = num;
							form.The_strFirstName = text;
							form.The_strLastName = text2;
							form.The_bMenOrWomen = flag3;
							form.The_dtBirthDate = the_dtBirthDate;
							form.The_strTitle = text3;
							form.The_iDepartmentID = num2;
							form.The_strDepartmentName = the_strDepartmentName;
							form.The_iJobID = num3;
							form.The_strJobName = the_strJobName;
							form.The_dtHireDate = the_dtHireDate;
							form.The_strAddress = text4;
							form.The_strCity = text5;
							form.The_strPhone = text6;
							form.The_strNote = text7;
							if (form.ShowDialog(this) == DialogResult.OK)
							{
								num = form.The_iEmployeeID;
								text = form.The_strFirstName;
								text2 = form.The_strLastName;
								flag3 = form.The_bMenOrWomen;
								the_dtBirthDate = form.The_dtBirthDate;
								text3 = form.The_strTitle;
								num2 = form.The_iDepartmentID;
								the_strDepartmentName = form.The_strDepartmentName;
								the_strJobName = form.The_strJobName;
								num3 = form.The_iJobID;
								the_dtHireDate = form.The_dtHireDate;
								text4 = form.The_strAddress;
								text5 = form.The_strCity;
								text6 = form.The_strPhone;
								text7 = form.The_strNote;
								if (!this.TheSqlData.IsExistEmployeeID(num))
								{
									if (this.TheSqlData.InsertEmployeeInfo(num, text, text2, flag3, the_dtBirthDate, text3, num2, num3, the_dtHireDate, text4, text5, text6, text7))
									{
										this.Employees = this.TheSqlData.ReaderEmployees();
										this.ShowEmployeesForListView(this.listView1, this.Employees);
										this.SetListViewItemSelectFocus(this.listView1, this.listView1.Items.Count - 1);
										flag = true;
									}
									else
									{
										MessageBox.Show(string.Concat(new string[]
										{
											Properties.Resources.Insert,
											Properties.Resources.EmployeeInfo,
											" ",
											Properties.Resources.Failure,
											"!"
										}));
									}
								}
								else
								{
									MyMsgBox.MsgError(string.Concat(new string[]
									{
										Properties.Resources.InfoOfEmployee,
										": ",
										num.ToString(),
										". ",
										text,
										" ",
										text2,
										" ",
										Properties.Resources.IsExisted,
										"!"
									}));
								}
							}
							else
							{
								flag2 = false;
							}
						}
					}
				}
			}
		}
		private void modifyEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EmployeeInfo employeeInfo = this.TheSqlData.ReaderEmployeeInfo(this.iEmployeeID);
			if (employeeInfo != null)
			{
				int num = this.iEmployeeID;
				string text = employeeInfo.strFirstName;
				string text2 = employeeInfo.strLastName;
				bool flag = employeeInfo.bMenOrWomen;
				DateTime dateTime = employeeInfo.dtBirthDate;
				string text3 = employeeInfo.strTitle;
				DepartmentArray departmentArray = this.TheSqlData.ReaderDepartments();
				if (departmentArray.Count != 0)
				{
					string[] array = new string[departmentArray.Count];
					for (int i = 0; i < departmentArray.Count; i++)
					{
						array[i] = departmentArray[i].strDepartmentName;
					}
					int[] array2 = new int[departmentArray.Count];
					for (int i = 0; i < departmentArray.Count; i++)
					{
						array2[i] = departmentArray[i].iDepartmentID;
					}
					JobArray jobArray = this.TheSqlData.ReaderJobs();
					if (jobArray.Count != 0)
					{
						string[] array3 = new string[jobArray.Count];
						for (int i = 0; i < jobArray.Count; i++)
						{
							array3[i] = jobArray[i].strJobName;
						}
						int[] array4 = new int[jobArray.Count];
						for (int i = 0; i < jobArray.Count; i++)
						{
							array4[i] = jobArray[i].iJobID;
						}
						int num2 = employeeInfo.iDepartmentID;
						string strDepartmentName = employeeInfo.strDepartmentName;
						int num3 = employeeInfo.iDepartmentID;
						string strJobName = employeeInfo.strJobName;
						DateTime dateTime2 = employeeInfo.dtHireDate;
						string text4 = employeeInfo.strAddress;
						string text5 = employeeInfo.strCity;
						string text6 = employeeInfo.strPhone;
						string text7 = employeeInfo.strNote;
						Form9 form = new Form9();
						form.bModify = true;
						form.The_DepartmentNames = array;
						form.The_DepartmentIDs = array2;
						form.The_JobNames = array3;
						form.The_JobIDs = array4;
						form.The_iEmployeeID = num;
						form.The_strFirstName = text;
						form.The_strLastName = text2;
						form.The_bMenOrWomen = flag;
						form.The_dtBirthDate = dateTime;
						form.The_strTitle = text3;
						form.The_iDepartmentID = num2;
						form.The_strDepartmentName = strDepartmentName;
						form.The_iJobID = num3;
						form.The_strJobName = strJobName;
						form.The_dtHireDate = dateTime2;
						form.The_strAddress = text4;
						form.The_strCity = text5;
						form.The_strPhone = text6;
						form.The_strNote = text7;
						if (form.ShowDialog(this) == DialogResult.OK)
						{
							text = form.The_strFirstName;
							text2 = form.The_strLastName;
							flag = form.The_bMenOrWomen;
							dateTime = form.The_dtBirthDate;
							text3 = form.The_strTitle;
							num2 = form.The_iDepartmentID;
							num3 = form.The_iJobID;
							dateTime2 = form.The_dtHireDate;
							text4 = form.The_strAddress;
							text5 = form.The_strCity;
							text6 = form.The_strPhone;
							text7 = form.The_strNote;
							if (this.TheSqlData.UpdateEmployeeInfo(num, text, text2, flag, dateTime, text3, num2, num3, dateTime2, text4, text5, text6, text7))
							{
								this.Employees = this.TheSqlData.ReaderEmployees();
								this.ShowEmployeesForListView(this.listView1, this.Employees);
								this.SetListViewItemSelectFocus(this.listView1, this.iItem);
							}
							else
							{
								MessageBox.Show(string.Concat(new string[]
								{
									Properties.Resources.Update,
									" ",
									Properties.Resources.EmployeeInfo,
									" ",
									Properties.Resources.Failure,
									"!"
								}));
							}
						}
					}
				}
			}
		}
		private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = this.iEmployeeID;
			string text = this.strEmployeeName;
			DialogResult dialogResult = MessageBox.Show(string.Concat(new string[]
			{
				Properties.Resources.DoYouWantTo,
				" ",
				Properties.Resources.Delete,
				" ",
				Properties.Resources.EmployeeInfo,
				": ",
				this.iEmployeeID.ToString(),
				". ",
				this.strEmployeeName,
				"?"
			}), Properties.Resources.DeleteEmployee, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.OK)
			{
				if (this.TheSqlData.DeleteEmployeeInfo(this.iEmployeeID))
				{
					this.Employees = this.TheSqlData.ReaderEmployees();
					this.ShowEmployeesForListView(this.listView1, this.Employees);
					this.SetListViewItemSelectFocus(this.listView1, (this.listView1.Items.Count > this.iItem) ? this.iItem : (this.iItem - 1));
				}
				else
				{
					MessageBox.Show(string.Concat(new string[]
					{
						Properties.Resources.DeleteU,
						" ",
						Properties.Resources.EmployeeInfo,
						" ",
						Properties.Resources.Failure,
						"!"
					}));
				}
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
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form10));
			this.panel1 = new Panel();
			this.listOfEmployeesLabel = new Label();
			this.statusStrip1 = new StatusStrip();
			this.toolStripStatusLabel1 = new ToolStripStatusLabel();
			this.listView1 = new ListView();
			this.imageList1 = new ImageList(this.components);
			this.contextMenuStrip1 = new ContextMenuStrip(this.components);
			this.newEmployeeToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.modifyEmployeeToolStripMenuItem = new ToolStripMenuItem();
			this.deleteEmployeeToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.employeePropertiesToolStripMenuItem = new ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.listOfEmployeesLabel);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(531, 23);
			this.panel1.TabIndex = 15;
			this.listOfEmployeesLabel.AutoSize = true;
			this.listOfEmployeesLabel.Location = new Point(8, 6);
			this.listOfEmployeesLabel.Name = "listOfEmployeesLabel";
			this.listOfEmployeesLabel.Size = new Size(94, 13);
			this.listOfEmployeesLabel.TabIndex = 0;
			this.listOfEmployeesLabel.Text = "List of Employees:";
			this.statusStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripStatusLabel1
			});
			this.statusStrip1.Location = new Point(0, 259);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(531, 22);
			this.statusStrip1.TabIndex = 16;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new Size(114, 17);
			this.toolStripStatusLabel1.Text = "Total: 0 employee(s)";
			this.listView1.Dock = DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new Point(0, 23);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new Size(531, 236);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 17;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = View.Details;
			this.listView1.MouseDown += new MouseEventHandler(this.listView1_MouseDown);
			this.imageList1.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = Color.Fuchsia;
			this.imageList1.Images.SetKeyName(0, "CheckMixed.bmp");
			this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.newEmployeeToolStripMenuItem,
				this.toolStripSeparator1,
				this.modifyEmployeeToolStripMenuItem,
				this.deleteEmployeeToolStripMenuItem,
				this.toolStripSeparator2,
				this.employeePropertiesToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(192, 104);
			this.newEmployeeToolStripMenuItem.Name = "newEmployeeToolStripMenuItem";
			this.newEmployeeToolStripMenuItem.Size = new Size(191, 22);
			this.newEmployeeToolStripMenuItem.Text = "New Employee...";
			this.newEmployeeToolStripMenuItem.Click += new EventHandler(this.newEmployeeToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(188, 6);
			this.modifyEmployeeToolStripMenuItem.Name = "modifyEmployeeToolStripMenuItem";
			this.modifyEmployeeToolStripMenuItem.Size = new Size(191, 22);
			this.modifyEmployeeToolStripMenuItem.Text = "Modify Employee...";
			this.modifyEmployeeToolStripMenuItem.Click += new EventHandler(this.modifyEmployeeToolStripMenuItem_Click);
			this.deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
			this.deleteEmployeeToolStripMenuItem.Size = new Size(191, 22);
			this.deleteEmployeeToolStripMenuItem.Text = "Delete Employee";
			this.deleteEmployeeToolStripMenuItem.Click += new EventHandler(this.deleteEmployeeToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(188, 6);
			this.employeePropertiesToolStripMenuItem.Name = "employeePropertiesToolStripMenuItem";
			this.employeePropertiesToolStripMenuItem.Size = new Size(191, 22);
			this.employeePropertiesToolStripMenuItem.Text = "Employee Properties...";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(531, 281);
			base.Controls.Add(this.listView1);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.panel1);
			this.Font = new Font("Tahoma", 8.25f);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MinimizeBox = false;
			base.Name = "Form10";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Employees Manager";
			base.Load += new EventHandler(this.Form10_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
