using Real_time_weather_monitoring_and_reporting_service.Bots;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace WeatherMonitoring.Tests.Bots
{
    public class RainBotTests
    {
        [Fact]
        public void Activate_ShouldReturnTrue_WhenHumidityExceedsThreshold()
        {
            var config = new Bot
            {
                Enabled = true,
                HumidityThreshold = 70,
                Message = "It looks like it's about to pour down!"
            };
            var rainBot = new RainBot(config);
            var weatherData = new WeatherData
            {
                Humidity = 80
            };


            var result = rainBot.Activate(weatherData);

            Assert.True(result);
        }

        [Fact]
        public void Activate_ShouldReturnFalse_WhenHumidityDoesNotExceedThreshold()
        {
            var config = new Bot
            {
                Enabled = true,
                HumidityThreshold = 70,
                Message = "It looks like it's about to pour down!"
            };
            var rainBot = new RainBot(config);
            var weatherData = new WeatherData
            {
                Humidity = 60
            };

            var result = rainBot.Activate(weatherData);

            Assert.False(result);
        }

        [Fact]
        public void Activate_ShouldReturnFalse_WhenBotIsDisabled()
        {
            var config = new Bot
            {
                Enabled = false,
                HumidityThreshold = 70,
                Message = "It looks like it's about to pour down!"
            };
            var rainBot = new RainBot(config);
            var weatherData = new WeatherData
            {
                Humidity = 80
            };

            var result = rainBot.Activate(weatherData);

            Assert.False(result);
        }
    }
}
