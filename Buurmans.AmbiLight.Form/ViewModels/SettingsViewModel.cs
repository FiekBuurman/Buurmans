using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Core.Models;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Mqtt;
using Buurmans.Mqtt.Models;

namespace Buurmans.AmbiLight.Form.ViewModels;

internal class SettingsViewModel(ISettingsModelProvider settingsModelProvider, IMqttEngine mqttEngine) : ISettingsViewModel
{
	private ISettingsView _settingsView;

	public void Init(ISettingsView settingsView)
	{
		_settingsView = settingsView;
	}

	public void SaveSettingsButtonPressed(AmbilLightConfigurationSettingsModel ambilLightConfigurationSettingsModel)
	{
		settingsModelProvider.SaveSettings(ambilLightConfigurationSettingsModel);
		_settingsView.CloseView();
	}

	public void LoadSettings()
	{
		var settingsModel = settingsModelProvider.GetSettingsModel();
		_settingsView.LoadSettings(settingsModel);
    }

	public void ResetSettingsButtonPressed()
	{
		var settingsModel = settingsModelProvider.GetSettingsModel();
		_settingsView.LoadSettings(settingsModel);
    }

	public void TestMqttSettingsButtonPressed(MqttConfigurationSettingsModel mqttConfigurationSettingsModel)
	{
		mqttEngine.TestSettings(mqttConfigurationSettingsModel);
	}
}