using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashDrone.Common.Entities
{
    public class Radar : CollisionEntity
    {

        public Radar()
        {
            this.Speed = 80f;
            InitGraphic();
        }

        protected override void InitGraphic()
        {
			Graphic = new CCSprite("/Assets/Content/Images/Collision/radar.png");
			Graphic.IsAntialiased = false;
			Graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
			AddChild(Graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
			Graphic.PositionX -= Speed * frameTimeInSeconds;
        }

		public override int Collide ()
		{
            return 0;
		}
    }
}
