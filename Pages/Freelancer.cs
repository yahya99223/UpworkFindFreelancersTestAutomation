using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Freelancer
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> Skills { get; set; }

        public bool ContainsKeyword(string keyword)
        {
            if ($"{Name} {Title} {Location} {Description} {String.Join(" ", Skills.ToArray())}".IndexOf(keyword, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return true;
            }
            return false;
        }
    }
}
