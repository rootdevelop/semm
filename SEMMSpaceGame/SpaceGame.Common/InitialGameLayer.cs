using System;
using CocosSharp;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Common
{
	public class InitialGameLayer : CCLayerColor
	{
		CCLabel helloLabel;
		CCTileMap tileMap;
		CCSprite playerSprite;

		public InitialGameLayer () : base (CCColor4B.Blue)
		{
			Schedule (RunGameLogic);
		}

		void RunGameLogic(float frameTimeInSeconds)
		{
			// Game loop
		}

		protected override void AddedToScene ()
		{
			base.AddedToScene ();

			tileMap = new CCTileMap ("tilemaps/Level0.tmx");
			this.AddChild (tileMap);

			playerSprite = new CCSprite ("Images/monkey.png");
			playerSprite.PositionX = ContentSize.Width/2;
			playerSprite.PositionY = ContentSize.Height/2;
			AddChild (playerSprite);

			/*
			helloLabel = new CCLabel("Hello Space Apps!", "Arial", 30, CCLabelFormat.SystemFont);
			helloLabel.PositionX = ContentSize.Height/2;
			helloLabel.PositionY = ContentSize.Width/2;
			helloLabel.Color = CCColor3B.White;
			AddChild (helloLabel);
			*/

			// Use the bounds to layout the positioning of our drawable assets
			CCRect bounds = VisibleBoundsWorldspace;
		}
	}
}