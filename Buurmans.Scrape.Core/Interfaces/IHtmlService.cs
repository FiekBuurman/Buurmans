using System.Threading.Tasks;

namespace Buurmans.Scrape.Core.Interfaces;

internal interface IHtmlService
{
	Task<string> DownloadHtmlAsync(string url);
}