using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class FreelancerPage
    {
        public FreelancerPage()
        {
            Thread.Sleep(2000);
            PageFactory.InitElements(Driver.driver, this);
            Name = nameHolder.Text;
            try
            {

                Description = descriptionHolder.Text;
            }
            catch (Exception e)
            {
                //freelancer did not add description
            }

            try
            {

                Location = locationHolder.Text;
            }
            catch (Exception e)
            {
                //freelancer did not add location
            }
        }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public bool ContainsKeyword(string keyword)
        {
            if ($"{Name} {Location} {Description}".IndexOf(keyword, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return true;
            }
            return false;
        }
        [FindsBy(How = How.CssSelector, Using = "h2.m-xs-bottom > span:nth-child(1)")]
        private IWebElement nameHolder { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".w-700")]
        private IWebElement locationHolder { get; set; }
        [FindsBy(How = How.CssSelector, Using = " .overlay-container")]
        private IWebElement descriptionHolder { get; set; }

    }
}
