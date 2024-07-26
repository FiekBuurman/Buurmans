using System;
using System.Net.Http;
using System.Threading.Tasks;
using Buurmans.Scrape.Core.Interfaces;

namespace Buurmans.Scrape.Core.Services;

internal class HtmlService : IHtmlService
{
	public async Task<string> DownloadHtmlAsync(string url)
	{
		using var client = new HttpClient();
		try
		{
			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}
		catch (Exception ex)
		{
			return $"Error downloading HTML from {url}: {ex.Message}";
		}
	}
}