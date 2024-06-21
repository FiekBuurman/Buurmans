using System;
using System.Globalization;

namespace Buurmans.Common.Extensions
{
    public static class StringExtensions
	{
		public static string AddTimePrefix(this string info) => $"{TimePrefix()}{info}";

		private static string TimePrefix() => DateTime.UtcNow.ToString("[HH:mm:ss.ff] - ", CultureInfo.InvariantCulture);
	}
}
