using System;
using System.Text.RegularExpressions;

namespace SiteMapWebCrawler.Common
{
    public static class Constants
    {
        internal static readonly Regex HttpUrlsRegex = new Regex(@"(?<url>((http|https):[/][/]|www.)([a-z]|[A-Z]|[0-9]|[_/.=&?%-]|[~])*)", RegexOptions.IgnoreCase);

    }
}
