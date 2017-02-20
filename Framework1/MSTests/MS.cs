using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
namespace Framework1
{
    [TestClass]
    public class MS
    {
        private TestContext testContextInstance;
        private static IWebDriver driver = WebDriver.InitDriver();
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        [TestMethod]
        [DeploymentItem(@"..\..\Data\journals.xml")]
           [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\Data\journals.xml", "Journal",
                      DataAccessMethod.Sequential)]
        public void MSSearchPositive()
        {
           var page = new MainPage(driver);
           string name = (string) TestContext.DataRow["string"];
            page.GoToJournalMainPage(name);
            page.SearchBox.SendKeys("health");
            page.SearchButton.Click();
        }
        [TestMethod]
        [DeploymentItem(@"..\..\Data\journals.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",@"..\..\Data\journals.xml", "string",
                     DataAccessMethod.Sequential)]
        public void MSSearchNegative()
        {
            var page = new MainPage(driver);
            string name = (string)TestContext.DataRow["string"];
            page.GoToJournalMainPage(name);
            page.SearchBox.SendKeys("zxcvbnm,");
            page.SearchButton.Click();


        }
        [ClassCleanup]
        public static void CleanAll()
        {
            driver.Quit();
        }
    }
}
