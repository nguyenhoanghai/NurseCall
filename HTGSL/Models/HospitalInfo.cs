using System;
namespace HTGSL
{
	public class HospitalInfo
	{
		public int iHospitalID;
		public string strHospitalName;
		public string strAddress;
		public string strWebsite;
		public string strEmail;
		public string strPhone;
		public string strFax;
		public string strNote;
		public HospitalInfo()
		{
		}
		public HospitalInfo(int i_hospital_id, string str_hospital_name, string str_address, string str_website, string str_email, string str_phone, string str_fax, string str_note)
		{
			this.iHospitalID = i_hospital_id;
			this.strHospitalName = str_hospital_name;
			this.strAddress = str_address;
			this.strWebsite = str_website;
			this.strEmail = str_email;
			this.strPhone = str_phone;
			this.strFax = str_fax;
			this.strNote = str_note;
		}
	}
}
