using Android.App;
using Android.Widget;
using Android.OS;
using CocosSharp;
using System;
using System.Collections.Generic;
using SpaceGame.Common;

namespace SpaceGame.Droid
{
	[Activity (Label = "SpaceGame.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			CCGameView gameView = (CCGameView)FindViewById (Resource.Id.GameView);
			gameView.ViewCreated += LoadGame;
		}

		private void LoadGame (object sender, EventArgs e)
		{
			CCGameView gameView = sender as CCGameView;
			if (gameView != null)
			{
				var contentSearchPaths = new List<string> () { "Fonts", "Sounds" };
				CCSizeI viewSize = gameView.ViewSize;

				int width = 600;
				int height = 400;

				// Set world dimensions
				gameView.DesignResolution = new CCSizeI (width, height);
				gameView.ResolutionPolicy = CCViewResolutionPolicy.ExactFit;

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


