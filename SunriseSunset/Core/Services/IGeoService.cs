namespace SunriseSunset.Core.Services
{
    internal interface IGeoService
    {
        Task<(double Latitude, double Longitude)> GetCoordinates();
    }
}
