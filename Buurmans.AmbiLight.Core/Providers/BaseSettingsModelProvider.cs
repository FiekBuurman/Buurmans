using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Buurmans.AmbiLight.Core.Models;

namespace Buurmans.AmbiLight.Core.Providers
{
	internal class BaseSettingsModelProvider
	{
		protected static SettingsModel GetDefaultSettings()
		{
			var settingsModel = new SettingsModel
			{
				PixelSkipSteps = 10,
				DelayInMilliseconds = 1000,
				ColorSettingModels = CreateColorSettingModels(),
				MqttSettings = CreateMqttSettings()
			};
			
			return settingsModel;
		}

		private static MqttSettingsModel CreateMqttSettings()
		{
			return new MqttSettingsModel
			{
				Broker = "127.0.0.1",
				Port = 8883,
				Timeout = 10,
				ClientId = string.Empty,
				UserName = string.Empty,
				Password = string.Empty,
				Topic = string.Empty
            };
		}

		private static List<ColorSettingModel> CreateColorSettingModels()
		{
			return CreateDefaultColorList().Select(color => new ColorSettingModel
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
}
