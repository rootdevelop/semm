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
            drone.SetStartPosition(new CCPoint(bounds.MaxX * 0.2f, bounds.MidY));
        }

        public void MoveUp()
        {
            CCPoint newLocation;
            if (drone.PositionY + 100 > 720)
            {
                newLocation = new CCPoint(drone.PositionX, 720);
            }
            else
            {
                newLocation = drone.Position.Offset(0, +100);
            }
            drone.HandleInput(newLocation);
        }

        public void MoveDown()
        {
            CCPoint newLocation;
            if (drone.PositionY - 100 < 120)
            {
                newLocation = new CCPoint(drone.PositionX, 120);
            }
            else
            {
                newLocation = drone.Position.Offset(0, -100);
            }
            drone.HandleInput(newLocation);
        }
    }
}

