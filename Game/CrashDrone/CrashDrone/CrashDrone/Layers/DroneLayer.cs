using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace CrashDrone.Common
{
    public class DroneLayer : CCLayerColor
    {
        CCSprite drone;

        public DroneLayer() : base(CCColor4B.Transparent)
        {
            drone = new CCSprite("/Asset/Content/Images/drone.png");
            drone.Scale = 0.3f;
            AddChild(drone);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;
            drone.Position = new CCPoint(bounds.MaxX * 0.1f, bounds.MidY);
        }

        public void MoveUp(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                drone.PositionY += 1;
            }
        }

        public void MoveDown(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                drone.PositionY -= 1;
            }
        }
    }
}

