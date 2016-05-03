using System.Collections.Generic;
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
            var divisorMessages = new Dictionary<int, string> { { y, msg } };
            var sut = new Core.FizzBuzz(divisorMessages);
            var actual = sut.Parse(x);
            actual.ShouldBe(msg);
        }
    }
}
