using System;
using System.Globalization;

namespace ScreenAmbiLightToMQTT.Core.Extensions
{
    internal static class StringExtensions
    {
		public static string AddTimePrefix(this string info) => TimePrefix() + info;

		private static string TimePrefix() => DateTime.UtcNow.ToString("[HH:mm:ss.ff] - ", CultureInfo.InvariantCulture);
	}
}
