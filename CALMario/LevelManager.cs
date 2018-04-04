using CALMario.Cameras;
using CALMario.Controllers;
using CALMario.DisplayLoaderFiles;
using CALMario.Entities;
using CALMario.Entities.Mario;
using CALMario.Sounds;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CALMario
{
    public class LevelManager
    {
        public List<IEntity> Entities { get; private set; }
        public IMario Player { get; set; }
        public IMario GhostPlayer { get; set; }
        public IGameStats Stats { get; set; }
        public bool DisplayingRemainingLivesScreen { get; set; }
        public bool DisplayingWinScreen { get; set; }
        public bool DisplayingGameOverScreen { get; set; }
        public Camera GameCamera { get; set; }

        private Game1 parent;
		private Vector2 lastLocation; 
        private bool underground;
		private bool shop;

        public LevelManager(Game1 game)
        {
            parent = game;
            DisplayingRemainingLivesScreen = true;
            DisplayingGameOverScreen = false;
            DisplayingWinScreen = false;
            underground = false;
			shop = false;
        }

        public void Die()
        {
            if (Stats.Lives == 0)
            {
                parent.gameOverScreen = new GameOverScreenLoader(parent, GameCamera);
                DisplayingGameOverScreen = true;
            }
            else
            {
                GhostPlayerInputs.TransferInputs();
                GhostPlayerInputs.CurrentRunInputs.Clear();
                GhostPlayerInputs.SpawnGhostMario = true;
                LevelLoader levelLoader = new LevelLoader(GameUtility.InitialLevelFile, parent);
                Stats.Lives--;
                Stats.Time = GameUtility.TimePerLevel;
                Player = levelLoader.Player;
                GhostPlayer = levelLoader.GhostPlayer;
                Entities = new List<IEntity>();
                Entities = Entities.Concat(levelLoader.Blocks).Concat(levelLoader.Items).Concat(levelLoader.Enemies).Concat(levelLoader.Projectiles).ToList();
                DisplayingRemainingLivesScreen = true;
                parent.ElapsedTime = 0;
            }
        }

        public void Win()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            parent.PlayBGM();
            SoundFactory.Factory.CreateLevelCompleteSFX().Play();
            DisplayingWinScreen = true;
        }

        public void Warp(PowerupStateType t)
        {
            if (!underground)
            {
                underground = true;
                LoadLevel(GameUtility.UndergroundFile);
            }
            else if (underground)
            {
                underground = false;
                LoadLevel(GameUtility.ReturnToLevelOneFile);
            }
            Player.StateMachine.State = t;
        }

		public void GoToShop(PowerupStateType t)
		{
			if(!shop)
			{
				shop = true; 
				lastLocation = Player.Location;
				LoadLevel(GameUtility.ShopFile);
			}
			else 
			{
				shop = false;
				LoadLevel(GameUtility.InitialLevelFile);
				Player.Location = lastLocation; 
			}

			Player.StateMachine.State = t;
			
		}

        public void LoadLevel(string levelFile)
        {
            LevelLoader levelLoader;

            levelLoader = new LevelLoader(levelFile, parent);
            Player = levelLoader.Player;
            GhostPlayer = levelLoader.GhostPlayer;
            Entities = new List<IEntity>();
            Entities = Entities.Concat(levelLoader.Blocks).Concat(levelLoader.Items).Concat(levelLoader.Enemies).Concat(levelLoader.Projectiles).ToList();
        }

    }
}
