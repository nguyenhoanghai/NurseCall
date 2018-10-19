using System;
using System.Collections;
namespace HTGSL
{
	public class PropertyArray : CollectionBase
	{
		public PropertyInfo this[int index]
		{
			get
			{
				return (PropertyInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(PropertyInfo Pi)
		{
			base.List.Add(Pi);
		}
	}
}
