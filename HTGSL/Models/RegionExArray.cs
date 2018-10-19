using System;
using System.Collections;
namespace HTGSL
{
	public class RegionExArray : CollectionBase
	{
		public RegionExInfo this[int index]
		{
			get
			{
				return (RegionExInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(RegionExInfo Ri)
		{
			base.List.Add(Ri);
		}
		public int GetIndex(int i_region_id)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].iRegionID == i_region_id)
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
		public RegionExInfo GetValue(int i_region_id)
		{
			int index = this.GetIndex(i_region_id);
			return (index != -1) ? this[index] : null;
		}
	}
}
