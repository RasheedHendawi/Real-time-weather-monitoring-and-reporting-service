using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;
using System.Text.Json;

namespace Real_time_weather_monitoring_and_reporting_service.Parsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string data)
        {
            return JsonSerializer.Deserialize<WeatherData>(data);
        }
    }
}
