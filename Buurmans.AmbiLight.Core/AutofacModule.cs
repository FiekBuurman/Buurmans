using Autofac;
using ScreenAmbiLightToMQTT.Core.Interfaces;
using ScreenAmbiLightToMQTT.Core.Managers;
using ScreenAmbiLightToMQTT.Core.Providers;
using ScreenAmbiLightToMQTT.Core.Services;

namespace ScreenAmbiLightToMQTT.Core
{
	public class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ScreenCaptureService>().As<IScreenCaptureService>().SingleInstance();
			builder.RegisterType<ColorCalculationService>().As<IColorCalculationService>().SingleInstance();
			builder.RegisterType<SettingsModelProvider>().As<ISettingsModelProvider>().SingleInstance();
			builder.RegisterType<ObserverManager>().As<IObserverManager>().SingleInstance();
		}
	}
}
