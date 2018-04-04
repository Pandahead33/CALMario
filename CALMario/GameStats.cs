using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario
{
    public class GameStats : IGameStats
    {
        public int Coins { get; set; }
        public int Lives { get; set; }
        public int Time { get; set; }
        public int Score { get; set; }

        public GameStats()
        {
            Coins = 0;
            Lives = 0;
            Time = 0;
            Score = 0;
        }
    }
}
