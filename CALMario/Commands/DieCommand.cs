using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class DieCommand : ICommand
    {
        private Game1 myGame;

        public DieCommand(Game1 g)
        {
            myGame = g;
        }

        public void Execute()
        {
            myGame.Level.Die();
        }
    }
}
