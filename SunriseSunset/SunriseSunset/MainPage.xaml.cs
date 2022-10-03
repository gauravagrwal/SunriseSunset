using SunriseSunset.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SunriseSunset
{
    public partial class MainPage : ContentPage
    {
        GeoService GeoService { get; set; }
        SunriseSunsetAPIService SunriseSunsetAPIService { get; set; }

        public MainPage()
        {
            InitializeComponent();

            GeoService = new GeoService();
            SunriseSunsetAPIService = new SunriseSunsetAPIService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            refreshView.IsRefreshing = true;
            var sunriseSunsetData = await GetSunriseSunsetData();
            InitializeUI(sunriseSunsetData.Item1, sunriseSunsetData.Item2, sunriseSunsetData.Item3);
            refreshView.IsRefreshing = false;
        }

        async Task<(DateTime, DateTime, TimeSpan)> GetSunriseSunsetData()
        {

            var (Latitude, Longitude) = await GeoService.GetCoordinates();
            var data = await SunriseSunsetAPIService.GetSunriseSunsetTimes(Latitude, Longitude);

            var sunriseTime = data.Sunrise.ToLocalTime();
            var sunsetTime = data.Sunset.ToLocalTime();
            var dayLength = data.DayLength;

            return (sunriseTime, sunsetTime, dayLength);
        }

        void InitializeUI(DateTime riseTime, DateTime setTime, TimeSpan span)
        {
            sunriseLabel.Text = riseTime.ToString("h:mm tt");
            daylightLabel.Text = $"{span.Hours} hours, {span.Minutes} minutes";
            sunsetLabel.Text = setTime.ToString("h:mm tt");
        }
    }
}
