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
        float velocityCoefficient = 3;
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
            AddChild(_graphic);
        }

        private void CreateCrashedGraphic()
        {
            var position = _graphic.Position;
            _graphic.Visible = false;
            this.Children.Remove(_graphic);
            this._graphic = new CCSprite("/Assets/Content/Images/crashed_drone.png");
            _graphic.Scale = 0.3f;
            _graphic.Position = position;
            this.AddChild(_graphic);
        }

        public void HandleInput(CCPoint touchPoint)
        {
            desiredLocation = touchPoint;
        }

        public void Activity(float frameTimeInSeconds)
        {
            Velocity = (desiredLocation - this.Position) * velocityCoefficient;

            this.Position += Velocity * frameTimeInSeconds;
        }

        public void Crash()
        {
            CreateCrashedGraphic();
            velocityCoefficient = 0.3f;
            this.HandleInput(new CCPoint(this.PositionX, -200));
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
