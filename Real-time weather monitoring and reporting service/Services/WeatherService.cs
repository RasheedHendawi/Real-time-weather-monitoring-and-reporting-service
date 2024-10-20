using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.Services
{
    public class WeatherService
    {
        private readonly WeatherData _weatherData;
        private readonly BotManager _botManager;

        public WeatherService(string configFilePath)
        {
            var configLoader = new BotConfigurationLoader();
            var botsConfig = configLoader.LoadConfig(configFilePath);

            _botManager = new BotManager(botsConfig);
            _weatherData = new WeatherData();

            foreach (var bot in _botManager.GetBots())
            {
                _weatherData.RegisterObserver(bot);
            }
        }

        public void ProcessWeatherData(string inputData, IWeatherDataParser parser)
        {
            WeatherData weatherData = parser.Parse(inputData);
            _weatherData.SetWeatherData(weatherData.Location, weatherData.Temperature, weatherData.Humidity);
        }
        public WeatherData GetWeatherData() => _weatherData;
        public BotManager GetBotManager() => _botManager;
    }

}