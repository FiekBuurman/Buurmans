using System;
using Buurmans.Mqtt.Models;
using MQTTnet.Client;

namespace Buurmans.Mqtt.Extensions
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