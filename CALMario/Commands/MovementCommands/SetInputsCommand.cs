using CALMario.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands.MovementCommands
{
    public class SetInputsCommand : ICommand
    {
        private Game1 myGame;
        private MarioInputs myInputs;

        public SetInputsCommand(Game1 g, MarioInputs mi)
        {
            myGame = g;
            myInputs = mi;
        }

        public void Execute()
        {
            myGame.Player.Controls = myInputs;
            GhostPlayerInputs.CurrentRunInputs.Add(myInputs);
        }
    }
}
