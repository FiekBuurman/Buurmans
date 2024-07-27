using Newtonsoft.Json;

namespace Buurmans.Mqtt.Models
{
	public class LightMqttPayloadModel : MqttPayloadModel
	{
		[JsonProperty("state")]
		public string State { get; set; }

		[JsonProperty("color")]
		public MqttLightColorModel ColorModel { get; set; }
	}
}