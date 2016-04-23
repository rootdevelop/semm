using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KeepOnDroning.Api.ServiceDomain;
using Newtonsoft.Json;

namespace KeepOnDroning.Api.Business
{
    public class WeatherBusiness
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

        private readonly string _openWeatherMapUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";
        private string _wheaterAppId = "37bafeb001ed3617ec71a179eaf594ce"; 

        public async Task<Weather> GetWeather(float latitude, float longitude)
        {
            using (var client = new HttpClient())
            {
                var uri = String.Format(_openWeatherMapUri, latitude, longitude, _wheaterAppId);
                var httpResponseMessage = await client.GetAsync(uri);
                httpResponseMessage.EnsureSuccessStatusCode();

                var resultAsString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Weather>(resultAsString, _jsonSerializerSettings);
            }
        }
    }
}
