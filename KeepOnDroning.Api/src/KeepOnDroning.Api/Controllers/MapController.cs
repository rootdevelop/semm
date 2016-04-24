using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Business;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

namespace KeepOnDroning.Api.Controllers
{
    [Route("Map")]
    public class MapController : Controller
    {
        private readonly NoFlyingBusiness _noFlyingBusiness;

        public MapController(NoFlyingBusiness noFlyingBusiness)
        {
            _noFlyingBusiness = noFlyingBusiness;
        }

        [HttpGet]
        [Route("Index/lat={lat}&lng={lng}")]
        public async Task<ActionResult> Index(float lat, float lng)
        {
            return View();
        }
    }
}
