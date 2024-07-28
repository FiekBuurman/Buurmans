using Buurmans.AmbiLight.Core.Models;
using Buurmans.Mqtt.Models;

namespace Buurmans.AmbiLight.Form.Interfaces
{
    internal interface ISettingsViewModel
	{
		void Init(ISettingsView settingsView);
		void SaveSettingsButtonPressed(AmbilLightConfigurationSettingsModel ambilLightConfigurationSettingsModel);
		void LoadSettings();
		void ResetSettingsButtonPressed();
		void TestMqttSettingsButtonPressed(MqttConfigurationSettingsModel mqttConfigurationSettingsModel);
	}
}
