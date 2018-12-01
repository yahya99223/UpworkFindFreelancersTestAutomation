using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Shared.Core;

namespace Pages
{
    public static class Driver
    {
        public static IWebDriver driver;
        
        public static void Factory(BroswerType type)
        {
            //setting driver for the selected browser
            if (type == BroswerType.Chrome)
            {
                if (driver == null)
                    driver = new ChromeDriver("Lib");
            }
            else
            {
                if (driver == null)
                    driver = new FirefoxDriver("Lib");
            }
            //clearing all cookies
            driver.Manage().Cookies.DeleteAllCookies();
        }
    }
   
}
