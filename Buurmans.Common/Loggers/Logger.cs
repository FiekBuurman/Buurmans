using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Buurmans.Common.Enums;
using Buurmans.Common.Extensions;
using Buurmans.Common.Helpers;
using Buurmans.Common.Interfaces;

namespace Buurmans.Common.Loggers;

public class Logger : ILogger
{
	private string _logFileFullPath = string.Empty;
	private LogLevelType _logLevelType = LogLevelType.All;

	public void Info(string message) => LogMessage(LogLevelType.Info, message);

	public void Warning(string message) => LogMessage(LogLevelType.Warning, message);

	public void Error(Exception exception) => LogMessage(LogLevelType.Error, exception.FlattenException());

	public void SetLogLevels(LogLevelType logLevelType)
	{
		_logLevelType = logLevelType;
		LogMessage(LogLevelType.All, $"LogLevelType set to: {logLevelType}");
	}

	private void LogMessage(LogLevelType logLevelType, string message)
	{
		var formattedMessage = CreateLogMessage(logLevelType, message);

		if (IsDebugMode())
			Trace.WriteLine(formattedMessage);

		if (!ShouldLog(logLevelType))
			return;

		EnsureLogFile();
		_ = AppendLogAsync(formattedMessage);
	}

	private string CreateLogMessage(LogLevelType logLevelType, string message)
	{
		return $"{logLevelType}: {message.AddTimePrefix()}";
	}

	private async Task AppendLogAsync(string message)
	{
		const int maxRetries = 10;
		for (var retry = 0; retry < maxRetries; retry++)
		{
			try
			{
				using var streamWriter = new StreamWriter(_logFileFullPath, append: true);
				await streamWriter.WriteLineAsync(message);
				break;
			}
			catch (IOException)
			{
				await Task.Delay(100);
			}
			catch (Exception ex)
			{
				Trace.WriteLine($"Error writing to log file: {ex.Message}");
				Trace.WriteLine(ex.StackTrace);
				break;
			}
		}
	}

	private bool ShouldLog(LogLevelType messageLogLevel)
	{
		return messageLogLevel == LogLevelType.All || _logLevelType switch
		{
			LogLevelType.NoLog => false,
			LogLevelType.All => true,
			LogLevelType.Error => messageLogLevel == LogLevelType.Error,
			LogLevelType.Info => messageLogLevel is LogLevelType.Info or LogLevelType.Warning or LogLevelType.Error,
			LogLevelType.Warning => messageLogLevel is LogLevelType.Warning or LogLevelType.Error,
			_ => throw new ArgumentOutOfRangeException(nameof(_logLevelType), _logLevelType, "Invalid log level type.")
		};
	}

	private void EnsureLogFile()
	{
		if (string.IsNullOrEmpty(_logFileFullPath) || !File.Exists(_logFileFullPath))
		{
			_logFileFullPath = TextFileLogHelper.GetOrCreateLogFileFullPath();
		}
	}

	private static bool IsDebugMode()
	{
#if DEBUG
		return true;
#else
            return false;
#endif
	}
}