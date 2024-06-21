using System;
using MQTTnet.Client;

namespace Buurmans.Mqtt
{
	internal static class MqttSettingsModelExtensions
	{
		public static MqttClientOptions CreateMqttClientOptions(this MqttConfigurationSettingsModel settings)
		{
			return new MqttClientOptionsBuilder()
				.WithClientId(settings.ClientId)
				.WithTcpServer(settings.BrokerUrl, settings.Port)
				.WithCredentials(settings.Username, settings.Password)
				.WithCleanSession(false)
				.WithKeepAlivePeriod(TimeSpan.FromSeconds(60))
				.WithTimeout(TimeSpan.FromSeconds(60))
				.Build();
		}
	}
}