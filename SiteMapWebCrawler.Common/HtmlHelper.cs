using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace SiteMapWebCrawler.Common
{
    public class HtmlHelper : IHtmlHelper
    {

        public IEnumerable<string> ExtractHttpUrls(string htmlContent, string aMatch = null)
        {
            if (String.IsNullOrEmpty(htmlContent)) yield break;
            var matches = Constants.HttpUrlsRegex.Matches(htmlContent);
            var vMatcher = aMatch == null ? null : new Regex(aMatch);
            foreach (Match match in matches)
            {
                var vUrl = HttpUtility.UrlDecode(match.Groups["url"].Value);
                if (vMatcher == null || vMatcher.IsMatch(vUrl))
                    yield return vUrl;
            }
        }

        public string GetUrl(in string domain)
        {
            if (!domain.StartsWith("http://www.", StringComparison.InvariantCultureIgnoreCase))
                return $"http://www.{domain}";

            return domain;
        }
    }
}
