
using System;
using System.Collections.Generic;
using System.Linq;
using Pages;

namespace TestScenarios
{
    public class FreelancersSearchTestScenario
    {
        public void RunWith(string keyword)
        {
            Console.WriteLine("Navigating to main page");
            MainPage mainPage = new MainPage();
            Console.WriteLine("Inputing keyword in search field and pressing search button");
            var searchpage = mainPage.FindFreelancer(keyword);
            Console.WriteLine("Reading freelancers listed in first page");
            var foundFreelancers = searchpage.GetAllFreelancers();
            Console.WriteLine("Found freelancers are:");
            foreach (var freelancer in foundFreelancers)
            {
                Console.Write(freelancer.Name);
                var containerFields = freelancer.GetFieldsContaining(keyword);
                if (containerFields.Any())
                {
                    Console.WriteLine($" which contains keyword in {string.Join(", ", containerFields.ToArray())}");
                }
                else
                {
                    Console.WriteLine(" which does not contain keyword in overview");
                }
            }
            //generating a random number with range [1, listed freelancers count]
            var randomFreelancerIndex = new Random().Next(1, searchpage.GetAllFreelancers().Count);
            //selecting freelancer with random index
            var freelancerOverview = foundFreelancers.ElementAt(randomFreelancerIndex);
            Console.WriteLine($"Going to random freelancer page, chosen freelancer is {freelancerOverview.Name}");
            var randomFreelancerPage = searchpage.GetFreelancer(randomFreelancerIndex);

            Console.WriteLine($"Reading details listed in {freelancerOverview.Name}'s page");
            var freelancerDetailedInfo = randomFreelancerPage.FetchFreelancerInfo();

            Console.WriteLine($"Comparing fields between overview and page");
            List<string> matches = new List<string>();
            if (freelancerDetailedInfo.Name == freelancerOverview.Name ||
                (!string.IsNullOrEmpty(freelancerDetailedInfo.Name) &&
                 freelancerDetailedInfo.Name.StartsWith(freelancerOverview.Name)))
            {
                matches.Add("Name");
            }
            if (freelancerDetailedInfo.Description == freelancerOverview.Description ||
                (!string.IsNullOrEmpty(freelancerDetailedInfo.Description)
                && freelancerDetailedInfo.Description.Trim().Contains(freelancerOverview.Description.Replace("...", "").Trim())))
            {
                matches.Add("Description");
            }
            if (!freelancerOverview.Skills.Except(freelancerDetailedInfo.Skills).Any())
            {
                matches.Add("Skills");
            }
            if (freelancerDetailedInfo.Title == freelancerOverview.Title)
            {
                matches.Add("Title");
            }
            if (freelancerDetailedInfo.Location.Contains(freelancerOverview.Location))
            {
                matches.Add("Location");
            }
            Console.WriteLine($"The following fields match between overview and detailed page: {string.Join(", ", matches.ToArray())}");

            Console.WriteLine($"Checking whether {freelancerOverview.Name}'s page contains keyword");
            var result = freelancerDetailedInfo.ContainsKeyword(keyword);
            if (result)
                Console.WriteLine($"Keyword is contained in {freelancerDetailedInfo.Name}'s details in the following areas:{ string.Join(", ", freelancerDetailedInfo.GetFieldsContaining(keyword).ToArray())}");
            else
            {
                Console.WriteLine($"Keyword is not contained in {freelancerDetailedInfo.Name}'s details");
            }
        }
    }
}
