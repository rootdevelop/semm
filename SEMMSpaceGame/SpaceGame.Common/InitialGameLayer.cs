using System;
using CocosSharp;

namespace SpaceGame.Common
{
	public class InitialGameLayer : CCLayerColor
	{
		CCLabel helloLabel;
		CCTileMap tileMap;

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

			tileMap = new CCTileMap ("tilemaps/dungeon.tmx");
			this.AddChild (tileMap);

			helloLabel = new CCLabel("Hello Space Apps!", "Arial", 30, CCLabelFormat.SystemFont);
			helloLabel.PositionX = ContentSize.Height/2;
			helloLabel.PositionY = ContentSize.Width/2;
			helloLabel.Color = CCColor3B.White;
			AddChild (helloLabel);

			// Use the bounds to layout the positioning of our drawable assets
			CCRect bounds = VisibleBoundsWorldspace;
		}
	}
}