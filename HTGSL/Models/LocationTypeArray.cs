using System;
using System.Collections;
namespace HTGSL
{
	public class LocationTypeArray : CollectionBase
	{
		public LocationTypeInfo this[int index]
		{
			get
			{
				return (LocationTypeInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(LocationTypeInfo LTi)
		{
			base.List.Add(LTi);
		}
	}
}
