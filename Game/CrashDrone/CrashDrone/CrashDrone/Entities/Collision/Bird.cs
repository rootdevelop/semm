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
        private float timeSinceLastFlap;
        private bool FlapUp = false;
        public bool IsRoasted { get; set; }
        private bool falling;
        public float collideLasts { get; private set; }
        public Bird()
        {
            this.Speed = CCRandom.GetRandomFloat(150f, 700f);
            CollisionEffect = CollisionEffect.LoseEnergy;
            EnergyChange = (int)(-0.05 * Speed);
            this.collideLasts = 0.05f;
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
            timeSinceLastFlap = 0.0f;
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
                timeSinceLastFlap += frameTimeInSeconds;
                Graphic.PositionX -= Speed * frameTimeInSeconds;
                if(FlapUp && timeSinceLastFlap > 0.9 - Speed / 1000)
                {
                    timeSinceLastFlap = 0.0f;
                    var position = Graphic.Position;
                    Graphic.Visible = false;
                    this.Children.Remove(Graphic);
                    this.Graphic = new CCSprite("/Assets/Content/Images/Collision/bird.png");
                    Graphic.Scale = 0.5f;
                    Graphic.Position = position;
                    this.AddChild(Graphic);
                    FlapUp = false;
                }
                else if (timeSinceLastFlap > 0.9 - Speed / 1000)
                {
                    timeSinceLastFlap = 0.0f;
                    var position = Graphic.Position;
                    Graphic.Visible = false;
                    this.Children.Remove(Graphic);
                    this.Graphic = new CCSprite("/Assets/Content/Images/Collision/bird_wingsup.png");
                    Graphic.Scale = 0.5f;
                    Graphic.Position = position;
                    this.AddChild(Graphic);
                    FlapUp = true;
                }
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
