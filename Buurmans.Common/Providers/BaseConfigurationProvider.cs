using System;
using System.IO;
using Buurmans.Common.Converters;
using Buurmans.Common.Interfaces;

namespace Buurmans.Common.Providers
{
	public class BaseConfigurationProvider<T>(IJsonConverter jsonConverter) : IBaseConfigurationProvider<T> where T : class
	{
		private string _filePath;
        private T _settingsModel;

		public T GetSettings() => _settingsModel ??= LoadSettingsFromFile();

		private T LoadSettingsFromFile()
		{
			EnsureFilePath();

            if (!File.Exists(_filePath))
				return null;

			var serializedSettingsModel = File.ReadAllText(_filePath);
			return jsonConverter.Deserialize<T>(serializedSettingsModel);
        }

		public void SaveSettings(T settingsModel)
		{
			EnsureFilePath();

            var serializedSettingsModel = jsonConverter.Serialize(settingsModel);
			File.WriteAllText(_filePath, serializedSettingsModel);
		}

		private void EnsureFilePath()
		{
			if (!string.IsNullOrWhiteSpace(_filePath))
				return;
			
            var appDomain = AppDomain.CurrentDomain.BaseDirectory;
			var typeName = typeof(T).Name;

			_filePath = Path.Combine(appDomain, $"{typeName}.config");
        }
    }
}
