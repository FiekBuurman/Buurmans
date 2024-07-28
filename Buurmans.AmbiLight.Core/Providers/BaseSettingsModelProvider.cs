using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Buurmans.AmbiLight.Core.Models;

namespace Buurmans.AmbiLight.Core.Providers;

internal class BaseSettingsModelProvider
{
	protected static AmbilLightConfigurationSettingsModel GetDefaultSettings()
	{
		var settingsModel = new AmbilLightConfigurationSettingsModel
		{
			PixelSkipSteps = 10,
			DelayInMilliseconds = 1000,
			ColorSettingModels = CreateColorSettingModels()
		};
			
		return settingsModel;
	}
		
	private static List<AmbiLightColorSettingModel> CreateColorSettingModels()
	{
		return CreateDefaultColorList().Select(color => new AmbiLightColorSettingModel
			{
				Color = color,
				Allowed = true
			})
			.ToList();
	}
		
	private static IEnumerable<Color> CreateDefaultColorList()
	{
		var colorList = new List<Color>
		{
			Color.FromArgb(255, 64, 0),
			Color.FromArgb(255, 128, 0),
			Color.FromArgb(255, 192, 0),
			Color.FromArgb(255, 255, 0),
			Color.FromArgb(192, 255, 0),
			Color.FromArgb(128, 255, 0),
			Color.FromArgb(64, 255, 0),
			Color.FromArgb(0, 255, 0),
			Color.FromArgb(0, 255, 64),
			Color.FromArgb(0, 255, 128),
			Color.FromArgb(0, 255, 192),
			Color.FromArgb(0, 255, 255),
			Color.FromArgb(0, 192, 255),
			Color.FromArgb(0, 128, 255),
			Color.FromArgb(0, 64, 255),
			Color.FromArgb(0, 0, 255),
			Color.FromArgb(64, 0, 255),
			Color.FromArgb(128, 0, 255),
			Color.FromArgb(192, 0, 255),
			Color.FromArgb(255, 0, 255),
			Color.FromArgb(255, 0, 192),
			Color.FromArgb(255, 0, 128),
			Color.FromArgb(255, 0, 64),
			Color.FromArgb(255, 0, 0)
		};

		return colorList;
	}
}