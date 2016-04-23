using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.ServiceDomain.Enums;

namespace KeepOnDroning.Api.ServiceDomain
{
    public class ServiceNoFlyZone
    {
        public string Name { get; set; }
        public ENoFlyZoneType Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Size { get; set; } //km
    }
}
