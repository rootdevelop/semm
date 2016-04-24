using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace KeepOnDroning.Api.Controllers
{
    [Route("Map")]
    public class MapController : Controller
    {

        [HttpGet]
        [Route("Index/lat={lat}&lng={lng}")]
        public async Task<ActionResult> Index(float lat, float lng)
        {
            return View();
        }
    }
}
