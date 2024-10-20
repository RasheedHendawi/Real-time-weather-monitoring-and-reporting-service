using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;
using Real_time_weather_monitoring_and_reporting_service.Parsers;
using Real_time_weather_monitoring_and_reporting_service.Services;
using System.Text.Json;

namespace WeatherMonitoring.Tests
{
    public class WeatherServiceTests
    {
        private const string ValidConfigPath = "AppConfigSetting.json";
        private WeatherService CreateWeatherService() => new WeatherService(ValidConfigPath);

        [Fact]
        public void WeatherService_Should_LoadBotsFromConfig()
        {
            var weatherService = CreateWeatherService();
            Assert.NotNull(weatherService);
        }

        [Theory]
        [InlineData("{\"Location\":\"City Name\",\"Temperature\":32,\"Humidity\":40}", "City Name", 32.0, 40.0)]
        [InlineData("<WeatherData><Location>City Name</Location><Temperature>23</Temperature><Humidity>85</Humidity></WeatherData>", "City Name", 23.0, 85.0)]
        public void ProcessWeatherData_Should_ParseAndUpdateWeatherData(
            string inputData, string expectedLocation, double expectedTemperature, double expectedHumidity)
        {
            var weatherService = CreateWeatherService();

            IWeatherDataParser parser = inputData.TrimStart().StartsWith("{")
                ? new JsonWeatherDataParser()
                : new XmlWeatherDataParser();

            weatherService.ProcessWeatherData(inputData, parser);
            WeatherData actualData = weatherService.GetWeatherData();

            Assert.Equal(expectedLocation, actualData.Location);
            Assert.Equal(expectedTemperature, actualData.Temperature);
            Assert.Equal(expectedHumidity, actualData.Humidity);
        }

        [Fact]
        public void WeatherService_Should_Handle_InvalidConfigFile()
        {

            string invalidConfigPath = "InvalidConfig.json";

            Assert.Throws<FileNotFoundException>(() => new WeatherService(invalidConfigPath));
        }

        [Theory]
        [InlineData("", typeof(JsonException))]
        [InlineData("{\"Location\":\"City\",\"Temperature\":\"Invalid\",\"Humidity\":50}", typeof(JsonException))]
        public void ProcessWeatherData_Should_ThrowException_OnInvalidInput(string inputData, Type expectedException)
        {
            var weatherService = CreateWeatherService();
            IWeatherDataParser parser = new JsonWeatherDataParser();

            Assert.Throws(expectedException, () => weatherService.ProcessWeatherData(inputData, parser));
        }

        [Theory]
        [InlineData("{\"Location\":\"City\",\"Temperature\":35,\"Humidity\":40}", new[] { "SunBot" })]
        [InlineData("{\"Location\":\"City\",\"Temperature\":5,\"Humidity\":80}", new[] { "RainBot" })]
        public void Bots_Should_Activate_BasedOnWeatherData(string inputData, string[] expectedActiveBots)
        {

            var weatherService = CreateWeatherService();
            IWeatherDataParser parser = inputData.TrimStart().StartsWith("{")
                ? new JsonWeatherDataParser()
                : new XmlWeatherDataParser();


            weatherService.ProcessWeatherData(inputData, parser);

            var activeBots = weatherService.GetWeatherData().GetActiveBots();
            var activeBotNames = activeBots.Select(b => b.GetType().Name).ToArray();

            Assert.Equal(expectedActiveBots, activeBotNames);
        }


    }
}




