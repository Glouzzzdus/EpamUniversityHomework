using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamUniversityHomework.PageObjects.YopMailObjects
{
    internal class YopMailRandomGeneratedMailPO
    {
        private readonly IWebDriver _webDriver;

        private readonly By _checkInboxBtn = By.XPath("//button/span[text()='Check Inbox']");
        private readonly By _generatedEmail = By.CssSelector("#egen");

        public YopMailRandomGeneratedMailPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetGeneratedEmail()
        {
            return _webDriver.FindElement(_generatedEmail).Text;
        }
        public YopMailInboxPO CheckInbox()
        {
            _webDriver.FindElement(_checkInboxBtn).Click();
            return new YopMailInboxPO(_webDriver);
        }
    }
}
