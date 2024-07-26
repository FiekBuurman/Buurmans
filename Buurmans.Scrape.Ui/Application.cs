using System;
using Buurmans.Scrape.Core;

namespace Buurmans.Scrape.Ui;

public class Application(IHtmlScrapeEngine htmlScrapeEngine) : IApplication
{
	public void Run()
	{
		var result = htmlScrapeEngine.Process().Result;
		Console.WriteLine(result);
		Console.WriteLine("Press any key to exit.");
		Console.ReadKey();
	}
}