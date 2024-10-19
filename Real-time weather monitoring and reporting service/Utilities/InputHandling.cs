using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Parsers;
using Real_time_weather_monitoring_and_reporting_service.Services;

namespace Real_time_weather_monitoring_and_reporting_service.Utilities
{
    internal class InputHandling
    {
        public void TakeBotConfiguration(string configPath)
        {
            WeatherService weatherService = new WeatherService(configPath);
            DisplayUserInput(weatherService);
        }
        private void DisplayUserInput (WeatherService weatherService)
        {
            while (true)
            {
                Console.WriteLine($"\nEnter weather data('--abort' to exit):\n");
                string inputData = Console.ReadLine();
                if (inputData.Equals("--abort")) break;
                IWeatherDataParser parser = inputData.TrimStart().StartsWith("{")
                    ? new JsonWeatherDataParser()
                    : new XmlWeatherDataParser();
                weatherService.ProcessWeatherData(inputData, parser);
            }
        }
    }
}
