using Real_time_weather_monitoring_and_reporting_service.Model;

namespace WeatherMonitoring.Tests
{
    [TestFixture]
    public class WeatherDataTests
    {
        [Test]
        public void RegisterObserver_AddsObserverToList()
        {
            // Arrange
            var weatherData = new WeatherData();
            var mockBot = new Mock<IBot>();

            // Act
            weatherData.RegisterObserver(mockBot.Object);

            // Assert
            Assert.Contains(mockBot.Object, weatherData.GetObservers());
        }

        [Test]
        public void NotifyObservers_ActivatesRegisteredObservers()
        {
            // Arrange
            var weatherData = new WeatherData();
            var mockBot = new Mock<IBot>();
            weatherData.RegisterObserver(mockBot.Object);

            // Act
            weatherData.SetWeatherData("City", 32.0, 80.0);

            // Assert
            mockBot.Verify(bot => bot.Activate(weatherData), Times.Once);
        }
    }
}
