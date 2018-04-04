using CALMario.Entities;
using CALMario.Entities.Mario;
using Microsoft.Xna.Framework;

namespace CALMario.Commands.MovementCommands
{
    class MoveEntityHorizontallyCommand : ICommand
    {
        private IEntity myEntity;
        private float pixels;

        public MoveEntityHorizontallyCommand(IEntity entity, float pixels)
        {
            this.pixels = pixels;
            this.myEntity = entity;
        }

        public void Execute()
        {
            myEntity.Location = new Vector2(myEntity.Location.X + pixels, myEntity.Location.Y);
        }
    }
}
