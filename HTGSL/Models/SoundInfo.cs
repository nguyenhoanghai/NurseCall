using System;
using System.Runtime.InteropServices;
using System.Text;
namespace HTGSL
{
	public static class SoundInfo
	{
		[DllImport("winmm.dll")]
		private static extern uint mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);
		public static int GetSoundLength(string fileName)
		{
			int result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(32);
				SoundInfo.mciSendString(string.Format("open \"{0}\" type waveaudio alias wave", fileName), null, 0, IntPtr.Zero);
				SoundInfo.mciSendString("status wave length", stringBuilder, stringBuilder.Capacity, IntPtr.Zero);
				SoundInfo.mciSendString("close wave", null, 0, IntPtr.Zero);
				int num = 0;
				int.TryParse(stringBuilder.ToString(), out num);
				result = num;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
	}
}
