using Autofac;
using Buurmans.Common.Interfaces;
using Buurmans.Common.Managers;

namespace Buurmans.Common;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterType<ObserverManager>().As<IObserverManager>().SingleInstance();
	}
}