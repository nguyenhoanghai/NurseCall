using System;
using System.Collections;
namespace HTGSL
{
	public class RegionArray : CollectionBase
	{
		public RegionInfo this[int index]
		{
			get
			{
				return (RegionInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(RegionInfo Ri)
		{
			base.List.Add(Ri);
		}
	}
}
