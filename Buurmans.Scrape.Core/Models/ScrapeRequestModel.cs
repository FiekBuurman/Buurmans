namespace Buurmans.Scrape.Core.Models;

public class ScrapeRequestModel
{
	public string Name { get; set; }
	public string Uri { get; set; }
	public string CssSelector { get; set; }
}