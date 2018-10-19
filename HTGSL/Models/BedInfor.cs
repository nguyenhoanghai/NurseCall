using System;
namespace HTGSL
{
	public class BedInfor
	{
		public string sBed_id;
		public int iEvent_Type;
		public int iMax_Times;
		public BedInfor()
		{
		}
		public BedInfor(string s_Bed_id, int i_event_type, int i_max_times)
		{
			this.sBed_id = s_Bed_id;
			this.iEvent_Type = i_event_type;
			this.iMax_Times = i_max_times;
		}
	}
}
