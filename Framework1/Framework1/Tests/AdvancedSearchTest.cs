using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Framework1.Tests
{
   // [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class AdvancedSearchTest
    {
        Dictionary<string, Journal> journals = DataInput.GetFile();
        public static string[] list = new string[] { "jonajournal" };//DataInput.GetTestSelection();
        IWebDriver driver = new ChromeDriver();
        [OneTimeSetUp]
        public void SetUp()
        {
            // WebDriver.Driver(GetType().Name);
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
            WebDriver.KillDriver(GetType().Name);
            driver.Quit();
        }
    }
}
