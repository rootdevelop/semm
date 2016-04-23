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
        public async Task<RouteResult> Estusses(IList<ServiceCoordinate> coordinates)
        {
            var list = new List<DancerResponse>();

            foreach (var coordinate in coordinates)
            {
                list.Add(await _dancerBusiness.Dancing(coordinate.Lat, coordinate.Lng));
            }

            var resp = new RouteResult
            {
                DancerResponses = list,
                BasinOfVows = new DancerResponse()
                {
                    CrossingFlightpaths = list.Any(x => x.CrossingFlightpaths),
                    HasBirds = list.Any(x => x.HasBirds),
                    HasDangerDanger = list.Any(x => x.HasDangerDanger),
                    HasNoFlyZone = list.Any(x => x.HasNoFlyZone),
                    MaxHeight = list.Max(x => x.MaxHeight),
                }
            };

            return resp;
        }
    }
}