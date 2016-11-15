using System.Threading.Tasks;

namespace Temp
{
    public class TemperatureService
    {
        private readonly ITemperatureService _service;

        public TemperatureService(ITemperatureService service)
        {
            _service = service;
        }

        public async Task<Temperature> GetTemperatureAsync(int zipCode)
        {
            return await _service.GetTemperatureAsync(zipCode);
        }
    }
}