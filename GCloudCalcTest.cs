using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using Ocelot.Infrastructure;
using SeleniumExtras.WaitHelpers;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Linq;
using EpamUniversityHomework.PageObjects.YopMailObjects;
using EpamUniversityHomework.PageObjects.GCloudObjects;

namespace EpamUniversityHomework
{
    public class Tests
    {
        private IWebDriver driver;
        private IWebDriver drivermail;

        private readonly string _searchInput = "Google Cloud Platform Pricing Calculator";
        
        private readonly By _computeEngineBtn = By.XPath("//*[@id='mainForm']//md-tab-item[1]/div[1]");
        private readonly By _numberOfInstances = By.XPath("//label[contains(text(),'Number of instances')]/following-sibling::input");
        private readonly By _operatingSysSoftDropdown = By.XPath("//md-select[contains(@aria-label,'Operating System / Software')]//div");
        private readonly By _operatingSysSoftChoise = By.XPath("//md-option[@value='free']//div");
        private readonly By _provisioningModelDropdown = By.XPath("//md-select[@placeholder='VM Class']//span");
        private readonly By _provisioningModelChoise = By.XPath("//md-option//div[contains(text(),'Regular')]");
        private readonly By _seriesDropdown = By.XPath("//md-select[@placeholder='Series' and contains(@ng-model,'computeServer')]//div");
        private readonly By _seriesChoise = By.XPath("//md-option[@value='n1' and contains(@ng-repeat,'computeServer')]");
        private readonly By _machineTypeDropdown = By.XPath("//md-select[@placeholder='Instance type' and contains(@ng-model,'computeServer')]");
        private readonly By _machineTypeChoise = By.XPath("//md-option//div[contains(text(),'n1-standard-8 (vCPUs: 8, RAM: 30GB)')]");
        private readonly By _addGPUsCheckBox = By.XPath("//div[13]//md-checkbox[@aria-label='Add GPUs']");
        private readonly By _GPUTypeDropdown = By.XPath("//md-select[@placeholder='GPU type']");
        private readonly By _GPUTypeChoise = By.XPath("//md-option[contains(@ng-repeat,'gpuList') and @value='NVIDIA_TESLA_V100']");
        private readonly By _numberOfGPUsDropdown = By.XPath("//md-select[@placeholder='Number of GPUs']");
        private readonly By _numberOfGPUsChoise = By.XPath("//md-option[contains(@ng-repeat,'supportedGpuNumbers') and @value='1']");
        private readonly By _localSSDDropdown = By.XPath("//md-select[@placeholder='Local SSD' and contains(@ng-model,'computeServer')]");
        private readonly By _localSSDChoise = By.XPath("//md-option[contains(@ng-repeat,'dynamicSsd.computeServer') and @value='2']");
        private readonly By _datacenterLocationDropdown = By.XPath("//div[16]//md-select[@placeholder='Datacenter location']//div");
        private readonly By _datacenterLocationChoise = By.XPath("//md-option[@value='europe-west3'and contains(@ng-repeat,'computeServer')]");
        private readonly By _committedUsageDropdown = By.XPath("//md-select[@placeholder='Committed usage' and contains(@ng-model,'computeServer')]/md-select-value");
        private readonly By _committedUsageChoise = By.XPath("//div[11]/md-select-menu//md-option[@ng-value='1']");

        private readonly By _addToEstimateBtn = By.XPath("//button[contains(@ng-disabled,'computeServer') and @aria-label='Add to Estimate']");
        private readonly By _sendMailBtn = By.CssSelector("#email_quote");
        private readonly By _estimateCostField = By.XPath("//*[@id='resultBlock']//b");
        private readonly By _sendMailInput = By.XPath("//div[3]/md-input-container/input");
        private readonly By _confirmMailBtn = By.XPath("//md-dialog-actions/button[@aria-label='Send Email']");

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-popup");
            driver = new ChromeDriver(options);
            drivermail = new ChromeDriver();
            drivermail.Navigate().GoToUrl("https://yopmail.com/");
            driver.Navigate().GoToUrl("https://cloud.google.com/");
            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void Test1()
        {
            var GCloudMainPage = new GCloudMainPagePO(driver);
            var GCloudSearchResultPage = new GCloudSearchResultsPagePO(driver);
            var YopMailMainPage = new YopMailMainPagePO(drivermail);
            var YopMailRandomGeneratedMail = new YopMailRandomGeneratedMailPO(drivermail);
            var YopMailInbox = new YopMailInboxPO(drivermail);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            GCloudMainPage.StartSearching(_searchInput);
            GCloudSearchResultPage.ChoiceResult();            
            
            CookieNotificationCatcher(driver, GCloudMainPage._gCloudCookieNoteBtn);

            driver.SwitchTo().Frame(0);
            driver.SwitchTo().Frame(1);

            IWebElement ComputeEngineBtn = GetElementWithWait(driver, 2, _computeEngineBtn);
            ComputeEngineBtn.Click();
            IWebElement NumberOfInstances = GetElementWithWait(driver, 10, _numberOfInstances);
            NumberOfInstances.Click();
            NumberOfInstances.SendKeys("4");
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement OperatingSysSoftDropdown = GetElementWithWait(driver, 10, _operatingSysSoftDropdown);
            OperatingSysSoftDropdown.Click();
            IWebElement OperatingSysSoftChoise = GetElementWithWait(driver, 5, _operatingSysSoftChoise);
            OperatingSysSoftChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement ProvisioningModelDropdown = GetElementWithWait(driver, 5, _provisioningModelDropdown);
            ProvisioningModelDropdown.Click();
            IWebElement ProvisioningModelChoise = GetElementWithWait(driver, 5, _provisioningModelChoise);
            ProvisioningModelChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement SeriesDropdown = GetElementWithWait(driver, 5, _seriesDropdown);
            SeriesDropdown.Click();
            IWebElement SeriesChoise = GetElementWithWait(driver, 5, _seriesChoise);
            SeriesChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement MachineTypeDropdown = GetElementWithWait(driver, 5, _machineTypeDropdown);
            MachineTypeDropdown.Click();            
            IWebElement MachineTypeChoise = GetElementWithWait(driver, 8, _machineTypeChoise);
            MachineTypeChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement AddGPUsCheckBox = GetElementWithWait(driver, 8, _addGPUsCheckBox);
            AddGPUsCheckBox.Click();
            IWebElement GPUTypeDropdown = GetElementWithWait(driver, 8, _GPUTypeDropdown);
            GPUTypeDropdown.Click();
            IWebElement GPUTypeChoise = GetElementWithWait(driver, 5, _GPUTypeChoise);
            GPUTypeChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement NumberOfGPUsDropdown = GetElementWithWait(driver, 5, _numberOfGPUsDropdown);
            NumberOfGPUsDropdown.Click();
            IWebElement NumberOfGPUsChoise = GetElementWithWait(driver, 5, _numberOfGPUsChoise);
            NumberOfGPUsChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement LocalSSDDropdown = GetElementWithWait(driver, 5, _localSSDDropdown);
            LocalSSDDropdown.Click();
            IWebElement LocalSSDChoise = GetElementWithWait(driver, 5, _localSSDChoise);
            LocalSSDChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 350)");
            IWebElement DatacenterLocationDropdown = GetElementWithWait(driver, 8, _datacenterLocationDropdown);
            DatacenterLocationDropdown.Click();
            IWebElement DatacenterLocationChoise = GetElementWithWait(driver, 8, _datacenterLocationChoise);
            jse.ExecuteScript("arguments[0].click();", DatacenterLocationChoise); 
            jse.ExecuteScript("window.scrollBy(0, 150)");
            IWebElement CommittedUsageDropdown = GetElementWithWait(driver, 5, _committedUsageDropdown);
            CommittedUsageDropdown.Click();
            IWebElement CommittedUsageChoise = GetElementWithWait(driver, 5, _committedUsageChoise);
            CommittedUsageChoise.Click();
            jse.ExecuteScript("window.scrollBy(0, 150)");

            IWebElement AddToEstimateBtn = GetElementWithWait(driver, 5, _addToEstimateBtn);
            AddToEstimateBtn.Click();

            IWebElement EstimateCostField = GetElementWithWait(driver, 5, _estimateCostField);
            string EstimateCostExceptionResult = EstimateCostField.Text;

            
            CookieNotificationCatcher(drivermail,  YopMailMainPage._yopMailCookieNoteBtn);
            YopMailMainPage.GetRandomEmail();
            string Email = YopMailRandomGeneratedMail.GetGeneratedEmail();

            IWebElement SendMailBtn = GetElementWithWait(driver, 5, _sendMailBtn);
            SendMailBtn.Click();
            IWebElement SendMailInput = GetElementWithWait(driver, 5, _sendMailInput);
            SendMailInput.SendKeys(Email);
            IWebElement ConfirmSendEmail = GetElementWithWait(driver, 8, _confirmMailBtn);
            ConfirmSendEmail.Click();

            CookieNotificationCatcher(drivermail, YopMailMainPage._yopMailCookieNoteBtn);
            YopMailRandomGeneratedMail.CheckInbox();                        
            YopMailInbox.CheckIncomes();
            string ReceiveCost = YopMailInbox.GetReceiveCost();

            Assert.True(EstimateCostExceptionResult.Contains(ReceiveCost));
        }
        //public void CookieNotificationCatcher(IWebDriver driver, By cookieWindow, By cookieBtn)
        //{
        //    if (driver.FindElement(cookieWindow).Enabled)
        //    {
        //        driver.FindElement(cookieBtn).Click();
        //    }
        //}

        public IWebElement GetElementWithWait(IWebDriver driver, long waitTimeFromSeconds, By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeFromSeconds)).Until(d => d.FindElement(by).Displayed);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(by));
            return driver.FindElement(by);
        }
        private IWebElement GetElementWithWaitJS(IWebDriver driver, long waitTimeFromSeconds, By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeFromSeconds)).Until(d => d.FindElement(by).Enabled);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(by));
            jse.ExecuteScript("window.scrollBy(0, 150)");
            return driver.FindElement(by);
        }

        public bool CheckForElementExist(IWebDriver driver, string s)
        {
            try 
            {
                driver.PageSource.Contains(s);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void CookieNotificationCatcher(IWebDriver driver, By cookieBtn)
        {
            try
            {
                driver.FindElement(cookieBtn).Click();
            }
            catch (NoSuchElementException)
            {}
        }

        [TearDown]
        public void TearDown()
        {            
            //driver.Quit();
        }
    }
}