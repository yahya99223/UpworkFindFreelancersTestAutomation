using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pages;

namespace TestScenarios
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Please enter the keyword you want to find");
            var keyword = Console.ReadLine()?.ToLower();
            MainPage mainPage = new MainPage();
            var searchpage = mainPage.FindFreelancer(keyword);
            var foundFreelancers = searchpage.GetAllFreelancers();
            foreach (var freelancer in foundFreelancers)
            {
                Console.Write(freelancer.Name);
                var containerFields = freelancer.GetFieldsContaining(keyword);
                if (containerFields.Any())
                {
                    Console.WriteLine($" Contains keyword in {string.Join(",", containerFields.ToArray())}");
                }
                else
                {
                    Console.WriteLine(" does not contain keyword");
                }
            }
            Random random = new Random();
            var randomFreelancerIndex = random.Next(1, searchpage.GetAllFreelancers().Count);
            var randomFreelancerPage = searchpage.GetFreelancer(randomFreelancerIndex);
            var freelancerOverview = foundFreelancers.ElementAt(randomFreelancerIndex);
            var freelancerDetailedInfo = randomFreelancerPage.FetchFreelancerInfo();
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
            var result = freelancerDetailedInfo.ContainsKeyword(keyword);
            if (result)
                Console.WriteLine($"Keyword is contained in {freelancerDetailedInfo.Name}'s details");
            else
            {
                Console.WriteLine($"Keyword is not contained in {freelancerDetailedInfo.Name}'s details");
            }
            Console.WriteLine($"The following fields match between overview and detailed page: {string.Join(", ", matches.ToArray())}");
            Console.ReadKey();
        }

    }
}
