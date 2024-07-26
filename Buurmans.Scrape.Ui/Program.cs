using Autofac;

namespace Buurmans.Scrape.Ui;

internal abstract class Program
{
	private static void Main()
	{
		var container = ApplicationSetup.CreateContainer();
		using var scope = container.BeginLifetimeScope();
			
		var application = scope.Resolve<IApplication>();
		application.Run();
	}
}