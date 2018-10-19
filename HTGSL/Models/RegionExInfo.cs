using System;
namespace HTGSL
{
	public class RegionExInfo
	{
		public int iRegionID;
		public string strRegionName;
		public RoomExArray Rooms = new RoomExArray();
		public LocationExArray Locations = new LocationExArray();
		public RegionExInfo()
		{
		}
		public RegionExInfo(int i_region_id, string str_region_name, RoomExArray rooms, LocationExArray locations)
		{
			this.iRegionID = i_region_id;
			this.strRegionName = str_region_name;
			this.Rooms = rooms;
			this.Locations = locations;
		}
	}
}
