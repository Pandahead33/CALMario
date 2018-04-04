using CALMario.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class RemoveEnemyCommand : ICommand
    {
        private IEnemy toRemove;
        private Game1 myGame;

        public RemoveEnemyCommand(Game1 g, IEnemy e)
        {
            myGame = g;
            toRemove = e;
        }
        
        public void Execute()
        {
            myGame.Entities.Remove(toRemove);
        }
    }
}
