namespace Buurmans.Mqtt.Models
{
	public class MqttConfigurationSettingsModel
    {
		public string BrokerUrl { get; set; }
		public int Port { get; set; }
		public string Topic { get; set; }
		public string ClientId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public double Timeout { get; set; }
	}
}
