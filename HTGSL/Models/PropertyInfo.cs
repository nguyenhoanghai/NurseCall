using System;
namespace HTGSL
{
	public class PropertyInfo
	{
		public string strTitle;
		public string strValue;
		public PropertyInfo()
		{
		}
		public PropertyInfo(string str_title, string str_value)
		{
			this.strTitle = str_title;
			this.strValue = str_value;
		}
	}
}
