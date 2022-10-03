namespace SunriseSunset.Models
{
    internal class SunriseSunset
    {
        public Results Results { get; set; }
        public string Status { get; set; }
    }

    internal class Results
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Day_Length { get; set; }
    }
}
