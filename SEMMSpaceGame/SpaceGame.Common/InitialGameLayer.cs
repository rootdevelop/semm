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

			tileMap = new CCTileMap ("tilemaps/Level0.tmx");
			this.AddChild (tileMap);


			stationCore = new CoreStation();
			stationCore.PositionX = center.X / 2.0f;
			stationCore.PositionY = center.Y / 2.0f;
			stationCore.SetDesiredPositionToCurrentPosition();
			AddChild(stationCore);

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