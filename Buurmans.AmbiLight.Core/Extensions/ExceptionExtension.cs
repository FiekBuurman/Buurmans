using System;
using System.Text;

namespace Buurmans.AmbiLight.Core.Extensions
{
    public static class ExceptionExtension
    {
		/// <summary>
		/// Returns all inner exceptions recursive
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		public static string FlattenException(this Exception exception)
		{
			var stringBuilder = new StringBuilder();
			var currentDate = DateTime.Now.ToLongDateString();

			while (exception != null)
			{
				stringBuilder.AppendLine(exception.Message != null
					? $"{currentDate}:\tMessage    :\t{exception.Message}"
					: $"{currentDate}:\tMessage    :\tNo message!");
				stringBuilder.AppendLine(exception.Source != null
					? $"{currentDate}:\tSource     :\t{exception.Source}"
					: $"{currentDate}:\tSource     :\tNo source!");
				stringBuilder.AppendLine(exception.StackTrace != null
					? $"{currentDate}:\tStacktrace :\t{exception.StackTrace.TrimStart()}"
					: $"{currentDate}:\tStacktrace :\tNo Stacktrace!");

				exception = exception.InnerException;
			}

			return stringBuilder.ToString();
		}
    }
}
