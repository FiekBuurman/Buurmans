using System.Threading.Tasks;

namespace Buurmans.Scrape.Core
{
	public interface IScrapeEngine
	{
		Task<string> Process();
	}
}