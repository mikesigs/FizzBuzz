using System;
using System.Collections.Generic;

namespace FizzBuzz.Host
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
                Git source control with build script
            */
            var divisorMap = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            var fizzBuzz = new Core.FizzBuzz(divisorMap);
            var upperBound = GetUpperBoundFromUser();

            foreach (var msg in fizzBuzz.ParseRange(1, upperBound))
            {
                Console.WriteLine(msg);
            }

            Console.WriteLine();
            Console.WriteLine("======================");
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }

        private static int GetUpperBoundFromUser()
        {
            Console.Write("Enter the upper bound: ");
            int upperBound;
            while (!Int32.TryParse(Console.ReadLine(), out upperBound))
            {
                Console.WriteLine($"Please enter a number between 1 and {Int32.MaxValue}: ");
            }
            return upperBound;
        }
    }
}
