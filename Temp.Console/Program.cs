using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.Exceptions;
using Temp.TemperatureServices;

namespace Temp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter zipcode: ");
            var zipCode = System.Console.ReadLine();

            var ow = new OpenWeatherTemperatureService(ConfigurationManager.AppSettings["OpenWeatherAppId"]);
            var service = new TemperatureService(ow);

            Task.Run(async () =>
            {
                var temp = await service.GetTemperatureAsync(Int32.Parse(zipCode));

                System.Console.WriteLine(temp.Temp);
            }).GetAwaiter().GetResult();
        }
    }
}
