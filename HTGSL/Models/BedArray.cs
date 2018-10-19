using System;
using System.Collections;
namespace HTGSL
{
	public class BedArray : CollectionBase
	{
		public BedInfo this[int index]
		{
			get
			{
				return (BedInfo)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public void Add(BedInfo Bi)
		{
			base.List.Add(Bi);
		}
	}
}
