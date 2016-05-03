using System;
using FizzBuzz.Core;

namespace FizzBuzz.Host.Infrastructure
{
    public class ConsoleWriter: IOutputStrategy
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
