using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;

namespace CrashDrone.Common.Entities
{
    public abstract class PeripheryEntity : CCNode
    {
        public float Speed { get; set; }

        public PeripheryEntity()
        {
        }

        public abstract void Activity(float frameTimeInSeconds);
    }
}
