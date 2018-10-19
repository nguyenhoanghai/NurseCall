using System;
namespace HTGSL
{
	public class BedExInfo
	{
		public int iBedID;
		public string strBedName;
		public string strBedNote;
		public bool bInstall;
		public int iStateID;
		public BedExInfo()
		{
		}
		public BedExInfo(int i_bed_id, string str_bed_name, string str_bed_note, bool b_install, int i_state_id)
		{
			this.iBedID = i_bed_id;
			this.strBedName = str_bed_name;
			this.strBedNote = str_bed_note;
			this.bInstall = b_install;
			this.iStateID = i_state_id;
		}
	}
}
