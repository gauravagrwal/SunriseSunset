using System.Threading.Tasks;

namespace SunriseSunset.Services
{
    internal interface IGeoService
    {
        Task<(double Latitude, double Longitude)> GetCoordinates();
    }
}
