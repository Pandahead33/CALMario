using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CALMario.Controllers;
using CALMario.Graphics;
using System.Collections.Generic;
using CALMario.Entities.Mario;
using CALMario.Entities.Blocks;
using System;
using Microsoft.VisualBasic.FileIO;
using CALMario.Entities.Items;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using CALMario.Entities.Enemies;
using CALMario.Entities.Projectiles;
using CALMario.Entities;

namespace CALMario
{

	class LevelLoader
	{
        private Game1 myGame;
		private String levelFileName;
		public List<IBlock> Blocks { get;  }
		public List<IEnemy> Enemies { get; }
		public List<IItem> Items { get; }
        public List<IProjectile> Projectiles { get; }
		public IMario Player { get; set; }
        public IMario GhostPlayer { get; set; }

        public LevelLoader(String levelFileName, Game1 game)
		{
			this.levelFileName = levelFileName;
            this.myGame = game;
			Enemies = new List<IEnemy>();
			Items = new List<IItem>();
			Blocks = new List<IBlock>();
            Projectiles = new List<IProjectile>();
            ParseFile(levelFileName);
		}

		private void ParseFile(String levelFileName)
		{
			//readHeader();
			//findScene();
			//displayLevel(); 
			//these are for future expansion and not necessary for sprint 3



			int height = 0;
			int width = 0;

			if (!File.Exists(Path.Combine(Environment.CurrentDirectory, @"\", levelFileName)))
			{
				//Debug.WriteLine(Environment.CurrentDirectory);
				
			}


			using (TextFieldParser parser = new TextFieldParser(@levelFileName))
			{
				parser.TextFieldType = FieldType.Delimited;
				parser.SetDelimiters(",");


				while (!parser.EndOfData)
				{
					String[] row = parser.ReadFields();

					for (int i = 0; i < row.Length; i++)
					{

						Vector2 currPos = new Vector2(width * GameUtility.LevelLoaderWidthFactor, height * GameUtility.LevelLoaderHeightFactor); //12,2f
						String current = row[i];
						if (current.Length >= 1)
						{
							ConvertCharacterToBlock(current[0], currPos);
						}					
						width++;
                    }
                    width = 0;
                    height++;

                }

			}

		}

		public void FindScene()
		{
			//TO-DO search for ~ and go to next line
			//increment scene field 
		}

		public void ConvertCharacterToBlock(char inputChar, Vector2 currPos)
		{
			switch (inputChar)

			{

				case 'O':
					Blocks.Add(new StoreBlock(currPos, myGame, RewardType.Item, 5));
					break;
				
				case '2':
					Blocks.Add(new StoreBlock(currPos, myGame, RewardType.OneUp, 10));
					break;

				case '3':
					Blocks.Add(new StoreBlock(currPos, myGame, RewardType.Jetpack, 15));
					break;

				case '@':
					Blocks.Add(new HitBlock(currPos));
					break;

                case 'C':
                    Blocks.Add(new QuestionBlock(currPos, myGame, RewardType.Coin));
                    break;

                case '?':
					Blocks.Add(new QuestionBlock(currPos, myGame, RewardType.Item));
					break;

                case 'J':
                    Blocks.Add(new QuestionBlock(currPos, myGame, RewardType.Jetpack));
                    break;

                case '1':
                    Blocks.Add(new QuestionBlock(currPos, myGame, RewardType.OneUp));
                    break;

                case 'i':
					Blocks.Add(new InvisibleBlock(currPos));
					break;

				case '#':
					Blocks.Add(new BrickBlock(currPos, myGame));
					break;

				case 'c':
					Items.Add(new Coin(currPos));
					break;

				case '=':
					Blocks.Add(new FloorBlock(currPos)); 
					break;

				case 'P':
                    Blocks.Add(new PipeBlock(new Vector2(currPos.X, currPos.Y + GameUtility.LevelLoaderYPosIncrease)));
					break;

                case 'W':
                    Blocks.Add(new WarpPipeBlock(new Vector2(currPos.X, currPos.Y + GameUtility.LevelLoaderYPosIncrease)));
                    break;

                case 'B':
                    Blocks.Add(new PipeBaseBlock(new Vector2(currPos.X, currPos.Y)));
                    break;

                case '*':
					Items.Add(new Star(currPos));
					break;

				case 'M':
					Player = new Mario(currPos);
                    if (GhostPlayerInputs.SpawnGhostMario)
                    {
                        GhostPlayer = new GhostMario(currPos);
                        GhostPlayerInputs.SpawnGhostMario = false;
                    }
                    break;

				case 'K':
					Enemies.Add(new Koopa(currPos));
					break;

				case 'G':
					Enemies.Add(new Goomba(currPos));
					break;

				case 'r':
					Items.Add(new RedMushroom(currPos)); 
					break;

				case 'g':
					Items.Add(new OneUpMushroom(currPos));
					break;

				case '&':
					Items.Add(new FireFlower(currPos)); 
					break;

                case 'F':
                    Blocks.Add(new Flagpole(currPos));
                    Blocks.Add(new FlagpoleRibbon(new Vector2(currPos.X + 10f, currPos.Y + 100f)));
                    break;

                case 'k':
                    Blocks.Add(new KillMarioBlock(currPos));
                    break;

				default:
					//assume blank space
					break;

			}

		}

	}
}





