using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class SearchResultsPage
    {
        [FindsBy(How = How.ClassName, Using = "air-card-hover_tile")]
        private IList<IWebElement> searchResElements { get; set; }

        private List<Freelancer> freelancers { get; set; }

        public SearchResultsPage()
        {
            freelancers = new List<Freelancer>();
            PageFactory.InitElements(Driver.driver, this);
        }

        public List<Freelancer> GetFreelancers()
        {
            if (freelancers.Count == 0)
                foreach (var element in searchResElements)
                {
                    freelancers.Add(new SearchResult(element).GetFreelancerInfo());
                }
            return freelancers;
        }

        public FreelancerPage GetFreelancer(int index)
        {
            var freelancer = new SearchResult(searchResElements[index - 1]).Explore();
            return freelancer;
        }
    }
}
