using CALMario.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands.MovementCommands
{
    public class SetEntityXAccelerationCommand : ICommand
    {
        private float myAcceleration;
        private IEntity myEntity;

        public SetEntityXAccelerationCommand(IEntity entity, float acceleration)
        {
            myEntity = entity;
            myAcceleration = acceleration;
        }
        public void Execute()
        {
            myEntity.Physics.Acceleration = new Vector2(myAcceleration, myEntity.Physics.Acceleration.Y);
        }
    }
}
