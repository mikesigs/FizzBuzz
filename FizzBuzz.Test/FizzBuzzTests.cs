using System.IO;
using FizzBuzz.Core;
using Moq;
using Shouldly;
using Xunit;

namespace FizzBuzz.Test
{
    public class FizzBuzzTests
    {
        private readonly Core.FizzBuzz _sut;

        public FizzBuzzTests()
        {
            _sut = new Core.FizzBuzz(new Mock<IOutputStrategy>().Object);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void WhenXIsDivisibleBy3SayFizz(int x)
        {
            var actual = _sut.Parse(x);
            actual.ShouldBe("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void WhenXIsDivisibleBy5SayBuzz(int x)
        {
            var actual = _sut.Parse(x);
            actual.ShouldBe("Buzz");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void WhenXIsNotDivisibleBy3Or5SayX(int x)
        {
            var actual = _sut.Parse(x);
            actual.ShouldBe(x.ToString());
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void WhenXIsDivisbleByBoth3And5SayFizzBuzz(int x)
        {
            var actual = _sut.Parse(x);
            actual.ShouldBe("Fizz Buzz");
        }
    }
}
