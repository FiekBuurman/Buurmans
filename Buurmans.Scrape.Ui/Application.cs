using System;
using Buurmans.Mqtt;
using Buurmans.Mqtt.Models;
using Buurmans.Scrape.Core;

namespace Buurmans.Scrape.Ui;

public class Application(IScrapeEngine htmlScrapeEngine, IMqttEngine mqttEngine) : IApplication
{
	public void Run()
	{
		var result = htmlScrapeEngine.Process().Result;
		Console.WriteLine(result);

		var mqttSettings = new MqttConfigurationSettingsModel
		{
			BrokerUrl = "192.168.2.249",
			Port = 1883,
			Topic = "zigbee2mqtt/gasprices",
			ClientId = "Buurmans.Mqtt",
			UserName = "buurmans",
			Password = "buurmans",
			Timeout = 60
		};

        mqttEngine.InitSettings(mqttSettings);

		var message = new MqttMessageModel(mqttSettings.Topic);
		message.MqttPayloadModel = new MqttPayloadModel();

        Console.WriteLine("Press any key to exit.");
		Console.ReadKey();
	}
}