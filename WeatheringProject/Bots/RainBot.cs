using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public class RainBot(Bot config) : IBot
    {
        private readonly Bot _config = config;

        public bool Activate(WeatherData weatherData)
        {
            if (_config.Enabled && weatherData.Humidity > _config.HumidityThreshold)
            {
                Console.WriteLine($"Rain Bot activated\n{_config.Message}");
                return true;
            }
            return false;
        }
    }

}
