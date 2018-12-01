using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class FreelancerPage
    {
        [FindsBy(How = How.CssSelector, Using = "h2.m-xs-bottom > span:nth-child(1)")]
        private IWebElement nameHolder { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".w-700")]
        private IWebElement locationHolder { get; set; }
        [FindsBy(How = How.CssSelector, Using = "o-profile-overview.d-none > div:nth-child(1) > p:nth-child(1) > span:nth-child(1) > span:nth-child(1)")]
        private IWebElement descriptionHolder { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".overlay-container > div:nth-child(1)")]
        private IWebElement titleHolder { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".o-tag-skill")]
        private IList<IWebElement> skillsTags { get; set; }

        public FreelancerPage()
        {
            Thread.Sleep(5000);
            PageFactory.InitElements(Driver.driver, this);
        }
        /// <summary>
        /// This method will read values of freelancer details from webpage to an object representing freelancer
        /// </summary>
        /// <returns></returns>
        public Freelancer FetchFreelancerInfo()
        {
            var freelancer = new Freelancer();
            try
            {
                freelancer.Name = nameHolder.Text;
            }
            catch (Exception e)
            {
                //could not fetch name
            }

            try
            {
                freelancer.Title = titleHolder?.GetAttribute("textContent").Trim();
            }
            catch (Exception e)
            {
                //could not fetch title
            }
            try
            {
                freelancer.Skills = skillsTags.Select(x => x.Text).ToList();
            }
            catch (Exception e)
            {
                //could not fetch skills
            }

            try
            {
                freelancer.Description = descriptionHolder?.GetAttribute("textContent").Trim();
            }
            catch (Exception e)
            {
                //freelancer did not add description
            }

            try
            {

                freelancer.Location = locationHolder.Text;
            }
            catch (Exception e)
            {
                //freelancer did not add location
            }

            return freelancer;
        }

    }
}
