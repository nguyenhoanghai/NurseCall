using System;
using System.Collections;
namespace HTGSL
{
	public class EmployeeArray : CollectionBase
	{
		public EmployeeInfo this[int index]
		{
			get
			{
				return (EmployeeInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(EmployeeInfo Ei)
		{
			base.List.Add(Ei);
		}
	}
}
