using CALMario.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class RemoveItemCommand : ICommand
    {
        private IItem toRemove;
        private Game1 myGame;

        public RemoveItemCommand(Game1 g, IItem i)
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
