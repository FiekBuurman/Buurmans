using Buurmans.Common.Converters;
using Buurmans.Common.Providers;
using Buurmans.Mqtt.Interfaces;
using Buurmans.Mqtt.Models;

namespace Buurmans.Mqtt.Providers
{
	internal class MqttConfigurationProvider(IJsonConverter jsonConverter) 
		: BaseConfigurationProvider<MqttConfigurationSettingsModel>(jsonConverter), IMqttConfigurationProvider
	{
		public new MqttConfigurationSettingsModel GetSettings()
		{
			var settings = base.GetSettings();
			return settings ?? CreateDefaultSettings();
        }
        
		private MqttConfigurationSettingsModel CreateDefaultSettings()
		{
            var settings = new MqttConfigurationSettingsModel
            {
                BrokerUrl = "127.0.0.1",
                Port = 1883,
                Topic = string.Empty,
                ClientId = string.Empty,
                UserName = string.Empty,
                Password = string.Empty
            };

            SaveSettings(settings);
            return settings;
        }
	}
}