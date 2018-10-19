using System;
using System.Collections;
namespace HTGSL
{
	public class SoundExArray : CollectionBase
	{
		public SoundExInfo this[int index]
		{
			get
			{
				return (SoundExInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(SoundExInfo si)
		{
			base.List.Add(si);
		}
		public int GetIndex(int i_sound_id)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].sound_id == i_sound_id)
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
		public int GetIndex(string s_sound_code)
		{
			int result = -1;
			bool flag = false;
			int num = 0;
			while (num < base.Count && !flag)
			{
				if (this[num].sound_code == s_sound_code)
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
		public SoundExInfo GetValue(int i_sound_id)
		{
			int index = this.GetIndex(i_sound_id);
			return (index != -1) ? this[index] : null;
		}
		public SoundExInfo GetValue(string s_sound_code)
		{
			int index = this.GetIndex(s_sound_code);
			return (index != -1) ? this[index] : null;
		}
	}
}
