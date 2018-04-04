using CALMario.Entities.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands.ItemCommands
{
    public class ChangeMarioCommand : ICommand
    {
        Game1 myGame;
        IMario newMario;

        public ChangeMarioCommand(Game1 g, IMario mario)
        {
            myGame = g;
            newMario = mario;
        }

        public void Execute()
        {
            myGame.Player = newMario;
        }
    }
}
