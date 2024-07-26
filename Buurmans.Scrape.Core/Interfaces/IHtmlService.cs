using System.Threading.Tasks;

namespace Buurmans.Scrape.Core.Interfaces;

public interface IHtmlService
{
	Task<string> DownloadHtmlAsync(string url);
}