using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMapWebCrawler.Service;

namespace SiteMapWebCrawler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrawlerController : ControllerBase
    {
        private readonly ICrawlerService _crawlerService;

        public CrawlerController(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;

        }
        // GET api/crawler/wiprodigital.com
        [HttpGet("{domain}")]
        public async Task<IEnumerable<string>> GetAsync(string domain)
        {
           return await _crawlerService.GetSiteMapAsync(domain);
        }
    }
}
