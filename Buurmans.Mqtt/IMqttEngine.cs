using System.Threading.Tasks;

namespace Buurmans.Mqtt
{
    internal interface IMqttEngine
    {
		Task Connect();
		Task Disconnect();
		Task Publish(string topic, string payload);
		void TestSettings(MqttConfigurationSettingsModel mqttSettingsModel);
    }
}
