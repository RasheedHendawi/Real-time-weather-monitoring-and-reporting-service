
using Real_time_weather_monitoring_and_reporting_service.Parsers;
using Real_time_weather_monitoring_and_reporting_service.Services;
using System.Configuration;

namespace WeatherMonitoring.Tests.Parsers
{
    public class XmlWeatherDataParserTests
    {
        [Fact]
        public void Parse_ShouldReturnWeatherData_WhenInputIsValidXml()
        {
            var parser = new XmlWeatherDataParser();
            string inputData = @"
                <WeatherData>
                    <Location>City</Location>
                    <Temperature>25</Temperature>
                    <Humidity>60</Humidity>
                </WeatherData>";

            var result = parser.Parse(inputData);

            Assert.NotNull(result);
            Assert.Equal("City", result.Location);
            Assert.Equal(25, result.Temperature);
            Assert.Equal(60, result.Humidity);
        }

        [Fact]
        public void Parse_ShouldThrowException_WhenInputIsInvalidXml()
        {
            var parser = new XmlWeatherDataParser();
            string inputData = "<InvalidXml>";

            var originalConsoleOut = Console.Out;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            try
            {
                var exception = Record.Exception(() => parser.Parse(inputData));

                Assert.NotNull(exception);
                //Assert.IsType<Exception>(exception);
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }

        }
    }
}
