using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using HTGSL.Properties;

namespace HTGSL
{
    public partial class FrmConfigManager : Form
    {
        public MySqlDataClass TheSqlData;
        HospitalNodeInfo MyHi = null;
        TreeNode tnMouseDown = null;
        TreeNode tnSelect = null;

        private bool bTVMouseDown = false;
        private int iHospitalID = 1,
            iRegionID = 0,
            iServiceID = 0,
            iRoomID = 0,
            iBedID = 0,
            iLocationID = 0,
            iItem = -1;

        private string strRegionName = "",
                strRoomName = "";

        string strServiceName0 = "",
          strServiceName1 = "";

        public FrmConfigManager()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.LoadCaptionsForControls();
            this.strServiceName0 = this.TheSqlData.GetServiceName(0);
            this.strServiceName1 = this.TheSqlData.GetServiceName(1);
            this.MyHi = this.TheSqlData.ReaderHospitalNode(this.iHospitalID);
            this.LoadHospitalNodeForTreeView(this.MyHi, this.treeView1);
        }

        private void LoadCaptionsForControls()
        {
            this.Text = Properties.Resources.ConfigManager;
            this.hospitalPropertiesToolStripMenuItem.Text = Properties.Resources.HospitalProperties + "...";
            this.newRegionTVToolStripMenuItem.Text = Properties.Resources.NewRegion + "...";
            this.modifyRegionTVToolStripMenuItem.Text = Properties.Resources.ModifyRegion + "...";
            this.deleteRegionTVToolStripMenuItem.Text = Properties.Resources.DeleteRegion;
            this.regionPropertiesTVToolStripMenuItem.Text = Properties.Resources.RegionProperties + "...";

            this.newRoomTVToolStripMenuItem.Text = Properties.Resources.NewRoom + "...";
            this.modifyRoomTVToolStripMenuItem.Text = Properties.Resources.ModifyRoom + "...";
            this.deleteRoomTVToolStripMenuItem.Text = Properties.Resources.DeleteRoom;
            this.roomPropertiesTVToolStripMenuItem.Text = Properties.Resources.RoomProperties + "...";

            this.newBedTVToolStripMenuItem.Text = Properties.Resources.NewBed + "...";
            this.newLocationTVToolStripMenuItem.Text = Properties.Resources.NewLocation + "...";

            this.newRegionLVToolStripMenuItem.Text = Properties.Resources.NewRegion + "...";
            this.modifyRegionLVToolStripMenuItem.Text = Properties.Resources.ModifyRegion + "...";
            this.deleteRegionLVToolStripMenuItem.Text = Properties.Resources.DeleteRegion;
            this.regionPropertiesLVToolStripMenuItem.Text = Properties.Resources.RegionProperties + "...";

            this.newRoomLVToolStripMenuItem.Text = Properties.Resources.NewRoom + "...";
            this.modifyRoomLVToolStripMenuItem.Text = Properties.Resources.ModifyRoom + "...";
            this.deleteRoomLVToolStripMenuItem.Text = Properties.Resources.DeleteRoom;
            this.roomPropertiesLVToolStripMenuItem.Text = Properties.Resources.RoomProperties + "...";

            this.newBedLVToolStripMenuItem.Text = Properties.Resources.NewBed + "...";
            this.modifyBedLVToolStripMenuItem.Text = Properties.Resources.ModifyBed + "...";
            this.deleteBedLVToolStripMenuItem.Text = Properties.Resources.DeleteBed;
            this.bedPropertiesLVToolStripMenuItem.Text = Properties.Resources.BedProperties + "...";

            this.newLocationLVToolStripMenuItem.Text = Properties.Resources.NewLocation + "...";
            this.modifyLocationLVToolStripMenuItem.Text = Properties.Resources.ModifyLocation + "...";
            this.deleteLocationLVToolStripMenuItem.Text = Properties.Resources.DeleteLocation;
            this.locationPropertiesLVToolStripMenuItem.Text = Properties.Resources.LocationProperties + "...";

        }

        #region TreeView
        private void LoadHospitalNodeForTreeView(HospitalNodeInfo hospital, TreeView tv)
        {
            TreeNode tnRoot = null;
            if (hospital == null)
            {
                tnRoot = new TreeNode("No item", 0, 0);
                tnRoot.Tag = "0";
                tnRoot.ForeColor = Color.Silver;
                tv.Nodes.Add(tnRoot);
                return;
            }
            tnRoot = new TreeNode(hospital.strHospitalName, 0, 0);
            tnRoot.Tag = hospital.iHospitalID.ToString();
            tv.Nodes.Add(tnRoot);
            foreach (RegionNodeInfo region in hospital.Regions)
            {
                TreeNode tnRegion = new TreeNode(region.strRegionName, 1, 1);
                tnRegion.Tag = region.iRegionID.ToString();
                tnRoot.Nodes.Add(tnRegion);
                TreeNode tnRooms = new TreeNode(region.rnRooms.strRoomsName, 2, 2);
                tnRooms.Tag = region.rnRooms.iRoomsID.ToString();
                tnRegion.Nodes.Add(tnRooms);
                foreach (RoomNodeInfo room in region.rnRooms.Rooms)
                {
                    TreeNode tnRoom = new TreeNode(room.strRoomName, 3, 3);
                    tnRoom.Tag = room.iRoomID.ToString();
                    tnRooms.Nodes.Add(tnRoom);
                }
            }
            tv.SelectedNode = tnRoot;
            tv.SelectedNode.Expand();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.bTVMouseDown)
                return;
            TreeView tv = (TreeView)sender;
            TreeNode tn = tv.SelectedNode;
            this.tnSelect = tn;
            int iNodeLevel = tn.Level;
            switch (iNodeLevel)
            {
                case 0:
                    this.iHospitalID = Int32.Parse(tn.Tag.ToString());
                    if (this.iHospitalID == 0)
                    {
                        this.titleLabel.Text = "+ " + tn.Text;
                        this.totalLabel.Text = "";
                        break;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    this.titleLabel.Text = "+ " + tn.Text;
                    this.InitColumnsHeaderRegionsForListView(this.listView1);
                    RegionArray Regions = this.TheSqlData.ReaderRegions();
                    this.totalLabel.Text = Regions.Count.ToString() + " " + Properties.Resources.Region_s + ".";
                    this.ShowRegionsForListViewAddRange(this.listView1, Regions);
                    this.Cursor = Cursors.Default;
                    break;
                case 1:
                    this.Cursor = Cursors.WaitCursor;
                    this.InitColumnsHeaderServicesForListView(this.listView1);
                    this.titleLabel.Text = "+ " + tn.Text + " - " + tn.Parent.Text;
                    this.iRegionID = Int32.Parse(tn.Tag.ToString());
                    this.strRegionName = tn.Text;
                    ServiceArray Services = new ServiceArray();
                    ServiceInfo Service0 = this.TheSqlData.ReaderRoomsServiceOfRegion(this.iRegionID);
                    Services.Add(Service0);
                    ServiceInfo Service1 = this.TheSqlData.ReaderLocationsServiceOfRegion(this.iRegionID);
                    Services.Add(Service1);
                    this.totalLabel.Text = Services.Count.ToString() + " " + Properties.Resources.Service_s + ".";
                    this.ShowServicesForListView(this.listView1, Services);
                    this.Cursor = Cursors.Default;
                    break;
                case 2:
                    this.Cursor = Cursors.WaitCursor;
                    this.iRegionID = Int32.Parse(tn.Parent.Tag.ToString());
                    this.strRegionName = tn.Parent.Text;
                    this.iServiceID = Int32.Parse(tn.Tag.ToString());
                    if (this.iServiceID == 0)
                    {
                        this.InitColumnsHeaderRoomsForListView(this.listView1);
                        this.titleLabel.Text = "+ " + tn.Text + " - " + tn.Parent.Text + " - " + tn.Parent.Parent.Text;
                        RoomArray Rooms = this.TheSqlData.ReaderRoomsOfRegion(this.iRegionID);
                        this.totalLabel.Text = Rooms.Count.ToString() + " " + Properties.Resources.Room_s + ".";
                        this.ShowRoomsForListViewAddRange(this.listView1, Rooms);
                    }
                    else
                    {
                        this.InitColumnsHeaderLocationsForListView(this.listView1);
                        this.titleLabel.Text = "+ " + tn.Text + " - " + tn.Parent.Text + " - " + tn.Parent.Parent.Text;
                        LocationArray Locations = this.TheSqlData.ReaderLocationsOfRegion(this.iRegionID);
                        this.totalLabel.Text = Locations.Count.ToString() + " " + Properties.Resources.Location_s + ".";
                        this.ShowLocationsForListViewAddRange(this.listView1, Locations);
                    }
                    this.Cursor = Cursors.Default;
                    break;
                case 3:
                    this.iServiceID = Int32.Parse(tn.Parent.Tag.ToString());
                    if (this.iServiceID == 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.InitColumnsHeaderBedsForListView(this.listView1);
                        this.titleLabel.Text = "+ " + tn.Text + " - " + tn.Parent.Parent.Text + " - " + tn.Parent.Parent.Parent.Text;
                        this.iRegionID = Int32.Parse(tn.Parent.Parent.Tag.ToString());
                        this.strRegionName = tn.Parent.Parent.Text;
                        this.iRoomID = Int32.Parse(tn.Tag.ToString());
                        this.strRoomName = tn.Text;
                        BedArray Beds = this.TheSqlData.ReaderBedsOfRoom(this.iRoomID, this.iRegionID);
                        this.totalLabel.Text = Beds.Count.ToString() + " " + Properties.Resources.Bed_s + ".";
                        this.ShowBedsForListViewAddRange(this.listView1, Beds);
                        this.Cursor = Cursors.Default;
                    }
                    break;
                default:
                    break;
            }

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = (TreeView)sender;
                TreeNode tn = tv.GetNodeAt(e.X, e.Y);
                if (tn != null)
                {
                    int iNodeLevel = tn.Level;
                    switch (iNodeLevel)
                    {
                        case 0:
                            this.tnMouseDown = tn;
                            this.newRegionTVToolStripMenuItem.Enabled = (tn.Tag.ToString() == "1");
                            this.hospitalPropertiesToolStripMenuItem.Enabled = true;
                            this.newRegionTVContextMenuStrip.Show(tv, e.X, e.Y);
                            break;
                        case 1:
                            this.tnMouseDown = tn;
                            this.iRegionID = Int32.Parse(tn.Tag.ToString());
                            this.strRegionName = tn.Text;
                            this.modifyRegionTVToolStripMenuItem.Enabled = true;
                            this.deleteRegionTVToolStripMenuItem.Enabled = true;
                            this.regionPropertiesTVToolStripMenuItem.Enabled = true;
                            this.regionTVContextMenuStrip.Show(tv, e.X, e.Y);
                            break;
                        case 2:
                            this.tnMouseDown = tn;
                            this.iServiceID = Int32.Parse(tn.Tag.ToString());
                            this.iRegionID = Int32.Parse(tn.Parent.Tag.ToString());
                            this.strRegionName = tn.Parent.Text;
                            if (this.iServiceID == 0)
                            {
                                this.newRoomTVToolStripMenuItem.Enabled = true;
                                this.newRoomTVContextMenuStrip.Show(tv, e.X, e.Y);
                            }
                            else
                            {
                                this.newLocationTVToolStripMenuItem.Enabled = true;
                                this.newLocationTVContextMenuStrip.Show(tv, e.X, e.Y);
                            }
                            break;
                        case 3:
                            this.iServiceID = Int32.Parse(tn.Parent.Tag.ToString());
                            if (this.iServiceID == 0)
                            {
                                this.tnMouseDown = tn;
                                this.iRegionID = Int32.Parse(tn.Parent.Parent.Tag.ToString());
                                this.strRegionName = tn.Parent.Parent.Text;
                                this.iRoomID = Int32.Parse(tn.Tag.ToString());
                                this.strRoomName = tn.Text;
                                this.newBedTVToolStripMenuItem.Enabled = true;
                                this.modifyRoomTVToolStripMenuItem.Enabled = true;
                                this.deleteRoomTVToolStripMenuItem.Enabled = true;
                                this.roomPropertiesTVToolStripMenuItem.Enabled = true;
                                this.roomTVContextMenuStrip.Show(tv, e.X, e.Y);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private void InitColumnsHeaderRegionsForListView(ListView lv)
        {
            lv.Columns.Clear();
            lv.Columns.Add(new ColHeader(Properties.Resources.RegionID, 100, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.RegionName, 200, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.TotalOfRooms, 100, HorizontalAlignment.Right, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.TotalOfLocations, 100, HorizontalAlignment.Right, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.Note, 250, HorizontalAlignment.Left, true));
        }
        private void ShowRegionsForListViewAddRange(ListView lv, RegionArray Rs)
        {
            lv.Items.Clear();
            const int iSizeOfBlock = 100;
            int iItemsCount = Rs.Count;
            int iSizeOfBlockLast = iItemsCount % iSizeOfBlock;
            int iNumberOfBlocks = iItemsCount / iSizeOfBlock + (iSizeOfBlockLast == 0 ? 0 : 1);
            for (int i = 0; i < iNumberOfBlocks; i++)
            {
                int iSizeOfBlockI = (i == iNumberOfBlocks - 1 && iSizeOfBlockLast > 0) ? iSizeOfBlockLast : iSizeOfBlock;
                ListViewItem[] lviArray = new ListViewItem[iSizeOfBlockI];
                for (int j = 0; j < iSizeOfBlockI; j++)
                {
                    RegionInfo Ri = Rs[i * iSizeOfBlock + j];
                    lviArray[j] = this.RetListViewItemFromRegionInfo(Ri);
                }
                lv.Items.AddRange(lviArray);
            }
            lv.Focus();
        }
        private ListViewItem RetListViewItemFromRegionInfo(RegionInfo Ri)
        {
            ListViewItem lvi;
            int iImageIndex = 1;
            lvi = new ListViewItem(new string[] {
                Ri.iRegionID.ToString(),
                Ri.strRegionName,
                Ri.iTotalOfRooms.ToString(),
                Ri.iTotalOfLocations.ToString(),
                Ri.strNote}, iImageIndex);
            lvi.Tag = Ri.iRegionID.ToString();
            lvi.ForeColor = Color.Black;
            return lvi;
        }


        private void InitColumnsHeaderServicesForListView(ListView lv)
        {
            lv.Columns.Clear();
            lv.Columns.Add(new ColHeader(Properties.Resources.ServiceID, 100, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.ServiceName, 200, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.Total, 100, HorizontalAlignment.Right, true));
        }
        private void ShowServicesForListView(ListView lv, ServiceArray Ss)
        {
            lv.Items.Clear();
            foreach (ServiceInfo Si in Ss)
            {
                int iImageIndex = Si.iServiceID == 0 ? 2 : 5;
                ListViewItem lvi = new ListViewItem(new string[] { Si.iServiceID.ToString(), Si.strServiceName, Si.iTotal.ToString() },
                    iImageIndex);
                lvi.Tag = Si.iServiceID.ToString();
                lvi.ForeColor = Color.Black;
                lv.Items.Add(lvi);
            }
            lv.Focus();
        }


        private void InitColumnsHeaderRoomsForListView(ListView lv)
        {
            lv.Columns.Clear();
            lv.Columns.Add(new ColHeader(Properties.Resources.RoomID, 100, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.RoomName, 200, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.TotalOfBeds, 100, HorizontalAlignment.Right, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.Note, 250, HorizontalAlignment.Left, true));
        }
        private void ShowRoomsForListViewAddRange(ListView lv, RoomArray Rs)
        {
            lv.Items.Clear();
            const int iSizeOfBlock = 100;
            int iItemsCount = Rs.Count;
            int iSizeOfBlockLast = iItemsCount % iSizeOfBlock;
            int iNumberOfBlocks = iItemsCount / iSizeOfBlock + (iSizeOfBlockLast == 0 ? 0 : 1);
            for (int i = 0; i < iNumberOfBlocks; i++)
            {
                int iSizeOfBlockI = (i == iNumberOfBlocks - 1 && iSizeOfBlockLast > 0) ? iSizeOfBlockLast : iSizeOfBlock;
                ListViewItem[] lviArray = new ListViewItem[iSizeOfBlockI];
                for (int j = 0; j < iSizeOfBlockI; j++)
                {
                    RoomInfo Ri = Rs[i * iSizeOfBlock + j];
                    lviArray[j] = this.RetListViewItemFromRoomInfo(Ri);
                }
                lv.Items.AddRange(lviArray);
            }
            lv.Focus();
        }
        private ListViewItem RetListViewItemFromRoomInfo(RoomInfo Ri)
        {
            ListViewItem lvi;
            int iImageIndex = 3;
            lvi = new ListViewItem(new string[] {
                Ri.iRoomID.ToString(),
                Ri.strRoomName,
                Ri.iTotalOfBeds.ToString(),
                Ri.strNote}, iImageIndex);
            lvi.Tag = Ri.iRoomID.ToString();
            lvi.ForeColor = Color.Black;
            return lvi;
        }


        private void InitColumnsHeaderBedsForListView(ListView lv)
        {
            lv.Columns.Clear();
            lv.Columns.Add(new ColHeader(Properties.Resources.BedID, 120, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.BedName, 200, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.Note, 250, HorizontalAlignment.Left, true));
            //  lv.Columns.Add(new ColHeader(Properties.Resources.Curator, 250, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader("Người phụ trách", 250, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.Install, 100, HorizontalAlignment.Center, true));
        }
        private void ShowBedsForListViewAddRange(ListView lv, BedArray Bs)
        {
            lv.Items.Clear();
            const int iSizeOfBlock = 100;
            int iItemsCount = Bs.Count;
            int iSizeOfBlockLast = iItemsCount % iSizeOfBlock;
            int iNumberOfBlocks = iItemsCount / iSizeOfBlock + (iSizeOfBlockLast == 0 ? 0 : 1);
            for (int i = 0; i < iNumberOfBlocks; i++)
            {
                int iSizeOfBlockI = (i == iNumberOfBlocks - 1 && iSizeOfBlockLast > 0) ? iSizeOfBlockLast : iSizeOfBlock;
                ListViewItem[] lviArray = new ListViewItem[iSizeOfBlockI];
                for (int j = 0; j < iSizeOfBlockI; j++)
                {
                    BedInfo Bi = Bs[i * iSizeOfBlock + j];
                    lviArray[j] = this.RetListViewItemFromBedInfo(Bi);
                }
                lv.Items.AddRange(lviArray);
            }
            lv.Focus();
        }
        private ListViewItem RetListViewItemFromBedInfo(BedInfo Bi)
        {
            ListViewItem lvi;
            int iImageIndex = 4;
            lvi = new ListViewItem(new string[] {
                Bi.iBedID.ToString(),
                Bi.strBedName,
                Bi.strNote,
                Bi.strCurator,
                Bi.bInstall ? "X" : "-"}, iImageIndex);
            lvi.Tag = Bi.iBedID.ToString();
            lvi.ForeColor = Color.Black;
            return lvi;
        }


        private void InitColumnsHeaderLocationsForListView(ListView lv)
        {
            lv.Columns.Clear();
            lv.Columns.Add(new ColHeader(Properties.Resources.LocationID, 75, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.LocationName, 150, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.TypeID, 75, HorizontalAlignment.Right, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.TypeName, 150, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.Note, 175, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader(Properties.Resources.Install, 75, HorizontalAlignment.Center, true));
        }
        private void ShowLocationsForListViewAddRange(ListView lv, LocationArray Ls)
        {
            lv.Items.Clear();
            const int iSizeOfBlock = 100;
            int iItemsCount = Ls.Count;
            int iSizeOfBlockLast = iItemsCount % iSizeOfBlock;
            int iNumberOfBlocks = iItemsCount / iSizeOfBlock + (iSizeOfBlockLast == 0 ? 0 : 1);
            for (int i = 0; i < iNumberOfBlocks; i++)
            {
                int iSizeOfBlockI = (i == iNumberOfBlocks - 1 && iSizeOfBlockLast > 0) ? iSizeOfBlockLast : iSizeOfBlock;
                ListViewItem[] lviArray = new ListViewItem[iSizeOfBlockI];
                for (int j = 0; j < iSizeOfBlockI; j++)
                {
                    LocationInfo Li = Ls[i * iSizeOfBlock + j];
                    lviArray[j] = this.RetListViewItemFromLocationInfo(Li);
                }
                lv.Items.AddRange(lviArray);
            }
            lv.Focus();
        }
        private ListViewItem RetListViewItemFromLocationInfo(LocationInfo Li)
        {
            ListViewItem lvi;
            int iImageIndex = 6;
            lvi = new ListViewItem(new string[] {
                Li.iLocationID.ToString(),
                Li.strLocationName,
                Li.iTypeID.ToString(),
                Li.strTypeName,
                Li.strNote,
                Li.bInstall ? "X" : "-"}, iImageIndex);
            lvi.Tag = Li.iLocationID.ToString();
            lvi.ForeColor = Color.Black;
            return lvi;
        }
        #endregion

        #region ListView
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListView lv = (ListView)sender;
                ListViewItem lvi = lv.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    this.iItem = lvi.Index;
                }
                int iNodeLevel = this.tnSelect.Level;
                switch (iNodeLevel)
                {
                    case 0:
                        if (lvi != null)
                            this.iRegionID = Int32.Parse(lvi.Tag.ToString());
                        this.newRegionLVToolStripMenuItem.Enabled = true;
                        this.modifyRegionLVToolStripMenuItem.Enabled = (lvi != null);
                        this.deleteRegionLVToolStripMenuItem.Enabled = (lvi != null);
                        this.regionPropertiesLVToolStripMenuItem.Enabled = (lvi != null);
                        this.regionLVContextMenuStrip.Show(lv, new Point(e.X, e.Y));
                        break;
                    case 1:
                        break;
                    case 2:
                        this.iRegionID = Int32.Parse(this.tnSelect.Parent.Tag.ToString());
                        this.iServiceID = Int32.Parse(this.tnSelect.Tag.ToString());
                        if (lvi != null)
                        {
                            if (this.iServiceID == 0)
                                this.iRoomID = Int32.Parse(lvi.Tag.ToString());
                            else
                                this.iLocationID = Int32.Parse(lvi.Tag.ToString());
                        }
                        if (this.iServiceID == 0)
                        {
                            this.newRoomLVToolStripMenuItem.Enabled = true;
                            this.modifyRoomLVToolStripMenuItem.Enabled = (lvi != null);
                            this.deleteRoomLVToolStripMenuItem.Enabled = (lvi != null);
                            this.roomPropertiesLVToolStripMenuItem.Enabled = (lvi != null);
                            this.roomLVContextMenuStrip.Show(lv, new Point(e.X, e.Y));
                        }
                        else
                        {
                            this.newLocationLVToolStripMenuItem.Enabled = true;
                            this.modifyLocationLVToolStripMenuItem.Enabled = (lvi != null);
                            this.deleteLocationLVToolStripMenuItem.Enabled = (lvi != null);
                            this.locationPropertiesLVToolStripMenuItem.Enabled = (lvi != null);
                            this.locationLVContextMenuStrip.Show(lv, new Point(e.X, e.Y));
                        }
                        break;
                    case 3:
                        this.iServiceID = Int32.Parse(this.tnSelect.Parent.Tag.ToString());
                        if (this.iServiceID == 0)
                        {
                            this.iRegionID = Int32.Parse(this.tnSelect.Parent.Parent.Tag.ToString());
                            this.iRoomID = Int32.Parse(this.tnSelect.Tag.ToString());
                            if (lvi != null)
                                this.iBedID = Int32.Parse(lvi.Tag.ToString());
                            this.newBedLVToolStripMenuItem.Enabled = true;
                            this.modifyBedLVToolStripMenuItem.Enabled = (lvi != null);
                            this.deleteBedLVToolStripMenuItem.Enabled = (lvi != null);
                            this.bedPropertiesLVToolStripMenuItem.Enabled = (lvi != null);
                            this.bedLVContextMenuStrip.Show(lv, new Point(e.X, e.Y));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem lvi = lv.SelectedItems[0];
            int iNodeLevel = this.tnSelect.Level;
            switch (iNodeLevel)
            {
                case 0:
                    this.Cursor = Cursors.WaitCursor;
                    this.iRegionID = Int32.Parse(lvi.Tag.ToString());
                    this.RegionProperties(this.iRegionID);
                    this.Cursor = Cursors.Default;
                    break;
                case 1:
                    this.Cursor = Cursors.WaitCursor;
                    this.iRegionID = Int32.Parse(this.tnSelect.Tag.ToString());
                    this.iServiceID = Int32.Parse(lvi.Tag.ToString());
                    this.ServiceProperties(this.iServiceID, this.iRegionID);
                    this.Cursor = Cursors.Default;
                    break;
                case 2:
                    this.iRegionID = Int32.Parse(this.tnSelect.Parent.Tag.ToString());
                    this.iServiceID = Int32.Parse(this.tnSelect.Tag.ToString());
                    if (this.iServiceID == 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.iRoomID = Int32.Parse(lvi.Tag.ToString());
                        this.RoomProperties(this.iRoomID, this.iRegionID);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.iLocationID = Int32.Parse(lvi.Tag.ToString());
                        this.LocationProperties(this.iLocationID, this.iRegionID);
                        this.Cursor = Cursors.Default;
                    }
                    break;
                case 3:
                    this.iServiceID = Int32.Parse(tnSelect.Parent.Tag.ToString());
                    if (this.iServiceID == 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.iRegionID = Int32.Parse(tnSelect.Parent.Parent.Tag.ToString());
                        this.iRoomID = Int32.Parse(tnSelect.Tag.ToString());
                        this.iBedID = Int32.Parse(lvi.Tag.ToString());
                        this.BedProperties(this.iBedID, this.iRoomID, this.iRegionID);
                        this.Cursor = Cursors.Default;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RegionProperties(int i_region_id)
        {
            MessageBox.Show(i_region_id.ToString());
        }

        private void ServiceProperties(int i_service_id, int i_region_id)
        {
            MessageBox.Show(i_service_id.ToString() + "\n" + i_region_id.ToString());
        }

        private void RoomProperties(int i_room_id, int i_region_id)
        {
            MessageBox.Show(i_room_id.ToString() + "\n" + i_region_id.ToString());
        }

        private void LocationProperties(int i_location_id, int i_region_id)
        {
            MessageBox.Show(i_location_id.ToString() + "\n" + i_region_id.ToString());
        }

        private void BedProperties(int i_bed_id, int i_room_id, int i_region_id)
        {
            MessageBox.Show(i_bed_id.ToString() + "\n" + i_room_id.ToString() + "\n" + i_region_id.ToString());
        }

        #endregion

        private void splitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            this.totalLabel.Left = e.SplitX + 12;
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            SplitContainer sc = (SplitContainer)sender;
            this.totalLabel.Left = sc.SplitterDistance + 12;
        }

        #region region lv tooltip
        private void newRegionLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bValidRegionID = false;
            bool bContinue = true;

            int iMaxRegionID = this.TheSqlData.GetMaxValueRegionID();
            int iRegionID_ = iMaxRegionID + 1;
            string strRegionName_ = "";
            string strNote_ = "";
            int iTotalOfRooms_ = 0;
            int iTotalOfLocations_ = 0;
            while (!bValidRegionID && bContinue)
            {
                Form4 form4 = new Form4();
                form4.bModify = false;
                form4.The_iRegionID = iRegionID_;
                form4.The_strRegionName = strRegionName_;
                form4.The_strNote = strNote_;
                if (form4.ShowDialog(this) == DialogResult.OK)
                {
                    iRegionID_ = form4.The_iRegionID;
                    strRegionName_ = form4.The_strRegionName;
                    strNote_ = form4.The_strNote;
                    if (this.TheSqlData.IsExistRegionID(iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfRegion + ": " + iRegionID_.ToString() + ". " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertRegionInfo(iRegionID_, strRegionName_, strNote_))
                        {
                            ListViewItem lvi = this.RetListViewItemFromRegionInfo(new RegionInfo(iRegionID_, strRegionName_, strNote_, iTotalOfRooms_, iTotalOfLocations_));
                            this.listView1.Items.Add(lvi);
                            this.listView1.Focus();
                            lvi.Selected = true;
                            lvi.Focused = true;
                            lvi.EnsureVisible();
                            TreeNode tn = this.InitRegionNode(iRegionID_, strRegionName_);
                            int iPos = this.FindPostionTreeNodeFromTreeNodeParent(this.tnSelect, iRegionID_);
                            this.tnSelect.Nodes.Insert(iPos, tn);
                            bValidRegionID = true;
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.RegionInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }
        }
        private TreeNode InitRegionNode(int i_region_id, string str_region_name)
        {
            TreeNode tn = new TreeNode(str_region_name, 1, 1);
            tn.Tag = i_region_id.ToString();
            TreeNode tnRooms = new TreeNode(this.strServiceName0, 2, 2);
            tnRooms.Tag = "0";
            tn.Nodes.Add(tnRooms);
            TreeNode tnLocations = new TreeNode(this.strServiceName1, 5, 5);
            tnLocations.Tag = "1";
            tn.Nodes.Add(tnLocations);
            return tn;
        }
        private int FindPostionTreeNodeFromTreeNodeParent(TreeNode tnFind, int i_number_id)
        {
            TreeNodeCollection tnNodes = tnFind.Nodes;
            int iFound = tnNodes.Count + 1;
            bool bFound = false;
            int i = 0;
            while (i < tnNodes.Count && !bFound)
            {
                if (i_number_id <= Int32.Parse(tnNodes[i].Tag.ToString()))
                {
                    bFound = true;
                    iFound = i;
                }
                else
                    i++;
            }
            return iFound;
        }


        private void modifyRegionLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RegionInfo Ri = this.TheSqlData.ReaderRegionInfo(this.iRegionID);
            int iRegionID_ = Ri.iRegionID;
            string strRegionName_ = Ri.strRegionName;
            string strNote_ = Ri.strNote;
            int iTotalOfRooms_ = Ri.iTotalOfRooms;
            int iTotalOfLocations = Ri.iTotalOfLocations;
            Form4 form4 = new Form4();
            form4.bModify = true;
            form4.The_iRegionID = iRegionID_;
            form4.The_strRegionName = strRegionName_;
            form4.The_strNote = strNote_;
            if (form4.ShowDialog(this) == DialogResult.OK)
            {
                iRegionID_ = form4.The_iRegionID;
                strRegionName_ = form4.The_strRegionName;
                strNote_ = form4.The_strNote;
                if (this.TheSqlData.UpdateRegionInfo(iRegionID_, strRegionName_, strNote_))
                {
                    ListViewItem lvi = this.RetListViewItemFromRegionInfo(new RegionInfo(iRegionID_, strRegionName_, strNote_, iTotalOfRooms_, iTotalOfLocations));
                    this.listView1.Items[this.iItem] = lvi;
                    this.listView1.Focus();
                    lvi.Selected = true;
                    lvi.Focused = true;
                    lvi.EnsureVisible();
                    TreeNode tn = this.FindBinaryTreeNodeFromTreeNodeParent(this.tnSelect, iRegionID_);
                    tn.Text = strRegionName_;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void deleteRegionLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegionInfo Ri = this.TheSqlData.ReaderRegionInfo(this.iRegionID);
            DialogResult dr = MessageBox.Show(
                Properties.Resources.DoYouWantTo + " " + Properties.Resources.Delete + " " + Properties.Resources.RegionInfo + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + "?",
                Properties.Resources.DeleteRegion,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (this.TheSqlData.IsExistRoomsInRegion(this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfRoom + " " + Properties.Resources.IsExistedIn + " " + Properties.Resources.Region + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + "!");
                    return;
                }
                if (this.TheSqlData.IsExistLocationsInRegion(this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfLocation + " " + Properties.Resources.IsExistedIn + " " + Properties.Resources.Region + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + "!");
                    return;
                }
                if (!this.TheSqlData.IsExistRegionID(this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfRegion + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + " " + Properties.Resources.IsNotFound + "!");
                    return;
                }
                if (this.TheSqlData.DeleteRegionInfo(this.iRegionID))
                {
                    this.listView1.Items.RemoveAt(this.iItem);
                    this.SetListViewItemSelectFocus(this.listView1, this.listView1.Items.Count > this.iItem ? this.iItem : this.iItem - 1);
                    TreeNode tn = this.FindBinaryTreeNodeFromTreeNodeParent(this.tnSelect, this.iRegionID);
                    this.tnSelect.Nodes.Remove(tn);
                }
            }
        }
        private void SetListViewItemSelectFocus(ListView lv, int i_item)
        {
            if (i_item > -1 && i_item < lv.Items.Count)
            {
                lv.Focus();
                ListViewItem lvi = lv.Items[i_item];
                lvi.Selected = true;
                lvi.Focused = true;
                lvi.EnsureVisible();
            }
        }

        #endregion

        #region Room lv tootip
        private void newRoomLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool
                bValidRoomID = false,
                bContinue = true;
            int
                iMaxRoomID = this.TheSqlData.GetMaxValueRoomID(this.iRegionID),
                iRoomID_ = iMaxRoomID + 1,
                iRegionID_ = this.iRegionID,
                iTotalOfBeds_ = 0,
                iLabor_ = 1;
            string
                strRoomName_ = "",
                strRegionName_ = this.strRegionName,
                strNote_ = "";

            while (!bValidRoomID && bContinue)
            {
                // Form5 form5 = new Form5();
                var form5 = new FrmRoom();
                form5.bModify = false;
                form5.The_iRoomID = iRoomID_;
                form5.The_strRoomName = strRoomName_;
                form5.The_iRegionID = iRegionID_;
                form5.The_strRegionName = strRegionName_;
                form5.The_strNote = strNote_;
                form5.The_iLabor = iLabor_;
                if (form5.ShowDialog(this) == DialogResult.OK)
                {
                    iRoomID_ = form5.The_iRoomID;
                    strRoomName_ = form5.The_strRoomName;
                    iRegionID_ = form5.The_iRegionID;
                    strRegionName_ = form5.The_strRegionName;
                    strNote_ = form5.The_strNote;
                    iLabor_ = form5.The_iLabor;
                    if (this.TheSqlData.IsExistRoomID(iRoomID_, iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfRoom + ": " + iRoomID_.ToString() + ". " + strRoomName_ + ", " + Properties.Resources.Region + ": " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertRoomInfo(iRoomID_, iRegionID_, strRoomName_, strNote_, iLabor_))
                        {
                            ListViewItem lvi = this.RetListViewItemFromRoomInfo(new RoomInfo(iRoomID_, iRegionID_, strRoomName_, strRegionName_, strNote_, iTotalOfBeds_, iLabor_));
                            this.listView1.Items.Add(lvi);
                            this.listView1.Focus();
                            lvi.Selected = true;
                            lvi.Focused = true;
                            lvi.EnsureVisible();
                            TreeNode tn = this.InitRoomNode(iRoomID_, strRoomName_);
                            int iPos = this.FindPostionTreeNodeFromTreeNodeParent(this.tnSelect, iRoomID_);
                            this.tnSelect.Nodes.Insert(iPos, tn);
                            bValidRoomID = true;
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.RoomInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }
        }
        private TreeNode InitRoomNode(int i_room_id, string str_room_name)
        {
            TreeNode tn = new TreeNode(str_room_name, 3, 3);
            tn.Tag = i_room_id.ToString();
            return tn;
        }


        private void modifyRoomLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RoomInfo Ri = this.TheSqlData.ReaderRoomInfo(this.iRoomID, this.iRegionID);

            int
                iRoomID_ = Ri.iRoomID,
                iLabor_ = Ri.iLabors,
                iRegionID_ = Ri.iRegionID,
                iTotalOfBeds_ = Ri.iTotalOfBeds;

            string
                strRoomName_ = Ri.strRoomName,
                strRegionName_ = Ri.strRegionName,
                strNote_ = Ri.strNote;

            // Form5 form5 = new Form5();
            var form5 = new FrmRoom();
            form5.bModify = true;
            form5.The_iRoomID = iRoomID_;
            form5.The_strRoomName = strRoomName_;
            form5.The_iRegionID = iRegionID_;
            form5.The_strRegionName = strRegionName_;
            form5.The_strNote = strNote_;
            form5.The_iLabor = iLabor_;
            if (form5.ShowDialog(this) == DialogResult.OK)
            {
                iRoomID_ = form5.The_iRoomID;
                iLabor_ = form5.The_iLabor;
                strRoomName_ = form5.The_strRoomName;
                iRegionID_ = form5.The_iRegionID;
                strRegionName_ = form5.The_strRegionName;
                strNote_ = form5.The_strNote;
                iLabor_ = form5.The_iLabor;
                if (this.TheSqlData.UpdateRoomInfo(iRoomID_, iRegionID_, strRoomName_, strNote_, iLabor_))
                {
                    ListViewItem lvi = this.RetListViewItemFromRoomInfo(new RoomInfo(iRoomID_, iRegionID_, strRoomName_, strRegionName_, strNote_, iTotalOfBeds_, iLabor_));
                    this.listView1.Items[this.iItem] = lvi;
                    this.listView1.Focus();
                    lvi.Selected = true;
                    lvi.Focused = true;
                    lvi.EnsureVisible();
                    TreeNode tn = this.FindBinaryTreeNodeFromTreeNodeParent(this.tnSelect, iRoomID_);
                    tn.Text = strRoomName_;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void deleteRoomLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomInfo Ri = this.TheSqlData.ReaderRoomInfo(this.iRoomID, this.iRegionID);
            DialogResult dr = MessageBox.Show(
                Properties.Resources.DoYouWantTo + " " + Properties.Resources.Delete + " " + Properties.Resources.RoomInfo + ": " + Ri.iRoomID.ToString() + ". " + Ri.strRoomName + "\n(" + Properties.Resources.Region + ": " + Ri.strRegionName + ") ?",
                Properties.Resources.DeleteRoom,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (this.TheSqlData.IsExistBedsInRoom(this.iRoomID, this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfBed + " " + Properties.Resources.IsExistedIn + " " + Properties.Resources.Room + ": " + Ri.iRoomID.ToString() + ". " + Ri.strRoomName + "\n(" + Properties.Resources.Region + ": " + Ri.strRegionName + ") " + "!");
                    return;
                }
                if (!this.TheSqlData.IsExistRoomID(this.iRoomID, this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfRoom + " " + Ri.iRoomID.ToString() + ". " + Ri.strRoomName + " (" + Properties.Resources.Region + ": " + Ri.strRegionName + ") " + Properties.Resources.IsNotFound + "!");
                    return;
                }
                if (this.TheSqlData.DeleteRoomInfo(this.iRoomID, this.iRegionID))
                {
                    this.listView1.Items.RemoveAt(this.iItem);
                    this.SetListViewItemSelectFocus(this.listView1, this.listView1.Items.Count > this.iItem ? this.iItem : this.iItem - 1);
                    TreeNode tn = this.FindBinaryTreeNodeFromTreeNodeParent(this.tnSelect, this.iRoomID);
                    this.tnSelect.Nodes.Remove(tn);
                }
            }
        }

        #endregion

        private TreeNode FindBinaryTreeNodeFromTreeNodeParent(TreeNode tnFind, int i_number_id_find)
        {
            TreeNode tnFound = null;
            TreeNodeCollection tnNodes = tnFind.Nodes;
            bool bFound = false;
            int iFirst = 0;
            int iLast = tnNodes.Count - 1;
            int iMid = 0;
            while (iFirst <= iLast && !bFound)
            {
                iMid = (iFirst + iLast) / 2; //Berechnung der Mitte
                if (i_number_id_find < Int32.Parse(tnNodes[iMid].Tag.ToString()))
                {
                    //falls e kleiner als das mittlere Element
                    iLast = iMid - 1; //setze rechte Grenze unterhalb der Mitte
                }
                else
                {
                    //sonst
                    if (i_number_id_find == Int32.Parse(tnNodes[iMid].Tag.ToString()))
                    {
                        //falls e gleich mittlerem Element
                        bFound = true; // e ist in a gefunden
                    }
                    else
                    {
                        //sonst
                        iFirst = iMid + 1;
                    }
                }
            }
            //setze linke Grenze oberhalb der Mitte

            if (bFound)
                tnFound = tnNodes[iMid];
            return tnFound;
        }

        #region Bed LV tooltip
        private void newBedLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bValidBedID = false;
            bool bContinue = true;
            int iMaxBedID = this.TheSqlData.GetMaxValueBedID(this.iRoomID, this.iRegionID);
            int iBedID_ = iMaxBedID + 1;
            string strBedName_ = "";
            int iRoomID_ = this.iRoomID;
            string strRoomName_ = this.strRoomName;
            int iRegionID_ = this.iRegionID;
            string strRegionName_ = this.strRegionName;
            string strNote_ = "";
            bool bInstall_ = false;
            int iCurator_ = 0;
            string strCurator_ = "";
            while (!bValidBedID && bContinue)
            {
                FrmCreateBed form6 = new FrmCreateBed();
                form6.bModify = false;
                form6.The_iBedID = iBedID_;
                form6.The_strBedName = strBedName_;
                form6.The_iRoomID = iRoomID_;
                form6.The_strRoomName = strRoomName_;
                form6.The_iRegionID = iRegionID_;
                form6.The_strRegionName = strRegionName_;
                form6.The_strNote = strNote_;
                form6.The_bInstall = bInstall_;
                form6.The_iCurator = iCurator_;
                form6.The_Curator = strCurator_;
                form6.The_iCurator = iCurator_;
                form6.The_Curator = strCurator_;
                if (form6.ShowDialog(this) == DialogResult.OK)
                {
                    iBedID_ = form6.The_iBedID;
                    strBedName_ = form6.The_strBedName;
                    iRoomID_ = form6.The_iRoomID;
                    strRoomName_ = form6.The_strRoomName;
                    iRegionID_ = form6.The_iRegionID;
                    strRegionName_ = form6.The_strRegionName;
                    strNote_ = form6.The_strNote;
                    bInstall_ = form6.The_bInstall;
                    iCurator_ = form6.The_iCurator;
                    strCurator_ = form6.The_Curator;
                    if (this.TheSqlData.IsExistBedID(iBedID_, iRoomID_, iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfBed + ": " + iBedID_.ToString() + ". " + strBedName_ + ", " + Properties.Resources.Room + ": " + strRoomName_ + ", " + Properties.Resources.Region + ": " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertBedInfo(iBedID_, iRoomID_, iRegionID_, strBedName_, strNote_, bInstall_, iCurator_))
                        {
                            ListViewItem lvi = this.RetListViewItemFromBedInfo(new BedInfo(iBedID_, iRoomID_, iRegionID_, strBedName_, strRoomName_, strRegionName_, strNote_, bInstall_, iCurator_, strCurator_));
                            this.listView1.Items.Add(lvi);
                            this.listView1.Focus();
                            lvi.Selected = true;
                            lvi.Focused = true;
                            lvi.EnsureVisible();
                            bValidBedID = true;
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.BedInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }
        }

        private void modifyBedLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BedInfo Bi = this.TheSqlData.ReaderBedInfo(this.iBedID, this.iRoomID, this.iRegionID);
            int iBedID_ = Bi.iBedID;
            string strBedName_ = Bi.strBedName;
            int iRoomID_ = Bi.iRoomID;
            string strRoomName_ = Bi.strRoomName;
            int iRegionID_ = Bi.iRegionID;
            string strRegionName_ = Bi.strRegionName;
            string strNote_ = Bi.strNote;
            bool bInstall_ = Bi.bInstall;
            int iCurator_ = Bi.iCurator;
            string strCurator_ = Bi.strCurator;
            FrmCreateBed form6 = new FrmCreateBed();
            form6.bModify = true;
            form6.The_iBedID = iBedID_;
            form6.The_strBedName = strBedName_;
            form6.The_iRoomID = iRoomID_;
            form6.The_strRoomName = strRoomName_;
            form6.The_iRegionID = iRegionID_;
            form6.The_strRegionName = strRegionName_;
            form6.The_strNote = strNote_;
            form6.The_bInstall = bInstall_;
            form6.The_iCurator = iCurator_;
            form6.The_Curator = strCurator_;
            if (form6.ShowDialog(this) == DialogResult.OK)
            {
                iBedID_ = form6.The_iBedID;
                strBedName_ = form6.The_strBedName;
                iRoomID_ = form6.The_iRoomID;
                strRoomName_ = form6.The_strRoomName;
                iRegionID_ = form6.The_iRegionID;
                strRegionName_ = form6.The_strRegionName;
                strNote_ = form6.The_strNote;
                bInstall_ = form6.The_bInstall;
                iCurator_ = form6.The_iCurator;
                strCurator_ = form6.The_Curator;
                if (this.TheSqlData.UpdateBedInfo(iBedID_, iRoomID_, iRegionID_, strBedName_, strNote_, bInstall_, iCurator_))
                {
                    ListViewItem lvi = this.RetListViewItemFromBedInfo(new BedInfo(iBedID_, iRoomID_, iRegionID_, strBedName_, strRoomName_, strRegionName_, strNote_, bInstall_, iCurator_, strCurator_));
                    this.listView1.Items[this.iItem] = lvi;
                    this.listView1.Focus();
                    lvi.Selected = true;
                    lvi.Focused = true;
                    lvi.EnsureVisible();
                }
            }
        }

        private void deleteBedLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BedInfo Bi = this.TheSqlData.ReaderBedInfo(this.iBedID, this.iRoomID, this.iRegionID);
            DialogResult dr = MessageBox.Show(
                Properties.Resources.DoYouWantTo + " " + Properties.Resources.Delete + " " + Properties.Resources.BedInfo + ": " + Bi.iBedID.ToString() + ". " + Bi.strBedName + "\n(" + Properties.Resources.Room + ": " + Bi.strRoomName + ", " + Properties.Resources.Region + ": " + Bi.strRegionName + ") ?",
                Properties.Resources.DeleteBed,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (!this.TheSqlData.IsExistBedID(this.iBedID, this.iRoomID, this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfBed + ": " + Bi.iBedID.ToString() + ". " + Bi.strBedName + " (" + Properties.Resources.Room + ": " + Bi.strRoomName + ", " + Properties.Resources.Region + ": " + Bi.strRegionName + ") " + Properties.Resources.IsNotFound + "!");
                    return;
                }
                if (this.TheSqlData.DeleteBedInfo(this.iBedID, this.iRoomID, this.iRegionID))
                {
                    this.listView1.Items.RemoveAt(this.iItem);
                    this.SetListViewItemSelectFocus(this.listView1, this.listView1.Items.Count > this.iItem ? this.iItem : this.iItem - 1);
                }
            }
        }

        #endregion

        #region Bed Tv tooltip
        private void roomTVContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.treeView1.SelectedNode = this.tnSelect;
            this.bTVMouseDown = false;
        }

        private void roomTVContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.bTVMouseDown = true;
            this.treeView1.SelectedNode = this.tnMouseDown;
        }

        private void newBedTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bValidBedID = false;
            bool bContinue = true;
            int iMaxBedID = this.TheSqlData.GetMaxValueBedID(this.iRoomID, this.iRegionID);
            int iBedID_ = iMaxBedID + 1;
            string strBedName_ = "";
            int iRoomID_ = this.iRoomID;
            string strRoomName_ = this.strRoomName;
            int iRegionID_ = this.iRegionID;
            string strRegionName_ = this.strRegionName;
            string strNote_ = "";
            bool bInstall_ = false;
            int iCurator_ = 0;
            string strCurator_ = "";
            while (!bValidBedID && bContinue)
            {
                FrmCreateBed form6 = new FrmCreateBed();
                form6.bModify = false;
                form6.The_iBedID = iBedID_;
                form6.The_strBedName = strBedName_;
                form6.The_iRoomID = iRoomID_;
                form6.The_strRoomName = strRoomName_;
                form6.The_iRegionID = iRegionID_;
                form6.The_strRegionName = strRegionName_;
                form6.The_strNote = strNote_;
                form6.The_bInstall = bInstall_;
                form6.The_iCurator = iCurator_;
                form6.The_Curator = strCurator_;
                if (form6.ShowDialog(this) == DialogResult.OK)
                {
                    iBedID_ = form6.The_iBedID;
                    strBedName_ = form6.The_strBedName;
                    iRoomID_ = form6.The_iRoomID;
                    strRoomName_ = form6.The_strRoomName;
                    iRegionID_ = form6.The_iRegionID;
                    strRegionName_ = form6.The_strRegionName;
                    strNote_ = form6.The_strNote;
                    bInstall_ = form6.The_bInstall;
                    iCurator_ = form6.The_iCurator;
                    strCurator_ = form6.The_Curator;
                    if (this.TheSqlData.IsExistBedID(iBedID_, iRoomID_, iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfBed + ": " + iBedID_.ToString() + ". " + strBedName_ + ", " + Properties.Resources.Room + ": " + strRoomName_ + ", " + Properties.Resources.Region + ": " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertBedInfo(iBedID_, iRoomID_, iRegionID_, strBedName_, strNote_, bInstall_, iCurator_))
                        {
                            bValidBedID = true;
                            if (this.tnSelect == this.tnMouseDown)
                            {
                                this.treeView1.SelectedNode = null;
                                this.treeView1.SelectedNode = this.tnMouseDown;
                            }
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.RoomInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }
        }
        private void modifyRoomTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomInfo Ri = this.TheSqlData.ReaderRoomInfo(this.iRoomID, this.iRegionID);
            int
              iRoomID_ = Ri.iRoomID,
              iLabor_ = Ri.iLabors,
              iRegionID_ = Ri.iRegionID;
            string
              strRoomName_ = Ri.strRoomName,
              strRegionName_ = Ri.strRegionName,
              strNote_ = Ri.strNote;
            // Form5 form5 = new Form5();
            var form5 = new FrmRoom();
            form5.bModify = true;
            form5.The_iRoomID = iRoomID_;
            form5.The_iLabor = iLabor_;
            form5.The_strRoomName = strRoomName_;
            form5.The_iRegionID = iRegionID_;
            form5.The_strRegionName = strRegionName_;
            form5.The_strNote = strNote_;
            if (form5.ShowDialog(this) == DialogResult.OK)
            {
                iRoomID_ = form5.The_iRoomID;
                iLabor_ = form5.The_iLabor;
                strRoomName_ = form5.The_strRoomName;
                iRegionID_ = form5.The_iRegionID;
                strRegionName_ = form5.The_strRegionName;
                strNote_ = form5.The_strNote;
                if (this.TheSqlData.UpdateRoomInfo(iRoomID_, iRegionID_, strRoomName_, strNote_, iLabor_))
                {
                    this.tnMouseDown.Text = strRoomName_;
                    if (this.tnMouseDown.Parent == this.tnSelect)
                    { 
                            this.treeView1.SelectedNode = null;
                            this.treeView1.SelectedNode = this.tnSelect; 
                    }
                }
            }
        }

        private void deleteRoomTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomInfo Ri = this.TheSqlData.ReaderRoomInfo(this.iRoomID, this.iRegionID);
            DialogResult dr = MessageBox.Show(
                Properties.Resources.DoYouWantTo + " " + Properties.Resources.Delete + " " + Properties.Resources.RoomInfo + ": " + Ri.iRoomID.ToString() + ". " + Ri.strRoomName + "\n(" + Properties.Resources.Region + ": " + Ri.strRegionName + ") ?",
                Properties.Resources.DeleteRoom,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (this.TheSqlData.IsExistBedsInRoom(this.iRoomID, this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfBed + " " + Properties.Resources.IsExistedIn + " " + Properties.Resources.Room + ": " + Ri.iRoomID.ToString() + ". " + Ri.strRoomName + "\n(" + Properties.Resources.Region + ": " + Ri.strRegionName + ") " + "!");
                    return;
                }
                if (!this.TheSqlData.IsExistRoomID(this.iRoomID, this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfRoom + ": " + Ri.iRoomID.ToString() + ". " + Ri.strRoomName + " (" + Properties.Resources.Region + ": " + Ri.strRegionName + ") " + Properties.Resources.IsNotFound + "!");
                    return;
                }
                if (this.TheSqlData.DeleteRoomInfo(this.iRoomID, this.iRegionID))
                {
                    if (this.tnMouseDown.Parent == this.tnSelect)
                    {
                        this.tnSelect.Nodes.Remove(this.tnMouseDown);
                        this.treeView1.SelectedNode = null;
                        this.treeView1.SelectedNode = this.tnSelect;
                    }
                    else
                        this.tnMouseDown.Parent.Nodes.Remove(this.tnMouseDown);
                }
            }
        }

        #endregion

        private void regionTVContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.bTVMouseDown = true;
            this.treeView1.SelectedNode = this.tnMouseDown;
        }

        private void regionTVContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.treeView1.SelectedNode = this.tnSelect;
            this.bTVMouseDown = false;
        }

        private void modifyRegionTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegionInfo Ri = this.TheSqlData.ReaderRegionInfo(this.iRegionID);
            int iRegionID_ = Ri.iRegionID;
            string strRegionName_ = Ri.strRegionName;
            string strNote_ = Ri.strNote;
            Form4 form4 = new Form4();
            form4.bModify = true;
            form4.The_iRegionID = iRegionID_;
            form4.The_strRegionName = strRegionName_;
            form4.The_strNote = strNote_;
            if (form4.ShowDialog(this) == DialogResult.OK)
            {
                iRegionID_ = form4.The_iRegionID;
                strRegionName_ = form4.The_strRegionName;
                strNote_ = form4.The_strNote;
                if (this.TheSqlData.UpdateRegionInfo(iRegionID_, strRegionName_, strNote_))
                {
                    this.tnMouseDown.Text = strRegionName_;
                    if (this.tnMouseDown.Parent == this.tnSelect)
                    {
                        this.treeView1.SelectedNode = null;
                        this.treeView1.SelectedNode = this.tnSelect;
                    }
                }
            }
        }

        private void deleteRegionTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegionInfo Ri = this.TheSqlData.ReaderRegionInfo(this.iRegionID);
            DialogResult dr = MessageBox.Show(
                Properties.Resources.DoYouWantTo + " " + Properties.Resources.Delete + " " + Properties.Resources.RegionInfo + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + "?",
                Properties.Resources.DeleteRegion,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (this.TheSqlData.IsExistRoomsInRegion(this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfRoom + " " + Properties.Resources.IsExistedIn + " " + Properties.Resources.Region + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + "!");
                    return;
                }
                if (this.TheSqlData.IsExistLocationsInRegion(this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfLocation + " " + Properties.Resources.IsExistedIn + " " + Properties.Resources.Region + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + "!");
                    return;
                }
                if (!this.TheSqlData.IsExistRegionID(this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfRegion + ": " + Ri.iRegionID.ToString() + ". " + Ri.strRegionName + " " + Properties.Resources.IsNotFound + "!");
                    return;
                }
                if (this.TheSqlData.DeleteRegionInfo(this.iRegionID))
                {
                    if (this.tnMouseDown.Parent == this.tnSelect)
                    {
                        this.tnSelect.Nodes.Remove(this.tnMouseDown);
                        this.treeView1.SelectedNode = null;
                        this.treeView1.SelectedNode = this.tnSelect;
                    }
                    else
                        this.tnMouseDown.Parent.Nodes.Remove(this.tnMouseDown);
                }
            }
        }





        private void newLocationLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bValidLocationID = false;
            bool bContinue = true;
            LocationTypeArray MyTypes = this.TheSqlData.ReaderLocationTypes();
            string[] TypeNames = new string[MyTypes.Count];
            for (int i = 0; i < MyTypes.Count; i++)
                TypeNames[i] = MyTypes[i].strTypeName;
            int[] TypeIDs = new int[MyTypes.Count];
            for (int i = 0; i < MyTypes.Count; i++)
                TypeIDs[i] = MyTypes[i].iTypeID;
            int iMaxLocationID = this.TheSqlData.GetMaxValueLocationID(this.iRegionID);
            int iLocationID_ = iMaxLocationID + 1;
            string strLocationName_ = "";
            int iRegionID_ = this.iRegionID;
            string strRegionName_ = this.strRegionName;
            int iTypeID_ = 0;
            string strTypeName_ = "";
            string strNote_ = "";
            bool bInstall_ = false;
            while (!bValidLocationID && bContinue)
            {
                Form7 form7 = new Form7();
                form7.bModify = false;
                form7.The_TypeNames = TypeNames;
                form7.The_TypeIDs = TypeIDs;
                form7.The_iLocationID = iLocationID_;
                form7.The_strLocationName = strLocationName_;
                form7.The_iRegionID = iRegionID_;
                form7.The_strRegionName = strRegionName_;
                form7.The_iTypeID = iTypeID_;
                form7.The_strTypeName = strTypeName_;
                form7.The_strNote = strNote_;
                form7.The_bInstall = bInstall_;
                if (form7.ShowDialog(this) == DialogResult.OK)
                {
                    iLocationID_ = form7.The_iLocationID;
                    strLocationName_ = form7.The_strLocationName;
                    iRegionID_ = form7.The_iRegionID;
                    strRegionName_ = form7.The_strRegionName;
                    iTypeID_ = form7.The_iTypeID;
                    strTypeName_ = form7.The_strTypeName;
                    strNote_ = form7.The_strNote;
                    bInstall_ = form7.The_bInstall;

                    if (this.TheSqlData.IsExistLocationID(iLocationID_, iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfLocation + ": " + iLocationID_.ToString() + ". " + strLocationName_ + ", " + Properties.Resources.Region + ": " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertLocationInfo(iLocationID_, iRegionID_, strLocationName_, iTypeID_, strNote_, bInstall_))
                        {
                            ListViewItem lvi = this.RetListViewItemFromLocationInfo(new LocationInfo(iLocationID_, iRegionID_, strLocationName_, strRegionName_, iTypeID_, strTypeName_, strNote_, bInstall_));
                            this.listView1.Items.Add(lvi);
                            this.listView1.Focus();
                            lvi.Selected = true;
                            lvi.Focused = true;
                            lvi.EnsureVisible();
                            bValidLocationID = true;
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.LocationInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }
        }

        private void modifyLocationLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocationInfo Li = this.TheSqlData.ReaderLocationInfo(this.iLocationID, this.iRegionID);
            int iLocationID_ = Li.iLocationID;
            string strLocationName_ = Li.strLocationName;
            int iTypeID_ = Li.iTypeID;
            string strTypeName_ = Li.strTypeName;
            int iRegionID_ = Li.iRegionID;
            string strRegionName_ = Li.strRegionName;
            string strNote_ = Li.strNote;
            bool bInstall_ = Li.bInstall;
            Form7 form7 = new Form7();
            form7.bModify = true;
            form7.The_iLocationID = iLocationID_;
            form7.The_strLocationName = strLocationName_;
            form7.The_iRegionID = iRegionID_;
            form7.The_strRegionName = strRegionName_;
            form7.The_iTypeID = iTypeID_;
            form7.The_strTypeName = strTypeName_;
            form7.The_strNote = strNote_;
            form7.The_bInstall = bInstall_;
            if (form7.ShowDialog(this) == DialogResult.OK)
            {
                iLocationID_ = form7.The_iLocationID;
                strLocationName_ = form7.The_strLocationName;
                iRegionID_ = form7.The_iRegionID;
                strRegionName_ = form7.The_strRegionName;
                iTypeID_ = form7.The_iTypeID;
                strTypeName_ = form7.The_strTypeName;
                strNote_ = form7.The_strNote;
                bInstall_ = form7.The_bInstall;

                if (this.TheSqlData.UpdateLocationInfo(iLocationID_, iRegionID_, strLocationName_, strNote_, bInstall_))
                {
                    ListViewItem lvi = this.RetListViewItemFromLocationInfo(new LocationInfo(iLocationID_, iRegionID_, strLocationName_, strRegionName_, iTypeID_, strTypeName_, strNote_, bInstall_));
                    this.listView1.Items[this.iItem] = lvi;
                    this.listView1.Focus();
                    lvi.Selected = true;
                    lvi.Focused = true;
                    lvi.EnsureVisible();
                }
            }

        }

        private void deleteLocationLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocationInfo Li = this.TheSqlData.ReaderLocationInfo(this.iLocationID, this.iRegionID);
            DialogResult dr = MessageBox.Show(
                Properties.Resources.DoYouWantTo + " " + Properties.Resources.Delete + " " + Properties.Resources.LocationInfo + ": " + Li.iLocationID.ToString() + ". " + Li.strLocationName + "\n(" + Properties.Resources.Region + ": " + Li.strRegionName + ") ?",
                Properties.Resources.DeleteLocation,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (!this.TheSqlData.IsExistLocationID(this.iLocationID, this.iRegionID))
                {
                    MyMsgBox.MsgError(Properties.Resources.InfoOfLocation + ": " + Li.iLocationID.ToString() + ". " + Li.strLocationName + " (" + Properties.Resources.Region + ": " + Li.strRegionName + ") " + Properties.Resources.IsNotFound + "!");
                    return;
                }
                if (this.TheSqlData.DeleteLocationInfo(this.iLocationID, this.iRegionID))
                {
                    this.listView1.Items.RemoveAt(this.iItem);
                    this.SetListViewItemSelectFocus(this.listView1, this.listView1.Items.Count > this.iItem ? this.iItem : this.iItem - 1);
                }
            }
        }









        private void newLocationTVContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.treeView1.SelectedNode = this.tnSelect;
            this.bTVMouseDown = false;
        }

        private void newLocationTVContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.bTVMouseDown = true;
            this.treeView1.SelectedNode = this.tnMouseDown;
        }

        private void newLocationTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bValidLocationID = false;
            bool bContinue = true;
            LocationTypeArray MyTypes = this.TheSqlData.ReaderLocationTypes();
            string[] TypeNames = new string[MyTypes.Count];
            for (int i = 0; i < MyTypes.Count; i++)
                TypeNames[i] = MyTypes[i].strTypeName;
            int[] TypeIDs = new int[MyTypes.Count];
            for (int i = 0; i < MyTypes.Count; i++)
                TypeIDs[i] = MyTypes[i].iTypeID;
            int iMaxLocationID = this.TheSqlData.GetMaxValueLocationID(this.iRegionID);
            int iLocationID_ = iMaxLocationID + 1;
            string strLocationName_ = "";
            int iRegionID_ = this.iRegionID;
            string strRegionName_ = this.strRegionName;
            int iTypeID_ = 0;
            string strTypeName_ = "";
            string strNote_ = "";
            bool bInstall_ = false;
            while (!bValidLocationID && bContinue)
            {
                Form7 form7 = new Form7();
                form7.bModify = false;
                form7.The_TypeNames = TypeNames;
                form7.The_TypeIDs = TypeIDs;
                form7.The_iLocationID = iLocationID_;
                form7.The_strLocationName = strLocationName_;
                form7.The_iRegionID = iRegionID_;
                form7.The_strRegionName = strRegionName_;
                form7.The_iTypeID = iTypeID_;
                form7.The_strTypeName = strTypeName_;
                form7.The_strNote = strNote_;
                form7.The_bInstall = bInstall_;
                if (form7.ShowDialog(this) == DialogResult.OK)
                {
                    iLocationID_ = form7.The_iLocationID;
                    strLocationName_ = form7.The_strLocationName;
                    iRegionID_ = form7.The_iRegionID;
                    strRegionName_ = form7.The_strRegionName;
                    iTypeID_ = form7.The_iTypeID;
                    strTypeName_ = form7.The_strTypeName;
                    strNote_ = form7.The_strNote;
                    bInstall_ = form7.The_bInstall;

                    if (this.TheSqlData.IsExistLocationID(iLocationID_, iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfLocation + ": " + iLocationID_.ToString() + ". " + strLocationName_ + ", " + Properties.Resources.Region + ": " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertLocationInfo(iLocationID_, iRegionID_, strLocationName_, iTypeID_, strNote_, bInstall_))
                        {
                            if (this.tnSelect == this.tnMouseDown)
                            {
                                this.treeView1.SelectedNode = null;
                                this.treeView1.SelectedNode = this.tnMouseDown;
                            }
                            bValidLocationID = true;
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.LocationInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }
        }




        private void newRegionTVContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.bTVMouseDown = true;
            this.treeView1.SelectedNode = this.tnMouseDown;
        }

        private void newRegionTVContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.treeView1.SelectedNode = this.tnSelect;
            this.bTVMouseDown = false;
        }

        private void newRegionTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bValidRegionID = false;
            bool bContinue = true;

            int iMaxRegionID = this.TheSqlData.GetMaxValueRegionID();
            int iRegionID_ = iMaxRegionID + 1;
            string strRegionName_ = "";
            string strNote_ = "";
            while (!bValidRegionID && bContinue)
            {
                Form4 form4 = new Form4();
                form4.bModify = false;
                form4.The_iRegionID = iRegionID_;
                form4.The_strRegionName = strRegionName_;
                form4.The_strNote = strNote_;
                if (form4.ShowDialog(this) == DialogResult.OK)
                {
                    iRegionID_ = form4.The_iRegionID;
                    strRegionName_ = form4.The_strRegionName;
                    strNote_ = form4.The_strNote;
                    if (this.TheSqlData.IsExistRegionID(iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfRegion + ": " + iRegionID_.ToString() + ". " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertRegionInfo(iRegionID_, strRegionName_, strNote_))
                        {
                            TreeNode tn = this.InitRegionNode(iRegionID_, strRegionName_);
                            int iPos = this.FindPostionTreeNodeFromTreeNodeParent(this.tnMouseDown, iRegionID_);
                            this.tnMouseDown.Nodes.Insert(iPos, tn);
                            if (this.tnSelect == this.tnMouseDown)
                            {
                                this.treeView1.SelectedNode = null;
                                this.treeView1.SelectedNode = this.tnMouseDown;
                            }
                            bValidRegionID = true;
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.RegionInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }
        }

        private void hospitalPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int iHospitalID_ = 1;
            HospitalInfo Hi = this.TheSqlData.ReaderHospitalInfo(iHospitalID_);
            bool bModify_ = (Hi != null);
            string strHospitalName_ = (Hi == null) ? "" : Hi.strHospitalName;
            string strAddress_ = (Hi == null) ? "" : Hi.strAddress;
            string strWebsite_ = (Hi == null) ? "" : Hi.strWebsite;
            string strEmail_ = (Hi == null) ? "" : Hi.strEmail;
            string strPhone_ = (Hi == null) ? "" : Hi.strPhone;
            string strFax_ = (Hi == null) ? "" : Hi.strFax;
            string strNote_ = (Hi == null) ? "" : Hi.strNote;
            Form8 form8 = new Form8();
            form8.bModify = bModify_;
            form8.The_iHospitalID = iHospitalID_;
            form8.The_strHospitalName = strHospitalName_;
            form8.The_strAddress = strAddress_;
            form8.The_strWebsite = strWebsite_;
            form8.The_strEmail = strEmail_;
            form8.The_strPhone = strPhone_;
            form8.The_strFax = strFax_;
            form8.The_strNote = strNote_;
            if (form8.ShowDialog() == DialogResult.OK)
            {
                iHospitalID_ = form8.The_iHospitalID;
                strHospitalName_ = form8.The_strHospitalName;
                strAddress_ = form8.The_strAddress;
                strWebsite_ = form8.The_strWebsite;
                strEmail_ = form8.The_strEmail;
                strPhone_ = form8.The_strPhone;
                strFax_ = form8.The_strFax;
                strNote_ = form8.The_strNote;
                if (!bModify_)
                {
                    if (this.TheSqlData.InsertHospitalInfo(
                        iHospitalID_, strHospitalName_,
                        strAddress_, strWebsite_, strEmail_,
                        strPhone_, strFax_,
                        strNote_))
                    {
                        this.tnMouseDown.Tag = iHospitalID_.ToString();
                        this.tnMouseDown.Text = strHospitalName_;
                        this.tnMouseDown.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (this.TheSqlData.UpdateHospitalInfo(
                        iHospitalID_, strHospitalName_,
                        strAddress_, strWebsite_, strEmail_,
                        strPhone_, strFax_,
                        strNote_))
                    {
                        this.tnMouseDown.Text = strHospitalName_;
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }






        private void newRoomTVContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.bTVMouseDown = true;
            this.treeView1.SelectedNode = this.tnMouseDown;
        }

        private void newRoomTVContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.treeView1.SelectedNode = this.tnSelect;
            this.bTVMouseDown = false;
        }

        private void newRoomTVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool
                bValidRoomID = false,
                bContinue = true;
            int
                iMaxRoomID = this.TheSqlData.GetMaxValueRoomID(this.iRegionID),
                iRoomID_ = iMaxRoomID + 1,
                iLabor_ = 1,
                iRegionID_ = this.iRegionID;
            string
                strRoomName_ = "",
                strRegionName_ = this.strRegionName,
                strNote_ = "";
            while (!bValidRoomID && bContinue)
            {
                // Form5 form5 = new Form5();
                var form5 = new FrmRoom();
                form5.bModify = false;
                form5.The_iRoomID = iRoomID_;
                form5.The_strRoomName = strRoomName_;
                form5.The_iRegionID = iRegionID_;
                form5.The_strRegionName = strRegionName_;
                form5.The_strNote = strNote_;
                form5.The_iLabor = iLabor_;
                if (form5.ShowDialog(this) == DialogResult.OK)
                {
                    iRoomID_ = form5.The_iRoomID;
                    strRoomName_ = form5.The_strRoomName;
                    iRegionID_ = form5.The_iRegionID;
                    strRegionName_ = form5.The_strRegionName;
                    strNote_ = form5.The_strNote;
                    iLabor_ = form5.The_iLabor;
                    if (this.TheSqlData.IsExistRoomID(iRoomID_, iRegionID_))
                    {
                        MyMsgBox.MsgError(Properties.Resources.InfoOfRoom + ": " + iRoomID_.ToString() + ". " + strRoomName_ + ", " + Properties.Resources.Region + ": " + strRegionName_ + " " + Properties.Resources.IsExisted + "!");
                    }
                    else
                    {
                        if (this.TheSqlData.InsertRoomInfo(iRoomID_, iRegionID_, strRoomName_, strNote_, iLabor_))
                        {
                            TreeNode tn = this.InitRoomNode(iRoomID_, strRoomName_);
                            int iPos = this.FindPostionTreeNodeFromTreeNodeParent(this.tnMouseDown, iRoomID_);
                            this.tnMouseDown.Nodes.Insert(iPos, tn);
                            if (this.tnSelect == this.tnMouseDown)
                            {
                                this.treeView1.SelectedNode = null;
                                this.treeView1.SelectedNode = this.tnMouseDown;
                            }
                            bValidRoomID = true;
                        }
                        else
                            MyMsgBox.MsgError(Properties.Resources.Insert + " " + Properties.Resources.RoomInfo + " " + Properties.Resources.Failure + "!");
                    }
                }
                else
                {
                    bContinue = false;
                }
            }

        }











    }
}
