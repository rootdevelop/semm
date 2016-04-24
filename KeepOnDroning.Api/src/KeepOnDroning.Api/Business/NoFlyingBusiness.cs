using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Data;
using KeepOnDroning.Api.Domain;
using KeepOnDroning.Api.ServiceDomain;
using KeepOnDroning.Api.ServiceDomain.Enums;
using Microsoft.Data.Entity;

namespace KeepOnDroning.Api.Business
{
    public class NoFlyingBusiness
    {
        private readonly DbContext _dbContext;

        public NoFlyingBusiness(DroningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///     Takes coordinates and returns a NoFlyResult <see cref="NoFlyResult"/>
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns><see cref="NoFlyResult"/></returns>
        public async Task<NoFlyResult> NoFlyResult(float latitude, float longitude)
        {
            var oois = await GetOois(latitude, longitude);
            var zones = await NoFlyZones(latitude, longitude);

            return new NoFlyResult()
            {
                NoFlyZones = zones.Count > 0 ? zones : null,
                Oois = oois.Count > 0 ? oois : null
            };
        }

        /// <summary>
        ///     Takes Coordinates, Returns a list of Object of Interest <see cref="Ooi"/>
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<List<Ooi>> GetOois(float latitude, float longitude)
        {
            var ooisEntities = await (from a in _dbContext.Set<Domain.Ooi>()
                                       where Distance(a.CurrentLat, a.CurrentLng, latitude, longitude, 'K') < 300 || Distance(a.DestinationLat, a.DestinationLng, latitude, longitude, 'K') < 300
                                       select a).ToListAsync();

            if (ooisEntities.Count > 0)
            {
                return null;
            }

            return ooisEntities;
        }

        /// <summary>
        ///     Takes Coordinates, Returns a list of No Fly Zones and their range <see cref="ServiceNoFlyZone"/>
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<List<ServiceNoFlyZone>> NoFlyZones(float latitude, float longitude)
        {
            var noFlyEntities = await (from a in _dbContext.Set<Domain.Airport>()
                                    where Distance(a.Lat, a.Lng, latitude, longitude, 'K') < 300
                                    select a).ToListAsync();

            if (noFlyEntities.Count <= 0)
            {
                return null;
            }

            var noFlyZones = noFlyEntities.Select(x =>
            {
                return new ServiceNoFlyZone()
                {
                    Name = x.Name,
                    Type = ENoFlyZoneType.Airport,
                    Latitude = x.Lat,
                    Longitude = x.Lng,
                    Size = 10000,
                };
            }).ToList();

            return noFlyZones;
        }

        /// <summary>
        ///     Check whether the coordinates supplied are within a no flight zone 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<bool> IsInNoFlyZone(float latitude, float longitude)
        {
            var noFlyZones = await (from a in _dbContext.Set<Domain.Airport>()
                                    where Distance(a.Lat, a.Lng, latitude, longitude, 'K') < 5
                                    select a).ToListAsync();

            if (noFlyZones.Count > 0)
            {
                return true;
            }
            return false;
        }

        //:::    unit = the unit you desire for results                               :::
        //:::           where: 'M' is statute miles (default)                         :::
        //:::                  'K' is kilometers                                      :::
        //:::                  'N' is nautical miles                                  :::
        //:::  For enquiries, please contact sales@geodatasource.com                  :::
        //:::                                                                         :::
        //:::  Official Web site: http://www.geodatasource.com                        :::
        //:::                                                                         :::
        //:::           GeoDataSource.com (C) All Rights Reserved 2015                :::
        //:::                                                                         :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            try
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                return (dist);
            }
            catch (Exception)
            {
            }
            return 99999;

        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
