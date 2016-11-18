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
		CCSprite shield;

		public CoreStation ()
		{
			CreateSpriteGraphic ();
		}

		private void CreateSpriteGraphic ()
		{
			graphic = new CCSprite ("Images/player.png");
			graphic.Scale = 0.4f;
			graphic.Rotation = 90f;
			graphic.IsAntialiased = false;
			AddChild (graphic);

			shield = new CCSprite("Images/shield.png");
			shield.Scale = 0.1f;
			shield.Position = new CCPoint(this.Position.X-20, this.Position.Y);
			shield.Rotation = -90f;
			shield.IsAntialiased = false;
			shield.Visible = false;
			AddChild(shield);
		}

		public void HandleInput(CCPoint touchPoint)
		{
			desiredLocation = touchPoint;

			float differenceY = touchPoint.Y - this.PositionY;
			float differenceX = touchPoint.X - this.PositionX;

			float angleInDegrees = -1 * CCMathHelper.ToDegrees(
				(float)System.Math.Atan2(differenceY, differenceX));

			var rotateAction = new CCRotateTo(0.3f, angleInDegrees);
			this.AddAction(rotateAction);

			var moveAction = new CCMoveTo(1f, touchPoint);
			CCAction easingAction = new CCEaseSineInOut(moveAction);
			this.AddAction(easingAction);
		}

		public void Activity(float frameTimeInSeconds)
		{
			if (desiredLocation.IsNear(this.Position, 20))
			{
				shield.Visible = false;
			}
			else
			{
				if (shield.Visible)
					shield.Visible = false;
				else
					shield.Visible = true;
			}
		}

		internal void SetDesiredPositionToCurrentPosition()
		{
			desiredLocation.X = this.PositionX;
			desiredLocation.Y = this.PositionY;
		}
	}
}

