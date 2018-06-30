using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avazquez_Test.Models
{
    public class DNA
    {
        public IEnumerable<string> ListOfSegments { get; set; }

        public DNA(IEnumerable<string> list)
        {
            ListOfSegments = list;
        }

        override
        public string ToString()
        {
            StringBuilder bob = new StringBuilder();
            int num = 0;
            foreach(string s  in ListOfSegments)
            {
                bob.Append(s);
                if (num < ListOfSegments.Count()-1)
                    bob.Append(", ");
                num += 1;
            }
            return bob.ToString();
        }

        public string DNAString()
        {
            StringBuilder bob = new StringBuilder();
            foreach(string s in ListOfSegments)
            {
                bob.Append(s);
            }

            return bob.ToString();
        }

    }
}
