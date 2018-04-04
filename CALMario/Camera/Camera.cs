using CALMario.Entities;
using CALMario.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CALMario.Cameras
{
	public class Camera : GameComponent, ICamera
	{
		private Vector2 cameraPosition;
		private float initialHeight;

		protected float windowHeight;
		protected float windowWidth;

		public Camera(Game game) : base(game) { }

		public Vector2 CameraPosition
		{
			get { return cameraPosition; }
			set { cameraPosition = value; }
		}
		public Vector2 Origin { get; set; }
		public float Scale { get; set; }
		public Vector2 ScreenCenter { get; protected set; } 
		public Vector2 SpotlightCameraPosition { get; set; }
		public Matrix Transform { get; set; }
		public float MoveSpeed { get; set; }

		public override void Initialize()
		{
			windowHeight = Game.GraphicsDevice.Viewport.Height;
			windowWidth = Game.GraphicsDevice.Viewport.Width;
			initialHeight = SpotlightCameraPosition.Y; 

			ScreenCenter = new Vector2(windowWidth / CameraUtility.ScreenCenterScale, windowHeight / CameraUtility.ScreenCenterScale);
            Scale = CameraUtility.Scale;
			MoveSpeed = CameraUtility.Speed;
		}

		public override void Update(GameTime gameTime)
		{
			Transform = Matrix.Identity *
						Matrix.CreateTranslation(-(int)cameraPosition.X, -(int)cameraPosition.Y, CameraUtility.CameraZPosition1) *
						Matrix.CreateRotationZ(CameraUtility.CameraRotation) *
						Matrix.CreateTranslation(Origin.X, Origin.Y, CameraUtility.CameraZPosition2) *
						Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

			Origin = ScreenCenter / Scale;

			var time = (float)gameTime.ElapsedGameTime.TotalSeconds;

			cameraPosition.X += ((SpotlightCameraPosition.X - cameraPosition.X) * MoveSpeed * time) + CameraUtility.CameraXPositionFactor;

			float currY = SpotlightCameraPosition.Y;


			if (currY <= initialHeight + CameraUtility.SpotlightYPositionFactor && currY > initialHeight + CameraUtility.CameraYPositionFactor2)
			{
				currY = initialHeight + CameraUtility.SpotlightYPositionFactor;
			}

			cameraPosition.Y += ((currY - cameraPosition.Y) * MoveSpeed * time) + CameraUtility.CameraYPositionFactor1;


		}

        public bool IsOnScreen(IEntity e)
        {
            Vector2 position = e.Location;
            ISprite texture = e.Sprite;
            if ((position.X + texture.Width) < (cameraPosition.X - Origin.X) || (position.X) > (cameraPosition.X + Origin.X))
                return false;

            if ((position.Y + texture.Height) < (cameraPosition.Y - Origin.Y) || (position.Y) > (cameraPosition.Y + Origin.Y))
                return false;

            return true;
        }
    }
}
