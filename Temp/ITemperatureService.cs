using System.Threading.Tasks;

namespace Temp
{
    public interface ITemperatureService
    {
        Task<Temperature> GetTemperatureAsync(int zipCode);
    }
}