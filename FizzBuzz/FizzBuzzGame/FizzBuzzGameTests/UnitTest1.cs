using FizzBuzzGame;
using Xunit;

namespace FizzBuzzGameTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(21)]
        public void Game_Should_Print_Fizz(int data)
        {
            var result = FizzBuzzParser.Write(data);

            Assert.NotNull(result);
            Assert.Equal(result, "Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(35)]
        [InlineData(40)]
        public void Game_Should_Print_Buzz(int data)
        {
            var result = FizzBuzzParser.Write(data);

            Assert.NotNull(result);
            Assert.Equal(result, "Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void Game_Should_Print_FizzBuzz(int data)
        {
            var result = FizzBuzzParser.Write(data);

            Assert.NotNull(result);
            Assert.Equal(result, "FizzBuzz");
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