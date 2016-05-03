using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Add Fizz Buzz unit test i.e. 15
                Configurable messages for a given number, e.g. 7 = baseball, 12 = football, ... n = foo
                Git source control with build script
            */

            var fizzBuzz = new Core.FizzBuzz();
            Console.WriteLine("Enter the upper bound: ");
            int upperBound;
            while (!Int32.TryParse(Console.ReadLine(), out upperBound))
            {
                Console.WriteLine("Please enter a number between 1 and " + Int32.MaxValue);
            }

            var results = fizzBuzz.Run(upperBound);
            foreach (var kvp in results)
            {
                Console.WriteLine(kvp.Value);
            }

            Console.ReadLine();
        }
    }
}
