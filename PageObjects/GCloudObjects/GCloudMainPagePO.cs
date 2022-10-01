using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamUniversityHomework.PageObjects.GCloudObjects
{
    internal class GCloudMainPagePO
    {
        private readonly IWebDriver _webDriver;

        public readonly By _gCloudCookieNoteBtn = By.XPath("//devsite-snackbar//button");
        private readonly By _mainSearchBtn = By.XPath("//devsite-header//div/input");
        
        public GCloudMainPagePO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GCloudSearchResultsPagePO StartSearching(string s)
        {
            _webDriver.FindElement(_mainSearchBtn).Click();
            _webDriver.FindElement(_mainSearchBtn).SendKeys(s + Keys.Enter);
            return new GCloudSearchResultsPagePO(_webDriver);
        }

        
    }
}
