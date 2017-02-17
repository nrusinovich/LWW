using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework1
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    class LoginTests
    {
        Dictionary<string, Journal> journals = DataInput.GetFile();
        IWebDriver driver = new ChromeDriver();
        public static string[] list = new string[] { "jonajournal" };//DataInput.GetTestSelection();
        
        [OneTimeSetUp]
        public void SetUp()
        {
            //WebDriver.Driver(GetType().Name);
            driver.Manage().Window.Maximize();
        }


        [Test, TestCaseSource("list")]
        public void LoginTest(string name)
        {
            var journalLoginPage = new LoginPage(driver);
            journalLoginPage.GoToJournalLoginPage(name);
            journalLoginPage.Login(Resource1.login, Resource1.password);
            if (journalLoginPage.LogoutLink.Displayed)
                journalLoginPage.LogOut();
            else
                Assert.True(false);
        }
        [Test, TestCaseSource("list")]
        public void LoginTestNegative(string name)
        {
            var journalLoginPage = new LoginPage(driver);
            journalLoginPage.GoToJournalLoginPage(name);
            journalLoginPage.Login(Resource1.login, " ");

        }
        [OneTimeTearDown]
        public void CleanUp()
        {
           // WebDriver.KillDriver(GetType().Name);
            driver.Quit();
        }
    }
}
