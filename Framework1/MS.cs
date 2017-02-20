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
        public static string[] list = DataInput.GetTestSelection();
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        [TestMethod]
        [DeploymentItem("Framework1\\XMLFile1.xml")]
           [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                       @"C:\Users\Nadzeya_Rusinovich\documents\visual studio 2015\Projects\Framework1\Framework1\XMLFile1.xml", "Journal",
                      DataAccessMethod.Sequential)]
        public void MSSearchPositive()
        {
           var page = new MainPage(driver);
           string name = (string)TestContext.DataRow["Data"];
            page.GoToJournalMainPage(name);
            page.SearchBox.SendKeys("health");
            page.SearchButton.Click();
        }
        [TestMethod]
        [DeploymentItem("Framework1\\XMLFile1.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    @"C:\Users\Nadzeya_Rusinovich\documents\visual studio 2015\Projects\Framework1\Framework1\XMLFile1.xml", "Journal",
                     DataAccessMethod.Sequential)]
        public void MSSearchNegative()
        {
            var page = new MainPage(driver);
            string name = (string)TestContext.DataRow["Data"];
            page.GoToJournalMainPage(name);
            page.SearchBox.SendKeys("zxcvbnm,");
            page.SearchButton.Click();


        }
        [ClassCleanup]
        public void CleanAll()
        {
            driver.Quit();
        }
    }
}
