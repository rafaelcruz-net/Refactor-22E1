using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class TennisCalculator : IScoreCalculator
    {
        public string Calculate(Player playerA, Player playerB)
        {
            if (CheckIfGameIsWon(playerA.Score, playerB.Score))
                return playerA.Score > playerB.Score ? $"Win for {playerA.Name}" : $"Win for {playerB.Name}";
            else if (CheckIfScoreIsDeuce(playerA.Score, playerB.Score))
                return "Deuce";
            else if (CheckIfScoreIsAdvantage(playerA.Score, playerB.Score))
                return playerA.Score > playerB.Score ? $"Advantage {playerA.Name}" : $"Advantage {playerB.Name}";
            else if (playerA.Score == playerB.Score)
                return $"{TranslateScore(playerA.Score)}-All";

            return $"{TranslateScore(playerA.Score)}-{TranslateScore(playerB.Score)}";
        }

        private string TranslateScore(int playerAScore) => playerAScore switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => null
        };

        private bool CheckIfScoreIsAdvantage(int playerAScore, int playerBScore)
        {
            return playerAScore >= 3 && playerBScore >= 3 && playerAScore != playerBScore;
        }

        private bool CheckIfScoreIsDeuce(int playerAScore, int playerBScore)
        {
            return playerAScore >= 3 && playerBScore >= 3 && playerAScore == playerBScore;
        }

        private bool CheckIfGameIsWon(int playerAScore, int playerBScore)
        {
            return ((playerAScore > 3 || playerBScore > 3) && Math.Abs(playerAScore - playerBScore) > 1);
        }
    }
}
