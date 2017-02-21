using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Security.Permissions;
using System.Threading;

namespace Framework1.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class AdvancedSearchTest
    {
        List<string> list = XmlInput.ReadFromXml();
        IWebDriver driver;
        [OneTimeSetUp]
        public void SetUp()
        {
            // WebDriver.Driver(GetType().Name);
            driver = WebDriver.InitDriver();
            driver.Manage().Window.Maximize();
        }

        [Test, TestCaseSource("list")]
        public void AdvancedPositive(string name)
        {
            var page = new AdvancedSearchPage(driver);
            page.GoToAdvancedSearch(name);
            page.ExpandSearch();
            page.SetDate(1);//from 0 to 5
            page.SetContentType(false, false);
            page.FillRow(1, "All Fields", "Video");
            page.SearchButton.Click();
            Assert.True(page.GetResult() != "0 results");
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
