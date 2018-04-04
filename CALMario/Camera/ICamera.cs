using CALMario.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALMario.Cameras
{
	public interface ICamera
	{
		Vector2 CameraPosition { get; set; }
		float MoveSpeed { get; set; }
		Vector2 Origin { get; }
		float Scale { get; set; }
		Vector2 ScreenCenter { get; }
		Matrix Transform { get; }
		Vector2 SpotlightCameraPosition { get; set; }
		bool IsOnScreen(IEntity e);
	}


}
