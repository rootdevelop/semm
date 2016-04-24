using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public class Drone : CCNode
    {
        CCPoint desiredLocation;
        public CCPoint Velocity;
        public CCSprite graphic { get; set; }

        public Drone()
        {
            CreateSpriteGraphic();
        }

        private void CreateSpriteGraphic()
        {
            graphic = new CCSprite("/Asset/Content/Images/drone.png");
            graphic.IsAntialiased = false;
            this.graphic.Scale = 0.3f;
            AddChild(graphic);
        }

        public void HandleInput(CCPoint touchPoint)
        {
            desiredLocation = touchPoint;
        }

        public void Activity(float frameTimeInSeconds)
        {
            const float velocityCoefficient = 1;

            Velocity = (desiredLocation - this.Position) * velocityCoefficient;

            this.Position += Velocity * frameTimeInSeconds;
        }

        internal void SetStartPosition(CCPoint position)
        {
            this.Position = position;
            this.desiredLocation = position;
        }
    }
}
