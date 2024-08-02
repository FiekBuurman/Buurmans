using Autofac;
using Buurmans.Mqtt.Providers;

namespace Buurmans.Mqtt;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterModule<Buurmans.Common.AutofacModule>();

		builder.RegisterType<MqttEngine>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<MqttConfigurationProvider>().AsImplementedInterfaces().SingleInstance();
	}
}