using System;
using System.Collections.Generic;
using System.Linq;
using Pages;
using Shared.Core;
using TestScenarios.Helpers;

namespace TestScenarios
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the keyword you want to find");
            var keyword = Console.ReadLine()?.ToLower();
            Console.WriteLine("Type C for Chrome or F for Firefox");
            var browser = Console.ReadLine()?.ToLower();
            TestSettingsSetter.SetSettings(browser);

            FreelancersSearchTestScenario scenario= new FreelancersSearchTestScenario();
            scenario.TestScenarioWithKeyword(keyword);
            Console.ReadKey();
        }

    }
}
