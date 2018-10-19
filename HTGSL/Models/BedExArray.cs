using System;
using System.Collections;
namespace HTGSL
{
	public class BedExArray : CollectionBase
	{
		public BedExInfo this[int index]
		{
			get
			{
				return (BedExInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(BedExInfo Bi)
		{
			base.List.Add(Bi);
		}
		public int GetIndex(int i_bed_id)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].iBedID == i_bed_id)
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
		public BedExInfo GetValue(int i_bed_id)
		{
			int index = this.GetIndex(i_bed_id);
			return (index != -1) ? this[index] : null;
		}
	}
}
