using System;
using System.Net;
using Buurmans.Scrape.Core.Interfaces;
using Buurmans.Scrape.Core.Models;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace Buurmans.Scrape.Core.Factories;

internal class ScrapeResultModelFactory : IScrapeResultModelFactory
{
	public ScrapeResultModel Create(ScrapeRequestModel requestModel, string html)
	{
		var scrapedValue = ExtractValueFromHtml(html, requestModel.CssSelector);
		return new ScrapeResultModel
		{
			Name = requestModel.Name,
			Uri = requestModel.Uri,
			CssSelector = requestModel.CssSelector,
			Value = !string.IsNullOrEmpty(scrapedValue) ? scrapedValue : "Not found"
		};
	}

	private static string ExtractValueFromHtml(string html, string cssSelector)
	{
		try
		{
			var document = new HtmlDocument();
			document.LoadHtml(html);
				
			var node = document.DocumentNode.QuerySelector(cssSelector);
			return node == null ? html : WebUtility.HtmlDecode(node.InnerText.Trim());
		}
		catch(Exception exception)
		{
			var message = $"Unable to find value from the given selector: {exception.Message}";
			return message;
		}
	}
}