using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    class ChangeGravityCommand : ICommand
    {
        private Game1 myGame;
        public ChangeGravityCommand(Game1 g)
        {
            myGame = g;
        }
        public void Execute()
        {
            myGame.Player.GravityMultiplier.Toggle();
        }
    }
}
