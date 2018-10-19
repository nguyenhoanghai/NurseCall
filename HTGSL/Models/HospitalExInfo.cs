using System;
namespace HTGSL
{
	public class HospitalExInfo
	{
		public int iHospitalID;
		public string strHospitalName;
		public RegionExArray Regions = new RegionExArray();
		public HospitalExInfo()
		{
		}
		public HospitalExInfo(int i_hospital_id, string str_hospital_name, RegionExArray regions)
		{
			this.iHospitalID = i_hospital_id;
			this.strHospitalName = str_hospital_name;
			this.Regions = regions;
		}
	}
}
