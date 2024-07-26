using System;
using System.Collections.Generic;

namespace Buurmans.Scrape.Core.Models;

public class ConfigurationModel
{
	public TimeSpan Interval { get; set; }  
	public List<ScrapeRequestModel> Requests { get; set; }
}