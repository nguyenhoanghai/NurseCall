using System;
using System.Collections;
namespace HTGSL
{
	public class BedsArray : CollectionBase
	{
		public BedInfor this[int index]
		{
			get
			{
				return (BedInfor)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(BedInfor si)
		{
			base.List.Add(si);
		}
		public int GetIndex(string s_Bed_id)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].sBed_id == s_Bed_id)
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
		public BedInfor GetValue(string s_Bed_id)
		{
			int index = this.GetIndex(s_Bed_id);
			return (index != -1) ? this[index] : null;
		}
	}
}
