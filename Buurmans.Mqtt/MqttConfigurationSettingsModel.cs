namespace Buurmans.Mqtt
{
    internal class MqttConfigurationSettingsModel
    {
		public string BrokerUrl { get; set; }
		public int Port { get; set; }
		public string Topic { get; set; }
		public string ClientId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
    }
}
