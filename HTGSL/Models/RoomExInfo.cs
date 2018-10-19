using System;
namespace HTGSL
{
	public class RoomExInfo
	{
		public int iRoomID;
		public string strRoomName;
		public string strRoomNote;
		public BedExArray Beds = new BedExArray();
		public RoomExInfo()
		{
		}
		public RoomExInfo(int i_room_id, string str_room_name, string str_room_note, BedExArray beds)
		{
			this.iRoomID = i_room_id;
			this.strRoomName = str_room_name;
			this.strRoomNote = str_room_note;
			this.Beds = beds;
		}
	}
}
