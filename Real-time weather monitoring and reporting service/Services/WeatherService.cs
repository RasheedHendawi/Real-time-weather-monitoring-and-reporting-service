using Microsoft.Extensions.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.Services
{
    public class WeatherService
    {
        private readonly WeatherData _weatherData;
        private readonly BotManager _botManager;

        public WeatherService(IConfiguration configuration)
        {
            var botConfig = configuration.GetSection("BotsConfig").Get<BotConfig>();
            if (botConfig != null)
            {
                _botManager = new BotManager(botConfig);
                _weatherData = new WeatherData();

                foreach (var bot in _botManager.GetBots())
                {
                    _weatherData.RegisterObserver(bot);
                }
            }
            else
            {
                throw new InvalidOperationException("Bot configurations are missing or invalid. Please check your configuration file.");
            }
        }

        public void ProcessWeatherData(string inputData, IWeatherDataParser parser)
        {
            WeatherData weatherData = parser.Parse(inputData);
            if (weatherData == null)
            {
                Console.WriteLine("Failed to parse weather data. Please check the input format.");
                return;
            }
            _weatherData.SetWeatherData(weatherData.Location, weatherData.Temperature, weatherData.Humidity);
        }
    }
}