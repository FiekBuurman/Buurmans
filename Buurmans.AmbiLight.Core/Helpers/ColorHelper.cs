using System;
using System.Collections.Generic;
using System.Drawing;

namespace Buurmans.AmbiLight.Core.Helpers;

internal static class ColorHelper
{
	public static List<Color> CreateAccurateColorList()
	{
		return
		[
			Color.FromArgb(255, 0, 0),
			Color.FromArgb(255, 24, 0),
			Color.FromArgb(255, 48, 0),
			Color.FromArgb(255, 72, 0),
			Color.FromArgb(255, 96, 0),
			Color.FromArgb(255, 120, 0),
			Color.FromArgb(255, 144, 0),
			Color.FromArgb(255, 168, 0),
			Color.FromArgb(255, 192, 0),
			Color.FromArgb(255, 216, 0),
			Color.FromArgb(255, 240, 0),
			Color.FromArgb(255, 255, 0),
			Color.FromArgb(240, 255, 0),
			Color.FromArgb(216, 255, 0),
			Color.FromArgb(192, 255, 0),
			Color.FromArgb(168, 255, 0),
			Color.FromArgb(144, 255, 0),
			Color.FromArgb(120, 255, 0),
			Color.FromArgb(96, 255, 0),
			Color.FromArgb(72, 255, 0),
			Color.FromArgb(48, 255, 0),
			Color.FromArgb(24, 255, 0),
			Color.FromArgb(0, 255, 0),
			Color.FromArgb(0, 255, 24),
			Color.FromArgb(0, 255, 48),
			Color.FromArgb(0, 255, 72),
			Color.FromArgb(0, 255, 96),
			Color.FromArgb(0, 255, 120),
			Color.FromArgb(0, 255, 144),
			Color.FromArgb(0, 255, 168),
			Color.FromArgb(0, 255, 192),
			Color.FromArgb(0, 255, 216),
			Color.FromArgb(0, 255, 240),
			Color.FromArgb(0, 255, 255),
			Color.FromArgb(0, 240, 255),
			Color.FromArgb(0, 216, 255),
			Color.FromArgb(0, 192, 255),
			Color.FromArgb(0, 168, 255),
			Color.FromArgb(0, 144, 255),
			Color.FromArgb(0, 120, 255),
			Color.FromArgb(0, 96, 255),
			Color.FromArgb(0, 72, 255),
			Color.FromArgb(0, 48, 255),
			Color.FromArgb(0, 24, 255),
			Color.FromArgb(0, 0, 255),
			Color.FromArgb(24, 0, 255),
			Color.FromArgb(48, 0, 255),
			Color.FromArgb(72, 0, 255),
			Color.FromArgb(96, 0, 255),
			Color.FromArgb(120, 0, 255),
			Color.FromArgb(144, 0, 255),
			Color.FromArgb(168, 0, 255),
			Color.FromArgb(192, 0, 255),
			Color.FromArgb(216, 0, 255),
			Color.FromArgb(240, 0, 255),
			Color.FromArgb(255, 0, 255),
			Color.FromArgb(255, 0, 240),
			Color.FromArgb(255, 0, 216),
			Color.FromArgb(255, 0, 192),
			Color.FromArgb(255, 0, 168),
			Color.FromArgb(255, 0, 144),
			Color.FromArgb(255, 0, 120),
			Color.FromArgb(255, 0, 96),
			Color.FromArgb(255, 0, 72),
			Color.FromArgb(255, 0, 48),
			Color.FromArgb(255, 0, 24),
			Color.FromArgb(255, 0, 0)
		];
	}

	public static double CalculateColorDistance(Color color1, Color color2)
	{
		var deltaR = color1.R - color2.R;
		var deltaG = color1.G - color2.G;
		var deltaB = color1.B - color2.B;

		return Math.Sqrt(deltaR * deltaR + deltaG * deltaG + deltaB * deltaB);
	}
}