using CALMario.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    class ResetCommand : ICommand
    {
        Game1 myGame;
        public ResetCommand(Game1 g)
        {
            this.myGame = g;
        }

        public void Execute()
        {
            GhostPlayerInputs.TransferInputs();
            GhostPlayerInputs.CurrentRunInputs.Clear();
            GhostPlayerInputs.SpawnGhostMario = true;
            myGame.Reset();
        }
    }
}
