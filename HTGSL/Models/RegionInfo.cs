using System;
namespace HTGSL
{
	public class RegionInfo
	{
		public int iRegionID;
		public string strRegionName;
		public string strNote;
		public int iTotalOfRooms;
		public int iTotalOfLocations;
		public RegionInfo()
		{
		}
		public RegionInfo(int i_region_id, string str_region_name, string str_note, int i_total_of_rooms, int i_total_of_locations)
		{
			this.iRegionID = i_region_id;
			this.strRegionName = str_region_name;
			this.strNote = str_note;
			this.iTotalOfRooms = i_total_of_rooms;
			this.iTotalOfLocations = i_total_of_locations;
		}
	}
}
