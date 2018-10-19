using System;
using System.Collections;
namespace HTGSL
{
	public class SoundTempArray : CollectionBase
	{
		public SoundTempInfo this[int index]
		{
			get
			{
				return (SoundTempInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(SoundTempInfo si)
		{
			base.List.Add(si);
		}
		public int GetIndex(int isound_template_id)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].iSound_template_id == isound_template_id)
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
		public int GetIndex(string ssound_template_code)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].sSound_template_code == ssound_template_code)
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
		public SoundTempInfo GetValue(int isound_template_id)
		{
			int index = this.GetIndex(isound_template_id);
			return (index != -1) ? this[index] : null;
		}
		public SoundTempInfo GetValue(string ssound_template_code)
		{
			int index = this.GetIndex(ssound_template_code);
			return (index != -1) ? this[index] : null;
		}
	}
}
