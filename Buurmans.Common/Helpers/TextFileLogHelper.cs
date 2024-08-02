using System;
using System.IO;

namespace Buurmans.Common.Helpers;

internal static class TextFileLogHelper
{
	public static string GetOrCreateLogFileFullPath()
	{
		var logFileFullPath =
			Path.Combine(GetLogsFolder(), $"{DateTime.Now:yyyy-MM-dd}-{GetUserOrComputerName()}.log");

		if (!File.Exists(logFileFullPath))
			File.Create(logFileFullPath).Dispose();

		return logFileFullPath;
	}

	private static string GetUserOrComputerName()
	{
		string returnName;
		try
		{
			if (string.IsNullOrEmpty(Environment.UserName))
			{
				returnName = $"({Environment.MachineName})";
			}

			returnName = $"({Environment.UserName})";
		}
		catch
		{
			returnName = "(Unknown)";
		}

		return returnName;
	}

	private static string GetLogsFolder() =>
		Directory.CreateDirectory(
			Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Log\\{DateTime.Now:yyyyMM}")).FullName;
}