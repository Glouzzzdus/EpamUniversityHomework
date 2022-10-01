using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamUniversityHomework
{
    internal class Utils
    {
        public static IWebElement GetElementWithWait(IWebDriver driver, long waitTimeFromSeconds, By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeFromSeconds)).Until(d => d.FindElement(by).Displayed);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(by));
            return driver.FindElement(by);
        }
        public static bool CheckForElementExist(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
