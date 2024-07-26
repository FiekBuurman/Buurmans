using System;
using System.Collections.Generic;
using Buurmans.Scrape.Core.Interfaces;
using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core.Providers;

internal class ConfigurationProvider : IConfigurationProvider
{
	public ConfigurationModel GetConfigurationModel()
	{
		return new ConfigurationModel
		{
			Interval = TimeSpan.FromHours(6),
			Requests = CreateScrapeRequestModels()
		};
	}

	private static List<ScrapeRequestModel> CreateScrapeRequestModels()
	{
		return
		[
			new ScrapeRequestModel
			{
				Name = "TinQ Delfgauw Price",
				Uri = "https://www.brandstof-zoeker.nl/station/tinq-delfgauw-delftsestraat-9992/",
				CssSelector = "#page > div:nth-child(3) > div > div:nth-child(2) > dl > dt:nth-child(3) > span"
			},

			new ScrapeRequestModel
			{
				Name = "Tango Delft Price",
				Uri = "https://www.brandstof-zoeker.nl/station/tango-delft-9430/",
				CssSelector = "#page > div:nth-child(3) > div > div:nth-child(2) > dl > dt:nth-child(3) > span"
			},

			new ScrapeRequestModel
			{
				Name = "Supertank Delft Price",
				Uri = "https://www.brandstof-zoeker.nl/station/supertank-delft-488/",
				CssSelector = "#page > div:nth-child(3) > div > div:nth-child(2) > dl > dt:nth-child(3) > span"
			},

			new ScrapeRequestModel
			{
				Name = "Argos Delft Price",
				Uri = "https://www.brandstof-zoeker.nl/station/argos-delft-2710/",
				CssSelector = "#page > div:nth-child(3) > div > div:nth-child(2) > dl > dt:nth-child(3) > span"
			},
			new ScrapeRequestModel
			{
				Name = "dOET IE UT?",
				Uri = "https://www.brandstof-zoeker.nl/station/argos-delft-2710/",
				CssSelector = "#page > div:nth-child(3) > div > div:nth-child(2) > dl > dt:nth-child(3) > span"
			}
		];
	}
}