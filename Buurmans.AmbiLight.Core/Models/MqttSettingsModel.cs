namespace Buurmans.AmbiLight.Core.Models
{
    public class MqttSettingsModel
    {
		public string Broker { get; set; }
		public int Port { get; set; }
		public int Timeout { get; set; }
		public string ClientId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
        public string Topic { get; set; }
    }
}
