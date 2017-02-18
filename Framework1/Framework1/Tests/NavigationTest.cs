using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Framework1
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    class NavigationTest
    {
        Dictionary<string, Journal> journals = DataInput.GetFile();
        public static string[] list = DataInput.GetTestSelection();
        IWebDriver driver;
        [OneTimeSetUp]
        public void SetUp()
        {

            ThreadPool.SetMinThreads(4, 4);
            driver = WebDriver.InitDriver();
            driver.Manage().Window.Maximize();

        }

        [Test, TestCaseSource("list")]
        public void TestNavigation(string name)
        {
            var page = new MainPage(driver);
            Journal j;
            journals.TryGetValue(name, out j);
            Assert.True(j != null);

            page.GoToJournalMainPage(j.Name + "/");

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            foreach (Category cat in j.menuContent)
            {
                MainPage.SetCategoryLocator(cat.Name);
                if (cat.content.Count != 0)
                    page.CatElement.Click();
                foreach (var s in cat.content)
                {
                    MainPage.SetItemLocator(s);
                }
            }
        }
        [OneTimeTearDown]
        public void CleanUp()
        {           
           driver.Quit();
        }

    }
}
