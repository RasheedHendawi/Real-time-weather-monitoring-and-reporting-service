using Real_time_weather_monitoring_and_reporting_service.Bots;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace WeatherMonitoring.Tests.Bots
{
    public class SunBotTests
    {
        [Fact]
        public void Activate_ShouldReturnTrue_WhenTemperatureExceedsThreshold()
        {
            var config = new Bot
            {
                Enabled = true,
                TemperatureThreshold = 30,
                Message = "Wow, it's a scorcher out there!"
            };
            var sunBot = new SunBot(config);
            var weatherData = new WeatherData
            {
                Temperature = 35
            };

            bool result = sunBot.Activate(weatherData);

            Assert.True(result);
        }

        [Fact]
        public void Activate_ShouldReturnFalse_WhenTemperatureDoesNotExceedThreshold()
        {
            var config = new Bot
            {
                Enabled = true,
                TemperatureThreshold = 30,
                Message = "Wow, it's a scorcher out there!"
            };
            var sunBot = new SunBot(config);
            var weatherData = new WeatherData
            {
                Temperature = 25
            };

            bool result = sunBot.Activate(weatherData);

            Assert.False(result);
        }

        [Fact]
        public void Activate_ShouldReturnFalse_WhenBotIsDisabled()
        {
            var config = new Bot
            {
                Enabled = false,
                TemperatureThreshold = 30,
                Message = "Wow, it's a scorcher out there!"
            };
            var sunBot = new SunBot(config);
            var weatherData = new WeatherData
            {
                Temperature = 35
            };

            bool result = sunBot.Activate(weatherData);

            Assert.False(result);
        }
    }
}
