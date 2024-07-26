using System.Collections.Generic;
using System.Threading.Tasks;
using Buurmans.Common.Converters;
using Buurmans.Scrape.Core.Interfaces;
using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core;

internal class HtmlScrapeEngine(
	IScrapeConfigurationProvider configurationProvider, 
	IScrapeResultModelFactory resultModelFactory,
	IJsonConverter jsonConverter,
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
		
		var jsonOutput = jsonConverter.Serialize(resultModels);
		return jsonOutput;
	}
}