using System;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;

namespace Buurmans.Console;

public class Application(IObserverManager observerManager) : IApplication
{
	public void Run()
	{
		RegisterObservers();

		observerManager.NotifyChange(new Exception("Big Bad Test Exception!"));
		observerManager.NotifyChange("Press any key to exit.");
		
		System.Console.ReadKey();

        UnRegisterObservers();
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