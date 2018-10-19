using System;
namespace HTGSL
{
	public class JobInfo
	{
		public int iJobID;
		public string strJobName;
		public string strNote;
		public JobInfo()
		{
		}
		public JobInfo(int i_job_id, string str_job_name, string str_note)
		{
			this.iJobID = i_job_id;
			this.strJobName = str_job_name;
			this.strNote = str_note;
		}
	}
}
