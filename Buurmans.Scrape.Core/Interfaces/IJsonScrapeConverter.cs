namespace Buurmans.Scrape.Core.Interfaces;

public interface IJsonScrapeConverter
{
	T ConvertFrom<T>(string jsonString);
	string ConvertTo(object modelToConvert);
}