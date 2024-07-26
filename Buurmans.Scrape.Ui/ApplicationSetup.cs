using Autofac;

namespace Buurmans.Scrape.Ui;

internal static class ApplicationSetup
{
	public static IContainer CreateContainer()
	{
		var builder = new ContainerBuilder();
		builder.RegisterType<Application>().As<IApplication>().SingleInstance();
		builder.RegisterModule<Buurmans.Scrape.Core.Autofac.AutofacModule>();
		return builder.Build();
	}
}