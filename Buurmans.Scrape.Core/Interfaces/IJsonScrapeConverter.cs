namespace Buurmans.Scrape.Core.Interfaces;

internal interface IJsonScrapeConverter
{
	T ConvertFrom<T>(string jsonString);
	string ConvertTo(object modelToConvert);
}