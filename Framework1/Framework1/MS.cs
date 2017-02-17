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
        private IWebDriver driver;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        public MS(IWebDriver driver)
        {
            this.driver = driver;
        }
        Dictionary<string, Journal> journals = DataInput.GetFile();
        public static string[] list = DataInput.GetTestSelection();
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
        [DeploymentItem(@"C:\Users\ASUS\Documents\Visual Studio 2015\Projects\Framework1\Framework1\XMLFile1.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    @"C:\Users\ASUS\Documents\Visual Studio 2015\Projects\Framework1\Framework1\XMLFile1.xml", "Journal",
                     DataAccessMethod.Sequential)]
        public void MSSearchNegative()
        {
            var page = new MainPage(driver);
            string name = (string)TestContext.DataRow["Data"];
            page.GoToJournalMainPage(name);
            page.SearchBox.SendKeys("zxcvbnm,");
            page.SearchButton.Click();


        }
    }
}
