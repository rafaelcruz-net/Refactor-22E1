using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class TicTacToeTests
    {
        [Fact]
        public void SolveGame_GameInProgress()
        {
            var board = new int[,]
            {
                {0,2,1},
                {0,1,0},
                {2,0,0}
            };

            var expect = TicTacToe.SolveGame(board);

            Assert.True(expect == -1);

        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWin_InRow(int winner, int expectedResult)
        {
            var board = new[,]
            {
                {winner, winner, winner},
                {1, 1, 2 },
                {2, 0, 0}
            };

            var result = TicTacToe.SolveGame(board);

            Assert.True(result == expectedResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWin_InLastRow(int winner, int expectedResult)
        {
            var board = new[,]
            {
                {1, 1, 2 },
                {2, 0, 0},
                {winner, winner, winner},
            };

            var result = TicTacToe.SolveGame(board);

            Assert.True(result == expectedResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWin_InColumn(int winner, int expectedResult)
        {

            var board = new[,]
           {
                {winner, 0, 1},
                {winner, 1, 2},
                {winner, 0, 0},
            };

            var result = TicTacToe.SolveGame(board);

            Assert.True(result == expectedResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWin_InColumnLast(int winner, int expectedResult)
        {

            var board = new[,]
            {
                {0, 1, winner},
                {1, 2, winner},
                {0, 0, winner},
            };

            var result = TicTacToe.SolveGame(board);

            Assert.True(result == expectedResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWin_InDiagonal(int winner, int expectedResult)
        {

            var board = new[,]
            {
                {winner, 1, 0},
                {1, winner, 0},
                {0, 0, winner},
            };

            var result = TicTacToe.SolveGame(board);

            Assert.True(result == expectedResult);

        }
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWin_InDiagonalInverse(int winner, int expectedResult)
        {

            var board = new[,]
            {
                {1, 0, winner},
                {1, winner, 0},
                {winner, 0, 0},
            };

            var result = TicTacToe.SolveGame(board);

            Assert.True(result == expectedResult);

        }
    }
}
