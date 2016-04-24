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
        private CCSprite _graphic;
        public CCSprite Graphic
        {
            get
            {
                return _graphic;
            }
            set
            {
                _graphic = value;
            }
        }

        public Drone()
        {
            CreateSpriteGraphic();
        }

        private void CreateSpriteGraphic()
        {
            _graphic = new CCSprite("/Asset/Content/Images/drone.png");
            _graphic.IsAntialiased = false;
            this._graphic.Scale = 0.3f;
            this.SetCollisionBounds();
            AddChild(_graphic);
        }

        public void HandleInput(CCPoint touchPoint)
        {
            desiredLocation = touchPoint;
        }

        protected void SetCollisionBounds()
        {
            //var graphicBounds = _graphic.BoundingBoxTransformedToWorld;
            //this.CollisionBounds = new CCRect(graphicBounds.MinX + 10, graphicBounds.MinY + 10, graphicBounds.MaxX - graphicBounds.MinX - 20, graphicBounds.MaxY - graphicBounds.MinY - 20);
        }

        public void Activity(float frameTimeInSeconds)
        {
            const float velocityCoefficient = 3;

            Velocity = (desiredLocation - this.Position) * velocityCoefficient;

            this.Position += Velocity * frameTimeInSeconds;
        }

        internal void SetStartPosition(CCPoint position)
        {
            this.Position = position;
            this.desiredLocation = position;
        }

        public CCRect CollisionBounds
        {
            get
            {
                var graphicBounds = _graphic.BoundingBoxTransformedToWorld;
                return new CCRect(graphicBounds.MinX + 7, graphicBounds.MinY + 7, graphicBounds.MaxX - graphicBounds.MinX - 14, graphicBounds.MaxY - graphicBounds.MinY - 14);
            }
        }
    }
}
