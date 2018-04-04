using CALMario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class RemoveEntityCommand : ICommand
    {
        private IEntity toRemove;
        private Game1 myGame;

        public RemoveEntityCommand(Game1 g, IEntity i)
        {
            myGame = g;
            toRemove = i;
        }
        
        public void Execute()
        {
            myGame.Entities.Remove(toRemove);
        }
    }
}
