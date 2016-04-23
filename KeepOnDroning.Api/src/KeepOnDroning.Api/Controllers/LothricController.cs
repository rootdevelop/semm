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
        private DancerBusiness _dancerBusiness;

        public LothricController(DancerBusiness dancerBusiness)
        {
            _dancerBusiness = dancerBusiness;
        }

        [Route("Estus")]
        public async Task<DancerResponse> Estus(float latitude, float longitude)
        {
            var dancer = await _dancerBusiness.Dancing(latitude, longitude);

            return dancer;
        }

        [Route("Estusses")]
        [HttpPost]
        public async Task<List<DancerResponse>> Estusses(IList<ServiceCoordinate> coordinates)
        {
            var list = new List<DancerResponse>();

            foreach (var coordinate in coordinates)
            {
                list.Add(await _dancerBusiness.Dancing(coordinate.Lat, coordinate.Lng));
            }

            return list;
        }
    }
}