using CALMario.Entities;
using CALMario.Entities.Mario;
using Microsoft.Xna.Framework;

namespace CALMario.Commands.MovementCommands
{
    class MoveEntityVerticallyCommand : ICommand
    {
        private IEntity myEntity;
        private float pixels;

        public MoveEntityVerticallyCommand(IEntity entity, float pixels)
        {
            this.pixels = pixels;
            this.myEntity = entity;
        }

        public void Execute()
        {
            myEntity.Location = new Vector2(myEntity.Location.X, myEntity.Location.Y + pixels);
        }
    }
}
