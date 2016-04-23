using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeepOnDroning.Api.ServiceDomain
{
    public class RouteResult
    {
        public IList<DancerResponse> DancerResponses { get; set; }
        public DancerResponse BasinOfVows { get; set; } // summary
    }
}
