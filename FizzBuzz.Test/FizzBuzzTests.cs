using System.IO;
using FizzBuzz.Core;
using Moq;
using Shouldly;
using Xunit;

namespace FizzBuzz.Test
{
    public class FizzBuzzTests
    {
        private readonly Mock<IOutputStrategy> _mockOutputStrategy;
        private readonly Core.FizzBuzz _sut;

        public FizzBuzzTests()
        {
            _mockOutputStrategy = new Mock<IOutputStrategy>();
            _sut = new Core.FizzBuzz(_mockOutputStrategy.Object);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void WhenXIsDivisibleBy3SayFizz(int x)
        {
            ShouldSayOnce(x, "Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void WhenXIsDivisibleBy5SayBuzz(int x)
        {
            ShouldSayOnce(x, "Buzz");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void WhenXIsNotDivisibleBy3Or5SayX(int x)
        {
            ShouldSayOnce(x, x.ToString());
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void WhenXIsDivisbleByBoth3And5SayFizzBuzz(int x)
        {
            ShouldSayOnce(x, "Fizz Buzz");
        }

        private void ShouldSayOnce(int input, string expectedOutput)
        {
            _sut.Say(input);
            _mockOutputStrategy.Verify(o => o.WriteLine(expectedOutput), Times.Once);
        }
    }
}
