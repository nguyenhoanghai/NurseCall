using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
	internal class clsDatabase
	{
		public static string gstrServerName = ".";
		public static string gstrDatabase = "ErrorSystem";
		public static string gstrUserID = "sa";
		public static string gstrPassword = "123";
		private string strSql = "";
		private SqlConnection conn;
		private string XMLFilename = Application.StartupPath + "\\DATA.XML";
		public static string gstrcnn = "Server=.;Database=ErrorSystem;uid=sa;pwd=123";
		public clsDatabase()
		{
			clsDatabase.gstrcnn = this.GetStringConnect();
		}
		public string DSLookup(string strFieldResult, string strTableName, string strCriteria)
		{
			string result = "";
			this.conn = new SqlConnection(clsDatabase.gstrcnn);
			this.conn.Open();
			if (strCriteria.Length == 0)
			{
				this.strSql = string.Concat(new string[]
				{
					"Select ",
					strFieldResult,
					" From ",
					strTableName,
					";"
				});
			}
			else
			{
				this.strSql = string.Concat(new string[]
				{
					"Select ",
					strFieldResult,
					" From ",
					strTableName,
					" Where (",
					strCriteria,
					") ;"
				});
			}
			SqlCommand sqlCommand = new SqlCommand(this.strSql, this.conn);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				while (sqlDataReader.Read())
				{
					result = sqlDataReader[0].ToString();
				}
			}
			this.conn.Close();
			this.conn.Dispose();
			this.conn = null;
			return result;
		}
		public void ExcuteSQL(string strSQL)
		{
			try
			{
				this.conn = new SqlConnection(clsDatabase.gstrcnn);
				this.conn.Open();
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = strSQL;
				sqlCommand.Connection = this.conn;
				SqlTransaction sqlTransaction = this.conn.BeginTransaction();
				sqlCommand.Transaction = sqlTransaction;
				try
				{
					sqlCommand.ExecuteNonQuery();
					sqlTransaction.Commit();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					sqlTransaction.Rollback();
				}
				this.conn.Close();
				this.conn.Dispose();
				this.conn = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		public long GetKey(string strTableName)
		{
			long result;
			try
			{
				string text = "TABLE_NAME = '" + strTableName + "'";
				long num = (long)Convert.ToInt32(this.DSLookup("NUMBER", "AUTONUMBER", text));
				long num2 = num + 1L;
				text = string.Concat(new object[]
				{
					"UPDATE AUTONUMBER SET AUTONUMBER.[NUMBER] = ",
					num2,
					" WHERE AUTONUMBER.",
					text
				});
				this.ExcuteSQL(text);
				result = num2;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = 1L;
			}
			return result;
		}
		public string GetStringConnect()
		{
			string result;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(this.XMLFilename);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("SQLServer");
				string innerText = elementsByTagName.Item(0).ChildNodes[0].InnerText;
				string innerText2 = elementsByTagName.Item(0).ChildNodes[1].InnerText;
				string innerText3 = elementsByTagName.Item(0).ChildNodes[2].InnerText;
				string innerText4 = elementsByTagName.Item(0).ChildNodes[3].InnerText;
				clsDatabase.gstrServerName = innerText;
				clsDatabase.gstrDatabase = innerText2;
				clsDatabase.gstrUserID = innerText3;
				clsDatabase.gstrPassword = innerText4;
				clsDatabase.gstrcnn = string.Concat(new string[]
				{
					"Server=",
					innerText,
					";Database=",
					innerText2,
					";uid=",
					innerText3,
					";pwd=",
					innerText4
				});
				result = clsDatabase.gstrcnn;
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		public long GetCustomerID()
		{
			long num = 0L;
			long result;
			try
			{
				this.conn = new SqlConnection(clsDatabase.gstrcnn);
				this.conn.Open();
				this.strSql = "SELECT TOP 1 [STT]  FROM [QLBX].[dbo].[MA_SO] WHERE [DA_DUNG] = 0 ORDER BY [STT]";
				SqlCommand sqlCommand = new SqlCommand(this.strSql, this.conn);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					while (sqlDataReader.Read())
					{
						num = long.Parse(sqlDataReader[0].ToString());
					}
				}
				this.strSql = "UPDATE MA_SO SET [DA_DUNG] = 1 WHERE STT = " + num;
				this.ExcuteSQL(this.strSql);
				result = num;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = 1L;
			}
			return result;
		}
		public bool ReturnCustomerID(long lngNumber)
		{
			bool result;
			try
			{
				this.strSql = "UPDATE MA_SO SET [DA_DUNG] = 0 WHERE STT = " + lngNumber;
				this.ExcuteSQL(this.strSql);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public void LoadSettingValue()
		{
			this.conn = new SqlConnection(clsDatabase.gstrcnn);
			this.conn.Open();
			this.strSql = "SELECT * FROM DEFAULTS;";
			SqlCommand sqlCommand = new SqlCommand(this.strSql, this.conn);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				while (sqlDataReader.Read())
				{
				}
			}
			this.conn.Close();
			this.conn.Dispose();
			this.conn = null;
		}
		public void ShowUserInfor(string nguoitao, string ngaytao, string nguoisua, string ngaysua)
		{
			new F9997
			{
				NGUOI_TAO = nguoitao,
				NGAY_TAO = ngaytao,
				NGUOI_SUA = nguoisua,
				NGAY_SUA = ngaysua
			}.Show();
		}
	}
}
