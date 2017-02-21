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
    public class LoginTests
    {
        IWebDriver driver;
        public static string[] list = DataInput.GetTestSelection();
        
        [OneTimeSetUp]
        public void SetUp()
        {

            ThreadPool.SetMinThreads(4, 4);
            //WebDriver.Driver(GetType().Name);
            driver = WebDriver.InitDriver();
            driver.Manage().Window.Maximize();
        }


        [Test, TestCaseSource("list")]
        public void LoginTest(string name)
        {
            var journalLoginPage = new LoginPage(driver);
            journalLoginPage.GoToJournalLoginPage(name);
            journalLoginPage.Login(Config.Resource1.login, Config.Resource1.password);
            journalLoginPage.LogOut();
         
        }
        /*[Test, TestCaseSource("list")]
        public void LoginTestNegative(string name)
        {
            var journalLoginPage = new LoginPage(driver);
            journalLoginPage.GoToJournalLoginPage(name);
            journalLoginPage.Login(Resource1.login, " ");

        }*/
        [OneTimeTearDown]
        public void CleanUp()
        {
           // WebDriver.KillDriver(GetType().Name);
            driver.Quit();
        }
    }
}
