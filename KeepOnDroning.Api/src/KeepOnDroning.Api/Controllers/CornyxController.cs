using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Business;
using KeepOnDroning.Api.ServiceDomain;
using Microsoft.AspNet.Mvc;

namespace KeepOnDroning.Api.Controllers
{
    [Route("api/Cornyx")]
    public class CornyxController : Controller
    {
        private readonly NoFlyingBusiness _noFlyingBusiness;

        public CornyxController(NoFlyingBusiness noFlyingBusiness)
        {
            _noFlyingBusiness = noFlyingBusiness;
        }

        [Route("Corny/{latitude}/{longitude}")]
        [HttpGet]
        public async Task<NoFlyResult> Corny(float latitude, float longitude)
        {
            return await _noFlyingBusiness.NoFlyResult(latitude, longitude);
        }

    }
}