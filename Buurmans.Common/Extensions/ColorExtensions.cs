using System.Drawing;

namespace Buurmans.Common.Extensions
{
    public static class ColorExtensions
    {
        public static string ToRgbString(this Color color)
        {
            return $"Color [R={color.R}, G={color.G}, B={color.B}]";
        }
    }
}
