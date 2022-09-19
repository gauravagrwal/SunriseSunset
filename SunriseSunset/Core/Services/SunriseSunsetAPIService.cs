using System.Text.Json;

namespace SunriseSunset.Core.Services
{
    internal class SunriseSunsetAPIService : ISunriseSunsetAPIService
    {
        const string apiURL = "https://api.sunrise-sunset.org";

        public async Task<(DateTime Sunrise, DateTime Sunset, TimeSpan DayLength)> GetSunriseSunsetTimes(double latitude, double longitude)
        {
            var endpoint = $"{apiURL}/json?lat={latitude}&lng={longitude}&date=today";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var json = await client.GetStringAsync(endpoint);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var data = JsonSerializer.Deserialize<Models.SunriseSunset>(json, options);

            return (DateTime.Parse(data.Results.Sunrise), DateTime.Parse(data.Results.Sunset), TimeSpan.Parse(data.Results.Day_Length));
        }
    }
}
