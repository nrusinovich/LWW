using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Framework1
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement LoginInput
        {
            get { return driver.FindElement(By.XPath("//*[contains(@id, 'txt_UserName')]")); }
        }
        public IWebElement PasswordInput { get {return driver.FindElement(By.XPath("//*[contains(@id, 'txt_Password')]")); } }
        public IWebElement LoginButton { get { return driver.FindElement(By.XPath("//*[contains(@id, 'LoginButton')]")); } }
        public IWebElement LoginLink { get { return driver.FindElement(By.XPath("//*[contains(@id, 'lnkLogin')]")); } }
        public IWebElement LogoutLink { get { return driver.FindElement(By.XPath("//*[contains(@id, 'lnkLogout')]")); } }

        public void Login(string user, string pasw)
        {
            LoginInput.Clear();
            PasswordInput.Clear();
            LoginInput.SendKeys(user);
            PasswordInput.SendKeys(pasw);
            LoginButton.Click();
        }
        
        public void LogOut()
        {
            LogoutLink.Click();
        }
        public void GoToJournalLoginPage(string name)
        {
            var page = new MainPage(driver);
            page.GoToJournalMainPage(name);
            LoginLink.Click();

        }
    }
}
