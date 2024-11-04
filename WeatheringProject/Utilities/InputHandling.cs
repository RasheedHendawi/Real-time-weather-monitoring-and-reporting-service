using Microsoft.Extensions.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Parsers;
using Real_time_weather_monitoring_and_reporting_service.Services;

namespace Real_time_weather_monitoring_and_reporting_service.Utilities
{
    public class InputHandling(IConfiguration configuration)
    {
        private readonly WeatherService _weatherService = new(configuration);

        public void DisplayUserInput()
        {
            while (true)
            {
                Console.WriteLine($"\nEnter weather data ('--abort' to exit) :\n");
                string? inputData = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputData))
                {
                    Console.WriteLine("Input cannot be empty. Please enter valid weather data.");
                    continue;
                }
                if (inputData.Trim().Equals("--abort", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }


                IWeatherDataParser parser = inputData.TrimStart().StartsWith('{')
                    ? new JsonWeatherDataParser()
                    : new XmlWeatherDataParser();

                _weatherService.ProcessWeatherData(inputData, parser);
            }
        }
    }
}
