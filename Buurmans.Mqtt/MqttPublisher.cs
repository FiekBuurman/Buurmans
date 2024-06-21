using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace Buurmans.Mqtt
{
    internal class MqttPublisher
    {
		private readonly MqttConfigurationSettingsModel _config;

		public MqttPublisher()
		{
			var configSettingsProvider = new MqttConfigurationProvider();
			_config = configSettingsProvider.GetSettings();
		}

		public async Task PublishMessageAsync(string message)
		{
			var factory = new MqttFactory();
			var mqttClient = factory.CreateMqttClient();

			var options = new MqttClientOptionsBuilder()
				.WithClientId(_config.ClientId)
				.WithTcpServer(_config.BrokerUrl, _config.Port)
				.WithCredentials(_config.Username, _config.Password)
				.Build();

			await mqttClient.ConnectAsync(options, CancellationToken.None);

			var mqttMessage = new MqttApplicationMessageBuilder()
				.WithTopic(_config.Topic)
				.WithPayload(Encoding.UTF8.GetBytes(message))
				.WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
				.Build();

			await mqttClient.PublishAsync(mqttMessage, CancellationToken.None);

			await mqttClient.DisconnectAsync();
		}
    }
}
