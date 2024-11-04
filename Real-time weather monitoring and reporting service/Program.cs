using Microsoft.Extensions.Configuration;
using Real_time_weather_monitoring_and_reporting_service.Utilities;

namespace Real_time_weather_monitoring_and_reporting_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            InputHandling inputHandling = new(configuration);
            inputHandling.DisplayUserInput();
        }
    }
}
