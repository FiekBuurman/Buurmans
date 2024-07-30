using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
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

    public void Info(string message, params object[] objects) => LogMessage(LogLevelType.Info, message, objects);

    public void Warning(string message, params object[] objects) => LogMessage(LogLevelType.Warning, message, objects);

    public void Error(string message, params object[] objects) => LogMessage(LogLevelType.Error, message, objects);

    public void Error(Exception exception) => LogMessage(LogLevelType.Error, exception.FlattenException());

    public void SetLogLevels(LogLevelType logLevelType) => _logLevelType = logLevelType;

    private void LogMessage(LogLevelType logLevelType, string message, params object[] objects)
    {
        if (!ShouldLog(logLevelType))
            return;

        EnsureLogFile();
        Task.Run(() => TryAppendText(string.Format(message, objects)));
    }

	private bool ShouldLog(LogLevelType messageLogLevel)
	{
		return _logLevelType switch
		{
			LogLevelType.NoLog => false,
			LogLevelType.All => true,
			LogLevelType.Error => messageLogLevel == LogLevelType.Error,
            LogLevelType.Info => messageLogLevel is LogLevelType.Info or LogLevelType.Warning or LogLevelType.Error,
			LogLevelType.Warning => messageLogLevel is LogLevelType.Warning or LogLevelType.Error,
			
			_ => throw new ArgumentOutOfRangeException(nameof(_logLevelType), _logLevelType, "Invalid log level type.")
		};
	}
    
    private void TryAppendText(string message)
    {
        var retryCount = 0;
        const int maxRetries = 10;

        while (retryCount < maxRetries)
        {
            try
			{
				using var streamWriter = new StreamWriter(_logFileFullPath, append: true);
				streamWriter.WriteLine(message.AddTimePrefix());
				break;
			}
            catch (IOException)
            {
                retryCount++;
                Thread.Sleep(500); // Wait for the file to be released by the previous thread
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error writing to log file: {ex.Message}");
                Trace.WriteLine(ex.StackTrace);
                break;
            }
        }
    }

    private void EnsureLogFile()
    {
        if (string.IsNullOrEmpty(_logFileFullPath) || !File.Exists(_logFileFullPath))
        {
            _logFileFullPath = TextFileLogHelper.GetOrCreateLogFileFullPath();
        }
    }
}
