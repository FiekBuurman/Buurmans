using Buurmans.Mqtt.Models;

namespace Buurmans.Mqtt.Interfaces
{
	internal interface IMqttConfigurationProvider
	{
		MqttConfigurationSettingsModel GetSettings();
	}
}