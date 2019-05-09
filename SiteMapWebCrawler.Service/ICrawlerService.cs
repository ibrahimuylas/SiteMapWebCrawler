using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMapWebCrawler.Service
{
    public interface ICrawlerService
    {
        Task<IEnumerable<string>> GetSiteMapAsync(string domain);
    }
}
