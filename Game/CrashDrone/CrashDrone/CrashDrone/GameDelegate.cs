using System;
using System.Collections.Generic;

using CocosSharp;
using CocosDenshion;

namespace CrashDrone.Common
{
    public static class GameDelegate
    {
        public static CCGameView GameView { get; private set; }

        public static void LoadGame(object sender, EventArgs e)
        {
            GameView = sender as CCGameView;

            if (GameView != null)
            {
                var contentSearchPaths = new List<string>() { "Fonts", "Sounds" };
                CCSizeI viewSize = GameView.ViewSize;

                int width = 1024;
                int height = 768;

                // Set world dimensions
                GameView.DesignResolution = new CCSizeI(width, height);
				GameView.ResolutionPolicy = CCViewResolutionPolicy.ExactFit;

                // Determine whether to use the high or low def versions of our images
                // Make sure the default texel to content size ratio is set correctly
                // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)

                if (width < viewSize.Width)
                {
                    //contentSearchPaths.Add("Images/Collision");
                    CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
                }
                else
                {
                    //contentSearchPaths.Add("Images/Periphery");
                    CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
                }
                

                GameView.ContentManager.SearchPaths = contentSearchPaths;


                var gameScene = new GameScene(GameView);
                GameView.RunWithScene(gameScene);
            }
        }

        public static void RestartGame()
        {
            GoToScene(new GameScene(GameView));
        }

        public static void GoToScene(CCScene scene)
        {
            if (GameView != null)
            {
                GameView.Director.ReplaceScene(scene);
            }
        }
    }
}