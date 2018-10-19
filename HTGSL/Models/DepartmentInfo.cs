using System;
namespace HTGSL
{
	public class DepartmentInfo
	{
		public int iDepartmentID;
		public string strDepartmentName;
		public string strNote;
		public DepartmentInfo()
		{
		}
		public DepartmentInfo(int i_department_id, string str_department_name, string str_note)
		{
			this.iDepartmentID = i_department_id;
			this.strDepartmentName = str_department_name;
			this.strNote = str_note;
		}
	}
}
