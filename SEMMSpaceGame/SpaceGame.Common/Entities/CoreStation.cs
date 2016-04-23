using System;
using CocosSharp;

namespace SpaceGame.Common
{
	public class CoreStation : CCNode
	{
		const float width = 150;
		const float height = 150;

		CCPoint desiredLocation;
		public CCPoint Velocity;

		CCSprite graphic;

		public CoreStation ()
		{
			CreateSpriteGraphic ();
		}

		private void CreateSpriteGraphic ()
		{
			graphic = new CCSprite ("Images/monkey.png");
			graphic.IsAntialiased = false;
			AddChild (graphic);
		}

		public void HandleInput(CCPoint touchPoint)
		{
			desiredLocation = touchPoint;
		}

		public void Activity(float frameTimeInSeconds)
		{
			const float velocityCoefficient = 1;

			Velocity = (desiredLocation - this.Position) * velocityCoefficient;

			this.Position += Velocity * frameTimeInSeconds;
		}

		internal void SetDesiredPositionToCurrentPosition()
		{
			desiredLocation.X = this.PositionX;
			desiredLocation.Y = this.PositionY;
		}
	}
}

