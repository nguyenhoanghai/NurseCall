using System;
namespace HTGSL
{
	public class SoundTempInfo
	{
		public int iSound_template_id;
		public string sSound_template_code;
		public int iSound_type_id;
		public int iSound_id;
		public int iNread;
		public SoundTempInfo()
		{
		}
		public SoundTempInfo(int isound_template_id, string ssound_template_code, int isound_type_id, int isound_id)
		{
			this.iSound_template_id = isound_template_id;
			this.sSound_template_code = ssound_template_code;
			this.iSound_type_id = isound_type_id;
			this.iSound_id = isound_id;
		}
		public SoundTempInfo(int isound_template_id, string ssound_template_code, int isound_type_id, int isound_id, int inread)
		{
			this.iSound_template_id = isound_template_id;
			this.sSound_template_code = ssound_template_code;
			this.iSound_type_id = isound_type_id;
			this.iSound_id = isound_id;
			this.iNread = inread;
		}
	}
}
