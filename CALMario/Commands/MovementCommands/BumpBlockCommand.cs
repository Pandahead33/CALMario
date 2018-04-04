using CALMario.Entities.Blocks;
using CALMario.Entities.Mario;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands.MovementCommands
{
    class BumpBlockCommand : ICommand
    {
        private IBlock block;
        private float speed;
        private float acceleration;

        public BumpBlockCommand(IBlock block, float speed, float acceleration)
        {
            this.block = block;
            this.speed = speed;
            this.acceleration = acceleration;
        }

        public void Execute()
        {
            block.Physics.Velocity = new Vector2(block.Physics.Velocity.X, speed);
            block.Physics.Acceleration = new Vector2(block.Physics.Acceleration.X, acceleration);
        }
    }
}
