using CALMario.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands.MovementCommands
{
    public class SetEntityXSpeedCommand : ICommand
    {
        private IEntity myEntity;
        private float mySpeed;

        public SetEntityXSpeedCommand(IEntity entity, float speed)
        {
            myEntity = entity;
            mySpeed = speed;
        }
        public void Execute()
        {
            myEntity.Physics.Velocity = new Vector2(mySpeed, myEntity.Physics.Velocity.Y);
        }
    }
}
