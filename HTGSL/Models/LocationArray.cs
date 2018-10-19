using System;
using System.Collections;
namespace HTGSL
{
	public class LocationArray : CollectionBase
	{
		public LocationInfo this[int index]
		{
			get
			{
				return (LocationInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(LocationInfo Li)
		{
			base.List.Add(Li);
		}
	}
}
