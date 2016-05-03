using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Core
{
    public class FizzBuzz
    {
        public IEnumerable<KeyValuePair<int, string>> Run(int upperBound)
        {
            return Enumerable.Range(1, upperBound)
                      .Select(x => new KeyValuePair<int, string>(x, Say(x)));
        }

        public string Say(int i)
        {
            if (i % 3 == 0 && i % 5 == 0) { return "Fizz Buzz"; }
            else if (i % 3 == 0) { return "Fizz"; }
            else if (i % 5 == 0) { return "Buzz"; }
            else return i.ToString();
        }
    }
}
