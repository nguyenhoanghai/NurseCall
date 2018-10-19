using System;
using System.Collections;
namespace HTGSL
{
	public class RoomArray : CollectionBase
	{
		public RoomInfo this[int index]
		{
			get
			{
				return (RoomInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(RoomInfo Ri)
		{
			base.List.Add(Ri);
		}
	}
}
