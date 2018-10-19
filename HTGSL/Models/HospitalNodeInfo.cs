using System;
namespace HTGSL
{
	public class HospitalNodeInfo
	{
		public int iHospitalID;
		public string strHospitalName;
		public RegionNodeArray Regions = new RegionNodeArray();
		public HospitalNodeInfo()
		{
		}
		public HospitalNodeInfo(int i_hospital_id, string str_hospital_name, RegionNodeArray regions)
		{
			this.iHospitalID = i_hospital_id;
			this.strHospitalName = str_hospital_name;
			this.Regions = regions;
		}
	}
}
