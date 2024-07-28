using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Buurmans.AmbiLight.Core.Interfaces;

namespace Buurmans.AmbiLight.Core.Services
{
	internal class ColorCalculationService(ISettingsModelProvider settingsModelProvider) : IColorCalculationService
	{
		public Color CalculateAverageColor(Bitmap bitmap)
		{
			var settingsModel = settingsModelProvider.GetSettingsModel();
			var averageColor = GetAverageColor(bitmap, settingsModel.PixelSkipSteps);
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
    }
}