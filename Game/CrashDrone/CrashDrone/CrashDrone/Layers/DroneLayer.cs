using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace CrashDrone.Common
{
    public class DroneLayer : CCLayerColor
    {
        Drone drone;

        public DroneLayer() : base(CCColor4B.Transparent)
        {
            drone = new Drone();
            AddChild(drone);
            Schedule(RunGameLogic);
        }

        void RunGameLogic(float frameTimeInSeconds)
        {
            drone.Activity(frameTimeInSeconds);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            var bounds = VisibleBoundsWorldspace;
            drone.SetStartPosition(new CCPoint(bounds.MaxX * 0.1f, bounds.MidY));
        }

        public void MoveUp()
        {
            drone.HandleInput(drone.Position.Offset(0, +100));
        }

        public void MoveDown()
        {
            drone.HandleInput(drone.Position.Offset(0, -100));
        }
    }
}

