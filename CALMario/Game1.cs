using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CALMario.Controllers;
using CALMario.Graphics;
using System.Collections.Generic;
using CALMario.Entities.Mario;
using CALMario.Commands;
using CALMario.Cameras;
using CALMario;
using CALMario.Entities;
using System.Linq;
using CALMario.DisplayLoaderFiles;
using CALMario.Sounds;
using Microsoft.Xna.Framework.Media;

namespace CALMario
{
    public class Game1 : Game
    {
        public IMario Player { get { return Level.Player; } set { Level.Player = value; } }
        public IMario GhostPlayer { get { return Level.GhostPlayer; } set { Level.GhostPlayer = value; } }
        public List<IEntity> Entities { get { return Level.Entities; } }
        public List<ICommand> CommandQueue { get; private set; }
        public IGameStats Stats { get { return Level.Stats; } private set { Level.Stats = value; } }
        private HUDLoader hud;
        private List<IController> inputs;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private int ticks;
        public int ElapsedTime { private get; set; }
        public bool paused = false;
        public bool underground = false;
		private Camera GameCamera { get { return Level.GameCamera; } set { Level.GameCamera = value; } }
        public string CurrentLevel { get; set; }
        private Song bgMusic;
        public LevelManager Level { get; set; }
        private RemainingLivesScreenLoader remainingLivesScreen;
        public GameOverScreenLoader gameOverScreen;
        private WinScreenLoader winScreen;

        public Game1()
        {
            Level = new LevelManager(this);
            CommandFactory.Factory.Initialize(this);
			GameCamera = new Camera(this);
            hud = new HUDLoader(this, GameCamera);
            graphics = new GraphicsDeviceManager(this)
                { PreferredBackBufferWidth = GameUtility.BackBufferWidth, PreferredBackBufferHeight = GameUtility.BackBufferHeight };
			graphics.ApplyChanges();
            Content.RootDirectory = GameUtility.ContentFolder;
            inputs = new List<IController>();
            Stats = new GameStats();
            ticks = 0;
            CommandQueue = new List<ICommand>();
            inputs.Add(new KeyboardController(this));
			inputs.Add(new GamepadController(this));
            CurrentLevel = GameUtility.InitialLevel;
            remainingLivesScreen = new RemainingLivesScreenLoader(this, Level.GameCamera);
            gameOverScreen = new GameOverScreenLoader(this, Level.GameCamera);
            winScreen = new WinScreenLoader(this, Level.GameCamera);
            GhostPlayerInputs.SpawnGhostMario = false;
        }

        public void Reset()
        {
            ElapsedTime = 0;
            Stats = new GameStats() { Time = GameUtility.TimePerLevel, Lives = GameUtility.LivesPerLevel};
            ticks = 0;
            Level.LoadLevel(GameUtility.InitialLevelFile);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.7f;
            PlayBGM();
            CommandQueue = new List<ICommand>();
            Level.DisplayingWinScreen = false;
            Level.DisplayingRemainingLivesScreen = true;
            Level.DisplayingGameOverScreen = false;
        }

        public void PlayBGM()
        {
            MediaPlayer.Play(bgMusic);
        }
        
        protected override void Initialize()
        {
            base.Initialize();
			Reset();
			GameCamera.SpotlightCameraPosition = new Vector2(Player.Location.X + Player.Sprite.Width, Player.Location.Y + Player.Sprite.Height);
			GameCamera.Initialize();

		}
        
        protected override void LoadContent() 
        {
			spriteBatch = new SpriteBatch(GraphicsDevice);
            hud.LoadContent(Content);
			SpriteFactory.Factory.LoadAllTextures(Content);
			SoundFactory.Factory.LoadAllSounds(Content);
            remainingLivesScreen.LoadContent(Content);
            gameOverScreen.LoadContent(Content);
            bgMusic = SoundFactory.Factory.CreateBackgroundMusic();
			MediaPlayer.IsRepeating = true; 
			MediaPlayer.Volume = 0.5f;
			MediaPlayer.Play(bgMusic); 

		}

		protected override void Update(GameTime gameTime)
        {
            if (!Level.DisplayingRemainingLivesScreen && !Level.DisplayingWinScreen)
            {
                foreach (IController input in inputs)
                {
                    input.Update();
                }

                if (paused)
                {
                    return;
                }

                Player.Update();
                if (GhostPlayer != null)
                {
                    GhostPlayer.Update();
                }
                foreach (IEntity e in Entities)
                {
                    e.Update();
                }

                DetectCollisions();

                GameCamera.SpotlightCameraPosition = new Vector2(Player.Location.X + Player.Sprite.Width, Player.Location.Y + Player.Sprite.Height);
                GameCamera.Update(gameTime);

                foreach (ICommand c in CommandQueue)
                {
                    c.Execute();
                }
                CommandQueue.Clear();

                ticks--;
                if (ticks % GameUtility.FramesPerSecond == 0)
                {
                    Stats.Time--;
                }

                if (Stats.Coins >= GameUtility.NumCoinsToIncreaseLives)
                {
                    Stats.Lives++;
                    Stats.Coins -= GameUtility.NumCoinsToIncreaseLives;
                }
            } else
            {
                CommandQueue.Clear();
                GameCamera.SpotlightCameraPosition = new Vector2(Player.Location.X + Player.Sprite.Width, Player.Location.Y + Player.Sprite.Height);
                GameCamera.Update(gameTime);

                foreach (IController input in inputs)
                {
                    input.Update();
                }
                foreach (ICommand c in CommandQueue)
                {
                    c.Execute();
                }
            }

			base.Update(gameTime);
        }

        public void DetectCollisions()
        {
            CollisionDetection.CollisionDetector.DetectAllCollisions(Entities, Player, GhostPlayer);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Level.DisplayingWinScreen)
            {
                winScreen.LoadContent(Content);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, GameCamera.Transform);
                winScreen.Draw(spriteBatch);
                spriteBatch.End();
            }
            else if (Level.DisplayingGameOverScreen)
            {
                gameOverScreen.LoadContent(Content);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, GameCamera.Transform);
                gameOverScreen.Draw(spriteBatch);
                spriteBatch.End();
            }
            else if (Level.DisplayingRemainingLivesScreen)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, GameCamera.Transform);

                remainingLivesScreen.Draw(spriteBatch);
                hud.Draw(spriteBatch);

                if (ElapsedTime > GameUtility.RemainingLivesScreenTime)
                {
                    Level.DisplayingRemainingLivesScreen = false;
                }
                ElapsedTime++;
                spriteBatch.End();
            }
            else
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, GameCamera.Transform);

                Player.Draw(spriteBatch);

                if (GhostPlayer != null)
                {
                    GhostPlayer.Draw(spriteBatch);
                }
                foreach (IEntity e in Entities)
                {
                    if(GameCamera.IsOnScreen(e))
                        e.Draw(spriteBatch);
                }

                hud.Draw(spriteBatch);

                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
