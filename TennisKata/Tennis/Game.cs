using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Game : ITennisGame
    {
        private readonly IScoreCalculator _calculator;
        private readonly Player playerA;
        private readonly Player playerB;

        public Game(string playerNameA, string playerNameB)
        {
            _calculator = ScoreFactory.Create();
            this.playerA = new Player(playerNameA);
            this.playerB = new Player(playerNameB);
        }


        public string GetScore()
        {
            return this._calculator.Calculate(this.playerA, this.playerB);
        }

        public void WonPoint(string playerName)
        {
            if (this.playerA.IsCurrentPlayer(playerName))
                this.playerA.WinPoint();
            else
                this.playerB.WinPoint();
        }
    }
}
