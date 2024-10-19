
using Real_time_weather_monitoring_and_reporting_service.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.Model
{
    public class WeatherData
    {
        public string Location { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        private readonly List<IBot> _observers = new List<IBot>();

        public void RegisterObserver(IBot bot)
        {
            _observers.Add(bot);
        }

        public void RemoveObserver(IBot bot)
        {
            _observers.Remove(bot);
        }

        public void NotifyObservers()
        {
            bool anyBotActivated = false;

            foreach (var observer in _observers)
            {
                if (observer.Activate(this))
                {
                    anyBotActivated = true;
                }
            }

            if (!anyBotActivated)
            {
                Console.WriteLine("No bots were activated for the given weather data.");
            }
        }

        public void SetWeatherData(string location, double temperature, double humidity)
        {
            Location = location;
            Temperature = temperature;
            Humidity = humidity;

            NotifyObservers();
        }
    }
}
