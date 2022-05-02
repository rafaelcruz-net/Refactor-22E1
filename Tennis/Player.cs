using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Player
    {
        public int Score { get; set; }

        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void WinPoint()
        {
            Score++;
        }

        public bool IsCurrentPlayer(string playerName)
        {
            return this.Name.Equals(playerName);
        }
    }
}
