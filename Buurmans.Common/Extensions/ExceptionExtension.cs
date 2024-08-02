using System;
using System.Net;
using System.Text;

namespace Buurmans.Common.Extensions;

public static class ExceptionExtension
{
	public static string FlattenException(this Exception exception)
	{
		if (exception == null)
			return string.Empty;

		var stringBuilder = new StringBuilder("\r");
		stringBuilder.AppendLine("-------------------------------------------------------------------");
        var currentDate = DateTime.Now.ToLongDateString();
		
        while (exception != null)
		{
			stringBuilder.AppendLine(
				$"{currentDate}:\tTime    :\t{DateTime.Now.ToLongTimeString()}");
			stringBuilder.AppendLine(
				$"{currentDate}:\tComputer    :\t{Dns.GetHostName()}");
				stringBuilder.AppendLine(exception.Message != null
				? $"{currentDate}:\tMessage    :\t{exception.Message}"
				: $"{currentDate}:\tMessage    :\tNo Message!");
			stringBuilder.AppendLine(exception.Source != null
				? $"{currentDate}:\tSource     :\t{exception.Source}"
				: $"{currentDate}:\tSource     :\tNo Source!");
			stringBuilder.AppendLine(exception.TargetSite != null
				? $"{currentDate}:\tMethod     :\t{exception.TargetSite.Name}"
				: $"{currentDate}:\tMethod     :\tNo Method!");
            stringBuilder.AppendLine(exception.StackTrace != null
				? $"{currentDate}:\tStacktrace :\t{exception.StackTrace.TrimStart()}"
				: $"{currentDate}:\tStacktrace :\tNo Stacktrace!");

			exception = exception.InnerException;
		}

		stringBuilder.AppendLine("-------------------------------------------------------------------");
        return stringBuilder.ToString();
	}
}