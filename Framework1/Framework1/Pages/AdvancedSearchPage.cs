using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace Framework1
{
    class AdvancedSearchPage
    {
        IWebDriver driver;
        public AdvancedSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement SearchButton
        {
            get { return driver.FindElement(By.XPath("//*[contains(@id, 'searchAgain')]")); }
        }
        IWebElement AddParamertButton
        {
            get { return driver.FindElement(By.XPath("//button[contains( @class,'advaddoperator')]")); }
        }
        public void GoToAdvancedSearch(string name)
        {
            var page = new MainPage(driver);
            page.GoToJournalMainPage(name);
            driver.FindElement(By.XPath("//*[contains(@id, 'lnkAdvanceSearch')]")).Click();
        }
        public void SetDate(int i)
        {
            var radioButton = driver.FindElements(By.XPath("//*[contains(@id, 'searchDatesRadioButtonList_')]"));
            radioButton.ElementAt(i).Click();
        }
        public void SetContentType(params bool[] flags)
        {
            var checkBox = driver.FindElements(By.XPath("//*[contains(@id, 'filterList')]"));
            for (int i = 0; i < Math.Min(flags.Count(), checkBox.Count); i++)
                if (flags[i])
                    checkBox[i].Click();
        }
       
        public void ExpandSearch()
        {
            AddParamertButton.Click();
            AddParamertButton.Click();
        }
        
        public void FillKeyWords(int i)
        {
            var dropdownList = driver.FindElement(By.XPath("//*[contains(@id, 'asb-keywords-row_')]"));
            
        }
        public void FillRow(int row, string type, string value)
        {
            SelectElement select = new SelectElement(driver.FindElement(By.XPath(string.Format("//*[contains(@id, 'dplScope_{0}')]", row))));
            select.SelectByValue(type);
            IWebElement inputbox = driver.FindElement(By.XPath(string.Format("//*[contains(@id, 'keywords_input_{0}')]", row)));
            inputbox.SendKeys(value);
        }
        public IWebElement SearchResults
        {
            get { return driver.FindElement(By.XPath("//*[contains(@id, 'results')]")); }
        }
        public string GetResult()
        {
            return SearchResults.Text;

        }
    }
}
