using CALMario.Entities.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class RemoveBlockCommand : ICommand
    {
        private IBlock toRemove;
        private Game1 myGame;

        public RemoveBlockCommand(Game1 g, IBlock b)
        {
            myGame = g;
            toRemove = b;
        }
        
        public void Execute()
        {
            myGame.Entities.Remove(toRemove);
        }
    }
}
