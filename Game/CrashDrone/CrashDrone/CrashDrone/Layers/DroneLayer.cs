using System;
using System.Collections.Generic;
using CocosSharp;
using CrashDrone.Common.Entities;
using Microsoft.Xna.Framework;

namespace CrashDrone.Common
{
    public class DroneLayer : CCLayerColor
    {
        public Drone Drone;

        public DroneLayer() : base(CCColor4B.Transparent)
        {
            Drone = new Drone();
            AddChild(Drone);
            Schedule(RunGameLogic);
        }

        void RunGameLogic(float frameTimeInSeconds)
        {
            Drone.Activity(frameTimeInSeconds);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            var bounds = VisibleBoundsWorldspace;
            Drone.SetStartPosition(new CCPoint(bounds.MaxX * 0.2f, bounds.MidY));
        }

        public void MoveUp()
        {
            CCPoint newLocation;
            if (Drone.PositionY + 100 > 720)
            {
                newLocation = new CCPoint(Drone.PositionX, 720);
            }
            else
            {
                newLocation = Drone.Position.Offset(0, +100);
            }
            Drone.HandleInput(newLocation);
        }

        public void MoveDown()
        {
            CCPoint newLocation;
            if (Drone.PositionY - 100 < 120)
            {
                newLocation = new CCPoint(Drone.PositionX, 120);
            }
            else
            {
                newLocation = Drone.Position.Offset(0, -100);
            }
            Drone.HandleInput(newLocation);
        }
    }
}

