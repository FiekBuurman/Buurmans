using System.Collections.Generic;
using System.Threading.Tasks;
using Buurmans.Scrape.Core.Interfaces;
using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core;

internal class HtmlScrapeEngine(
	IScrapeConfigurationProvider configurationProvider, 
	IScrapeResultModelFactory resultModelFactory,
	IJsonScrapeConverter jsonScrapeConverter,
	IHtmlService htmlService) : IHtmlScrapeEngine
{

	public async Task<string> Process()
	{
		var requestModels = configurationProvider.GetSettings().Requests;
		var resultModels = new List<ScrapeResultModel>();
			
		foreach (var requestModel in requestModels)
		{
			var html = await htmlService.DownloadHtmlAsync(requestModel.Uri);
			resultModels.Add(resultModelFactory.Create(requestModel, html));
		}
		
		var jsonOutput = jsonScrapeConverter.ConvertTo(resultModels);
		return jsonOutput;
	}
}

public interface IHtmlScrapeEngine
{
	Task<string> Process();
}