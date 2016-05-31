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
        public bool crashed = false;

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

        public void Crash()
        {
            crashed = true;
            Drone.Crash();

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = AllowRestart;
            AddEventListener(touchListener, this);
        }

        private void AllowRestart(List<CCTouch> touches, CCEvent e)
        {
            if (touches.Count > 0 && Drone.PositionY < 0)
            {
                GameDelegate.RestartGame();
            }
        }

        public void MoveUp()
        {
            if (!crashed)
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
        }

        public void MoveDown()
        {
            if (!crashed)
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
}

