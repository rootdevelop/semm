using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public class Bird : CollisionEntity
    {
        public bool IsRoasted { get; set; }
        public Bird()
        {
            this.Speed = CCRandom.GetRandomFloat(200f, 500f);
            InitGraphic();
        }

        protected override void InitGraphic()
        {
            Graphic = new CCSprite("/Assets/Content/Images/Collision/bird.png");
            Graphic.IsAntialiased = false;
            Graphic.Scale = 0.4f;
            Graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            this.SetCollisionBounds();
            AddChild(Graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            if (IsRoasted)
            {
                Speed += 1f;
                Graphic.PositionY -= Speed * frameTimeInSeconds;
                if (Speed == 20f)
                {
                    var position = Graphic.Position;
                    this.Children.Remove(Graphic);
                    this.Graphic = new CCSprite("/Assets/Content/Images/Periphery/bird_baked.png");
                    Graphic.Position = position;
                    this.AddChild(Graphic);
                }
            }
            else
            {
                Graphic.PositionX -= Speed * frameTimeInSeconds;
            }
        }

        public override void Collide()
        {
            this.Speed = 0f;
            var position = Graphic.Position;
            this.Children.Remove(Graphic);
            this.Graphic = new CCSprite("/Assets/Content/Images/Collision/collide.png");
            Graphic.Position = position;
            this.AddChild(Graphic);
            this.IsRoasted = true;
        }
    }
}
