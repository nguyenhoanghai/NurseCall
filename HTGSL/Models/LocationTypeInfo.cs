using System;
namespace HTGSL
{
	public class LocationTypeInfo
	{
		public int iTypeID;
		public string strTypeName;
		public string strNote;
		public LocationTypeInfo()
		{
		}
		public LocationTypeInfo(int i_type_id, string str_type_name, string str_note)
		{
			this.iTypeID = i_type_id;
			this.strTypeName = str_type_name;
			this.strNote = str_note;
		}
	}
}
