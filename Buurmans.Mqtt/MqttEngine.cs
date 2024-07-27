using System;
using System.Threading.Tasks;
using Buurmans.Common.Converters;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt.Extensions;
using Buurmans.Mqtt.Interfaces;
using Buurmans.Mqtt.Models;
using MQTTnet;
using MQTTnet.Client;

namespace Buurmans.Mqtt
{
	internal class MqttEngine(
		IObserverManager observerManager, 
		IMqttConfigurationProvider mqttConfigurationProvider, 
		IJsonConverter jsonConverter) : IMqttEngine
	{
		private readonly IMqttClient _mqttClient = new MqttFactory().CreateMqttClient();

		public Task Publish(MqttMessageModel mqttMessageModel)
		{
			var payload = jsonConverter.Serialize(mqttMessageModel.MqttPayloadModel);
			return Publish(mqttMessageModel.Topic, payload);
		}

        private async Task Connect()
		{
			var mqttSettingsModel = mqttConfigurationProvider.GetSettings();
			var result = await ConnectAsync(mqttSettingsModel.CreateMqttClientOptions());

			observerManager.NotifyChange(result.FormatResult());
		}

		private async Task<MqttEngineResultModel> ConnectAsync(MqttClientOptions options)
		{
			if (_mqttClient.IsConnected)
				return new MqttEngineResultModel(MqttClientConnectResultCode.Success, "Already Connected");

			try
			{
				var result = await _mqttClient.ConnectAsync(options);
				return new MqttEngineResultModel(result);
			}
			catch (Exception exception)
			{
				return new MqttEngineResultModel(MqttClientConnectResultCode.UnspecifiedError)
				{
					ReasonString = exception.Message,
					ResponseInformation = exception.FlattenException()
				};
			}
		}

		private async Task Disconnect()
		{
			var result = await DisconnectAsync();
			observerManager.NotifyChange(result.FormatResult());
        }

		private async Task<MqttEngineResultModel> DisconnectAsync()
		{
			if (!_mqttClient.IsConnected)
				return new MqttEngineResultModel(MqttClientConnectResultCode.Success, "Was not Connected");

			try
			{
				await _mqttClient.DisconnectAsync();
				return new MqttEngineResultModel(MqttClientConnectResultCode.Success, "Disconnected");
			}
			catch (Exception exception)
			{
				return new MqttEngineResultModel(MqttClientConnectResultCode.UnspecifiedError)
				{
					ReasonString = exception.Message,
					ResponseInformation = exception.FlattenException()
				};
			}
		}

		private async Task Publish(string topic, string payload)
        {
            if (!_mqttClient.IsConnected)
				await Connect();

            if (!_mqttClient.IsConnected)
                throw new InvalidOperationException("MQTT client is not connected.");

            var message = new MqttApplicationMessageBuilder()
				.WithTopic(topic)
				.WithPayload(payload)
				.WithRetainFlag()
				.Build();

            try
            {
                var result = await _mqttClient.PublishAsync(message);
                var resultMessage = result.ReasonCode == MqttClientPublishReasonCode.Success
					? $"Successfully published message to topic '{topic}' with payload: \r\n{payload}"
					: $"Failed to publish message to topic '{topic}' with payload: \r\n{payload}\r\nReason: \r\n{result.ReasonCode}";

                observerManager.NotifyChange(resultMessage);
            }
            catch (Exception exception)
            {
				observerManager.NotifyChange(CreateErrorResult(exception).FormatResult());
            }
        }

		private static MqttEngineResultModel CreateErrorResult(Exception exception)
		{
			return new MqttEngineResultModel(MqttClientConnectResultCode.UnspecifiedError)
			{
				ReasonString = exception.Message,
				ResponseInformation = exception.FlattenException()
			};
		}
		
		private void TestSettings()
		{
			var factory = new MqttFactory();
			var client = factory.CreateMqttClient();
            var mqttSettingsModel = mqttConfigurationProvider.GetSettings();

            try
			{
				var mqttOptions = mqttSettingsModel.CreateMqttClientOptions();
				var result = client.ConnectAsync(mqttOptions).Result;

				observerManager.NotifyChange(result.ResultCode == MqttClientConnectResultCode.Success
					? "Connection succeeded!"
					: "Connection Failed!");

				var resultModel = new MqttEngineResultModel(result);
				observerManager.NotifyChange(resultModel.FormatResult());
			}
			catch (Exception exception)
			{
				var resultModel = new MqttEngineResultModel(MqttClientConnectResultCode.UnspecifiedError)
				{
					ReasonString = exception.Message,
					ResponseInformation = exception.FlattenException()
				};
				observerManager.NotifyChange(resultModel.FormatResult());
			}
			finally
			{
				client.DisconnectAsync();
			}
		}
	}
}