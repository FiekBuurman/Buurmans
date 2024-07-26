using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core.Interfaces;

internal interface IScrapeResultModelFactory
{
	ScrapeResultModel Create(ScrapeRequestModel requestModel, string html);
}