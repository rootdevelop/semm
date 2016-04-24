﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public class Bird : CollisionEntity
    {
        private CCSprite _graphic;
        public Bird()
        {
            this.Speed = CCRandom.GetRandomFloat(200f, 500f);
            InitGraphic();
        }

        private void InitGraphic()
        {
            _graphic = new CCSprite("/Assets/Content/Images/Collision/bird.png");
            _graphic.IsAntialiased = false;
            _graphic.Scale = 0.4f;
            _graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            AddChild(_graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            _graphic.PositionX -= Speed * frameTimeInSeconds;
        }

        public float GraphicWidth { get { return _graphic.ContentSize.Width; } }
        public float GraphicHeight { get { return _graphic.ContentSize.Height; } }
    }
}
