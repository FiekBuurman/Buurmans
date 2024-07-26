using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core.Interfaces;

public interface IScrapeResultModelFactory
{
	ScrapeResultModel Create(ScrapeRequestModel requestModel, string html);
}