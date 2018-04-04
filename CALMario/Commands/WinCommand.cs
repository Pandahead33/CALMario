using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALMario.Sounds;

namespace CALMario.Commands
{
    class WinCommand : ICommand
    {
        Game1 myGame;
        public WinCommand(Game1 g)
        {
            this.myGame = g;
        }
        public void Execute()
        {
            myGame.Level.Win();
        }
    }
}
