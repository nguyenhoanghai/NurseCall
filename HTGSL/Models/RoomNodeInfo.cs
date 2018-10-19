using System;
namespace HTGSL
{
	public class RoomNodeInfo
	{
		public int iRoomID;
		public string strRoomName;
		public RoomNodeInfo()
		{
		}
		public RoomNodeInfo(int i_room_id, string str_room_name)
		{
			this.iRoomID = i_room_id;
			this.strRoomName = str_room_name;
		}
	}
}
