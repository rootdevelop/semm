using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public abstract class CollisionEntity : CCNode
    {
        public float Speed { get; set; }
        public CollisionEffect CollisionEffect { get; set; }
        public int MyProperty { get; set; }
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

        protected void SetCollisionBounds()
        {
            //var graphicBounds = _graphic.BoundingBoxTransformedToWorld;
            //this.CollisionBounds = new CCRect(graphicBounds.MinX + 10, graphicBounds.MinY + 10, graphicBounds.MaxX - graphicBounds.MinX - 20, graphicBounds.MaxY - graphicBounds.MinY - 20);
        }

        public float GraphicWidth { get { return Graphic.ContentSize.Width; } }
        public float GraphicHeight { get { return Graphic.ContentSize.Height; } }
        protected abstract void InitGraphic();
        public abstract void Activity(float frameTimeInSeconds);
        public CCRect CollisionBounds { get
            {
                var graphicBounds = _graphic.BoundingBoxTransformedToWorld;
                return new CCRect(graphicBounds.MinX + 7, graphicBounds.MinY + 7, graphicBounds.MaxX - graphicBounds.MinX - 14, graphicBounds.MaxY - graphicBounds.MinY - 14);
            } }

        public abstract void Collide();
    }
}
