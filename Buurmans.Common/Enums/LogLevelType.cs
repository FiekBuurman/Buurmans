using System;

namespace Buurmans.Common.Enums;

[Flags]
public enum LogLevelType
{
	NoLog = 0,
	Info = 1,
	Warning = 2,
	Error = 4,
	All = Info | Warning | Error
}