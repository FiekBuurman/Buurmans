using Autofac;

namespace Buurmans.Mqtt;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterModule<Buurmans.Common.AutofacModule>();
	}
}