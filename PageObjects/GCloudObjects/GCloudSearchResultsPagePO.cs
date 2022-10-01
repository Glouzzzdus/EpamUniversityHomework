using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamUniversityHomework.PageObjects.GCloudObjects
{
    internal class GCloudSearchResultsPagePO
    {
        private readonly IWebDriver _webDriver;

        private readonly By _SearchResult = By.XPath("//div[contains(@class,'resultsbox')]//a[@href='https://cloud.google.com/products/calculator']");

        public GCloudSearchResultsPagePO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GCloudCalcPagePO ChoiceResult()
        {
            _webDriver.FindElement(_SearchResult).Click();
            return new GCloudCalcPagePO(_webDriver);
        }
    }
}
