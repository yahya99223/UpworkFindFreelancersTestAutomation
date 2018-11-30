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
                if (driver == null)
                    driver = new ChromeDriver("D:\\");
                return driver;
            }
            else
            {
                if (driver == null)
                    driver = new FirefoxDriver("D:\\");
                return driver;
            }
        }
    }
    public enum BroswerType { Chrome, Firefox, Edge }
}
