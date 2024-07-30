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
		IJsonConverter jsonConverter) : IMqttEngine
	{
		private readonly IMqttClient _mqttClient = new MqttFactory().CreateMqttClient();
		private MqttConfigurationSettingsModel _mqttConfigurationSettingsModel;

        public void InitSettings(MqttConfigurationSettingsModel mqttConfigurationSettingsModel) 
			=> _mqttConfigurationSettingsModel = mqttConfigurationSettingsModel;

		public Task Publish(MqttMessageModel mqttMessageModel)
		{
			var payload = jsonConverter.Serialize(mqttMessageModel.MqttPayloadModel);
			return Publish(mqttMessageModel.Topic, payload);
		}

        public async Task Connect()
		{
			ValidateSettings();
            var result = await ConnectAsync(_mqttConfigurationSettingsModel.CreateMqttClientOptions());
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

		public async Task Disconnect()
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
		
		public void TestSettings(MqttConfigurationSettingsModel mqttConfigurationSettingsModel)
		{
			ValidateSettings();

            var factory = new MqttFactory();
			var client = factory.CreateMqttClient();

            try
			{
				var mqttOptions = _mqttConfigurationSettingsModel.CreateMqttClientOptions();
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

		private void ValidateSettings()
		{
			if (_mqttConfigurationSettingsModel == null)
				throw new Exception("MqttConfigurationSettingsModel = null, make sure to call InitSettings()");

			// TODO add other validations settings, and maybe testing the settings.
		}
	}
}