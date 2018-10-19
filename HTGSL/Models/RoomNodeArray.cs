using System;
using System.Collections;
namespace HTGSL
{
	public class RoomNodeArray : CollectionBase
	{
		public RoomNodeInfo this[int index]
		{
			get
			{
				return (RoomNodeInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(RoomNodeInfo Ri)
		{
			base.List.Add(Ri);
		}
	}
}
