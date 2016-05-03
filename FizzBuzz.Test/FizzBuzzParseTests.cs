using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace FizzBuzz.Test
{
    public class FizzBuzzParseTests
    {
        [Theory]
        [InlineData(3, 3, "Fizz")]
        [InlineData(6, 3, "Fizz")]
        [InlineData(5, 5, "Buzz")]
        [InlineData(10, 5, "Buzz")]
        [InlineData(7, 7, "Boom")]
        public void WhenXIsDivislbeByYShouldReturnMsg(int x, int y, string msg)
        {
            var divisorMap = new Dictionary<int, string> { { y, msg } };
            var sut = new Core.FizzBuzz(divisorMap);
            var actual = sut.Parse(x);
            actual.ShouldBe(msg);
        }

        [Fact]
        public void ParseRangeTest()
        {
            var divisorMap = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" },
                { 6, "Boom" }
            };

            var expected = new[]
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz Boom", "7", "8", "Fizz", "Buzz"
            };

            var sut = new Core.FizzBuzz(divisorMap);
            var actual = sut.ParseRange(1, 10).ToList();
            actual.ShouldBe(expected);
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldContain(x => x == "Fizz", 2),
                () => actual.ShouldContain(x => x == "Buzz", 2),
                () => actual.ShouldContain(x => x == "Fizz Boom", 1),
                () => actual.ShouldContain(x => x == "1", 1),
                () => actual.ShouldContain(x => x == "2", 1),
                () => actual.ShouldContain(x => x == "4", 1),
                () => actual.ShouldContain(x => x == "7", 1),
                () => actual.ShouldContain(x => x == "8", 1));
        }
    }
}
