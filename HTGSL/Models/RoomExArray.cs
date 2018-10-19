using System;
using System.Collections;
namespace HTGSL
{
	public class RoomExArray : CollectionBase
	{
		public RoomExInfo this[int index]
		{
			get
			{
				return (RoomExInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(RoomExInfo Ri)
		{
			base.List.Add(Ri);
		}
		public int GetIndex(int i_room_id)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].iRoomID == i_room_id)
				{
					result = num;
					flag = true;
				}
				else
				{
					num++;
				}
			}
			return result;
		}
		public RoomExInfo GetValue(int i_room_id)
		{
			int index = this.GetIndex(i_room_id);
			return (index != -1) ? this[index] : null;
		}
	}
}
