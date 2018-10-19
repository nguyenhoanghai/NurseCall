using System;
using System.Collections;
namespace HTGSL
{
	public class ServiceArray : CollectionBase
	{
		public ServiceInfo this[int index]
		{
			get
			{
				return (ServiceInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(ServiceInfo Si)
		{
			base.List.Add(Si);
		}
	}
}
