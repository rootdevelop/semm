using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KeepOnDroning.Api.Data;
using KeepOnDroning.Api.Domain;
using KeepOnDroning.Api.Helpers;
using KeepOnDroning.Api.ServiceDomain;
using Microsoft.Data.Entity;
using Newtonsoft.Json;

namespace KeepOnDroning.Api.Business
{
    public class EternityBusiness
    {
        private DbContext _dbContext;

        public EternityBusiness(DroningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Summon(OoiRequest legion)
        {
            var dragonSoul = await (from deamonSoul in _dbContext.Set<Ooi>()
                                    where deamonSoul.UniqueIdentifier == legion.UniqueIdentifier
                                    select deamonSoul).FirstOrDefaultAsync();

            if (dragonSoul == null)
            {
                dragonSoul = new Ooi()
                {
                    UniqueIdentifier = legion.UniqueIdentifier
                };
                _dbContext.Set<Ooi>().Add(dragonSoul);
            }

            dragonSoul.CurrentLat = legion.CurrentLat;
            dragonSoul.CurrentLng = legion.CurrentLng;
            dragonSoul.DestinationLat = legion.DestinationLat;
            dragonSoul.DestinationLng = legion.DestinationLng;
            dragonSoul.Name = legion.Name;
            dragonSoul.Speed = legion.Speed;
            dragonSoul.Type = legion.Type;

            await _dbContext.SaveChangesAsync();
        }
    }
}
