using System;
using Buurmans.Common.Enums;

namespace Buurmans.Common.Extensions
{
	public static class LogLevelTypeExtensions
	{
		public static string GetDescription(this LogLevelType logLevelType)
		{
			var description = logLevelType switch
			{
				LogLevelType.NoLog => "nothing",
				LogLevelType.Info => "Info, Warnings && Errors",
				LogLevelType.Warning => "Warnings && Errors",
				LogLevelType.Error => "Errors",
				LogLevelType.All => "Info, Warnings && Errors",
				_ => throw new ArgumentOutOfRangeException(nameof(logLevelType), logLevelType, null)
			};

			return $"Currently logging: {description}.";
		}
	}
}