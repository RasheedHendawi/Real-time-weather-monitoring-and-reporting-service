using Real_time_weather_monitoring_and_reporting_service.Utilities;

namespace Real_time_weather_monitoring_and_reporting_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string configPath = "AppConfigSetting.json";
            InputHandling inputHandling = new InputHandling(configPath);
            inputHandling.TakeBotConfiguration();
        }
    }

}