using System;
using Xciles.Uncommon.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using KeepOnDroning.Core.Domain;

namespace KeepOnDroning.Core.Services
{
    public class ToDroneOrNotToDroneOrMaybeShouldCouldIDroneTodayOrNotBecauseILikeDroningSoMuchPleaseYesService
    {

        public async Task<ToDroneOrNotToDroneResponse> TellMe(double lat, double lng)
        {
            try
            {
                #if DEBUG
                return new ToDroneOrNotToDroneResponse()
                {
                    HasBirds = true,
                    CrossingFlightpaths = false,
                    HasNoFlyZone = false,
                    HasDangerDanger = false,
                    MaxHeight = 100,
                    Weather = new WeatherResponse()
                    {
                        WindDegree = 0.45f,
                        WindSpeed = 50
                    }
                };

                #else
                var res = await UncommonRequestHelper.ProcessGetRequestAsync<ToDroneOrNotToDroneResponse>("uri here");
                return res.Result;
                #endif
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new ToDroneOrNotToDroneResponse();
            }



        }
    }
}

