using System;
using System.IO;
using Newtonsoft.Json;

namespace Buurmans.Mqtt
{
	internal class MqttConfigurationProvider : IMqttConfigurationProvider
    {
		private string _filePath = string.Empty;
		private MqttConfigurationSettingsModel _settingsModel;

        public MqttConfigurationSettingsModel GetSettings() => _settingsModel ??= LoadSettingsFromFile();

		private MqttConfigurationSettingsModel LoadSettingsFromFile()
		{
			EnsureFilePath();

			if (!File.Exists(_filePath))
			{
				var defaultSettingsModel = CreateDefaultSettings();
				SaveSettings(defaultSettingsModel);
			}

			var serializedSettingsModel = File.ReadAllText(_filePath);
			return JsonConvert.DeserializeObject<MqttConfigurationSettingsModel>(serializedSettingsModel);
		}

		private void SaveSettings(MqttConfigurationSettingsModel settingsModel)
		{
			EnsureFilePath();

			var serializeSettingsModel = JsonConvert.SerializeObject(settingsModel, Formatting.Indented);
			File.WriteAllText(_filePath, serializeSettingsModel);
		}

		private static MqttConfigurationSettingsModel CreateDefaultSettings()
		{
			return new MqttConfigurationSettingsModel
			{
				BrokerUrl = string.Empty,
				Port = 1883,
				Topic = string.Empty,
				ClientId = string.Empty,
				Username = string.Empty,
				Password = string.Empty
			};
		}

		private void EnsureFilePath()
		{
			if (!string.IsNullOrWhiteSpace(_filePath))
				return;

			var appDomain = AppDomain.CurrentDomain.BaseDirectory;
			_filePath = $"{appDomain}MqttSettings.config";
		}
	}
}