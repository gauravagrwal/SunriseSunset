namespace SunriseSunset.Core.Models
{
    public class SunriseSunset
    {
        public Results Results { get; set; }
        public string Status { get; set; }
    }

    public class Results
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Day_Length { get; set; }
    }
}
