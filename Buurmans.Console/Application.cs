using System;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt;

namespace Buurmans.Console;

public class Application(IObserverManager observerManager, IMqttEngine mqttEngine) : IApplication
{
	public void Run()
	{
		RegisterObservers();

		observerManager.NotifyChange(new Exception("Big Bad Test Exception!"));
		observerManager.NotifyChange("Press any key to exit.");

		SendMqttMessage();

		System.Console.ReadKey();

        UnRegisterObservers();
	}

	private void SendMqttMessage() 
	{
		mqttEngine.Publish("develop", "test1");
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