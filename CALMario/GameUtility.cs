
namespace CALMario
{
    internal static class GameUtility
    {
        public const int TimePerLevel = 300;
        public const int NumCoinsToIncreaseLives = 100;
        public const int FramesPerSecond = 60;
        public const int RemainingLivesScreenTime = 100;
        public const int LivesPerLevel = 3;
        public const int BackBufferWidth = 368;
        public const int BackBufferHeight = 160;
        public const string ContentFolder = "Content";
		public const string ShopFile = "store.csv";
		public const string InitialLevel = "1-1";
        public const string InitialLevelFile = "levelOne.csv";
        public const string UndergroundFile = "underground.csv";
        public const string ReturnToLevelOneFile = "returnToLevelOne.csv";
        public const int LevelLoaderWidthFactor = 16;
        public const int LevelLoaderHeightFactor = 16;
        public const int LevelLoaderYPosIncrease = 4;
    }
}