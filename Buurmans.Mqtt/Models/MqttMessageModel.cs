using Newtonsoft.Json;

namespace Buurmans.Mqtt.Models
{
	public class MqttMessageModel
	{
		public MqttMessageModel(string topic)
		{
			Topic = topic;
		}

		[JsonProperty("topic")]
		public string Topic { get; private set; }

		[JsonProperty("payload")]
		public MqttPayloadModel MqttPayloadModel { get; set; }
	}
}