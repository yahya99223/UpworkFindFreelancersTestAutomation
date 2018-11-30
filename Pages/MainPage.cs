using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class MainPage
    {
        private TopHeader topHeader { get; set; }

        public MainPage()
        {
            Driver.Factory(BroswerType.Firefox).Navigate().GoToUrl("https://www.upwork.com/"); ;
            topHeader= new TopHeader();
        }
        public SearchResultsPage FindFreelancer(string searchText)
        {
            topHeader.KeyWordsTextbox.SendKeys(searchText);
            topHeader.SearchButon.Click();
            return new SearchResultsPage();
        }
    }
}
