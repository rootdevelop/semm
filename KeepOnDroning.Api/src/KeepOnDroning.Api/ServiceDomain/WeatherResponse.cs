using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeepOnDroning.Api.ServiceDomain
{
    public class WeatherResponse
    {
        // wind
        // windrichting
        public int WindSpeed { get; set; }
        public int WindDegree { get; set; }
    }
}
