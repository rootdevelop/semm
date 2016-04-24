using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashDrone.Common.Entities
{
    public class Battery : CollisionEntity
    {
        public bool isPlopped = false;
        public float collideLasts { get; private set; }

        public Battery()
        {
            this.Speed = 300.0f;
            this.collideLasts = 1f;
            InitGraphic();
        }

        protected override void InitGraphic()
        {
            Graphic = new CCSprite("/Assets/Content/Images/Collision/battery_up.png");
            Graphic.IsAntialiased = false;
            Graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            this.SetCollisionBounds();
            AddChild(Graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            if (!isPlopped)
            {
                Graphic.PositionX -= Speed * frameTimeInSeconds;
            }
            else
            {
                if (Graphic.Opacity >= 5)
                {
                    Graphic.Opacity -= 5;
                }
                else
                {
                    Graphic.Opacity = 0;
                }
            }
        }

        public override int Collide()
        {
            if (!isPlopped)
            {
                this.Speed = 0f;
                var position = Graphic.Position;
                Graphic.Visible = false;
                this.Children.Remove(Graphic);
                this.Graphic = new CCSprite("/Assets/Content/Images/Collision/battery_up_plop.png");
                Graphic.Scale = 0.5f;
                Graphic.Position = position;
                this.AddChild(Graphic);
                this.isPlopped = true;
                return 50;
            }
            return 0;
        }
    }
}
