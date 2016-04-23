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
        public PeripheryEntity(string filename) : base(filename)
        {
        }
    }
}
