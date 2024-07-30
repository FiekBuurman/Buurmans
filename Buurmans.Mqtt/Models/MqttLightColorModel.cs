using Newtonsoft.Json;
using System.Drawing;

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

		public void UpdateColor(Color color) 
		{ 
			Red = color.R;
			Green = color.G;
			Blue = color.B;
		}
	}
}