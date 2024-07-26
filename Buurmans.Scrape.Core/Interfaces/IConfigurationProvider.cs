using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core.Interfaces;

public interface IConfigurationProvider
{
	ConfigurationModel GetConfigurationModel();
}