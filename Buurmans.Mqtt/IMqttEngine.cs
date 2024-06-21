using System.Threading.Tasks;
using Buurmans.Mqtt.Models;

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
