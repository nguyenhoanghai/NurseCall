using System;
namespace HTGSL
{
	public class LocationExInfo
	{
		public int iLocationID;
		public string strLocationName;
		public LocationExInfo()
		{
		}
		public LocationExInfo(int i_location_id, string str_location_name)
		{
			this.iLocationID = i_location_id;
			this.strLocationName = str_location_name;
		}
	}
}
