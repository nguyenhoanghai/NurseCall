using System;
using System.Collections;
namespace HTGSL
{
	public class DepartmentArray : CollectionBase
	{
		public DepartmentInfo this[int index]
		{
			get
			{
				return (DepartmentInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(DepartmentInfo Di)
		{
			base.List.Add(Di);
		}
	}
}
