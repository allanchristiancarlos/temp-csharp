using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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
                var service = new TemperatureService(new OpenWeatherTemperatureService("be1fcf9c172f8dea5d663ccbde94dbe2"));

                var temperature = await service.GetTemperatureAsync(90001);

                Assert.IsTrue(temperature != null);
            }).GetAwaiter().GetResult();
        }
    }
}
