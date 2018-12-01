using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class SearchResultsPage
    {
        [FindsBy(How = How.ClassName, Using = "air-card-hover_tile")]
        private IList<IWebElement> searchResultsElements { get; set; }

        private List<Freelancer> freelancers { get; set; }

        public SearchResultsPage()
        {
            freelancers = new List<Freelancer>();
            PageFactory.InitElements(Driver.driver, this);
        }
        /// <summary>
        /// Returns all freelancers found according to search criteria in search page
        /// </summary>
        /// <returns></returns>
        public List<Freelancer> GetAllFreelancers()
        {
            if (freelancers.Count == 0)
                foreach (var element in searchResultsElements)
                {
                    freelancers.Add(new FreelancerOverview(element).GetFreelancerInfo());
                }
            return freelancers;
        }

        /// <summary>
        /// Navigates to freelancer listed with selected index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FreelancerPage GetFreelancer(int index)
        {
            var freelancer = new FreelancerOverview(searchResultsElements[index]).Explore();
            return freelancer;
        }
    }
}
