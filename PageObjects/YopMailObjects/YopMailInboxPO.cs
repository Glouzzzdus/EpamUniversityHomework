using Ocelot.Infrastructure;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamUniversityHomework.PageObjects.YopMailObjects
{
    internal class YopMailInboxPO
    {
        private readonly IWebDriver _webDriver;

        private readonly By _emptyInboxMsg = By.LinkText("This inbox is empty");
        private readonly By _incomeLetterBtn = By.XPath("//div[@class='m']");
        private readonly By _inboxRefreshBtn = By.Id("refresh");
        private readonly By _receivedCostField = By.XPath("//div[@id='mail']//td[2]/h3");
        public YopMailInboxPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void CheckIncomes()
        {
            do
            {
                _webDriver.FindElement(_inboxRefreshBtn).Click();
                Wait.WaitFor(300);
            }while (Utils.CheckForElementExist(_webDriver, _emptyInboxMsg));
        }
        public string GetReceiveCost()
        {
            _webDriver.SwitchTo().Frame("ifinbox");
            _webDriver.FindElement(_incomeLetterBtn).Click();
            _webDriver.SwitchTo().DefaultContent();
            _webDriver.SwitchTo().Frame("ifmail");            
            return _webDriver.FindElement(_receivedCostField).Text;
        }
    }
}
