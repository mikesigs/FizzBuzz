using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz.Host.Infrastructure;

namespace FizzBuzz.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Configurable messages for a given number, e.g. 7 = baseball, 12 = football, ... n = foo
                Git source control with build script
            */

            var fizzBuzz = new Core.FizzBuzz(new ConsoleWriter());
            Console.WriteLine("Enter the upper bound: ");
            int upperBound;
            while (!Int32.TryParse(Console.ReadLine(), out upperBound))
            {
                Console.WriteLine("Please enter a number between 1 and " + Int32.MaxValue);
            }

            fizzBuzz.SayRange(upperBound);
            Console.ReadLine();
        }
    }
}
