using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using SiteMapWebCrawler.Common;

namespace SiteMapWebCrawler.Service
{
    public class CrawlerService : ICrawlerService
    {
        private IHtmlHelper _htmlHelper;

        public CrawlerService(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;

        }
        public async Task<IEnumerable<string>> GetSiteMapAsync(string domain)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(_htmlHelper.GetUrl(domain));
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var urlList = new List<string>();

            foreach (string link in _htmlHelper.ExtractHttpUrls(html, domain))
            {
                if (link.StartsWith("http", StringComparison.InvariantCultureIgnoreCase) && !urlList.Contains(link))
                    urlList.Add(link);
            }

            return urlList;
        }

    }
}
