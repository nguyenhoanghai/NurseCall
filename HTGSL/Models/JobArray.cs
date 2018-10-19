using System;
using System.Collections;
namespace HTGSL
{
	public class JobArray : CollectionBase
	{
		public JobInfo this[int index]
		{
			get
			{
				return (JobInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(JobInfo Ji)
		{
			base.List.Add(Ji);
		}
	}
}
