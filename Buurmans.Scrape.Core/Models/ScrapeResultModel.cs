namespace Buurmans.Scrape.Core.Models;

internal class ScrapeResultModel
{
	public string Name { get; set; }
	public string Uri { get; set; }
	public string CssSelector { get; set; }
	public string Value { get; set; }
}