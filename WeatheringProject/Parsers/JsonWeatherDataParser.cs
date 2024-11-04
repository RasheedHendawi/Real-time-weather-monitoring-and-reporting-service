using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;
using System.Text.Json;

namespace Real_time_weather_monitoring_and_reporting_service.Parsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string data)
        {
            try
            {
                var js = JsonSerializer.Deserialize<WeatherData>(data);
                if (js != null)
                {
                    return js;
                }
                else
                {
                    throw new Exception("null retrun json");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"JSON PARSING ERROR: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
