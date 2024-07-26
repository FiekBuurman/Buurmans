using Autofac;
using Buurmans.Scrape.Core.Converters;
using Buurmans.Scrape.Core.Factories;
using Buurmans.Scrape.Core.Providers;
using Buurmans.Scrape.Core.Services;

namespace Buurmans.Scrape.Core.Autofac;

public class AutofacModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterType<JsonScrapeConverter>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<ScrapeResultModelFactory>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<ConfigurationProvider>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<HtmlService>().AsImplementedInterfaces().SingleInstance();
		builder.RegisterType<HtmlScrapeEngine>().AsImplementedInterfaces().SingleInstance();
	}
}