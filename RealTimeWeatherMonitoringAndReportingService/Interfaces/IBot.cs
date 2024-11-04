using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public interface IBot
    {
        bool Activate(WeatherData weatherData);
    }
}
