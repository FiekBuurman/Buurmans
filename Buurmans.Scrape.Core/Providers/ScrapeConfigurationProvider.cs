using System;
using System.Collections.Generic;
using Buurmans.Common.Converters;
using Buurmans.Common.Providers;
using Buurmans.Scrape.Core.Interfaces;
using Buurmans.Scrape.Core.Models;

namespace Buurmans.Scrape.Core.Providers;

internal class ScrapeConfigurationProvider(IJsonConverter jsonConverter) 
	: BaseConfigurationProvider<ScrapeConfigurationSettingsModel>(jsonConverter), IScrapeConfigurationProvider
{
	public new ScrapeConfigurationSettingsModel GetSettings()
	{
		var settings = base.GetSettings();
		return settings ?? CreateDefaultSettings();
	}

	private ScrapeConfigurationSettingsModel CreateDefaultSettings()
	{
		var settings = new ScrapeConfigurationSettingsModel
		{
			Interval = TimeSpan.FromHours(6),
			Requests = CreateDefailtScrapeRequestModels()
		};

		SaveSettings(settings);
		return settings;
	}

	private static List<ScrapeRequestModel> CreateDefailtScrapeRequestModels()
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