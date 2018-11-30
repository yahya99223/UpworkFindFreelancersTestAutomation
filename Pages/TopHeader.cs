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
        public TopHeader()
        {
           // var wait =new WebDriverWait(Driver.driver,new TimeSpan(0,0,10)).Until(ExpectedConditions.ElementToBeSelected(By.CssSelector("#layout > nav > div > div.navbar-collapse.d-none.d-lg-flex > div.navbar-form > form > div.input-group.input-group-search-dropdown.input-group-navbar > input.form-control")));
            PageFactory.InitElements(Driver.driver,this);
        }
        [FindsBy(How = How.CssSelector, Using = "#layout > nav > div > div.navbar-collapse.d-none.d-lg-flex > div.navbar-form > form > div.input-group.input-group-search-dropdown.input-group-navbar > input.form-control")]
        public IWebElement KeyWordsTextbox { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#layout > nav > div > div.navbar-collapse.d-none.d-lg-flex > div.navbar-form > form > div.input-group.input-group-search-dropdown.input-group-navbar > div > button.btn.p-0-left-right")]
        public IWebElement SearchButon { get; set; }
    }
}
