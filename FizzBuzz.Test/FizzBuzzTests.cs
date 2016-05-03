using Shouldly;
using Xunit;

namespace FizzBuzz.Test
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void WhenXIsDivisibleBy3SayFizz(int x)
        {
            var sut = new Core.FizzBuzz();
            var actual = sut.Say(x);
            actual.ShouldBe("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void WhenXIsDivisibleBy5SayBuzz(int x)
        {
            var sut = new Core.FizzBuzz();
            var actual = sut.Say(x);
            actual.ShouldBe("Buzz");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void WhenXIsNotDivisibleBy3Or5SayX(int x)
        {
            var sut = new Core.FizzBuzz();
            var actual = sut.Say(x);
            actual.ShouldBe(x.ToString());
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void WhenXIsDivisbleByBoth3And5SayFizzBuzz(int x)
        {
            var sut = new Core.FizzBuzz();
            var actual = sut.Say(x);
            actual.ShouldBe("Fizz Buzz");
        }
    }
}
