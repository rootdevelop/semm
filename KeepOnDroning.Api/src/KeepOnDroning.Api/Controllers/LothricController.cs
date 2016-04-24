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
    public class LothricController : Controller
    {
        private DancerBusiness _dancerBusiness;

        public LothricController(DancerBusiness dancerBusiness)
        {
            _dancerBusiness = dancerBusiness;
        }

        /// <summary>
        ///     Returns a quick overview in the form of a <see cref="DancerResponse"/> to check if the drone is flying in or going to a zone that is save to fly in, both in terms of weather and regulations. 
        /// </summary>
        /// <param name="latitude">Float latitude</param>
        /// <param name="longitude">Float latitude</param>
        /// <returns>Returns a DancerResult <see cref="DancerResponse"/></returns>
        [Route("Estus/{latitude}/{longitude}")]
        [HttpGet]
        public async Task<DancerResponse> Estus(float latitude, float longitude)
        {
            var dancer = await _dancerBusiness.Dancing(latitude, longitude);

            return dancer;
        }

        /// <summary>
        ///     Takes a List of coordinates (a Drone Route/Fly plan) and return a summary of the safety of the fly plan
        /// </summary>
        /// <param name="coordinates"> Takes a List of Service Coordinates <see cref="ServiceCoordinate"></param>
        /// <returns> <see cref="RouteResult"></returns>
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