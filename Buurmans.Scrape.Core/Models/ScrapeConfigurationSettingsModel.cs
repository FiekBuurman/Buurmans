using System;
using System.Collections.Generic;

namespace Buurmans.Scrape.Core.Models;

internal class ScrapeConfigurationSettingsModel
{
	public TimeSpan Interval { get; set; }  
	public List<ScrapeRequestModel> Requests { get; set; }
}