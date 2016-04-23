using System;

using UIKit;
using CocosSharp;
using System.Collections.Generic;
using SpaceGame.Common;

namespace SpaceGame.iOS
{
	public partial class InitialViewController : UIViewController
	{
		public InitialViewController () : base ("InitialViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (GameView != null)
			{
				// Set loading event to be called once game view is fully initialised
				GameView.ViewCreated += LoadGame;
			}
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			if (GameView != null)
				GameView.Paused = true;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if (GameView != null)
				GameView.Paused = false;
		}

		void LoadGame (object sender, EventArgs e)
		{
			CCGameView gameView = sender as CCGameView;

			if (gameView != null)
			{
				var contentSearchPaths = new List<string> () { "Fonts", "Sounds" };
				CCSizeI viewSize = gameView.ViewSize;

				// Set world dimensions

				gameView.DesignResolution = new CCSizeI (viewSize.Width, viewSize.Height);
				//gameView.ResolutionPolicy = CCViewResolutionPolicy.ExactFit;


				// Determine whether to use the high or low def versions of our images
				// Make sure the default texel to content size ratio is set correctly
				// Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
				/*
				if (width < viewSize.Width)
				{
					contentSearchPaths.Add ("Images/Hd");
					CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
				}
				else
				{
					contentSearchPaths.Add ("Images/Ld");
					CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
				}
				*/

				gameView.ContentManager.SearchPaths = contentSearchPaths;
				CCScene gameScene = new CCScene (gameView);
				gameScene.AddLayer (new InitialGameLayer ());
				gameView.RunWithScene (gameScene);
			}
		}
	}
}


