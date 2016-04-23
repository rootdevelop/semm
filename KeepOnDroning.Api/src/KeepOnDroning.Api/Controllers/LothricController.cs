using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.ServiceDomain;
using Microsoft.AspNet.Mvc;

namespace KeepOnDroning.Api.Controllers
{
    [Route("api/lothric")]
    public class LothricController
    {
        [Route("Estus")]
        public async Task<DancerResponse> Estus(float latitude, float longitude)
        {
            return new DancerResponse()
            {
                Weather = new WeatherResponse()
                {
                    WindSpeed = 10,
                    WindDegree = 20
                },
                CrossingFlightpaths = false,
                HasBirds = true,
                HasDangerDanger = true,
                HasNoFlyZone = true,
                MaxHeight = 500
            };
        }
    }
}