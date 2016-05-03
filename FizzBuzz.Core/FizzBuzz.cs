using System.Linq;

namespace FizzBuzz.Core
{
    public class FizzBuzz
    {
        private readonly IOutputStrategy _outputStrategy;

        public FizzBuzz(IOutputStrategy outputStrategy)
        {
            _outputStrategy = outputStrategy;
        }

        public void SayRange(int upperBound)
        {
            foreach (var x in Enumerable.Range(1, upperBound))
            {
                Parse(x);
            }
        }

        public string Parse(int i)
        {
            if (i % 3 == 0 && i % 5 == 0) { return "Fizz Buzz"; }
            if (i % 3 == 0) { return "Fizz"; }
            if (i % 5 == 0) { return "Buzz"; }
            return i.ToString();
        }
    }
}
