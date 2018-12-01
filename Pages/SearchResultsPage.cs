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

        public List<Freelancer> GetAllFreelancers()
        {
            if (freelancers.Count == 0)
                foreach (var element in searchResElements)
                {
                    freelancers.Add(new FreelancerOverview(element).GetFreelancerInfo());
                }
            return freelancers;
        }

        public FreelancerPage GetFreelancer(int index)
        {
            var freelancer = new FreelancerOverview(searchResElements[index]).Explore();
            return freelancer;
        }
    }
}
