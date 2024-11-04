using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;
using System.Xml.Serialization;

namespace Real_time_weather_monitoring_and_reporting_service.Parsers
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string data)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using var reader = new StringReader(data);
                if (serializer.Deserialize(reader) is WeatherData xml)
                {
                    return xml;
                }
                else
                {
                    throw new Exception("null return");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"XML Parsing Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
