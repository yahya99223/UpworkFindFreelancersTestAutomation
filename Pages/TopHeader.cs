using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
        }

        public SearchResultsPage SearchForFreelancers(string searchText)
        {
            //click on search type dropdown
            searchTypeButton.Click();
            //click on Freelancers option
            selectSearch = Driver.driver.FindElements(By.CssSelector("#search-dropdown li"));
            selectSearch.First(x => x.Text == "Freelancers").Click();
            //input the keyword in search field
            keyWordsTextbox.SendKeys(searchText);
            //Click Search button
            searchButon.Click();
            return new SearchResultsPage();
        }

    }
}
