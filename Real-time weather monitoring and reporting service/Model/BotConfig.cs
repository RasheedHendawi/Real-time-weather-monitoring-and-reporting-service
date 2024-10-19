
namespace Real_time_weather_monitoring_and_reporting_service.Model
{
    public class BotConfig
    {
        public bool Enabled { get; set; }
        public double TemperatureThreshold { get; set; }
        public double HumidityThreshold { get; set; }
        public required string Message { get; set; }
    }
}
