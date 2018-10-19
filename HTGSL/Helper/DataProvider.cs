using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
	internal class DataProvider
	{
		public SqlConnection connection;
		public SqlDataAdapter da;
		public SqlCommand command;
		private DataSet ds;
		protected static string connectionString;
		public static string ConnectionString
		{
			get
			{
				return DataProvider.connectionString;
			}
			set
			{
				DataProvider.connectionString = value;
			}
		}
		public DataProvider()
		{
			DataProvider.ConnectionString = this.GetStringConnect();
			this.connection = new SqlConnection(DataProvider.ConnectionString);
		}
		public void connect()
		{
			this.connection = new SqlConnection(DataProvider.ConnectionString);
			if (this.connection.State == ConnectionState.Closed)
			{
				this.connection.Open();
			}
		}
		public void disconnect()
		{
			if (this.connection.State == ConnectionState.Open)
			{
				this.connection.Close();
			}
		}
		public SqlDataReader excuteQuery(string sqlString)
		{
			SqlDataReader result;
			try
			{
				this.connect();
				this.command = new SqlCommand(sqlString, this.connection);
				result = this.command.ExecuteReader();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public void excuteNonQuery(string sqlString)
		{
			try
			{
				this.connect();
				this.command = new SqlCommand(sqlString, this.connection);
				SqlTransaction sqlTransaction = this.connection.BeginTransaction();
				this.command.Transaction = sqlTransaction;
				try
				{
					this.command.ExecuteNonQuery();
					sqlTransaction.Commit();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString(), "excuteNonQuery", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					sqlTransaction.Rollback();
				}
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
			finally
			{
				this.disconnect();
			}
		}
		public void excuteNonTran(string sqlString)
		{
			try
			{
				this.connect();
				this.command = new SqlCommand(sqlString, this.connection);
				this.command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.disconnect();
			}
		}
		public object excuteScalar(string sqlString)
		{
			this.command = new SqlCommand(sqlString, this.connection);
			return this.command.ExecuteScalar();
		}
		public DataSet execute(string sqlString)
		{
			DataSet result;
			try
			{
				this.da = new SqlDataAdapter(sqlString, this.connection);
				this.ds = new DataSet();
				this.da.Fill(this.ds);
				result = this.ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.disconnect();
			}
			return result;
		}
		public DataSet execute(string sqlString, string tablename)
		{
			DataSet result;
			try
			{
				this.da = new SqlDataAdapter(sqlString, this.connection);
				this.ds = new DataSet();
				this.da.Fill(this.ds, tablename);
				result = this.ds;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.disconnect();
			}
			return result;
		}
		public DataTable GetDs(string sqlString)
		{
			DataTable result;
			try
			{
				this.connect();
				this.da = new SqlDataAdapter(sqlString, this.connection);
				this.ds = new DataSet();
				this.da.Fill(this.ds);
				result = this.ds.Tables[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.disconnect();
			}
			return result;
		}
		public DataTable GetDs(string sqlString, string tablename)
		{
			DataTable result;
			try
			{
				this.connect();
				this.da = new SqlDataAdapter(sqlString, this.connection);
				this.ds = new DataSet();
				this.da.Fill(this.ds, tablename);
				result = this.ds.Tables[tablename];
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.disconnect();
			}
			return result;
		}
		public string GetStringConnect()
		{
			string result;
			try
			{
				string filename = Application.StartupPath + "\\DATA.XML";
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(filename);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("SQLServer");
				string innerText = elementsByTagName.Item(0).ChildNodes[0].InnerText;
				string innerText2 = elementsByTagName.Item(0).ChildNodes[1].InnerText;
				string innerText3 = elementsByTagName.Item(0).ChildNodes[2].InnerText;
				string innerText4 = elementsByTagName.Item(0).ChildNodes[3].InnerText;
				string text = string.Concat(new string[]
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
				result = text;
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		public long GetKey(string strTableName)
		{
			long num = 0L;
			long num2 = 0L;
			long result;
			try
			{
				string sqlString = "SELECT NUMBER FROM AUTONUMBER WHERE TABLE_NAME = '" + strTableName + "'";
				SqlDataReader sqlDataReader = this.excuteQuery(sqlString);
				if (sqlDataReader.HasRows)
				{
					while (sqlDataReader.Read())
					{
						num = (long)Convert.ToInt32(sqlDataReader["NUMBER"].ToString());
					}
					num2 = num + 1L;
					sqlString = string.Concat(new object[]
					{
						"UPDATE AUTONUMBER SET [NUMBER] = ",
						num2,
						" WHERE [TABLE_NAME] = '",
						strTableName,
						"'"
					});
					this.excuteNonQuery(sqlString);
				}
				result = num2;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = 1L;
			}
			return result;
		}
		public string DSLookup(string strFieldResult, string strTableName, string strCriteria)
		{
			string text = "";
			string result;
			try
			{
				string sqlString;
				if (strCriteria.Length == 0)
				{
					sqlString = string.Concat(new string[]
					{
						"SELECT ",
						strFieldResult,
						" FROM ",
						strTableName,
						";"
					});
				}
				else
				{
					sqlString = string.Concat(new string[]
					{
						"SELECT ",
						strFieldResult,
						" FROM ",
						strTableName,
						" WHERE (",
						strCriteria,
						") ;"
					});
				}
				this.connect();
				SqlDataReader sqlDataReader = this.excuteQuery(sqlString);
				if (sqlDataReader.HasRows)
				{
					while (sqlDataReader.Read())
					{
						text = sqlDataReader[0].ToString();
					}
				}
				this.disconnect();
				result = text;
			}
			catch (Exception)
			{
				this.disconnect();
				result = "";
			}
			return result;
		}
	}
}
