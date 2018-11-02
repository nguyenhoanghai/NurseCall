using  Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Management;
using System.Windows.Forms;
using System.Xml;
namespace HTGSL
{
	public class clsUtl
	{
		private static int iHospital_ID = 1;
		private static int iShift_ID = 1;
		private static int iUser_ID = 1;
		private static string sUser_Name = "Admin";
		private static string sPassword = "";
		private static int iRight = 0;
		private static string sConnectString = "";
		private static bool bConnect_Status = false;
        private static List<string> iUserBedIds = new List<string>();

        public static List<string> UserBedIds
        {
            get
            {
                return iUserBedIds;
            }
            set
            {
                iUserBedIds = value;
            }
        }

		public static int HOSPITAL_ID
		{
			get
			{
				return clsUtl.iHospital_ID;
			}
			set
			{
				clsUtl.iHospital_ID = value;
			}
		}
		public static int SHIFT_ID
		{
			get
			{
				return clsUtl.iShift_ID;
			}
			set
			{
				clsUtl.iShift_ID = value;
			}
		}
		public static int USER_ID
		{
			get
			{
				return clsUtl.iUser_ID;
			}
			set
			{
				clsUtl.iUser_ID = value;
			}
		}
		public static string USER_NAME
		{
			get
			{
				return clsUtl.sUser_Name;
			}
			set
			{
				clsUtl.sUser_Name = value;
			}
		}
		public static string PASSWORD
		{
			get
			{
				return clsUtl.sPassword;
			}
			set
			{
				clsUtl.sPassword = value;
			}
		}
		public static int RIGHT
		{
			get
			{
				return clsUtl.iRight;
			}
			set
			{
				clsUtl.iRight = value;
			}
		}
		public static string CONNECT_STRING
		{
			get
			{
				return clsUtl.GetStringConnect();
			}
			set
			{
				clsUtl.sConnectString = value;
			}
		}
		public static bool CONNECT_STATUS
		{
			get
			{
				bool result;
				try
				{
					SqlConnection sqlConnection = new SqlConnection(clsUtl.CONNECT_STRING);
					sqlConnection.Open();
					if (sqlConnection.State == ConnectionState.Open)
					{
						sqlConnection.Close();
					}
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			}
			set
			{
				clsUtl.bConnect_Status = value;
			}
		}
		public clsUtl()
		{
			clsUtl.sConnectString = clsUtl.GetStringConnect();
		}
		public string ReadDefaultSetting(string strKey)
		{
			string result;
			try
			{
				string text = Settings.Default.Context[strKey].ToString();
				result = text;
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		public void SetDefaultSetting(string strKey, string strValue)
		{
			Settings.Default.Context[strKey] = strValue;
			Settings.Default.Save();
		}
		public static Form IsFormAlreadyOpen(Type FormType)
		{
			Form result;
			foreach (Form form in Application.OpenForms)
			{
				if (form.GetType() == FormType)
				{
					result = form;
					return result;
				}
			}
			result = null;
			return result;
		}
		public static string GetHarewareinfo(int Type)
		{
			string result = "";
			switch (Type)
			{
			case 1:
				{
					ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_Processor");
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ManagementObject managementObject = (ManagementObject)enumerator.Current;
							foreach (PropertyData current in managementObject.Properties)
							{
								if (current.Name == "ProcessorId")
								{
									if (current.Value != null && current.Value.ToString() != "")
									{
										result = current.Value.ToString();
									}
								}
							}
						}
					}
					break;
				}

			case 2:
				{
					ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_BIOS");
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ManagementObject managementObject = (ManagementObject)enumerator.Current;
							foreach (PropertyData current in managementObject.Properties)
							{
								if (current.Name == "SerialNumber")
								{
									if (current.Value != null && current.Value.ToString() != "")
									{
										result = current.Value.ToString();
									}
								}
							}
						}
					}
					break;
				}
			}
			return result;
		}
		private static string GetStringConnect()
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
		public static void WriteLog(string logMessage)
		{
			using (StreamWriter streamWriter = File.AppendText("log.txt"))
			{
				streamWriter.WriteLine(DateTime.Now.ToString("hh:mm:ss tt") + " --> " + logMessage);
			}
		}
		public static void ReadLog()
		{
			using (StreamReader streamReader = File.OpenText("log.txt"))
			{
				string value;
				while ((value = streamReader.ReadLine()) != null)
				{
					Console.WriteLine(value);
				}
			}
		}
	}
}
