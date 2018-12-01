using Shared.Core;

namespace Pages
{
    public class MainPage
    {
        private TopHeader topHeader { get; set; }

        public MainPage()
        {
            Driver.Factory(TestSettings.Browser);
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
