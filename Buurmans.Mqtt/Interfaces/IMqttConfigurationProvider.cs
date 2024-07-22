using Buurmans.Common.Interfaces;
using Buurmans.Mqtt.Models;

namespace Buurmans.Mqtt.Interfaces
{
	internal interface IMqttConfigurationProvider : IBaseConfigurationProvider<MqttConfigurationSettingsModel>
	{
		new MqttConfigurationSettingsModel GetSettings();
	}
}