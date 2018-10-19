using System;
namespace HTGSL
{
	public class ServiceInfo
	{
		public int iServiceID;
		public string strServiceName;
		public int iTotal;
		public ServiceInfo()
		{
		}
		public ServiceInfo(int i_service_id, string str_service_name, int i_total)
		{
			this.iServiceID = i_service_id;
			this.strServiceName = str_service_name;
			this.iTotal = i_total;
		}
	}
}
