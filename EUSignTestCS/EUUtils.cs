using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using EUSignCP;

namespace EUSignTestCS
{
	class EUUtils
	{
		public static bool ReadFile(string fileName, out byte[] byteArray)
		{
			byteArray = null;

			try
			{
				byteArray = File.ReadAllBytes(fileName);

				return true;
			}
			catch (Exception)
			{
				EUSignCPOwnGUI.ShowError(IEUSignCP.EU_ERROR_BAD_PARAMETER);
			}

			return false;
		}

		public static bool WriteFile(string fileName, byte[] byteArray)
		{
			try
			{
				FileStream fileStream = new FileStream(fileName,
					FileMode.Create, FileAccess.Write);

				fileStream.Write(byteArray, 0, byteArray.Length);
				fileStream.Close();

				return true;
			}
			catch (Exception)
			{
				EUSignCPOwnGUI.ShowError(IEUSignCP.EU_ERROR_BAD_PARAMETER);

				return false;
			}
		}

		public static string DateToString(IEUSignCP.SYSTEMTIME time)
		{
			try
			{
				DateTime date = new DateTime((int)time.wYear, 
					(int)time.wMonth, (int)time.wDay, (int)time.wHour,
					(int)time.wMinute, (int)time.wSecond);
				return date.ToString("dd.MM.yyyy HH:mm:ss");
			}
			catch (Exception)
			{
				return "";
			}
		}

		public static IEUSignCP.SYSTEMTIME DateToSystemDate(DateTime date)
		{
			IEUSignCP.SYSTEMTIME systemDate = new IEUSignCP.SYSTEMTIME();

			systemDate.wYear = (short)date.Year;
			systemDate.wMonth = (short)date.Month;
			systemDate.wDay = (short)date.Day;
			systemDate.wHour = (short)date.Hour;
			systemDate.wMinute = (short)date.Minute;
			systemDate.wSecond = (short)date.Second;

			return systemDate;
		}
	}
}
