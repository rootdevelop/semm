using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public class Tree : CollisionEntity
    {
        public Tree()
        {
            this.Speed = 80f;
            InitGraphic();
        }

        protected override void InitGraphic()
        {
            _graphic = new CCSprite("/Assets/Content/Images/Collision/tree.png");
            _graphic.IsAntialiased = false;
            _graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            AddChild(_graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            _graphic.PositionX -= Speed * frameTimeInSeconds;
        }
    }
}
