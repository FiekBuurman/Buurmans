using Autofac;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.AmbiLight.Form.ViewModels;
using Buurmans.AmbiLight.Form.Views;

namespace Buurmans.AmbiLight.Form;

internal static class ApplicationSetup
{
	public static IContainer CreateContainer()
	{
		var builder = new ContainerBuilder();

		builder.RegisterModule<Buurmans.AmbiLight.Core.AutofacModule>();

		builder.RegisterType<MainView>().As<IMainView>().SingleInstance();
		builder.RegisterType<MainViewModel>().As<IMainViewModel>().SingleInstance();
		builder.RegisterType<SettingsView>().As<ISettingsView>().SingleInstance();
		builder.RegisterType<SettingsViewModel>().As<ISettingsViewModel>().SingleInstance();
		
		return builder.Build();
	}
}