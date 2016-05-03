using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace FizzBuzz.Test
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void WhenXIsDivisibleBy3SayFizz(int x)
        {
            var sut = new Core.FizzBuzz();
            var actual = sut.Say(x);
            actual.ShouldBe("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void WhenXIsDivisibleBy5SayBuzz(int x)
        {
            var sut = new Core.FizzBuzz();
            var actual = sut.Say(x);
            actual.ShouldBe("Buzz");
        }
    }
}
