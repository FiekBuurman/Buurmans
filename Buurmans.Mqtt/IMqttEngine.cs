﻿using System.Threading.Tasks;
using Buurmans.Mqtt.Models;

namespace Buurmans.Mqtt
{
    public interface IMqttEngine
    {
		void InitSettings(MqttConfigurationSettingsModel mqttConfigurationSettingsModel);
        Task Connect();
		Task Disconnect();
		//Task Publish(string topic, string payload);
		Task Publish(MqttMessageModel mqttMessageModel);
		void TestSettings(MqttConfigurationSettingsModel mqttConfigurationSettingsModel);
	}
}
	