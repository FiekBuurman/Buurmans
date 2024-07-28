using Autofac;
using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Core.Providers;
using Buurmans.AmbiLight.Core.Services;

namespace Buurmans.AmbiLight.Core;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterType<ScreenCaptureService>().As<IScreenCaptureService>().SingleInstance();
		builder.RegisterType<ColorCalculationService>().As<IColorCalculationService>().SingleInstance();
		builder.RegisterType<SettingsModelProvider>().As<ISettingsModelProvider>().SingleInstance();
	}
}