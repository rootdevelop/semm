using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Business;
using KeepOnDroning.Api.ServiceDomain;
using Microsoft.AspNet.Mvc;

namespace KeepOnDroning.Api.Controllers
{
    [Route("api/Eternity")]
    public class EternityController : Controller
    {
        private EternityBusiness _eternityBusiness;

        public EternityController(EternityBusiness eternityBusiness)
        {
            _eternityBusiness = eternityBusiness;
        }

        [Route("Azshara")]
        [HttpPost]
        public async Task Azshara(OoiRequest legion)
        {
            await _eternityBusiness.Summon(legion);
        }
    }
}
