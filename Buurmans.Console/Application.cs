using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Buurmans.Common.Converters;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt;
using Buurmans.Mqtt.Models;

namespace Buurmans.Console;

public class Application(IObserverManager observerManager, IMqttEngine mqttEngine, IJsonConverter jsonConverter) : IApplication
{
    public void Run()
    {
        RegisterObservers();

        TestMqtt();

        //observerManager.NotifyChange(new Exception("Big Bad Test Exception!"));

        observerManager.NotifyChange("Press any key to exit.");
        System.Console.ReadKey();

        UnRegisterObservers();
    }

    private void TestMqtt()
    {
        try
		{
			var colorSequence = CreateMqttLightColorModels();
            var colorIndex = 0;
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var mqttMessageModel = new MqttMessageModel("zigbee2mqtt/woonkamer lamp test/set")
			{
				MqttPayloadModel = new LightMqttPayloadModel
				{
					State = "ON",
					ColorModel = colorSequence[colorIndex]
				}
			};

            while (stopwatch.Elapsed < TimeSpan.FromMinutes(1))
            {
                mqttMessageModel.MqttPayloadModel = new LightMqttPayloadModel
                {
                    State = "ON",
                    ColorModel = colorSequence[colorIndex]
                };

                var payload = jsonConverter.Serialize(mqttMessageModel.MqttPayloadModel);
                mqttEngine.Publish(mqttMessageModel.Topic, payload);
                
                colorIndex = (colorIndex + 1) % colorSequence.Count;

                Thread.Sleep(3000);
            }

            var offPayLoad = new LightMqttPayloadModel { State = "OFF" };
            mqttEngine.Publish(mqttMessageModel.Topic, jsonConverter.Serialize(offPayLoad));

        }
        catch (Exception exception)
        {
            observerManager.NotifyChange(exception);
        }
    }

	private static List<MqttLightColorModel> CreateMqttLightColorModels()
	{
		List<MqttLightColorModel> colorSequence =
		[
			new MqttLightColorModel { Red = 255, Green = 0, Blue = 0 },
			new MqttLightColorModel { Red = 255, Green = 128, Blue = 0 },
			new MqttLightColorModel { Red = 255, Green = 255, Blue = 0 },
			new MqttLightColorModel { Red = 128, Green = 255, Blue = 0 },
			new MqttLightColorModel { Red = 0, Green = 255, Blue = 0 },
			new MqttLightColorModel { Red = 0, Green = 255, Blue = 128 },
			new MqttLightColorModel { Red = 0, Green = 255, Blue = 255 },
			new MqttLightColorModel { Red = 0, Green = 128, Blue = 255 },
			new MqttLightColorModel { Red = 0, Green = 0, Blue = 255 },
			new MqttLightColorModel { Red = 128, Green = 0, Blue = 255 },
			new MqttLightColorModel { Red = 255, Green = 0, Blue = 255 },
			new MqttLightColorModel { Red = 255, Green = 0, Blue = 128 }
		];
		return colorSequence;
	}

	private void RegisterObservers()
    {
        observerManager.Register<string>(WriteToConsole);
        observerManager.Register<Exception>(WriteToConsole);
    }

    private void UnRegisterObservers()
    {
        observerManager.Unregister<string>(WriteToConsole);
        observerManager.Unregister<Exception>(WriteToConsole);
    }

    private static void WriteToConsole(Exception exception) => System.Console.WriteLine(exception.FlattenException());

    private static void WriteToConsole(string message) => System.Console.WriteLine(message.AddTimePrefix());
}