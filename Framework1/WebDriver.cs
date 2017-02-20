using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.Collections.Concurrent;
using OpenQA.Selenium.Remote;

namespace Framework1
{
    public class WebDriver
    {
        public WebDriver() { }

        private static IWebDriver driver;
        public static IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    var service = FirefoxDriverService.CreateDefaultService();
                    driver = new FirefoxDriver(service);
                    break;
                case "remote":
                    DesiredCapabilities capability = DesiredCapabilities.Firefox();
                    capability.SetCapability("browserstack.user", "nadya26");
                    capability.SetCapability("browserstack.key", "huZ9vpNzzTJHF47Jcwiq");

                    driver = new RemoteWebDriver(
                      new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
                    );
                    break;

            }
            return driver;

        }
        public static IWebDriver InitDriver()
        {

            return GetDriver(Config.Resource1.browser);
            
        }
  
    }
}
