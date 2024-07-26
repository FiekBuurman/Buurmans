using Buurmans.Common.Interfaces;
using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core.Interfaces;

internal interface IScrapeConfigurationProvider : IBaseConfigurationProvider<ScrapeConfigurationSettingsModel>
{
	new ScrapeConfigurationSettingsModel GetSettings();
}