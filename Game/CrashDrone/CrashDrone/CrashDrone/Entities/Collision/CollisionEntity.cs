﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public abstract class CollisionEntity : CCSprite
    {
        public float Speed { get; set; }
        public CollisionEffect CollisionEffect { get; set; }

        public CollisionEntity(string filename) : base(filename)
        {
        }
    }
}
