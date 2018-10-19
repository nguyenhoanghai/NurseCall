using System;
using System.Windows.Forms;
namespace HTGSL
{
	public class MyMsgBox
	{
		public static void MsgAsterisk(string strMessage)
		{
			MessageBox.Show(strMessage, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		public static void MsgWarning(string strMessage)
		{
			MessageBox.Show(strMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		public static void MsgError(string strMessage)
		{
			MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		public static void MsgErrorTitle(string strMessage, string strTitle)
		{
			MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		public static void MsgInformation(string strMessage, string strTitle)
		{
			MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		public static DialogResult MsgQuestionOKCancel(string strMessage, string strTitle)
		{
			return MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
		}
		public static DialogResult MsgQuestionYesNo(string strMessage, string strTitle)
		{
			return MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
		}
	}
}
