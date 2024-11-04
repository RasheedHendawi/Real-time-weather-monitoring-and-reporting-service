using Real_time_weather_monitoring_and_reporting_service.Model;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Moq;

namespace WeatherMonitoring.Tests.Model
{
    public class WeatherDataTests
    {
        [Fact]
        public void NotifyObservers_ShouldCallActivateOnAllObservers()
        {
            var weatherData = new WeatherData();
            var botMock1 = new Mock<IBot>();
            var botMock2 = new Mock<IBot>();

            botMock1.Setup(b => b.Activate(It.IsAny<WeatherData>())).Returns(false);
            botMock2.Setup(b => b.Activate(It.IsAny<WeatherData>())).Returns(false);

            weatherData.RegisterObserver(botMock1.Object);
            weatherData.RegisterObserver(botMock2.Object);

            var originalConsoleOut = Console.Out;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);// here i used this for disposed problem

            try
            {
                weatherData.SetWeatherData("City", 25, 60);

                botMock1.Verify(b => b.Activate(weatherData), Times.Once);
                botMock2.Verify(b => b.Activate(weatherData), Times.Once);

                var output = stringWriter.ToString();// so the output will be inside stringWriter
                Assert.Contains("No bots were activated for the given weather data.", output);
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }
        }
    }
}
