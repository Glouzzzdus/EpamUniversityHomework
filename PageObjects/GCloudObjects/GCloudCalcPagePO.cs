using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamUniversityHomework.PageObjects.GCloudObjects
{
    internal class GCloudCalcPagePO
    {
        private readonly IWebDriver _webDriver;

        public GCloudCalcPagePO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
