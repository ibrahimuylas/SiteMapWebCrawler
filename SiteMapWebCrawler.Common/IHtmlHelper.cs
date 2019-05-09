using System;
using System.Collections.Generic;

namespace SiteMapWebCrawler.Common
{
    public interface IHtmlHelper
    {
        string GetUrl(in string domain);

        IEnumerable<string> ExtractHttpUrls(string htmlContent, string aMatch = null);

    }
}
