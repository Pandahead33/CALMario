using CALMario.Entities.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    class ShopCommand : ICommand
    {
        private Game1 myGame;

        public ShopCommand(Game1 g)
        {
            this.myGame = g;

        }
        public void Execute()
        {
			myGame.Level.GoToShop(myGame.Player.StateMachine.State);
        }
    }
}
