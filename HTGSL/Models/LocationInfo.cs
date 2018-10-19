using System;
namespace HTGSL
{
	public class LocationInfo
	{
		public int iLocationID;
		public int iRegionID;
		public string strLocationName;
		public string strRegionName;
		public int iTypeID;
		public string strTypeName;
		public string strNote;
		public bool bInstall;
		public LocationInfo()
		{
		}
		public LocationInfo(int i_location_id, int i_region_id, string str_location_name, string str_region_name, int i_type_id, string str_type_name, string str_note, bool b_install)
		{
			this.iLocationID = i_location_id;
			this.iRegionID = i_region_id;
			this.strLocationName = str_location_name;
			this.strRegionName = str_region_name;
			this.iTypeID = i_type_id;
			this.strTypeName = str_type_name;
			this.strNote = str_note;
			this.bInstall = b_install;
		}
	}
}
