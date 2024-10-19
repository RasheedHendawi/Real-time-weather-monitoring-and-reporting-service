using Real_time_weather_monitoring_and_reporting_service.Model;
using System.Text.Json;

namespace Real_time_weather_monitoring_and_reporting_service.Services
{
    public class BotConfigurationLoader
    {
        public BotsConfig LoadConfig(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                //Console.WriteLine("JSON Content: " + jsonContent);//for debug

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true 
                };

                BotsConfig config = JsonSerializer.Deserialize<BotsConfig>(jsonContent, options);

                if (config == null)
                {
                    Console.WriteLine("Failed to deserialize JSON. Check the structure.");
                }

                return config;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Parsing Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }
        }
    }
}
