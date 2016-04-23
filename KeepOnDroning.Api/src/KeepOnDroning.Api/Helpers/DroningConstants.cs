using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeepOnDroning.Api.Helpers
{
    public static class DroningConstants
    {
        public static float MaxWindSpeed = 4;
        public static string[] WindDirections = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
    }
}
