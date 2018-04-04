using CALMario.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class AddItemCommand : ICommand
    {
        private IItem toAdd;
        private Game1 myGame;

        public AddItemCommand(Game1 g, IItem i)
        {
            myGame = g;
            toAdd = i;
        }
        
        public void Execute()
        {
            myGame.Entities.Add(toAdd);
        }
    }
}
