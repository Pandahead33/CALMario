using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class AddScoreCommand : ICommand
    {
        private Game1 myGame;
        private int amount;

        public AddScoreCommand(Game1 game, int amount)
        {
            myGame = game;
            this.amount = amount;
        }

        public void Execute()
        {
            myGame.Stats.Score += amount;
        }
    }
}
