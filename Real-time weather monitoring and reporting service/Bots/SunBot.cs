using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public class SunBot : IBot
    {
        private readonly BotConfig _config;

        public SunBot(BotConfig config)
        {
            _config = config;
        }
        public bool Activate(WeatherData weatherData)
        {
            if (_config.Enabled && weatherData.Temperature > _config.TemperatureThreshold)
            {
                Console.WriteLine($"Sun Bot activated\n{_config.Message}");
                return true;
            }
            return false;
        }
    }
}
