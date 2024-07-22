using System;
using System.Threading.Tasks;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt.Extensions;
using Buurmans.Mqtt.Interfaces;
using Buurmans.Mqtt.Models;
using MQTTnet;
using MQTTnet.Client;

namespace Buurmans.Mqtt
{
	internal class MqttEngine : IMqttEngine
	{
		private readonly IObserverManager _observerManager;
		private readonly IMqttConfigurationProvider _mqttConfigurationProvider;
		private readonly IMqttClient _mqttClient;
		public MqttEngine(IObserverManager observerManager, IMqttConfigurationProvider mqttConfigurationProvider)
		{
			_observerManager = observerManager;
			_mqttConfigurationProvider = mqttConfigurationProvider;
			var factory = new MqttFactory();
			_mqttClient = factory.CreateMqttClient();
		}

		public async Task Connect()
		{
			var mqttSettingsModel = _mqttConfigurationProvider.GetSettings();
			var result = await ConnectAsync(mqttSettingsModel.CreateMqttClientOptions());

			_observerManager.NotifyChange(result.FormatResult());
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
			_observerManager.NotifyChange(result.FormatResult());
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

        public async Task Publish(string topic, string payload)
        {
            if (!_mqttClient.IsConnected)
				await Connect();

            if (!_mqttClient.IsConnected)
                throw new InvalidOperationException("MQTT client is not connected.");

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

            try
            {
                var result = await _mqttClient.PublishAsync(message);
                var resultMessage = result.ReasonCode == MqttClientPublishReasonCode.Success
					? $"Successfully published message to topic '{topic}' with payload '{payload}'."
					: $"Failed to publish message to topic '{topic}' with payload '{payload}'. Reason: {result.ReasonCode}";

                _observerManager.NotifyChange(resultMessage);
            }
            catch (Exception exception)
            {
                _observerManager.NotifyChange(new MqttEngineResultModel(MqttClientConnectResultCode.UnspecifiedError)
                {
                    ReasonString = exception.Message,
                    ResponseInformation = exception.FlattenException()
                }.FormatResult());
            }
        }

        public void TestSettings()
		{
			var factory = new MqttFactory();
			var client = factory.CreateMqttClient();
            var mqttSettingsModel = _mqttConfigurationProvider.GetSettings();

            try
			{
				var mqttOptions = mqttSettingsModel.CreateMqttClientOptions();
				var result = client.ConnectAsync(mqttOptions).Result;

				_observerManager.NotifyChange(result.ResultCode == MqttClientConnectResultCode.Success
					? "Connection succeeded!"
					: "Connection Failed!");

				var resultModel = new MqttEngineResultModel(result);
				_observerManager.NotifyChange(resultModel.FormatResult());
			}
			catch (Exception exception)
			{
				var resultModel = new MqttEngineResultModel(MqttClientConnectResultCode.UnspecifiedError)
				{
					ReasonString = exception.Message,
					ResponseInformation = exception.FlattenException()
				};
				_observerManager.NotifyChange(resultModel.FormatResult());
			}
			finally
			{
				client.DisconnectAsync();
			}
		}
	}
}