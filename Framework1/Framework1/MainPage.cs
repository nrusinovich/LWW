using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Framework1
{
    class MainPage
    {
        private static string naviLocator;
        private static string menuLocator;
        private static  IWebDriver driver;
        public MainPage(IWebDriver driverp)
        {
            driver = driverp;
        }


        public static void SetCategoryLocator(string cat)
        {
            naviLocator = String.Format("//a[contains(.,'{0}')]", cat);
        }

        public static void SetItemLocator(string cat)
        {
            menuLocator = $"//span[@class={cat}]";
        }

        public IWebElement CatElement
        {
            get { return driver.FindElement(By.XPath(naviLocator)); }
            set { }
        }

        public IWebElement MenuElement
        {
            get { return driver.FindElement(By.XPath(menuLocator)); }
        }
        public IWebElement SearchBox
        {
            get { return driver.FindElement(By.XPath("//*[contains(@id, 'txtKeywords')]")); }
        }
        public IWebElement SearchButton
        {
            get { return driver.FindElement(By.XPath("//*[contains(@id, 'btnGlobalSearchMagnifier')]")); }
        }
        public IWebElement SearchResults
        {
            get { return driver.FindElement(By.XPath("//*[contains(@id, 'results')]")); }
        }
        public string GetResult()
        {
            return SearchResults.Text;
        }
        public void GoToJournalMainPage(string name)
        {
            driver.Navigate().GoToUrl(Resource1.MainLink + name);
        }
    }
}
