using CALMario.Commands.ItemCommands;
using CALMario.Commands.MovementCommands;
using CALMario.Controllers;
using CALMario.Entities;
using CALMario.Entities.Blocks;
using CALMario.Entities.Enemies;
using CALMario.Entities.Items;
using CALMario.Entities.Mario;
using CALMario.Testing;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Commands
{
    public class CommandFactory
    {
        private Game1 myGame;

        private CommandFactory() { }

        private static CommandFactory factory = new CommandFactory();

        public static CommandFactory Factory { get { return factory; } }

        public void Initialize(Game1 g)
        {
            myGame = g;
        }

        //Movement commands
        public ICommand CreateSetEntityXSpeedCommand(IEntity entity, float speed)
        {
            return new SetEntityXSpeedCommand(entity, speed);
        }
        public ICommand CreateSetEntityYSpeedCommand(IEntity entity, float speed)
        {
            return new SetEntityYSpeedCommand(entity, speed);
        }
        public ICommand CreateMoveMarioHorizontallyCommand(float pixels)
        {
            return new MoveMarioHorizontallyCommand(myGame, pixels);
        }
        public ICommand CreateMoveMarioVerticallyCommand(float pixels)
        {
            return new MoveMarioVerticallyCommand(myGame, pixels);
        }
        public ICommand CreateMoveEntityHorizontallyCommand(IEntity entity, float pixels)
        {
            return new MoveEntityHorizontallyCommand(entity, pixels);
        }
        public ICommand CreateMoveEntityVerticallyCommand(IEntity entity, float pixels)
        {
            return new MoveEntityVerticallyCommand(entity, pixels);
        }
        public ICommand CreateSetEntityXAccelerationCommand(IEntity entity, float acceleration)
        {
            return new SetEntityXAccelerationCommand(entity, acceleration);
        }
        public ICommand CreateSetEntityYAccelerationCommand(IEntity entity, float acceleration)
        {
            return new SetEntityYAccelerationCommand(entity, acceleration);
        }
        public ICommand CreateSetInputsCommand(MarioInputs inputs)
        {
            return new SetInputsCommand(myGame, inputs);
        }
        public ICommand CreateBumpBlockCommand(IBlock block, float speed, float acceleration)
        {
            return new BumpBlockCommand(block, speed, acceleration);
        }
        public ICommand CreateChangeEntityMovingDirectionOnCollisionCommand(IEntity entityToMove, IEntity entityCollidedWith, Side side, float newYSpeedTop, float newYSpeedBottom, float newXSpeedLeft, float newXSpeedRight)
        {
            return new ChangeEntityMovingDirectionOnCollisionCommand(entityToMove, entityCollidedWith, side, newYSpeedTop, newYSpeedBottom, newXSpeedLeft, newXSpeedRight);
        }

        public ICommand CreateResetCommand()
        {
            return new ResetCommand(myGame);
        }
        public ICommand CreatePauseCommand()
        {
            return new PauseCommand(myGame);
        }
        public ICommand CreateExitCommand()
        {
            return new ExitCommand(myGame);
        }
        public ICommand CreateWinCommand()
        {
            return new WinCommand(myGame);
        }
        public ICommand CreateWarpCommand(PowerupStateType t)
        {
            return new WarpCommand(myGame, t);
        }
		public ICommand CreateGoToShopCommand()
		{
			return new ShopCommand(myGame);
		}
        public ICommand CreateCollectStarCommand(IMario m)
        {
            return new ChangeMarioCommand(myGame, new StarMario(m));
        }
        public ICommand CreateChangeMarioCommand(IMario m)
        {
            return new ChangeMarioCommand(myGame, m);
        }
        public ICommand CreateChangeGravityCommand()
        {
            return new ChangeGravityCommand(myGame);
        }
        public ICommand CreateTryFireballCommand()
        {
            return new TryFireballCommand(myGame);
        }
        public ICommand CreateRemoveEnemyCommand(IEnemy e)
        {
            return new RemoveEnemyCommand(myGame, e);
        }
        public ICommand CreateAddItemCommand(IItem i)
        {
            return new AddItemCommand(myGame, i);
        }
        public ICommand CreateAddEntityCommand(IEntity e)
        {
            return new AddEntityCommand(myGame, e);
        }
        public ICommand CreateRemoveItemCommand(IItem i)
        {
            return new RemoveItemCommand(myGame, i);
        }
        public ICommand CreateRemoveBlockCommand(IBlock b)
        {
            return new RemoveBlockCommand(myGame, b);
        }
        public ICommand CreateRemoveEntityCommand(IEntity e)
        {
            return new RemoveEntityCommand(myGame, e);
        }
        public ICommand CreateCollectCoinCommand()
        {
            return new CollectCoinCommand(myGame);
        }
        public ICommand CreateDieCommand()
        {
            return new DieCommand(myGame);
        }
        public ICommand CreateAddScoreCommand(int amount)
        {
            return new AddScoreCommand(myGame, amount);
        }
        public ICommand CreateOneUpCommand()
        {
            return new OneUpCommand(myGame);
        }

        public ICommand CreateTestCommand()
        {
            return new TestCommand(myGame);
        }
    }
}
