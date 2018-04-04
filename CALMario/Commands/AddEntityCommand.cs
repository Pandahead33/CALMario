using CALMario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class AddEntityCommand : ICommand
    {
        private IEntity toAdd;
        private Game1 myGame;

        public AddEntityCommand(Game1 g, IEntity e)
        {
            myGame = g;
            toAdd = e;
        }

        public void Execute()
        {
            myGame.Entities.Add(toAdd);
        }
    }
}
