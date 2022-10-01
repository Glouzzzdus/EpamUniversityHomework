using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamUniversityHomework.PageObjects.YopMailObjects
{
    internal class YopMailMainPagePO
    {
        private readonly IWebDriver _webDriver;

        public readonly By _yopMailCookieNoteBtn = By.CssSelector("#accept");

        private readonly By _emailGenerateBtn = By.XPath("//div[@id='listeliens']/a[@href='email-generator']");
        
        public YopMailMainPagePO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public YopMailRandomGeneratedMailPO GetRandomEmail()
        {
            _webDriver.FindElement(_emailGenerateBtn).Click();
            return new YopMailRandomGeneratedMailPO(_webDriver);
        }        
    }
}
