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
        protected CCSprite _graphic;

        public float GraphicWidth { get { return _graphic.ContentSize.Width; } }
        public float GraphicHeight { get { return _graphic.ContentSize.Height; } }
        protected abstract void InitGraphic();
        public abstract void Activity(float frameTimeInSeconds);
    }
}
