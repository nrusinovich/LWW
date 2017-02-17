using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
namespace Framework1
{    [TestFixture]
    class SimpleSearchTests
    {
        Dictionary<string, Journal> journals = DataInput.GetFile();
        public static string[] list = DataInput.GetTestSelection();
        [Test, TestCaseSource("list")]
        public void SearchPositive(string name)
        {
            var page = new JournalMainPage();
            page.NavigateHere(name);
            page.SearchBox.SendKeys("health");
            page.SearchButton.Click();


        }
        [Test, TestCaseSource("list")]
        public void SearchNegative(string name)
        {
            var page = new JournalMainPage();
            page.NavigateHere(name);
            page.SearchBox.SendKeys("zxcvbnm,");
            page.SearchButton.Click();
            Assert.True(page.GetResult() == "0 results");


        }
    }
}
