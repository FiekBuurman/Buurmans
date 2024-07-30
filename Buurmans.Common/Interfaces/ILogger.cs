using System;
using Buurmans.Common.Enums;

namespace Buurmans.Common.Interfaces;

public interface ILogger
{
	void Info(string message, params object[] objects);

	void Warning(string message, params object[] objects);

	void Error(string message, params object[] objects);
	
	void Error(Exception exception);

	void SetLogLevels(LogLevelType logLevelType);
}