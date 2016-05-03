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
                Say(x);
            }
        }

        public void Say(int i)
        {
            if (i % 3 == 0 && i % 5 == 0) { _outputStrategy.WriteLine("Fizz Buzz"); }
            else if (i % 3 == 0) { _outputStrategy.WriteLine("Fizz"); }
            else if (i % 5 == 0) { _outputStrategy.WriteLine("Buzz"); }
            else { _outputStrategy.WriteLine(i.ToString()); }
        }
    }
}
