using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.ServiceDomain;
using Microsoft.AspNet.Mvc;

namespace KeepOnDroning.Api.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Weather(float latitude, float longitude)
        {
            return null;
        }
    }
}
