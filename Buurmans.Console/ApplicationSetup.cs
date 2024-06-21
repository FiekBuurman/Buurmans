using Autofac;

namespace Buurmans.Console;

internal static class ApplicationSetup
{
	public static IContainer CreateContainer()
	{
		var builder = new ContainerBuilder();
		builder.RegisterType<Application>().AsImplementedInterfaces().SingleInstance();
		return builder.Build();
	}
}