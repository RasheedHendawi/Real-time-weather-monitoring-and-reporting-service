using Microsoft.Extensions.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Parsers;
using Real_time_weather_monitoring_and_reporting_service.Services;


namespace WeatherMonitoring.Tests.Services
{
    public class WeatherServiceTests
    {
        [Fact]
        public void ProcessWeatherData_ShouldActivateBots_WhenConditionsAreValid()
        {
            var inMemory = new Dictionary<string, string?> {
            {"BotsConfig:SunBot:Enabled", "true"},
            {"BotsConfig:SunBot:TemperatureThreshold", "30"},
            {"BotsConfig:SunBot:HumidityThreshold", "0"},
            {"BotsConfig:SunBot:Message", "Wow, it's a scorcher out there!"},
            };


            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemory)
                .Build();

            var weatherService = new WeatherService(configuration);
            string inputData = "{\"Location\":\"City\",\"Temperature\":35,\"Humidity\":50}";
            var parser = new JsonWeatherDataParser();

            var originalConsoleOut = Console.Out;
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            try
            {
                weatherService.ProcessWeatherData(inputData, parser);

                string output = consoleOutput.ToString();
                Console.SetOut(originalConsoleOut);
                Console.WriteLine($"Captured Output:\n{output}");

                Assert.Contains("Sun Bot activated", output);
                Assert.Contains("Wow, it's a scorcher out there!", output);
            }
            catch (Exception ex)
            {
                Console.SetOut(originalConsoleOut);
                Console.WriteLine($"Test failed with exception: {ex}");
                throw;
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }
        }

        [Fact]
        public void ProcessWeatherData_ShouldThrowException_WhenInvalidOperaiton()
        {
            var inMemory = new Dictionary<string, string?> {
                {"nothing:SunBot:Enabled", "true"},
                {"nothing:SunBot:TemperatureThreshold", "30"},
                {"nothing:SunBot:Message", "Wow, it's a scorcher out there!"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemory)
                .Build();
            var exception = Record.Exception(() => new WeatherService(configuration));

            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}
