using System;
namespace HTGSL
{
	public class RoomsNodeInfo
	{
		public int iRoomsID;
		public string strRoomsName;
		public RoomNodeArray Rooms = new RoomNodeArray();
		public RoomsNodeInfo()
		{
		}
		public RoomsNodeInfo(int i_rooms_id, string str_rooms_name, RoomNodeArray rooms)
		{
			this.iRoomsID = i_rooms_id;
			this.strRoomsName = str_rooms_name;
			this.Rooms = rooms;
		}
	}
}
