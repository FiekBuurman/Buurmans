using System;
using System.IO;
using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Core.Models;
using Buurmans.Common.Converters;

namespace Buurmans.AmbiLight.Core.Providers;

internal class SettingsModelProvider : BaseSettingsModelProvider, ISettingsModelProvider
{
	private readonly IJsonConverter _jsonConverter;

	public SettingsModelProvider(IJsonConverter jsonConverter)
	{
		_jsonConverter = jsonConverter;
	}
	private string _filePath = string.Empty;
	private AmbilLightConfigurationSettingsModel _settingsModel;

	public AmbilLightConfigurationSettingsModel GetSettingsModel()
	{
		if (_settingsModel != null)
			return _settingsModel;

		EnsureFilePath();

		if (!File.Exists(_filePath))
		{
			var defaultSettingsModel = GetDefaultSettings();
			SaveSettings(defaultSettingsModel);
		}

		var serializedSettingsModel = File.ReadAllText(_filePath);
		_settingsModel = _jsonConverter.Deserialize<AmbilLightConfigurationSettingsModel>(serializedSettingsModel);

		return _settingsModel;
	}

	public void SaveSettings(AmbilLightConfigurationSettingsModel settingsModel)
	{
		EnsureFilePath();
		var serializeSettingsModel = _jsonConverter.Serialize(settingsModel);
		File.WriteAllText(_filePath, serializeSettingsModel);

		_settingsModel = null;
	}



	private void EnsureFilePath()
	{
		if (!string.IsNullOrWhiteSpace(_filePath))
			return;

		var appDomain = AppDomain.CurrentDomain.BaseDirectory;
		_filePath = $"{appDomain}Settings.config";
	}
}