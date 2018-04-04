using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    class PauseCommand : ICommand
    {
        Game1 mygame;
        public PauseCommand(Game1 g)
        {
            this.mygame = g;
        }
        public void Execute()
        {
            Sounds.SoundFactory.Factory.CreatePauseSFX().Play();
            mygame.paused = !mygame.paused;
        }
    }
}
