using System;
namespace HTGSL
{
	public class SoundExInfo
	{
		public int sound_id;
		public string sound_code;
		public int sound_type;
		public string sound_path;
		public SoundExInfo()
		{
		}
		public SoundExInfo(int i_sound_id, string s_sound_code, int i_sound_type, string s_sound_path)
		{
			this.sound_id = i_sound_id;
			this.sound_code = s_sound_code;
			this.sound_type = i_sound_type;
			this.sound_path = s_sound_path;
		}
	}
}
