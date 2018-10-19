using System;
namespace HTGSL
{
	public class BedInfo
	{
        public int iBedID;
        public int iRoomID;
        public int iRegionID;
        public string strBedName;
        public string strRoomName;
        public string strRegionName;
        public string strNote;
        public bool bInstall;
        public int iCurator;
        public string strCurator;
        public BedInfo()
        {
        }
        public BedInfo(
            int i_bed_id,
            int i_room_id,
            int i_region_id,
            string str_bed_name,
            string str_room_name,
            string str_region_name,
            string str_note,
            bool b_install,
            int i_curator,
            string str_curator)
        {
            this.iBedID = i_bed_id;
            this.iRoomID = i_room_id;
            this.iRegionID = i_region_id;
            this.strBedName = str_bed_name;
            this.strRoomName = str_room_name;
            this.strRegionName = str_region_name;
            this.strNote = str_note;
            this.bInstall = b_install;
            this.iCurator = i_curator;
            this.strCurator = str_curator;
        }
	}
}
