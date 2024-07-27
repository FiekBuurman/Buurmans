using Newtonsoft.Json;

namespace Buurmans.Mqtt.Models
{
	public class MqttLightColorModel
	{
		[JsonProperty("r")]
		public int Red { get; set; }

		[JsonProperty("g")]
		public int Green { get; set; }

		[JsonProperty("b")]
		public int Blue { get; set; }
	}
}