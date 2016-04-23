using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KeepOnDroning.Api.ServiceDomain;

namespace KeepOnDroning.Api.Business
{
    public class WeatherBusiness
    {
        private string _openWeatherMapUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";
        private string _wheaterAppId = "37bafeb001ed3617ec71a179eaf594ce"; 
        public async Task<Weather> GetWeather(float latitude, float longitude)
        {
            //var client = new UncommonHttpClient();
            //var uri = String.Format(_openWeatherMapUri, latitude, longitude, _wheaterAppId);

            //var weather = await client.GetJsonAsync<Weather>(uri, HttpCompletionOption.ResponseContentRead);

            //return weather;
            return null;
        }
    }
}
