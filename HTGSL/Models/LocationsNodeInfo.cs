using System;
namespace HTGSL
{
	public class LocationsNodeInfo
	{
		public int iLocationsID;
		public string strLocationsName;
		public LocationsNodeInfo()
		{
		}
		public LocationsNodeInfo(int i_locations_id, string str_locations_name)
		{
			this.iLocationsID = i_locations_id;
			this.strLocationsName = str_locations_name;
		}
	}
}
