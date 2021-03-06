﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class CollectCoinCommand : ICommand
    {
        private Game1 myGame;

        public CollectCoinCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Stats.Score += CommandUtility.CoinPoints;
            myGame.Stats.Coins++;
        }
    }
}
