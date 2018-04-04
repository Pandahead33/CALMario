using CALMario.Entities.Mario;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands.MovementCommands
{
    class MoveMarioHorizontallyCommand : ICommand
    {
        private Game1 game;
        private float pixels;

        public MoveMarioHorizontallyCommand(Game1 game, float pixels)
        {
            this.pixels = pixels;
            this.game = game;
        }

        public void Execute()
        {
            IMario mario = game.Player;
            if(!mario.IsDead)
                mario.Location = new Vector2(mario.Location.X + pixels, mario.Location.Y);
        }
    }
}
