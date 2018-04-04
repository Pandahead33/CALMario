using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class OneUpCommand : ICommand
    {
        private Game1 myGame;

        public OneUpCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Stats.Lives++;
        }
    }
}
