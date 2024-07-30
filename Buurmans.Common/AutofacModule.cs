using Autofac;
using Buurmans.Common.Converters;
using Buurmans.Common.Interfaces;
using Buurmans.Common.Loggers;
using Buurmans.Common.Managers;

namespace Buurmans.Common;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterType<ObserverManager>().As<IObserverManager>().SingleInstance();
		builder.RegisterType<JsonConverter>().As<IJsonConverter>().SingleInstance();
		builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
	}
}