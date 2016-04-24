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
        private bool falling;
        public float collideLasts { get; private set; }
        public Bird()
        {
            this.Speed = CCRandom.GetRandomFloat(200f, 500f);
            CollisionEffect = CollisionEffect.LoseEnergy;
            EnergyChange = -10;
            this.collideLasts = 0.5f;
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
                if (falling)
                    Speed += 10f;
                Graphic.PositionY -= Speed * frameTimeInSeconds;
                this.collideLasts -= frameTimeInSeconds;
                if (!falling && collideLasts <= 0)
                {
                    falling = true;
                    var position = Graphic.Position;
                    Graphic.Visible = false;
                    this.Children.Remove(Graphic);
                    this.Graphic = new CCSprite("/Assets/Content/Images/Periphery/bird_baked.png");
                    Graphic.Scale = 0.5f;
                    Graphic.Position = position;
                    this.AddChild(Graphic);
                }
            }
            else
            {
                Graphic.PositionX -= Speed * frameTimeInSeconds;
            }
        }

        public override int Collide()
        {
            if (!IsRoasted)
            {
                this.Speed = 0f;
                var position = Graphic.Position;
                Graphic.Visible = false;
                this.Children.Remove(Graphic);
                this.Graphic = new CCSprite("/Assets/Content/Images/Collision/collide.png");
                Graphic.Scale = 0.5f;
                Graphic.Position = position;
                this.AddChild(Graphic);
                this.IsRoasted = true;
                return EnergyChange;
            }
            return 0;
        }
    }
}
