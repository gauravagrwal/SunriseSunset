namespace SunriseSunset.Core.Services
{
    internal class GeoService : IGeoService
    {
        public async Task<(double Latitude, double Longitude)> GetCoordinates()
        {
            double latitude = 0.0, longitude = 0.0;

            var permission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (permission == PermissionStatus.Granted)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);
                latitude = location.Latitude;
                longitude = location.Longitude;
            }
            return (latitude, longitude);
        }
    }
}
