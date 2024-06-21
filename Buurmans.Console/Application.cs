namespace Buurmans.Console;

public class Application : IApplication
{
	public void Run()
	{
		System.Console.WriteLine("Press any key to exit.");
		System.Console.ReadKey();
	}
}