using System;
namespace HTGSL
{
	public class RegionNodeInfo
	{
		public int iRegionID;
		public string strRegionName;
		public RoomsNodeInfo rnRooms = new RoomsNodeInfo();
		public LocationsNodeInfo lnLocations = new LocationsNodeInfo();
		public RegionNodeInfo()
		{
		}
		public RegionNodeInfo(int i_region_id, string str_region_name, RoomsNodeInfo rn_rooms, LocationsNodeInfo ln_locations)
		{
			this.iRegionID = i_region_id;
			this.strRegionName = str_region_name;
			this.rnRooms = rn_rooms;
			this.lnLocations = ln_locations;
		}
	}
}
