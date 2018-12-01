using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Pages
{
    public static class Driver
    {
        public static IWebDriver driver;
        
        public static IWebDriver Factory(BroswerType type)
        {
            if (type == BroswerType.Chrome)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                if (driver == null)
                    driver = new ChromeDriver("D:\\",options);
            }
            else
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArgument("--start-maximized");
                if (driver == null)
                    driver = new FirefoxDriver("D:\\",options);
            }

            driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }
    }
    public enum BroswerType { Chrome, Firefox, Edge }
}
