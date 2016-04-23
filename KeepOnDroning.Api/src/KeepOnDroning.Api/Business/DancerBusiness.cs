using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KeepOnDroning.Api.Helpers;
using KeepOnDroning.Api.ServiceDomain;
using Newtonsoft.Json;

namespace KeepOnDroning.Api.Business
{
    public class DancerBusiness
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

        private readonly string _openWeatherMapUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";
        private string _wheaterAppId = "37bafeb001ed3617ec71a179eaf594ce"; 

        public async Task<WeatherResult> GetWeather(float latitude, float longitude)
        {
            using (var client = new HttpClient())
            {
                var uri = String.Format(_openWeatherMapUri, latitude, longitude, _wheaterAppId);
                var httpResponseMessage = await client.GetAsync(uri);
                httpResponseMessage.EnsureSuccessStatusCode();

                var resultAsString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResult>(resultAsString, _jsonSerializerSettings);
            }
        }

        public async Task<DancerResponse> Dancing(float latitude, float longitude)
        {
            var weather = await GetWeather(latitude, longitude);



            var random = new Random();
            var randomBirds = random.Next(100) < 10;

            var dancer = new DancerResponse()
            {
                Lat = latitude,
                Lng = longitude,
                HasBirds = randomBirds,
                Weather = new WeatherResponse()
                {
                    WindDegree = weather.Wind.Deg,
                    WindSpeed = weather.Wind.Speed
                },
                HasDangerDanger = IsDangerDanger(weather),
                MaxHeight = 1000,
                
            };
            return dancer;
        }

        private bool IsDangerDanger(WeatherResult weather)
        {
            int weatherCode;
            try
            {
                weatherCode = int.Parse(weather.WeatherCode.ToString("N"));
            }
            catch (Exception)
            {
                return true;
            }
            
            if (weatherCode >= 232 && weatherCode <= 501)
            {
                return true;
            }
            if (weatherCode <= 500 && weatherCode <= 781)
            {
                return true;
            }
            if (weatherCode <= 900 && weatherCode <= 902)
            {
                return true;
            }
            if (weatherCode <= 957)
            {
                return true;
            }
            if (weather.Wind.Speed > DroningConstants.MaxWindSpeed)
            {
                return true;
            }
            return false;
        }


    }
}
