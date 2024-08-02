using System;
using Buurmans.Common.Enums;

namespace Buurmans.Common.Interfaces;

public interface ILogger
{
	void Info(string message);

	void Warning(string message);
	
	void Error(Exception exception);

	void SetLogLevels(LogLevelType logLevelType);
}