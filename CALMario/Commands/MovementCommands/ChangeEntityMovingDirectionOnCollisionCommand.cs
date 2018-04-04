using CALMario.Entities;
using CALMario.Entities.Mario;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands.MovementCommands
{
    public class ChangeEntityMovingDirectionOnCollisionCommand : ICommand
    {
        private IEntity myEntityToMove;
        private IEntity myEntityCollidedWith;
        private Side mySide;
        private float myNewYSpeedTop;
        private float myNewYSpeedBottom;
        private float myNewXSpeedLeft;
        private float myNewXSpeedRight;

        public ChangeEntityMovingDirectionOnCollisionCommand(IEntity entityToMove, IEntity entityCollidedWith, Side side, float newYSpeedTop, float newYSpeedBottom, float newXSpeedLeft, float newXSpeedRight)
        {
            myEntityToMove = entityToMove;
            myEntityCollidedWith = entityCollidedWith;
            mySide = side;
            myNewYSpeedTop = newYSpeedTop;
            myNewYSpeedBottom = newYSpeedBottom;
            myNewXSpeedLeft = newXSpeedLeft;
            myNewXSpeedRight = newXSpeedRight;
    }
        public void Execute()
        {
            if (mySide == Side.Top)
            {
                CommandFactory.Factory.CreateSetEntityYSpeedCommand(myEntityToMove, myNewYSpeedTop).Execute();
                CommandFactory.Factory.CreateMoveEntityVerticallyCommand(myEntityToMove, myEntityCollidedWith.Location.Y + myEntityCollidedWith.Sprite.Height - myEntityToMove.Location.Y).Execute();
                CommandFactory.Factory.CreateSetEntityYAccelerationCommand(myEntityToMove, Math.Max(0, myEntityToMove.Physics.Acceleration.Y)).Execute();
            }
            else if (mySide == Side.Bottom)
            {
                CommandFactory.Factory.CreateSetEntityYSpeedCommand(myEntityToMove, myNewYSpeedBottom).Execute();
                CommandFactory.Factory.CreateMoveEntityVerticallyCommand(myEntityToMove, myEntityCollidedWith.Location.Y - myEntityToMove.Sprite.Height - myEntityToMove.Location.Y).Execute();
                CommandFactory.Factory.CreateSetEntityYAccelerationCommand(myEntityToMove, Math.Min(0, myEntityToMove.Physics.Acceleration.Y)).Execute();
            }
            else if (mySide == Side.Left)
            {
                CommandFactory.Factory.CreateSetEntityXSpeedCommand(myEntityToMove, myNewXSpeedLeft).Execute();
                CommandFactory.Factory.CreateMoveEntityHorizontallyCommand(myEntityToMove, myEntityCollidedWith.Location.X + myEntityCollidedWith.Sprite.Width - myEntityToMove.Location.X).Execute();
                CommandFactory.Factory.CreateSetEntityXAccelerationCommand(myEntityToMove, Math.Max(0, myEntityToMove.Physics.Acceleration.X)).Execute();
            }
            else if (mySide == Side.Right)
            {
                CommandFactory.Factory.CreateSetEntityXSpeedCommand(myEntityToMove, myNewXSpeedRight).Execute();
                CommandFactory.Factory.CreateMoveEntityHorizontallyCommand(myEntityToMove, myEntityCollidedWith.Location.X - myEntityToMove.Location.X - myEntityToMove.Sprite.Width).Execute();
                CommandFactory.Factory.CreateSetEntityXAccelerationCommand(myEntityToMove, Math.Min(0, myEntityToMove.Physics.Acceleration.X)).Execute();
            }
        }
    }
}
