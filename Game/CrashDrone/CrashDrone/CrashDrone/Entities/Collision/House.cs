﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public class House : CollisionEntity
    {
        private CCSprite _graphic;
        public House()
        {
            this.Speed = 50f;
            InitGraphic();
        }

        private void InitGraphic()
        {
            _graphic = new CCSprite("/Assets/Content/Images/Collision/house.png");
            _graphic.IsAntialiased = false;
            _graphic.Position = new CCPoint(this.Layer.VisibleBoundsWorldspace.MaxX + _graphic.ContentSize.Width * 0.5f, this.Layer.VisibleBoundsWorldspace.MinY + _graphic.ContentSize.Height * 0.5f);
            _graphic.AnchorPoint = new CCPoint(0.0f, 0.0f);
            AddChild(_graphic);
        }

        public override void Activity(float frameTimeInSeconds)
        {
            _graphic.PositionX -= Speed * frameTimeInSeconds;
        }
    }
}
