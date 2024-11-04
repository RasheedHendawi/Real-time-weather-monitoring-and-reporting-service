

using Real_time_weather_monitoring_and_reporting_service.Bots;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace WeatherMonitoring.Tests.Bots
{
    public class SnowBotTests
    {
        [Fact]
        public void Activate_ShouldReturnTrue_WhenTemperatureExceedsThreshold()
        {
            var config = new Bot
            {
                Enabled = true,
                TemperatureThreshold = 0,
                Message = "Brrr, it's getting chilly!"
            };
            var snowBot = new SnowBot(config);
            var weatherData = new WeatherData
            {
                Temperature = -10
            };

            bool result = snowBot.Activate(weatherData);

            Assert.True(result);
        }
        [Fact]
        public void Activate_ShouldReturnFalse_WhenTemperatureDoesNotExceedThreshold()
        {
            var config = new Bot
            {
                Enabled = true,
                TemperatureThreshold = 0,
                Message = "Brrr, it's getting chilly!"
            };
            var snowBot = new SnowBot(config);
            var weatherData = new WeatherData
            {
                Temperature = 25
            };

            bool result = snowBot.Activate(weatherData);

            Assert.False(result);
        }

        [Fact]
        public void Activate_ShouldReturnFalse_WhenBotIsDisabled()
        {
            var config = new Bot
            {
                Enabled = false,
                TemperatureThreshold = 0,
                Message = "Brrr, it's getting chilly!"
            };
            var snowBot = new SnowBot(config);
            var weatherData = new WeatherData
            {
                Temperature = 30
            };

            bool result = snowBot.Activate(weatherData);

            Assert.False(result);
        }
    }
}
