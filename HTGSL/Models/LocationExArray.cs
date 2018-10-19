using System;
using System.Collections;
namespace HTGSL
{
	public class LocationExArray : CollectionBase
	{
		public LocationExInfo this[int index]
		{
			get
			{
				return (LocationExInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(LocationExInfo Li)
		{
			base.List.Add(Li);
		}
	}
}
