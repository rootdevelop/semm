using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Domain;

namespace KeepOnDroning.Api.ServiceDomain
{
    public class NoFlyResult
    {
        public IList<ServiceNoFlyZone> NoFlyZones { get; set; }
        public IList<Ooi> Oois { get; set; }
    }
}