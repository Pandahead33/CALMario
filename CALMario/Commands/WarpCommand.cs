using CALMario.Entities.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    class WarpCommand : ICommand
    {
        private Game1 myGame;
        private PowerupStateType myType;

        public WarpCommand(Game1 g, PowerupStateType t)
        {
            this.myGame = g;
            myType = t;
        }
        public void Execute()
        {
            myGame.Level.Warp(myType);
        }
    }
}
