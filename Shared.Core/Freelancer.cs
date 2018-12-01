using System;
using System.Collections.Generic;

namespace Pages
{
    public class Freelancer
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> Skills { get; set; }

        public Freelancer()
        {
            Skills = new List<string>();
        }
        public bool ContainsKeyword(string keyword)
        {
            if ($"{Name} {Title} {Location} {Description} {String.Join(" ", Skills.ToArray())}".IndexOf(keyword, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return true;
            }
            return false;
        }

        public List<string> GetFieldsContaining(string keyword)
        {
            List<string> result = new List<string>();
            if (Name.ToLower().Contains(keyword))
            {
                result.Add("Name");
            }
            if (Description != null && Description.ToLower().Contains(keyword))
            {
                result.Add("Description");
            }
            if (Title.ToLower().Contains(keyword))
            {
                result.Add("Title");
            }
            if (string.Join(" ", Skills.ToArray()).ToLower().Contains(keyword))
            {
                result.Add("Skills");
            }
            return result;
        }
    }
}
