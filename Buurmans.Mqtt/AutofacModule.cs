using Autofac;
using Buurmans.Mqtt.Interfaces;
using Buurmans.Mqtt.Providers;

namespace Buurmans.Mqtt;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterModule<Buurmans.Common.AutofacModule>();

		builder.RegisterType<MqttConfigurationProvider>().As<IMqttConfigurationProvider>();
        builder.RegisterType<MqttEngine>().As<IMqttEngine>();
    }
}