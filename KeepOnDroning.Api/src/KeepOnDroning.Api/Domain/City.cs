using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KeepOnDroning.Api.Domain
{
    public class City
    {
        [JsonProperty(PropertyName = "_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "coord")]
        public Coordinate Coordinate { get; set; }
    }
}
