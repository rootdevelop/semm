﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashDrone.Common.Entities
{
    public class Forest : PeripheryEntity
    {
        public Forest() : base("forest.png")
        {
            this.Speed = 0.5f;
        }

    }
}
