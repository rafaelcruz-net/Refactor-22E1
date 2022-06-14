using FizzBuzzGame;
using Xunit;

namespace FizzBuzzGameTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(6, "Fizz")]
        [InlineData(9, "Fizz")]
        [InlineData(12, "Fizz")]
        [InlineData(18, "Fizz")]
        [InlineData(21, "Fizz")]
        public void Game_Should_Print_Fizz(int data, string expectedResult)
        {
            var result = FizzBuzzParser.Write(data);

            Assert.NotNull(result);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(5, "Buzz")]
        [InlineData(10, "Buzz")]
        [InlineData(20, "Buzz")]
        [InlineData(25, "Buzz")]
        [InlineData(35, "Buzz")]
        [InlineData(40, "Buzz")]
        public void Game_Should_Print_Buzz(int data, string expectedResult)
        {
            var result = FizzBuzzParser.Write(data);

            Assert.NotNull(result);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        public void Game_Should_Print_FizzBuzz(int data, string expectedResult)
        {
            var result = FizzBuzzParser.Write(data);

            Assert.NotNull(result);
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void Game_Should_Print_Correct()
        {
            for (int i = 1; i <= 100; i++)
            {
                var result = FizzBuzzParser.Write(i);
                
                if (i % 5 == 0 && i % 3 == 0)
                   Assert.Equal(result, "FizzBuzz");
                else if (i % 3 == 0)
                    Assert.Equal(result, "Fizz");
                else if (i % 5 == 0)
                    Assert.Equal(result, "Buzz");
                else
                    Assert.Equal(result, i.ToString());
            }
        }



    }
}