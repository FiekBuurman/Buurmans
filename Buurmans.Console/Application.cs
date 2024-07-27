using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Buurmans.Common.Converters;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt;
using Buurmans.Mqtt.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

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
            List<LightColor> colorSequence =
            [
                new LightColor { Red = 255, Green = 0, Blue = 0 },
                new LightColor { Red = 255, Green = 128, Blue = 0 },
                new LightColor { Red = 255, Green = 255, Blue = 0 },
                new LightColor { Red = 128, Green = 255, Blue = 0 },
                new LightColor { Red = 0, Green = 255, Blue = 0 },
                new LightColor { Red = 0, Green = 255, Blue = 128 },
                new LightColor { Red = 0, Green = 255, Blue = 255 },
                new LightColor { Red = 0, Green = 128, Blue = 255 },
                new LightColor { Red = 0, Green = 0, Blue = 255 },
                new LightColor { Red = 128, Green = 0, Blue = 255 },
                new LightColor { Red = 255, Green = 0, Blue = 255 },
                new LightColor { Red = 255, Green = 0, Blue = 128 }
            ];

            MqttMessage mqttMessage = new();
            mqttMessage.Topic = "zigbee2mqtt/woonkamer lamp test/set";
            int colorIndex = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            
            mqttEngine.Publish("zigbee2mqtt/woonkamer lamp test/set", "{\"state\":\"OFF\"}");

            while (stopwatch.Elapsed < TimeSpan.FromMinutes(1))
            {
                var lightPayload = new LightPayload
                {
                    State = "ON",
                    Color = colorSequence[colorIndex]
                };

                var payload = jsonConverter.Serialize(lightPayload);

                mqttEngine.Publish(mqttMessage.Topic, payload);


                colorIndex = (colorIndex + 1) % colorSequence.Count;

                Thread.Sleep(3000);
            }
            // TODO turn off
            var offPayLoad = new LightPayload { State = "OFF"/*, Color = new LightColor { Red = 0, Green = 255, Blue = 0 }*/ };
            mqttEngine.Publish(mqttMessage.Topic, jsonConverter.Serialize(offPayLoad));

        }
        catch (Exception exception)
        {
            observerManager.NotifyChange(exception);
        }
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

public class MqttMessage
{
    [JsonProperty("topic")]
    public string Topic { get; set; }

    [JsonProperty("payload")]
    public Payload Payload { get; set; }
}


public class Payload
{

}

public class LightPayload : Payload
{
    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("color")]
    public LightColor Color { get; set; }
}

public class LightColor
{
    [JsonProperty("r")]
    public int Red { get; set; }

    [JsonProperty("g")]
    public int Green { get; set; }

    [JsonProperty("b")]
    public int Blue { get; set; }
}