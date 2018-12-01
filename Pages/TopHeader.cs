using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    class TopHeader
    {
        [FindsBy(How = How.CssSelector, Using = "#layout > nav > div > div.navbar-collapse.d-none.d-lg-flex > div.navbar-form > form > div.input-group.input-group-search-dropdown.input-group-navbar > input.form-control")]
        private IWebElement keyWordsTextbox { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#search-dropdown li")]
        private IList<IWebElement> selectSearch { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div.d-lg-flex > div:nth-child(1) > form:nth-child(1) > div:nth-child(3) > div:nth-child(1) > button:nth-child(2)")]
        private IWebElement searchTypeButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#layout > nav > div > div.navbar-collapse.d-none.d-lg-flex > div.navbar-form > form > div.input-group.input-group-search-dropdown.input-group-navbar > div > button.btn.p-0-left-right")]
        private IWebElement searchButon { get; set; }
        public TopHeader()
        {
            
            PageFactory.InitElements(Driver.driver, this);
            searchTypeButton.Click();
            selectSearch = Driver.driver.FindElements(By.CssSelector("#search-dropdown li"));
            selectSearch.First(x=>x.Text=="Freelancers").Click();
        }

        public SearchResultsPage SearchForFreelancers(string searchText)
        {
            searchTypeButton.Click();
            keyWordsTextbox.SendKeys(searchText);
            searchButon.Click();
            return new SearchResultsPage();
        }

    }
}
