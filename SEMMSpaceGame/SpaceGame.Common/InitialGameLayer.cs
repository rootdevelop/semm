using System;
using CocosSharp;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SpaceGame.Common
{
	public class InitialGameLayer : CCLayerColor
	{
		CCLabel helloLabel;
		CCTileMap tileMap;
		CoreStation stationCore;

		public InitialGameLayer () : base (CCColor4B.Blue)
		{
			CreateTouchListener();

			Schedule (RunGameLogic);
		}

		void RunGameLogic(float frameTimeInSeconds)
		{
			stationCore.Activity(frameTimeInSeconds);
		}

		protected override void AddedToScene ()
		{
			base.AddedToScene ();
			CCPoint center = new CCPoint (ContentSize.Width/2, ContentSize.Height/2);

			tileMap = new CCTileMap ("tilemaps/level0.tmx");
			this.AddChild (tileMap);


			stationCore = new CoreStation();
			stationCore.PositionX = center.X / 2.0f;
			stationCore.PositionY = center.Y / 2.0f;
			stationCore.SetDesiredPositionToCurrentPosition();
			AddChild(stationCore);


			tileMap.TileLayersContainer.RunAction(new CCFollow(stationCore, new CCRect(0, 0, 5000.0f, 5000.0f)));


			// Use the bounds to layout the positioning of our drawable assets
			CCRect bounds = VisibleBoundsWorldspace;
		}

		private void HandleTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
		{
			var locationOnScreen = touches [0].Location;
			stationCore.HandleInput (locationOnScreen);
		}

		private void CreateTouchListener()
		{
			var touchListener = new CCEventListenerTouchAllAtOnce();
			touchListener.OnTouchesBegan = HandleTouchesBegan;
			AddEventListener(touchListener);
		}
	}
}