using System;

namespace LifeScheduler.API.DTO
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public float TemperatureC { get; set; }
        public float TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}
