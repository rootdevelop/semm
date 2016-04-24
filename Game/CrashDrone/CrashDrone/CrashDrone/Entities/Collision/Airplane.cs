using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public class Airplane : CollisionEntity
    {
        public Airplane()
        {
            this.Speed = 50f;
            InitGraphic();
        }

        protected override void InitGraphic()
        {
            Graphic = new CCSprite("/Assets/Content/Images/Collision/airplane.png");
            Graphic.IsAntialiased = false;
            Graphic.Position = new CCPoint(this.Layer.VisibleBoundsWorldspace.MaxX + Graphic.ContentSize.Width * 0.5f, this.Layer.VisibleBoundsWorldspace.MinY + Graphic.ContentSize.Height * 0.5f);
            Graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            AddChild(Graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            Graphic.PositionX -= Speed * frameTimeInSeconds;
        }

        public override int Collide()
        {
            throw new NotImplementedException();
        }
    }
}
