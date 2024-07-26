using Autofac;
using Buurmans.Scrape.Core.Factories;
using Buurmans.Scrape.Core.Providers;
using Buurmans.Scrape.Core.Services;

namespace Buurmans.Scrape.Core.Autofac;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterModule<Buurmans.Common.AutofacModule>();
        builder.RegisterType<ScrapeResultModelFactory>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<ScrapeConfigurationProvider>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<HtmlService>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<ScrapeEngine>().AsImplementedInterfaces().SingleInstance();
	}
}