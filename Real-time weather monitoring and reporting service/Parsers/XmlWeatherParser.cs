﻿using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;
using System.Xml.Serialization;

namespace Real_time_weather_monitoring_and_reporting_service.Parsers
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string data)
        {
            var serializer = new XmlSerializer(typeof(WeatherData));
            using (var reader = new StringReader(data))
            {
                return (WeatherData)serializer.Deserialize(reader);
            }
        }
    }
}
