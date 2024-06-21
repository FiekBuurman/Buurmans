using Autofac;

namespace Buurmans.Console;

internal static class ApplicationSetup
{
	public static IContainer CreateContainer()
	{
		var builder = new ContainerBuilder();

		builder.RegisterModule<Buurmans.Common.AutofacModule>();
		builder.RegisterModule<Buurmans.Mqtt.AutofacModule>();
		
		builder.RegisterType<Buurmans.Console.Application>().AsImplementedInterfaces().SingleInstance();

		return builder.Build();
	}
}