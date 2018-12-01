using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class MainPage
    {
        private TopHeader topHeader { get; set; }

        public MainPage()
        {
            Driver.Factory(BroswerType.Firefox);
            goTo();
            topHeader = new TopHeader();
        }

        private void goTo()
        {
            Driver.driver.Navigate().GoToUrl("https://www.upwork.com/");
        }
        public SearchResultsPage FindFreelancer(string searchText)
        {
            return topHeader.SearchForFreelancers(searchText);
        }
    }
}
