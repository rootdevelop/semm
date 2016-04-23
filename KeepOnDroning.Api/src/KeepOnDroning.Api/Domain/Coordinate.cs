using Newtonsoft.Json;

namespace KeepOnDroning.Api.Domain
{
    public class Coordinate
    {
        [JsonProperty(PropertyName = "lon")]
        public float Longitude { get; set; }
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }
    }
}