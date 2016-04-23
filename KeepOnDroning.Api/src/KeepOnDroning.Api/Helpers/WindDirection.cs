﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeepOnDroning.Api.Helpers
{
    public static class WindDirection
    {
        public static string WindDegreesToDirection(float deg)
        {
            var val =((deg/22.5) + .5);
            var index = (int)Math.Round(val%16);           
            return DroningConstants.WindDirections[index];
        }
    }
}
