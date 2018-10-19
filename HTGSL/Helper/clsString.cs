using System;
using System.Globalization;
using System.Text;
namespace HTGSL
{
	public class clsString
	{
		public static byte[] StrToByteArray(string s)
		{
			s = s.Replace(" ", string.Empty);
			byte[] array = new byte[s.Length];
			char[] array2 = new char[s.Length];
			array2 = s.ToCharArray();
			for (int i = 0; i < s.Length; i++)
			{
				array[i] = Convert.ToByte(array2[i]);
			}
			return array;
		}
		public static string ByteArrayToStr(byte[] input)
		{
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			return aSCIIEncoding.GetString(input);
		}
		public static string XOR(string s)
		{
			byte b = 0;
			char[] array = new char[s.Length];
			array = s.ToCharArray();
			for (int i = 0; i < s.Length; i++)
			{
				b ^= Convert.ToByte(array[i]);
			}
			string text = Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' ');
			return text.ToUpper().Trim();
		}
		public static byte XorString(string s)
		{
			s = s.Replace(" ", string.Empty);
			byte b = 0;
			char[] array = new char[s.Length];
			array = s.ToCharArray();
			for (int i = 0; i < s.Length; i++)
			{
				b ^= Convert.ToByte(array[i]);
			}
			return b;
		}
		public static byte XORN(string s)
		{
			byte b = 0;
			char[] array = new char[s.Length];
			array = s.ToCharArray();
			for (int i = 0; i < s.Length; i++)
			{
				b ^= Convert.ToByte(array[i]);
			}
			return b;
		}
		public static string ByteToHex(byte[] comByte)
		{
			StringBuilder stringBuilder = new StringBuilder(comByte.Length * 3);
			for (int i = 0; i < comByte.Length; i++)
			{
				byte value = comByte[i];
				stringBuilder.Append(Convert.ToString(value, 16).PadLeft(2, '0').PadRight(3, ' '));
			}
			return stringBuilder.ToString().ToUpper();
		}
		public static byte[] HexToByte(string msg)
		{
			msg = msg.Replace(" ", "");
			byte[] array = new byte[msg.Length / 2];
			for (int i = 0; i < msg.Length; i += 2)
			{
				array[i / 2] = Convert.ToByte(msg.Substring(i, 2), 16);
			}
			return array;
		}
		public static string GenerateString(int Length, string sinput, int p1, int p2, int p3, int p4, int NumAdd, int pNumAdd)
		{
			string result;
			try
			{
				Random random = new Random((int)DateTime.Now.Ticks);
				string text = "0123456789";
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < Length; i++)
				{
					if (i == p1 - 1)
					{
						string text2 = (Convert.ToInt32(sinput.Substring(0, 1)) + NumAdd).ToString();
						char value = Convert.ToChar(text2.Substring(text2.Length - 1, 1));
						stringBuilder.Append(value);
					}
					else
					{
						if (i == p2 - 1)
						{
							string text2 = (Convert.ToInt32(sinput.Substring(1, 1)) + NumAdd).ToString();
							char value = Convert.ToChar(text2.Substring(text2.Length - 1, 1));
							stringBuilder.Append(value);
						}
						else
						{
							if (i == p3 - 1)
							{
								string text2 = (Convert.ToInt32(sinput.Substring(2, 1)) + NumAdd).ToString();
								char value = Convert.ToChar(text2.Substring(text2.Length - 1, 1));
								stringBuilder.Append(value);
							}
							else
							{
								if (i == p4 - 1)
								{
									string text2 = (Convert.ToInt32(sinput.Substring(3, 1)) + NumAdd).ToString();
									char value = Convert.ToChar(text2.Substring(text2.Length - 1, 1));
									stringBuilder.Append(value);
								}
								else
								{
									if (i == pNumAdd - 1)
									{
										stringBuilder.Append(NumAdd);
									}
									else
									{
										stringBuilder.Append(text.Substring(random.Next(0, text.Length - 1), 1));
									}
								}
							}
						}
					}
				}
				result = stringBuilder.ToString();
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		private static string RandomString(int size, bool lowerCase)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random();
			for (int i = 0; i < size; i++)
			{
				char value = Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0)));
				stringBuilder.Append(value);
			}
			string result;
			if (lowerCase)
			{
				result = stringBuilder.ToString().ToLower();
			}
			else
			{
				result = stringBuilder.ToString();
			}
			return result;
		}
		public string RandomString()
		{
			int num = 6;
			Random random = new Random((int)DateTime.Now.Ticks);
			string text = "0123456789";
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Append(text.Substring(random.Next(0, text.Length - 1), 1));
			}
			return stringBuilder.ToString();
		}
		private int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}
		public string GetPassword()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(clsString.RandomString(4, true));
			stringBuilder.Append(this.RandomNumber(1000, 9999));
			stringBuilder.Append(clsString.RandomString(2, false));
			return stringBuilder.ToString();
		}
		public static string Ascii2HexString(string asciiString)
		{
			string text = "";
			for (int i = 0; i < asciiString.Length; i++)
			{
				char c = asciiString[i];
				int num = (int)c;
				text += string.Format("{0:X2}", Convert.ToUInt32(num.ToString()));
			}
			return text;
		}
		public static string Ascii2HexStringNull(string sInput)
		{
			string text = "";
			for (int i = 0; i < sInput.Length; i++)
			{
				char c = sInput[i];
				int num = (int)c;
				text = text + string.Format("{0:X2}", Convert.ToUInt32(num.ToString())) + " ";
			}
			return text.Trim();
		}
		public static string HexString2Ascii(string hexString)
		{
			StringBuilder stringBuilder = new StringBuilder();
			hexString = hexString.Replace(" ", "");
			hexString = hexString.Replace("-", "");
			for (int i = 0; i <= hexString.Length - 2; i += 2)
			{
				stringBuilder.Append(Convert.ToString(Convert.ToChar(int.Parse(hexString.Substring(i, 2), NumberStyles.HexNumber))));
			}
			return stringBuilder.ToString();
		}
		public static string ConvertHexStringToString(string hexInput, Encoding encoding)
		{
			hexInput = hexInput.Replace(" ", "");
			int length = hexInput.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
			}
			return encoding.GetString(array);
		}
		public static byte[] HexString2Byte(string hex)
		{
			hex = hex.Replace("-", "");
			hex = hex.Replace(" ", "");
			byte[] array = new byte[hex.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
			}
			return array;
		}
		public static string ChangeNum2VNStr(double num)
		{
			string text = num.ToString();
			int num2 = text.IndexOf(".") + text.IndexOf(",") + 1;
			string result;
			if (num2 > 0)
			{
				string num3 = text.Substring(0, num2);
				string num4 = (text + "00").Substring(num2 + 1, 2);
				result = clsString.Num2VNStr(num3) + " phẩy " + clsString.Num2VNStr(num4) + " đồng";
			}
			else
			{
				result = clsString.Num2VNStr(text) + " đồng";
			}
			return result;
		}
		private static string RemoveNumberZero(string pnum)
		{
			int num = 0;
			while (pnum[num].Equals('0'))
			{
				num++;
			}
			return pnum.Substring(num, pnum.Length - num);
		}
		public static string Num2VNStr(string num)
		{
			string text = "";
			if (num.Equals("0"))
			{
				text = "không";
			}
			else
			{
				num = clsString.RemoveNumberZero(num);
				if (num[0].ToString().Equals("-"))
				{
					text = "âm ";
					num = num.Substring(1, num.Length - 1);
				}
				if (num[0].ToString().Equals("+"))
				{
					num = num.Substring(1, num.Length - 1);
				}
				string[] array = new string[]
				{
					"không",
					"một",
					"hai",
					"ba",
					"bốn",
					"năm",
					"sáu",
					"bảy",
					"tám",
					"chín"
				};
				string[] array2 = new string[]
				{
					"",
					"ngàn",
					"triệu",
					"tỷ"
				};
				string text2 = num;
				int length = text2.Length;
				for (int i = 0; i < length; i++)
				{
					string text3 = "";
					int num2 = (length - i - 1) % 3;
					int num3 = int.Parse(text2.Substring(i, 1));
					int num4 = num3;
					switch (num4)
					{
					case 0:
						array[0] = "";
						if (num2 == 0 && length.Equals(1))
						{
							array[0] = "không";
						}
						else
						{
							if (num2 == 1)
							{
								if (text2.Substring(i + 1, 1) != "0")
								{
									array[0] = "lẻ";
								}
							}
							else
							{
								if (num2 == 2)
								{
									if (text2.Substring(i + 1, 1) != "0" || text2.Substring(i + 2, 1) != "0")
									{
										array[0] = "không";
									}
								}
							}
						}
						break;

					case 1:
						if (num2 == 0 && i > 0)
						{
							if (text2.Substring(i - 1, 1) != "1" && text2.Substring(i - 1, 1) != "0")
							{
								array[1] = "mốt";
							}
							else
							{
								array[1] = "một";
							}
						}
						else
						{
							if (num2 == 1)
							{
								array[1] = "mười";
							}
							else
							{
								array[1] = "một";
							}
						}
						break;

					default:
						if (num4 == 5)
						{
							if (num2 == 0 && i != 0)
							{
								if (text2.Substring(i - 1, 1) != "0")
								{
									array[5] = "lăm";
								}
								else
								{
									array[5] = "năm";
								}
							}
							else
							{
								array[5] = "năm";
							}
						}
						break;
					}
					switch (num2)
					{
					case 1:
						if (text2.Substring(i, 1) != "1" && text2.Substring(i, 1) != "0")
						{
							text3 = "mươi";
						}
						break;

					case 2:
						if (i == 0)
						{
							text3 = "trăm";
						}
						else
						{
							if (text2.Substring(i, 1) != "0" || text2.Substring(i + 1, 1) != "0" || text2.Substring(i + 2, 1) != "0")
							{
								text3 = "trăm";
							}
						}
						break;

					default:
						{
							int num5 = (length - i) / 3;
							if (num5 > 3)
							{
								num5 %= 3;
							}
							if (i > 2)
							{
								if (text2.Substring(i - 2, 1) != "0" || text2.Substring(i - 1, 1) != "0" || text2.Substring(i, 1) != "0" || i == text2.Length)
								{
									text3 = array2[num5];
								}
							}
							else
							{
								text3 = array2[num5];
							}
							break;
						}
					}
					if (array[num3] == "")
					{
						text = text.Trim() + " " + text3;
					}
					else
					{
						text = string.Concat(new string[]
						{
							text.Trim(),
							" ",
							array[num3],
							" ",
							text3
						});
					}
				}
			}
			return text.Trim();
		}
		public static string Num2VNUnSign(string num)
		{
			string text = "";
			if (num.Equals("0"))
			{
				text = "khong";
			}
			else
			{
				num = clsString.RemoveNumberZero(num);
				if (num[0].ToString().Equals("-"))
				{
					text = "am ";
					num = num.Substring(1, num.Length - 1);
				}
				if (num[0].ToString().Equals("+"))
				{
					num = num.Substring(1, num.Length - 1);
				}
				string[] array = new string[]
				{
					"khong",
					"mot",
					"hai",
					"ba",
					"bon",
					"nam",
					"sau",
					"bay",
					"tam",
					"chin"
				};
				string[] array2 = new string[]
				{
					"",
					"ngan",
					"trieu",
					"ty"
				};
				string text2 = num;
				int length = text2.Length;
				for (int i = 0; i < length; i++)
				{
					string text3 = "";
					int num2 = (length - i - 1) % 3;
					int num3 = int.Parse(text2.Substring(i, 1));
					int num4 = num3;
					switch (num4)
					{
					case 0:
						array[0] = "";
						if (num2 == 0 && length.Equals(1))
						{
							array[0] = "khong";
						}
						else
						{
							if (num2 == 1)
							{
								if (text2.Substring(i + 1, 1) != "0")
								{
									array[0] = "lẻ";
								}
							}
							else
							{
								if (num2 == 2)
								{
									if (text2.Substring(i + 1, 1) != "0" || text2.Substring(i + 2, 1) != "0")
									{
										array[0] = "khong";
									}
								}
							}
						}
						break;

					case 1:
						if (num2 == 0 && i > 0)
						{
							if (text2.Substring(i - 1, 1) != "1" && text2.Substring(i - 1, 1) != "0")
							{
								array[1] = "mot1";
							}
							else
							{
								array[1] = "mot";
							}
						}
						else
						{
							if (num2 == 1)
							{
								array[1] = "muoi2";
							}
							else
							{
								array[1] = "mot";
							}
						}
						break;

					default:
						if (num4 == 5)
						{
							if (num2 == 0 && i != 0)
							{
								if (text2.Substring(i - 1, 1) != "0")
								{
									array[5] = "lam";
								}
								else
								{
									array[5] = "nam";
								}
							}
							else
							{
								array[5] = "nam";
							}
						}
						break;
					}
					switch (num2)
					{
					case 1:
						if (text2.Substring(i, 1) != "1" && text2.Substring(i, 1) != "0")
						{
							text3 = "muoi";
						}
						break;

					case 2:
						if (i == 0)
						{
							text3 = "tram";
						}
						else
						{
							if (text2.Substring(i, 1) != "0" || text2.Substring(i + 1, 1) != "0" || text2.Substring(i + 2, 1) != "0")
							{
								text3 = "tram";
							}
						}
						break;

					default:
						{
							int num5 = (length - i) / 3;
							if (num5 > 3)
							{
								num5 %= 3;
							}
							if (i > 2)
							{
								if (text2.Substring(i - 2, 1) != "0" || text2.Substring(i - 1, 1) != "0" || text2.Substring(i, 1) != "0" || i == text2.Length)
								{
									text3 = array2[num5];
								}
							}
							else
							{
								text3 = array2[num5];
							}
							break;
						}
					}
					if (array[num3] == "")
					{
						text = text.Trim() + " " + text3;
					}
					else
					{
						text = string.Concat(new string[]
						{
							text.Trim(),
							" ",
							array[num3],
							" ",
							text3
						});
					}
				}
			}
			return text.Trim();
		}
	}
}
