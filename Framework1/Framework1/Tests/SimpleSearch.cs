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
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class SimpleSearch
    {
        IWebDriver driver;
        public static string[] list = new string[] {"jonajournal" };//DataInput.GetTestSelection();
         [OneTimeSetUp]
        public void SetUp()
        {
            // WebDriver.Driver(GetType().Name);
            driver = WebDriver.InitDriver();
            driver.Manage().Window.Maximize();

        }
        [Ignore("")]
        [Test, TestCaseSource("list")]
        public void SearchPositive(string name)
        {
            var page = new MainPage(driver);
            page.GoToJournalMainPage(name);
            page.SearchBox.SendKeys("health");
            page.SearchButton.Click();


        }
        [Test, TestCaseSource("list")]
        public void SearchNegative(string name)
        {
            var page = new MainPage(driver);
            page.GoToJournalMainPage(name);
            page.SearchBox.SendKeys("zxcvbnm,");
            page.SearchButton.Click();
            Assert.True(page.GetResult() == "0 results");
            


        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            //WebDriver.KillDriver(GetType().Name);
            driver.Quit();
        }
        
    }
}
