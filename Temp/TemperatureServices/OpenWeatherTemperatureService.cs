using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Temp.Exceptions;

namespace Temp.TemperatureServices
{
    public class OpenWeatherTemperatureService : ITemperatureService
    {
        private readonly string _appId;
        private readonly string _apiUrl;

        public OpenWeatherTemperatureService(string appId)
            : this(appId, "http://api.openweathermap.org/data/2.5/weather")
        {
        }

        public OpenWeatherTemperatureService(string appId, string apiUrl)
        {
            _appId = appId;
            _apiUrl = apiUrl;
        }

        async Task<Temperature> ITemperatureService.GetTemperatureAsync(int zipCode)
        {
            var request = new HttpClient();
            var response = await request.GetAsync(String.Format($"{_apiUrl}?zip={zipCode}&appid={_appId}&units=metric"));

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedException();
                }
            }

            var responseString = await response.Content.ReadAsStringAsync();
            OpenWeatherResponse responseObject = null;

            try
            {
                responseObject = JsonConvert.DeserializeObject<OpenWeatherResponse>(responseString);
            }
            catch (Exception)
            {
                throw new DataUnavailableException();
            }

            if (responseObject?.Main.Temp == null)
            {
                throw new DataUnavailableException();
            }

            return new Temperature()
            {
                Temp = (double)responseObject.Main.Temp,
                Location = "",
                ZipCode = zipCode
            };

        }
    }

    public class OpenWeatherResponseMain
    {
        public decimal? Temp { get; set; }
    }

    public class OpenWeatherResponse
    {
        public OpenWeatherResponseMain Main { get; set; }
    }
}