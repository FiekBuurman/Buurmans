using System.Threading.Tasks;

namespace Buurmans.Scrape.Core
{
	public interface IHtmlScrapeEngine
	{
		Task<string> Process();
	}
}