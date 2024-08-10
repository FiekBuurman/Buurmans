using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Buurmans.AmbiLight.Core.Interfaces;

namespace Buurmans.AmbiLight.Core.Services;

internal class ColorCalculationService(
	IAmbiLightConfigurationProvider settingsProvider
	) : IColorCalculationService
{
	private IEnumerable<Color> _colors = CreateDefaultColorList();

	public Color CalculateAverageColor(Bitmap bitmap)
	{
		var settingsModel = settingsProvider.GetSettings();
		var averageColor = GetAverageColor(bitmap, settingsModel.PixelSkipSteps);

        if (settingsModel.UseAccurateColors)
            return FindClosestColor(_colors.ToList(), averageColor);

        var allowedColors = settingsModel.ColorSettingModels.Where(x => x.Allowed).Select(o => o.Color).ToList();
		return FindClosestColor(allowedColors, averageColor);
	}

	private static unsafe Color GetAverageColor(Bitmap image, int pixelSkipSteps)
	{
		var imageData = image.LockBits(
			new Rectangle(Point.Empty, image.Size),
			ImageLockMode.ReadOnly,
			PixelFormat.Format32bppArgb);

		var pixelsPointer = (int*)imageData.Scan0.ToPointer();
		var (sumRed, sumGreen, sumBlue) = (0L, 0L, 0L);
		var stride = imageData.Stride / sizeof(int) * pixelSkipSteps;

		for (var y = 0; y < imageData.Height; y += pixelSkipSteps)
		{
			for (var x = 0; x < imageData.Width; x += pixelSkipSteps)
			{
				var argb = pixelsPointer[x];
				sumRed += (argb & 0x00FF0000) >> 16;
				sumGreen += (argb & 0x0000FF00) >> 8;
				sumBlue += argb & 0x000000FF;
			}

			pixelsPointer += stride;
		}

		image.UnlockBits(imageData);

		var numSamples = imageData.Width / pixelSkipSteps * imageData.Height / pixelSkipSteps;
		var averageRed = sumRed / numSamples;
		var averageGreen = sumGreen / numSamples;
		var averageBlue = sumBlue / numSamples;

		return Color.FromArgb((int)averageRed, (int)averageGreen, (int)averageBlue);
	}

    private static Color FindClosestColor(List<Color> colorList, Color targetColor)
	{
		if (colorList == null || !colorList.Any())
			return targetColor;

		var closestColor = targetColor;
		var minDistance = double.MaxValue;

		foreach (var color in colorList)
		{
			var distance = CalculateColorDistance(targetColor, color);
			if (distance < minDistance)
			{
				minDistance = distance;
				closestColor = color;
			}
		}

		return closestColor;
	}

	private static double CalculateColorDistance(Color color1, Color color2)
	{
		var deltaR = color1.R - color2.R;
		var deltaG = color1.G - color2.G;
		var deltaB = color1.B - color2.B;

		return Math.Sqrt(deltaR * deltaR + deltaG * deltaG + deltaB * deltaB);
	}

    private static IEnumerable<Color> CreateDefaultColorList()
    {
        var colorList = new List<Color>
    {
        // Red to Yellow
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

        // Yellow to Green
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

        // Green to Cyan
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

        // Cyan to Blue
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

        // Blue to Magenta
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

        // Magenta to Red
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
    };

        return colorList;
    }

}