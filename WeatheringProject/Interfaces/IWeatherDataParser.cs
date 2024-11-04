using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public interface IWeatherDataParser
    {
        WeatherData Parse(string data);
    }
}
