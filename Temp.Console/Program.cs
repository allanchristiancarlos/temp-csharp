using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temp.TemperatureServices;

namespace Temp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter zipcode: ");
            var zipCode = System.Console.ReadLine();

            var ow = new OpenWeatherTemperatureService("be1fcf9c172f8dea5d663ccbde94dbe2");
            var service = new TemperatureService(ow);

            Task.Run(async () =>
            {
                var temp = await service.GetTemperatureAsync(Int32.Parse(zipCode));

                System.Console.WriteLine(temp.Temp);
            }).GetAwaiter().GetResult();
        }
    }
}
