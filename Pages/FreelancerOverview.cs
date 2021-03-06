﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class FreelancerOverview
    {
        [FindsBy(How = How.ClassName, Using = "freelancer-tile-name")]
        private IWebElement nameHolder { get; set; }


        [FindsBy(How = How.ClassName, Using = "freelancer-tile-title")]
        private IWebElement titleHolder { get; set; }

        [FindsBy(How = How.ClassName, Using = "freelancer-tile-location")]
        private IWebElement locationHolder { get; set; }

        [FindsBy(How = How.ClassName, Using = "freelancer-tile-description")]
        private IWebElement descriptionHolder { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".o-tag-skill > span")]
        private IList<IWebElement> skillsTags { get; set; }

        public FreelancerOverview(IWebElement element)
        {
            PageFactory.InitElements(element, this);
        }
        /// <summary>
        /// This method will read values of freelancer overview from webpage to an object representing freelancer
        /// </summary>
        /// <returns></returns>
        public Freelancer GetFreelancerInfo()
        {
            var freelancer = new Freelancer()
            {
                Name = nameHolder?.GetAttribute("textContent").Trim(),
                Location = locationHolder?.Text,
                Title = titleHolder?.Text,
                Skills = skillsTags?.Select(x => x.Text).ToList()
            };
            try
            {
                freelancer.Description = descriptionHolder?.GetAttribute("textContent");
            }
            catch (Exception e)
            {
               //this freelancer did not add description
            }
            return freelancer;
        }
        /// <summary>
        /// This method will click on the current freelancer title to navigate to his/her page
        /// </summary>
        /// <returns></returns>
        public FreelancerPage Explore()
        {
            IJavaScriptExecutor executor = ((Driver.driver) as IJavaScriptExecutor);
            executor.ExecuteScript("arguments[0].click()", nameHolder);
            return new FreelancerPage();
        }

    }
}
