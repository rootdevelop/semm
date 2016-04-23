using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.ServiceDomain.Enums;
using Newtonsoft.Json;

namespace KeepOnDroning.Api.ServiceDomain
{
    public class WeatherResult
    {
        [JsonProperty(PropertyName = "coord")]
        public Coord Coordinate { get; set; }
        [JsonProperty(PropertyName = "sys")]
        public Sys Sys { get; set; }
        [JsonProperty(PropertyName = "weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty(PropertyName = "main")]
        public Main Main { get; set; }
        [JsonProperty(PropertyName = "wind")]
        public Wind Wind { get; set; }
        [JsonProperty(PropertyName = "rain")]
        public Rain Rain { get; set; }
        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty(PropertyName = "dt")]
        public int Dt { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "cod")]
        public EWheaterCode WheaterCode { get; set; }
    }

    public class Coord
    {
        [JsonProperty(PropertyName = "lon")]
        public int Lon { get; set; }
        [JsonProperty(PropertyName = "lat")]
        public int Lat { get; set; }
    }

    public class Sys
    {
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty(PropertyName = "sunset")]
        public int Sunset { get; set; }
    }

    public class Main
    {
        [JsonProperty(PropertyName = "temp")]
        public float Temp { get; set; }
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public float TempMin { get; set; }
        [JsonProperty(PropertyName = "temp_max")]
        public float TempMax { get; set; }
    }

    public class Wind
    {
        [JsonProperty(PropertyName = "speed")]
        public float Speed { get; set; }
        [JsonProperty(PropertyName = "deg")]
        public float Deg { get; set; }
    }

    public class Rain
    {
        [JsonProperty(PropertyName = "_3h")]
        public int _3H { get; set; }
    }

    public class Clouds
    {
        [JsonProperty(PropertyName = "all")]
        public int All { get; set; }
    }

    public class Weather
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "main")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }

}
