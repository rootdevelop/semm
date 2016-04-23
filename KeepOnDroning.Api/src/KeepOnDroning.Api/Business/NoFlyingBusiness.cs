﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Data;
using KeepOnDroning.Api.Domain;
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

        public async Task<List<Airport>> NoFlightZones(float latitude, float longitude)
        {
            var noFlyZones = await (from a in _dbContext.Set<Domain.Airport>()
                                    where distance(a.Lat, a.Lng, latitude, longitude, 'K') < 50
                                    select a).ToListAsync();

            if (noFlyZones.Count > 0)
            {
                return null;
            }
            return noFlyZones;
        }

        public async Task<bool> IsInNoFlightZone(float latitude, float longitude)
        {
            var noFlyZones = await (from a in _dbContext.Set<Domain.Airport>()
                                    where distance(a.Lat, a.Lng, latitude, longitude, 'K') < 5
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
        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
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
