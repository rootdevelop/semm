﻿using System;
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
            Graphic = new CCSprite("/Assets/Content/Images/Collision/tree.png");
            Graphic.IsAntialiased = false;
            Graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            AddChild(Graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            Graphic.PositionX -= Speed * frameTimeInSeconds;
        }

        public override void Collide()
        {
            
        }
    }
}
