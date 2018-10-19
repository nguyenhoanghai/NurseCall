using  Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace HTGSL
{
	public class Form13 : Form
	{
		public MySqlDataClass TheSqlData;
		private int iJobID = 0;
		private string strJobName;
		private JobArray Jobs = new JobArray();
		private int iItem = -1;
		private IContainer components = null;
		private Panel panel1;
		private Label listOfJobsLabel;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ListView listView1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem newJobToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem modifyJobToolStripMenuItem;
		private ToolStripMenuItem deleteJobToolStripMenuItem;
		private ToolStripMenuItem jobPropertiesToolStripMenuItem;
		private ImageList imageList1;
		private ToolStripSeparator toolStripSeparator2;
		public Form13()
		{
			this.InitializeComponent();
		}
		private void Form13_Load(object sender, EventArgs e)
		{
			this.LoadCaptionForControls();
			this.InitColumnsHeaderForListView(this.listView1);
			this.Jobs = this.TheSqlData.ReaderJobs();
			this.ShowJobsForListView(this.listView1, this.Jobs);
		}
		private void LoadCaptionForControls()
		{
			this.Text = "F13 - " + Properties.Resources.Jobs;
			this.listOfJobsLabel.Text = Properties.Resources.ListOfJobs + ":";
			this.newJobToolStripMenuItem.Text = Properties.Resources.NewJob + "...";
			this.modifyJobToolStripMenuItem.Text = Properties.Resources.ModifyJob + "...";
			this.deleteJobToolStripMenuItem.Text = Properties.Resources.DeleteJob;
			this.jobPropertiesToolStripMenuItem.Text = Properties.Resources.JobProperties + "...";
		}
		private void InitColumnsHeaderForListView(ListView lv)
		{
			lv.Columns.Add(new ColHeader(Properties.Resources.JobID, 100, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.JobName, 200, HorizontalAlignment.Left, true));
			lv.Columns.Add(new ColHeader(Properties.Resources.Note, 250, HorizontalAlignment.Left, true));
		}
		private void ShowJobsForListView(ListView lv, JobArray Js)
		{
			lv.Items.Clear();
			if (Js != null)
			{
				for (int i = 0; i < Js.Count; i++)
				{
					JobInfo jobInfo = Js[i];
					ListViewItem listViewItem = new ListViewItem(new string[]
					{
						jobInfo.iJobID.ToString(),
						jobInfo.strJobName,
						jobInfo.strNote
					}, 0);
					listViewItem.Tag = jobInfo.iJobID.ToString("0000");
					lv.Items.Add(listViewItem);
				}
				this.toolStripStatusLabel1.Text = string.Concat(new string[]
				{
					Properties.Resources.Total,
					": ",
					Js.Count.ToString(),
					" ",
					Properties.Resources.Job_s_,
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
					this.iJobID = int.Parse(itemAt.Tag.ToString());
					this.strJobName = itemAt.SubItems[1].Text;
				}
				this.newJobToolStripMenuItem.Enabled = true;
				this.modifyJobToolStripMenuItem.Enabled = (itemAt != null);
				this.jobPropertiesToolStripMenuItem.Enabled = (itemAt != null);
				this.deleteJobToolStripMenuItem.Enabled = (itemAt != null);
				this.contextMenuStrip1.Show(this.listView1, e.X, e.Y);
			}
		}
		private void newJobToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			bool flag2 = true;
			int maxValueJobID = this.TheSqlData.GetMaxValueJobID();
			if (maxValueJobID != -1)
			{
				int num = maxValueJobID + 1;
				string text = "";
				string text2 = "";
				while (!flag && flag2)
				{
					Form14 form = new Form14();
					form.bModify = false;
					form.The_iJobID = num;
					form.The_strJobName = text;
					form.The_strNote = text2;
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						num = form.The_iJobID;
						text = form.The_strJobName;
						text2 = form.The_strNote;
						if (!this.TheSqlData.IsExistJobID(num))
						{
							if (this.TheSqlData.InsertJobInfo(num, text, text2))
							{
								this.Jobs = this.TheSqlData.ReaderJobs();
								this.ShowJobsForListView(this.listView1, this.Jobs);
								this.SetListViewItemSelectFocus(this.listView1, this.listView1.Items.Count - 1);
								flag = true;
							}
							else
							{
								MessageBox.Show(string.Concat(new string[]
								{
									Properties.Resources.Insert,
									Properties.Resources.JobInfo,
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
								Properties.Resources.InfoOfJob,
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
		private void modifyJobToolStripMenuItem_Click(object sender, EventArgs e)
		{
			JobInfo jobInfo = this.TheSqlData.ReaderJobInfo(this.iJobID);
			if (jobInfo != null)
			{
				int num = this.iJobID;
				string the_strJobName = jobInfo.strJobName;
				string text = jobInfo.strNote;
				Form14 form = new Form14();
				form.bModify = true;
				form.The_iJobID = num;
				form.The_strJobName = the_strJobName;
				form.The_strNote = text;
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					the_strJobName = form.The_strJobName;
					text = form.The_strNote;
					if (this.TheSqlData.UpdateJobInfo(num, the_strJobName, text))
					{
						this.Jobs = this.TheSqlData.ReaderJobs();
						this.ShowJobsForListView(this.listView1, this.Jobs);
						this.SetListViewItemSelectFocus(this.listView1, this.iItem);
					}
					else
					{
						MessageBox.Show(string.Concat(new string[]
						{
							Properties.Resources.Update,
							" ",
							Properties.Resources.JobInfo,
							" ",
							Properties.Resources.Failure,
							"!"
						}));
					}
				}
			}
		}
		private void deleteJobToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = this.iJobID;
			string text = this.strJobName;
			DialogResult dialogResult = MessageBox.Show(string.Concat(new string[]
			{
				Properties.Resources.DoYouWantTo,
				" ",
				Properties.Resources.Delete,
				" ",
				Properties.Resources.JobInfo,
				": ",
				this.iJobID.ToString(),
				". ",
				this.strJobName,
				"?"
			}), Properties.Resources.DeleteJob, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.OK)
			{
				if (this.TheSqlData.DeleteJobInfo(this.iJobID))
				{
					this.Jobs = this.TheSqlData.ReaderJobs();
					this.ShowJobsForListView(this.listView1, this.Jobs);
					this.SetListViewItemSelectFocus(this.listView1, (this.listView1.Items.Count > this.iItem) ? this.iItem : (this.iItem - 1));
				}
				else
				{
					MessageBox.Show(string.Concat(new string[]
					{
						Properties.Resources.DeleteU,
						" ",
						Properties.Resources.JobInfo,
						" ",
						Properties.Resources.Failure,
						"!"
					}));
				}
			}
		}
		private void jobPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form13));
			this.panel1 = new Panel();
			this.listOfJobsLabel = new Label();
			this.statusStrip1 = new StatusStrip();
			this.toolStripStatusLabel1 = new ToolStripStatusLabel();
			this.listView1 = new ListView();
			this.imageList1 = new ImageList(this.components);
			this.contextMenuStrip1 = new ContextMenuStrip(this.components);
			this.newJobToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.modifyJobToolStripMenuItem = new ToolStripMenuItem();
			this.deleteJobToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.jobPropertiesToolStripMenuItem = new ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.listOfJobsLabel);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(554, 23);
			this.panel1.TabIndex = 15;
			this.listOfJobsLabel.AutoSize = true;
			this.listOfJobsLabel.Location = new Point(8, 6);
			this.listOfJobsLabel.Name = "listOfJobsLabel";
			this.listOfJobsLabel.Size = new Size(65, 13);
			this.listOfJobsLabel.TabIndex = 0;
			this.listOfJobsLabel.Text = "List of Jobs:";
			this.statusStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripStatusLabel1
			});
			this.statusStrip1.Location = new Point(0, 259);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(554, 22);
			this.statusStrip1.TabIndex = 16;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new Size(79, 17);
			this.toolStripStatusLabel1.Text = "Total: 0 job(s)";
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
				this.newJobToolStripMenuItem,
				this.toolStripSeparator1,
				this.modifyJobToolStripMenuItem,
				this.deleteJobToolStripMenuItem,
				this.toolStripSeparator2,
				this.jobPropertiesToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(158, 104);
			this.newJobToolStripMenuItem.Name = "newJobToolStripMenuItem";
			this.newJobToolStripMenuItem.Size = new Size(157, 22);
			this.newJobToolStripMenuItem.Text = "New Job...";
			this.newJobToolStripMenuItem.Click += new EventHandler(this.newJobToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(154, 6);
			this.modifyJobToolStripMenuItem.Name = "modifyJobToolStripMenuItem";
			this.modifyJobToolStripMenuItem.Size = new Size(157, 22);
			this.modifyJobToolStripMenuItem.Text = "Modify Job...";
			this.modifyJobToolStripMenuItem.Click += new EventHandler(this.modifyJobToolStripMenuItem_Click);
			this.deleteJobToolStripMenuItem.Name = "deleteJobToolStripMenuItem";
			this.deleteJobToolStripMenuItem.Size = new Size(157, 22);
			this.deleteJobToolStripMenuItem.Text = "Delete Job";
			this.deleteJobToolStripMenuItem.Click += new EventHandler(this.deleteJobToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(154, 6);
			this.jobPropertiesToolStripMenuItem.Name = "jobPropertiesToolStripMenuItem";
			this.jobPropertiesToolStripMenuItem.Size = new Size(157, 22);
			this.jobPropertiesToolStripMenuItem.Text = "Job Properties...";
			this.jobPropertiesToolStripMenuItem.Click += new EventHandler(this.jobPropertiesToolStripMenuItem_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(554, 281);
			base.Controls.Add(this.listView1);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.panel1);
			this.Font = new Font("Tahoma", 8.25f);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MinimizeBox = false;
			base.Name = "Form13";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "F13 - Jobs";
			base.Load += new EventHandler(this.Form13_Load);
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
