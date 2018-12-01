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
            var keyword=Console.ReadLine();
            MainPage mainPage = new MainPage();
            var searchpage= mainPage.FindFreelancer(keyword);
            foreach (var freelancer in searchpage.GetFreelancers())
            {
                Console.Out.Write(freelancer.Name);
                if (freelancer.ContainsKeyword(keyword))
                {
                    Console.Out.WriteLine(" Pass");
                }
                else
                {
                    Console.Out.WriteLine(" Fail");
                }
            }
            Random random = new Random();
            var randomFreelancerIndex=random.Next(1, searchpage.GetFreelancers().Count);
            var randomFreelancer = searchpage.GetFreelancer(randomFreelancerIndex);
            var result=randomFreelancer.ContainsKeyword(keyword);
        }
    }
}
