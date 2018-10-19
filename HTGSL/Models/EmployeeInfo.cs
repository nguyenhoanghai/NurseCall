using System;
namespace HTGSL
{
	public class EmployeeInfo
	{
		public int iEmployeeID;
		public string strFirstName;
		public string strLastName;
		public bool bMenOrWomen;
		public DateTime dtBirthDate;
		public string strTitle;
		public int iDepartmentID;
		public string strDepartmentName;
		public int iJobID;
		public string strJobName;
		public DateTime dtHireDate;
		public string strAddress;
		public string strCity;
		public string strPhone;
		public string strNote;
		public EmployeeInfo()
		{
		}
		public EmployeeInfo(int i_employee_id, string str_first_name, string str_last_name, bool b_men_or_women, DateTime dt_birth_date, string str_title, int i_department_id, string str_department_name, int i_job_id, string str_job_name, DateTime dt_hire_date, string str_address, string str_city, string str_phone, string str_note)
		{
			this.iEmployeeID = i_employee_id;
			this.strFirstName = str_first_name;
			this.strLastName = str_last_name;
			this.dtBirthDate = dt_birth_date;
			this.bMenOrWomen = b_men_or_women;
			this.strTitle = str_title;
			this.iDepartmentID = i_department_id;
			this.strDepartmentName = str_department_name;
			this.iJobID = i_job_id;
			this.strJobName = str_job_name;
			this.dtHireDate = dt_hire_date;
			this.strAddress = str_address;
			this.strCity = str_city;
			this.strPhone = str_phone;
			this.strNote = str_note;
		}
	}
}
