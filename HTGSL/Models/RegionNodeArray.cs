using System;
using System.Collections;
namespace HTGSL
{
	public class RegionNodeArray : CollectionBase
	{
		public RegionNodeInfo this[int index]
		{
			get
			{
				return (RegionNodeInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(RegionNodeInfo Ri)
		{
			base.List.Add(Ri);
		}
	}
}
