using System;
namespace HTGSL
{
	public class RoomInfo
	{
		public int iRoomID;
		public int iRegionID;
		public string strRoomName;
		public string strRegionName;
		public string strNote;
		public int iTotalOfBeds;
		public RoomInfo()
		{
		}
		public RoomInfo(int i_room_id, int i_region_id, string str_room_name, string str_region_name, string str_note, int i_total_of_beds)
		{
			this.iRoomID = i_room_id;
			this.iRegionID = i_region_id;
			this.strRoomName = str_room_name;
			this.strRegionName = str_region_name;
			this.strNote = str_note;
			this.iTotalOfBeds = i_total_of_beds;
		}
	}
}
