using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SunriseSunset.Services
{
    internal class SunriseSunsetAPIService : ISunriseSunsetAPIService
    {
        public async Task<(DateTime Sunrise, DateTime Sunset, TimeSpan DayLength)> GetSunriseSunsetTimes(double latitude, double longitude)
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://api.sunrise-sunset.org/") };
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var json = await client.GetStringAsync($"json?lat={latitude}&lng={longitude}&date=today");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var data = JsonSerializer.Deserialize<Models.SunriseSunset>(json, options);

            return (DateTime.Parse(data.Results.Sunrise), DateTime.Parse(data.Results.Sunset), TimeSpan.Parse(data.Results.Day_Length));
        }
    }
}