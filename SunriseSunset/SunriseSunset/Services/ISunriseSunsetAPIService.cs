using System;
using System.Threading.Tasks;

namespace SunriseSunset.Services
{
    internal interface ISunriseSunsetAPIService
    {
        Task<(DateTime Sunrise, DateTime Sunset, TimeSpan DayLength)> GetSunriseSunsetTimes(double latitude, double longitude);
    }
}
