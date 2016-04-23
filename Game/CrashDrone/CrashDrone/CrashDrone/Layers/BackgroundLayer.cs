using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace CrashDrone.Common
{
    public class BackgroundLayer : CCLayerGradient
    {

        public BackgroundLayer() : base(new CCColor4B(34, 52, 107), new CCColor4B(132, 195, 232))
        {

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;
            
        }
	}
}

