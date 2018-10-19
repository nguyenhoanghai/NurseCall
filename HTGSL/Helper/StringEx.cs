using System;
using System.Text;
namespace HTGSL
{
	public class StringEx
	{
		public static string ProperCase(string s)
		{
			s = s.ToLower();
			string text = "";
			char[] separator = new char[]
			{
				' '
			};
			string[] array = s.Split(separator);
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				text += char.ToUpper(text2[0]);
				text = text + text2.Substring(1, text2.Length - 1) + ' ';
			}
			return text;
		}
		public static bool IsStrNumber(string str)
		{
			bool result;
			if (str == string.Empty)
			{
				result = false;
			}
			else
			{
				int num = 0;
				bool flag = true;
				while (num < str.Length && flag)
				{
					if (!char.IsNumber(str, num))
					{
						flag = false;
					}
					else
					{
						num++;
					}
				}
				result = flag;
			}
			return result;
		}
		public static bool IsNumberRange(int iNumber, int iNumberMin, int iNumberMax)
		{
			return iNumber >= iNumberMin && iNumber <= iNumberMax;
		}
		public static bool IsDate(int iDay, int iMonth, int iYear)
		{
			return StringEx.IsNumberRange(iMonth, 1, 12) && StringEx.IsNumberRange(iYear, 1945, 2025) && StringEx.IsNumberRange(iDay, 1, StringEx.GetLastDay(iMonth, iYear));
		}
		public static bool IsStrDate(string strText)
		{
			bool result;
			if (strText.Length != 10)
			{
				result = false;
			}
			else
			{
				string text = strText.Substring(0, 2).Trim();
				if (!StringEx.IsStrNumber(text))
				{
					result = false;
				}
				else
				{
					int num = int.Parse(text);
					if (num == 0)
					{
						result = false;
					}
					else
					{
						string text2 = strText.Substring(3, 2).Trim();
						if (!StringEx.IsStrNumber(text2))
						{
							result = false;
						}
						else
						{
							int num2 = int.Parse(text2);
							if (num2 == 0)
							{
								result = false;
							}
							else
							{
								string text3 = strText.Substring(6, 4).Trim();
								if (!StringEx.IsStrNumber(text3))
								{
									result = false;
								}
								else
								{
									int num3 = int.Parse(text3);
									result = (num3 != 0 && StringEx.IsDate(num, num2, num3));
								}
							}
						}
					}
				}
			}
			return result;
		}
		public static int GetLastDay(int iMonth, int iYear)
		{
			int num = 31;
			switch (iMonth)
			{
			case 2:
				num = 28;
				if (iYear % 400 == 0 || (iYear % 4 == 0 && iYear % 100 != 0))
				{
					num++;
				}
				return num;

			case 3:
			case 5:
				return num;

			case 4:
			case 6:
				break;

			default:
				switch (iMonth)
				{
				case 9:
				case 11:
					break;

				case 10:
					return num;

				default:
					return num;
				}
				break;
			}
			num = 30;
			return num;
		}
		public static DateTime GetDate(string strText)
		{
			DateTime now = DateTime.Now;
			int length = strText.Length;
			DateTime result;
			if (length != 10)
			{
				result = now;
			}
			else
			{
				string text = strText.Substring(0, 2).Trim();
				if (!StringEx.IsStrNumber(text))
				{
					result = now;
				}
				else
				{
					int num = int.Parse(text);
					string text2 = strText.Substring(3, 2).Trim();
					if (!StringEx.IsStrNumber(text2))
					{
						result = now;
					}
					else
					{
						int num2 = int.Parse(text2);
						string text3 = strText.Substring(6, 4).Trim();
						if (!StringEx.IsStrNumber(text3))
						{
							result = now;
						}
						else
						{
							int num3 = int.Parse(text3);
							if (!StringEx.IsDate(num, num2, num3))
							{
								result = now;
							}
							else
							{
								result = new DateTime(num3, num2, num);
							}
						}
					}
				}
			}
			return result;
		}
		public static string GetStringDateRange(string str_all_dates, string str_from_date, bool b_from_date, DateTime dt_from_date, string str_to_date, bool b_to_date, DateTime dt_to_date)
		{
			string text = b_from_date ? dt_from_date.ToString("dd/MM/yyyy") : " ";
			string text2 = b_to_date ? dt_to_date.ToString("dd/MM/yyyy") : " ";
			string result;
			if (b_from_date)
			{
				if (b_to_date)
				{
					result = string.Concat(new string[]
					{
						str_from_date,
						": ",
						text,
						" ... ",
						str_to_date,
						": ",
						text2,
						"."
					});
				}
				else
				{
					result = str_from_date + ": " + text + ".";
				}
			}
			else
			{
				if (b_to_date)
				{
					result = str_to_date + ": " + text2 + ".";
				}
				else
				{
					result = str_all_dates + ".";
				}
			}
			return result;
		}
		public static string CutBlanks(string strSource)
		{
			string text = "";
			string text2 = strSource.Trim();
			bool flag = false;
			bool flag2 = true;
			string text3 = text2;
			int i = 0;
			while (i < text3.Length)
			{
				char c = text3[i];
				char c2 = c;
				switch (c2)
				{
				case ' ':
					if (!flag2)
					{
						flag2 = true;
						text += c.ToString();
					}
					break;

				case '!':
					goto IL_69;

				case '"':
					break;

				default:
					if (c2 != '\'')
					{
						goto IL_69;
					}
					break;
				}
				IL_A7:
				i++;
				continue;
				goto IL_A7;
				IL_69:
				if (flag2)
				{
					flag2 = false;
				}
				if (!flag)
				{
					flag = true;
					text += c.ToString().ToUpper();
				}
				else
				{
					text += c.ToString();
				}
				goto IL_A7;
			}
			return text;
		}
		public static string CutBlanksUpper(string strSource)
		{
			string text = strSource.Trim();
			bool flag = true;
			string text2 = "";
			string text3 = text;
			int i = 0;
			while (i < text3.Length)
			{
				char c = text3[i];
				char c2 = c;
				switch (c2)
				{
				case ' ':
					if (!flag)
					{
						flag = true;
						text2 += c.ToString();
					}
					break;

				case '!':
					goto IL_65;

				case '"':
					break;

				default:
					if (c2 != '\'')
					{
						goto IL_65;
					}
					break;
				}
				IL_9F:
				i++;
				continue;
				goto IL_9F;
				IL_65:
				if (flag)
				{
					flag = false;
					text2 += c.ToString().ToUpper();
				}
				else
				{
					text2 += c.ToString().ToLower();
				}
				goto IL_9F;
			}
			return text2;
		}
		public static string CutBlanksAllUpper(string strSource)
		{
			string text = strSource.Trim();
			bool flag = true;
			string text2 = "";
			string text3 = text;
			int i = 0;
			while (i < text3.Length)
			{
				char c = text3[i];
				char c2 = c;
				switch (c2)
				{
				case ' ':
					if (!flag)
					{
						flag = true;
						text2 += c.ToString();
					}
					break;

				case '!':
					goto IL_62;

				case '"':
					break;

				default:
					if (c2 != '\'')
					{
						goto IL_62;
					}
					break;
				}
				IL_83:
				i++;
				continue;
				goto IL_83;
				IL_62:
				if (flag)
				{
					flag = false;
				}
				text2 += c.ToString().ToUpper();
				goto IL_83;
			}
			return text2;
		}
		public static string CutBlanksAllLower(string strSource)
		{
			string text = strSource.Trim();
			bool flag = true;
			string text2 = "";
			string text3 = text;
			int i = 0;
			while (i < text3.Length)
			{
				char c = text3[i];
				char c2 = c;
				switch (c2)
				{
				case ' ':
					if (!flag)
					{
						flag = true;
						text2 += c.ToString();
					}
					break;

				case '!':
					goto IL_62;

				case '"':
					break;

				default:
					if (c2 != '\'')
					{
						goto IL_62;
					}
					break;
				}
				IL_83:
				i++;
				continue;
				goto IL_83;
				IL_62:
				if (flag)
				{
					flag = false;
				}
				text2 += c.ToString().ToLower();
				goto IL_83;
			}
			return text2;
		}
		private static int RandomNumber(int i_min, int i_max)
		{
			Random random = new Random();
			return random.Next(i_min, i_max);
		}
		private static string RandomString(int i_size, bool b_lower_case)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random();
			for (int i = 0; i < i_size; i++)
			{
				char value = Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0)));
				stringBuilder.Append(value);
			}
			string result;
			if (b_lower_case)
			{
				result = stringBuilder.ToString().ToLower();
			}
			else
			{
				result = stringBuilder.ToString();
			}
			return result;
		}
		public static string GetRegisterCode()
		{
			string text = StringEx.RandomNumber(0, 99999).ToString("00000");
			string str = StringEx.RandomString(1, false);
			return text.Substring(0, 3) + str + text.Substring(3, 2);
		}
		public static bool IsStrNumberFull(string str, int i_length)
		{
			bool result;
			if (str == string.Empty)
			{
				result = false;
			}
			else
			{
				if (str.Length != i_length)
				{
					result = false;
				}
				else
				{
					int num = 0;
					bool flag = true;
					while (num < str.Length && flag)
					{
						if (!char.IsNumber(str, num))
						{
							flag = false;
						}
						else
						{
							num++;
						}
					}
					result = flag;
				}
			}
			return result;
		}
		public static bool IsRegisterCode(string strTest)
		{
			bool result;
			if (strTest.Length != 6)
			{
				result = false;
			}
			else
			{
				string str = strTest.Substring(0, 3);
				if (!StringEx.IsStrNumberFull(str, 3))
				{
					result = false;
				}
				else
				{
					string s = strTest.Substring(3, 1);
					if (!char.IsLetter(s, 0))
					{
						result = false;
					}
					else
					{
						string str2 = strTest.Substring(4, 2);
						result = StringEx.IsStrNumberFull(str2, 2);
					}
				}
			}
			return result;
		}
	}
}
