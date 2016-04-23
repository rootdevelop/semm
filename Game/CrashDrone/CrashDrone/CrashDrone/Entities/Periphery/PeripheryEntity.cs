using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public abstract class PeripheryEntity : CCSprite
    {
        public float Speed { get; set; }

        public PeripheryEntity(string filename) : base(filename)
        {
        }

        public void Activity(float frameTimeInSeconds)
        {
            this.Position.Offset(Speed * frameTimeInSeconds, 0);
        }
    }
}
