using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Temp.Exceptions;
using Temp.Exceptions;
using Temp.TemperatureServices;


namespace Temp.Tests
{
    [TestClass]
    public class OpenWeatherTemperatureServiceTests
    {
        [TestMethod]
        public void It_should_be_getting_the_temperature_of_california_using_zip_code()
        {
            Task.Run(async () =>
            {
                var service = new TemperatureService(new OpenWeatherTemperatureService(ConfigurationManager.AppSettings["OpenWeatherAppId"]));

                var temperature = await service.GetTemperatureAsync(90001);

                Assert.IsTrue(temperature != null);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public void Should_throw_exception_if_given_a_wrong_key()
        {
            Task.Run(async () =>
            {
                var service = new TemperatureService(new OpenWeatherTemperatureService("WRONG_APP_ID"));

                var temperature = await service.GetTemperatureAsync(90001);

                Assert.IsTrue(temperature != null);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        [ExpectedException(typeof(DataUnavailableException))]
        public void Should_throw_exception_if_no_data_available()
        {
            Task.Run(async () =>
            {
                // To test this lets just pass a wrong api endpoint url
                var openWeather = new OpenWeatherTemperatureService(ConfigurationManager.AppSettings["OpenWeatherAppId"]);
                var service = new TemperatureService(openWeather);

                var temperature = await service.GetTemperatureAsync(6212312);
            }).GetAwaiter().GetResult();
        }
    }
}
