using Real_time_weather_monitoring_and_reporting_service.Model;
using Real_time_weather_monitoring_and_reporting_service.Services;
using Real_time_weather_monitoring_and_reporting_service.Utilities;


namespace WeatherMonitoring.Tests
{
    public class InputHandlingTests
    {
        [Fact]
        public void TakeBotConfiguration_ShouldProcessWeatherData_WhenInputIsValid()
        {
            string configPath = "AppConfigSetting.json";
            var inputHandling = new InputHandling(configPath);

            var input = new StringReader("{\"Location\": \"City Name\", \"Temperature\": 23.0, \"Humidity\": 85.0}\n--abort\n");
            Console.SetIn(input);

            inputHandling.TakeBotConfiguration();

            Assert.NotEmpty(inputHandling.GetWeatherService().GetWeatherData().GetActiveBots());
        }

        [Fact]
        public void DisplayUserInput_ShouldExit_WhenInputIsAbort()
        {
            string configPath = "AppConfigSetting.json";
            var inputHandling = new InputHandling(configPath);
            var weatherService = new WeatherService(configPath);

            var input = new StringReader("--abort\n");
            Console.SetIn(input);

            inputHandling.TakeBotConfiguration();

            WeatherData weatherData = new WeatherData();
            Assert.Empty(inputHandling.GetWeatherService().GetWeatherData().GetActiveBots());
        }
    }
}

