using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Business;
using KeepOnDroning.Api.ServiceDomain;
using Microsoft.AspNet.Mvc;

namespace KeepOnDroning.Api.Controllers
{
    [Route("api/lothric")]
    public class LothricController
    {
        [Route("Estus")]
        public async Task<DancerResponse> Estus(WeatherBusiness weatherBusiness, float latitude, float longitude)
        {
            var dancer = await weatherBusiness.Dancing(latitude, longitude);

            return dancer;
        }
    }
}