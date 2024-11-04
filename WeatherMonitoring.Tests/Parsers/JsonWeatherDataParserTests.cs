using Real_time_weather_monitoring_and_reporting_service.Parsers;


namespace WeatherMonitoring.Tests.Parsers
{
    public class JsonWeatherDataParserTests
    {
        [Fact]
        public void Parse_ShouldReturnWeatherData_WhenInputIsValidJson()
        {
            var parser = new JsonWeatherDataParser();
            string inputData = "{\"Location\":\"City\",\"Temperature\":25,\"Humidity\":60}";

            var result = parser.Parse(inputData);

            Assert.NotNull(result);
            Assert.Equal("City", result.Location);
            Assert.Equal(25, result.Temperature);
            Assert.Equal(60, result.Humidity);
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenInputIsInvalidJson()
        {
            var parser = new JsonWeatherDataParser();
            string inputData = "{Invalid Json}";

            var result = parser.Parse(inputData);

            Assert.Null(result);
        }
    }
}
