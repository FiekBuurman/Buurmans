using System.Text;
using Buurmans.Mqtt.Models;
using MQTTnet.Client;
using Newtonsoft.Json;

namespace Buurmans.Mqtt.Extensions
{
	internal static class MqttClientConnectResultExtensions
	{
		public static string FormatResult(this MqttEngineResultModel result)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Connection Result:");
			stringBuilder.AppendLine($"Result Code: {result.ResultCode}");

			if (!string.IsNullOrEmpty(result.ReasonString))
				stringBuilder.AppendLine($"Reason: {result.ReasonString}");

			if (!string.IsNullOrEmpty(result.ResponseInformation))
				stringBuilder.AppendLine($"ResponseInformation: {result.ResponseInformation}");

			if (result.MqttClientConnectResult == null)
				return stringBuilder.ToString();

			stringBuilder.AppendLine("MqttClientConnectResult:");
			stringBuilder.AppendLine(GetOutput(result.MqttClientConnectResult));

			return stringBuilder.ToString();
		}

		private static string GetOutput(MqttClientConnectResult mqttClientConnectResult)
		{
			var output = mqttClientConnectResult == null
				? "NULL"
				: JsonConvert.SerializeObject(mqttClientConnectResult, Formatting.Indented);

			return $"[{mqttClientConnectResult?.GetType().Name}]:\r\n{output}";
		}
	}
}