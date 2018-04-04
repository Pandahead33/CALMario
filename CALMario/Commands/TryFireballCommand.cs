using CALMario.Entities.Mario;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALMario.Sounds;

namespace CALMario.Commands
{
    public class TryFireballCommand : ICommand
    {
        Game1 myGame;

        public TryFireballCommand(Game1 g)
        {
            myGame = g;
        }

        public void Execute()
        {
			myGame.Player.TryFireball();
        }
    }
}
