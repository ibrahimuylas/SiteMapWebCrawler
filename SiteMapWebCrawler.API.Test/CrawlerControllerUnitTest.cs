using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SiteMapWebCrawler.Controllers;
using SiteMapWebCrawler.Service;
using Xunit;

namespace SiteMapWebCrawler.API.Test
{
    public class UnitTest1
    {
        [Fact]
        public static void NullCollectionThrows()
        {
            // Arrange
            var mockRepo = new Mock<ICrawlerService>();
            var controller = new CrawlerController(mockRepo.Object);

            //Act
            var result = controller.GetAsync("wiprodigital.com");

            Assert.NotNull(result);
            Assert.NotEmpty((System.Collections.IEnumerable)result);
        }

        [Fact]
        public void HasContainOtherUrls()
        {
            var domain = "wiprodigital.com";
            // Arrange
            var mockRepo = new Mock<ICrawlerService>();
            var controller = new CrawlerController(mockRepo.Object);

            //Act
            var result = controller.GetAsync(domain);
            var items = ((System.Collections.IEnumerable)result).Cast<string>().ToArray();

            //Assert
            Assert.All(items, x => Assert.Contains(domain, x));


        }
    }
}
