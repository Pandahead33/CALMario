using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario
{
    public interface IGameStats
    {
        int Coins { get; set; }
        int Lives { get; set; }
        int Time { get; set; }
        int Score { get; set; }
    }
}
