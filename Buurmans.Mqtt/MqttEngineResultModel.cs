using MQTTnet.Client;

namespace Buurmans.Mqtt
{
    internal class MqttEngineResultModel
    {
		public MqttEngineResultModel(MqttClientConnectResult mqttClientConnectResult = null)
		{
			if (mqttClientConnectResult == null)
				return;

			MqttClientConnectResult = mqttClientConnectResult;
			ResultCode = mqttClientConnectResult.ResultCode;
			ReasonString = mqttClientConnectResult.ReasonString;
			ResponseInformation = mqttClientConnectResult.ResponseInformation;
		}

		public MqttEngineResultModel(MqttClientConnectResultCode mqttClientConnectResultCode, string reasonSting = "")
		{
			ResultCode = mqttClientConnectResultCode;
			ReasonString = reasonSting;
		}

		public MqttClientConnectResult MqttClientConnectResult { get; set; }
		public MqttClientConnectResultCode ResultCode { get; set; }
		public string ReasonString { get; set; }
		public string ResponseInformation { get; set; }
    }
}
