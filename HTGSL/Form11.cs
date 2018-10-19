using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form11 : Form
	{
		private IContainer components = null;
		private Panel panel1;
		private Label listOfDepartmentsLabel;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ListView listView1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem newDepartmentToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem modifyDepartmentToolStripMenuItem;
		private ToolStripMenuItem deleteDepartmentToolStripMenuItem;
		private ToolStripMenuItem departmentPropertiesToolStripMenuItem;
		private ImageList imageList1;
		private ToolStripSeparator toolStripSeparator2;
		public MySqlDataClass TheSqlData;
		private int iDepartmentID = 0;
		private string strDepartmentName;
		private DepartmentArray Departments = new DepartmentArray();
		private int iItem = -1;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form11));
			this.panel1 = new Panel();
			this.listOfDepartmentsLabel = new Label();
			this.statusStrip1 = new StatusStrip();
			this.toolStripStatusLabel1 = new ToolStripStatusLabel();
			this.listView1 = new ListView();
			this.imageList1 = new ImageList(this.components);
			this.contextMenuStrip1 = new ContextMenuStrip(this.components);
			this.newDepartmentToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.modifyDepartmentToolStripMenuItem = new ToolStripMenuItem();
			this.deleteDepartmentToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.departmentPropertiesToolStripMenuItem = new ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.listOfDepartmentsLabel);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(554, 23);
			this.panel1.TabIndex = 15;
			this.listOfDepartmentsLabel.AutoSize = true;
			this.listOfDepartmentsLabel.Location = new Point(8, 6);
			this.listOfDepartmentsLabel.Name = "listOfDepartmentsLabel";
			this.listOfDepartmentsLabel.Size = new Size(105, 13);
			this.listOfDepartmentsLabel.TabIndex = 0;
			this.listOfDepartmentsLabel.Text = "List of Departments:";
			this.statusStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripStatusLabel1
			});
			this.statusStrip1.Location = new Point(0, 259);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(554, 22);
			this.statusStrip1.TabIndex = 16;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new Size(124, 17);
			this.toolStripStatusLabel1.Text = "Total: 0 department(s)";
			this.listView1.Dock = DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new Point(0, 23);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new Size(554, 236);
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
				this.newDepartmentToolStripMenuItem,
				this.toolStripSeparator1,
				this.modifyDepartmentToolStripMenuItem,
				this.deleteDepartmentToolStripMenuItem,
				this.toolStripSeparator2,
				this.departmentPropertiesToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(203, 104);
			this.newDepartmentToolStripMenuItem.Name = "newDepartmentToolStripMenuItem";
			this.newDepartmentToolStripMenuItem.Size = new Size(202, 22);
			this.newDepartmentToolStripMenuItem.Text = "New Department...";
			this.newDepartmentToolStripMenuItem.Click += new EventHandler(this.newDepartmentToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(199, 6);
			this.modifyDepartmentToolStripMenuItem.Name = "modifyDepartmentToolStripMenuItem";
			this.modifyDepartmentToolStripMenuItem.Size = new Size(202, 22);
			this.modifyDepartmentToolStripMenuItem.Text = "Modify Department...";
			this.modifyDepartmentToolStripMenuItem.Click += new EventHandler(this.modifyDepartmentToolStripMenuItem_Click);
			this.deleteDepartmentToolStripMenuItem.Name = "deleteDepartmentToolStripMenuItem";
			this.deleteDepartmentToolStripMenuItem.Size = new Size(202, 22);
			this.deleteDepartmentToolStripMenuItem.Text = "Delete Department";
			this.deleteDepartmentToolStripMenuItem.Click += new EventHandler(this.deleteDepartmentToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(199, 6);
			this.departmentPropertiesToolStripMenuItem.Name = "departmentPropertiesToolStripMenuItem";
			this.departmentPropertiesToolStripMenuItem.Size = new Size(202, 22);
			this.departmentPropertiesToolStripMenuItem.Text = "Department Properties...";
			this.departmentPropertiesToolStripMenuItem.Click += new EventHandler(this.departmentPropertiesToolStripMenuItem_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(554, 281);
			base.Controls.Add(this.listView1);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.panel1);
			this.Font = new Font("Tahoma", 8.25f);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MinimizeBox = false;
			base.Name = "Form11";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F11 - Departments";
			base.Load += new EventHandler(this.Form11_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public Form11()
		{
			this.InitializeComponent();
		}
		private void Form11_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.InitColumnsHeaderForListView(this.listView1);
			this.Departments = this.TheSqlData.ReaderDepartments();
			this.ShowDepartmentsForListView(this.listView1, this.Departments);
		}
		private void LoadCaptionForControls()
		{
			this.Text = "F11 - " + Properties.Resources.Departments;
			this.listOfDepartmentsLabel.Text = Properties.Resources.ListOfDepartments + ":";
			this.newDepartmentToolStripMenuItem.Text = Properties.Resources.NewDepartment + "...";
			this.modifyDepartmentToolStripMenuItem.Text = Properties.Resources.ModifyDepartment + "...";
			this.deleteDepartmentToolStripMenuItem.Text = Properties.Resources.DeleteDepartment;
			this.departmentPropertiesToolStripMenuItem.Text = Properties.Resources.DepartmentProperties + "...";
		}
		private void InitColumnsHeaderForListView(ListView lv)
		{
			lv.Columns.Add(new ColHeader(Properties.Resources.DepartmentID, 100, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.DepartmentName, 200, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Note, 250, HorizontalAlignment.Left, true));
		}
		private void ShowDepartmentsForListView(ListView lv, DepartmentArray Ds)
		{
			if (Ds != null)
			{
				lv.Items.Clear();
				for (int i = 0; i < Ds.Count; i++)
				{
					DepartmentInfo departmentInfo = Ds[i];
					ListViewItem listViewItem = new ListViewItem(new string[]
					{
						departmentInfo.iDepartmentID.ToString(),
						departmentInfo.strDepartmentName,
						departmentInfo.strNote
					}, 0);
					listViewItem.Tag = departmentInfo.iDepartmentID.ToString("0000");
					lv.Items.Add(listViewItem);
				}
				this.toolStripStatusLabel1.Text = string.Concat(new string[]
				{
					Properties.Resources.Total,
					": ",
					Ds.Count.ToString(),
					" ",
					Properties.Resources.Department_s_,
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
					this.iDepartmentID = int.Parse(itemAt.Tag.ToString());
					this.strDepartmentName = itemAt.SubItems[1].Text;
				}
				this.newDepartmentToolStripMenuItem.Enabled = true;
				this.modifyDepartmentToolStripMenuItem.Enabled = (itemAt != null);
				this.departmentPropertiesToolStripMenuItem.Enabled = (itemAt != null);
				this.deleteDepartmentToolStripMenuItem.Enabled = (itemAt != null);
				this.contextMenuStrip1.Show(this.listView1, e.X, e.Y);
			}
		}
		private void newDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			bool flag2 = true;
			int maxValueDepartmentID = this.TheSqlData.GetMaxValueDepartmentID();
			if (maxValueDepartmentID != -1)
			{
				int num = maxValueDepartmentID + 1;
				string text = "";
				string text2 = "";
				while (!flag && flag2)
				{
					Form12 form = new Form12();
					form.bModify = false;
					form.The_iDepartmentID = num;
					form.The_strDepartmentName = text;
					form.The_strNote = text2;
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						num = form.The_iDepartmentID;
						text = form.The_strDepartmentName;
						text2 = form.The_strNote;
						if (!this.TheSqlData.IsExistDepartmentID(num))
						{
							if (this.TheSqlData.InsertDepartmentInfo(num, text, text2))
							{
								this.Departments = this.TheSqlData.ReaderDepartments();
								this.ShowDepartmentsForListView(this.listView1, this.Departments);
								this.SetListViewItemSelectFocus(this.listView1, this.listView1.Items.Count - 1);
								flag = true;
							}
							else
							{
								MessageBox.Show(string.Concat(new string[]
								{
									Properties.Resources.Insert,
									Properties.Resources.DepartmentInfo,
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
								Properties.Resources.InfoOfDepartment,
								": ",
								num.ToString(),
								". ",
								text,
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
		private void modifyDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DepartmentInfo departmentInfo = this.TheSqlData.ReaderDepartmentInfo(this.iDepartmentID);
			if (departmentInfo != null)
			{
				int num = this.iDepartmentID;
				string the_strDepartmentName = departmentInfo.strDepartmentName;
				string text = departmentInfo.strNote;
				Form12 form = new Form12();
				form.bModify = true;
				form.The_iDepartmentID = num;
				form.The_strDepartmentName = the_strDepartmentName;
				form.The_strNote = text;
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					the_strDepartmentName = form.The_strDepartmentName;
					text = form.The_strNote;
					if (this.TheSqlData.UpdateDepartmentInfo(num, the_strDepartmentName, text))
					{
						this.Departments = this.TheSqlData.ReaderDepartments();
						this.ShowDepartmentsForListView(this.listView1, this.Departments);
						this.SetListViewItemSelectFocus(this.listView1, this.iItem);
					}
					else
					{
						MessageBox.Show(string.Concat(new string[]
						{
							Properties.Resources.Update,
							" ",
							Properties.Resources.DepartmentInfo,
							" ",
							Properties.Resources.Failure,
							"!"
						}));
					}
				}
			}
		}
		private void deleteDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = this.iDepartmentID;
			string text = this.strDepartmentName;
			DialogResult dialogResult = MessageBox.Show(string.Concat(new string[]
			{
				Properties.Resources.DoYouWantTo,
				" ",
				Properties.Resources.Delete,
				" ",
				Properties.Resources.DepartmentInfo,
				": ",
				this.iDepartmentID.ToString(),
				". ",
				this.strDepartmentName,
				"?"
			}), Properties.Resources.DeleteDepartment, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.OK)
			{
				if (this.TheSqlData.DeleteDepartmentInfo(this.iDepartmentID))
				{
					this.Departments = this.TheSqlData.ReaderDepartments();
					this.ShowDepartmentsForListView(this.listView1, this.Departments);
					this.SetListViewItemSelectFocus(this.listView1, (this.listView1.Items.Count > this.iItem) ? this.iItem : (this.iItem - 1));
				}
				else
				{
					MessageBox.Show(string.Concat(new string[]
					{
						Properties.Resources.DeleteU,
						" ",
						Properties.Resources.DepartmentInfo,
						" ",
						Properties.Resources.Failure,
						"!"
					}));
				}
			}
		}
		private void departmentPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}
	}
}
