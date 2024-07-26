using System;
using Buurmans.Scrape.Core.Interfaces;
using Newtonsoft.Json;

namespace Buurmans.Scrape.Core.Converters;

internal class JsonScrapeConverter : IJsonScrapeConverter
{
	public T ConvertFrom<T>(string jsonString)
	{
		try
		{
			return JsonConvert.DeserializeObject<T>(jsonString);
		}
		catch (JsonException ex)
		{
			Console.WriteLine($"Error converting JSON to object: {ex.Message}");
			return default;
		}
	}

	public string ConvertTo(object modelToConvert)
	{
		try
		{
			return JsonConvert.SerializeObject(modelToConvert, Formatting.Indented);
		}
		catch (JsonException ex)
		{
			Console.WriteLine($"Error converting object to JSON: {ex.Message}");
			return string.Empty;
		}
	}
}