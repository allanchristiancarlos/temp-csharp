using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Temp.TemperatureServices
{
    public class OpenWeatherTemperatureService : ITemperatureService
    {
        private readonly string _appId;
        private const string ApiUrl = "http://api.openweathermap.org/data/2.5/weather";

        public OpenWeatherTemperatureService(string appId)
        {
            _appId = appId;
        }

        async Task<Temperature> ITemperatureService.GetTemperatureAsync(int zipCode)
        {
            var request = new HttpClient();
            var response = await request.GetAsync(String.Format($"{ApiUrl}?zip={zipCode}&appid={_appId}&units=metric"));
            var responseString = String.Empty;

            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }

            var responseObject = JsonConvert.DeserializeObject<OpenWeatherResponse>(responseString);

            return new Temperature()
            {
                Temp = responseObject.Main.Temp,
                Location = "",
                ZipCode = zipCode
            };

        }
    }

    public class OpenWeatherResponseMain
    {
        public double Temp { get; set; }
    }

    public class OpenWeatherResponse
    {
        public OpenWeatherResponseMain Main { get; set; }
    }
}