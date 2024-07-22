using System;
using System.IO;
using Buurmans.Common.Interfaces;
using Newtonsoft.Json;

namespace Buurmans.Common.Providers
{
	public class BaseConfigurationProvider<T> : IBaseConfigurationProvider<T> where T : class
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
			return JsonConvert.DeserializeObject<T>(serializedSettingsModel);
        }

		public void SaveSettings(T settingsModel)
		{
			EnsureFilePath();

            var serializedSettingsModel = JsonConvert.SerializeObject(settingsModel, Formatting.Indented);
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
