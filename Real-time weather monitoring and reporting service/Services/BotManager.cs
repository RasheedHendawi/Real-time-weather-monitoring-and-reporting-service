using Real_time_weather_monitoring_and_reporting_service.Bots;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;


namespace Real_time_weather_monitoring_and_reporting_service.Services
{
    public class BotManager
    {
        private readonly List<IBot> _bots;

        public BotManager(BotsConfig config)
        {
            _bots = new List<IBot>();
            BotConfig tempBot;
            if (config.RainBot.Enabled)
            {
                tempBot = config.RainBot;
                _bots.Add(new RainBot(tempBot));
            }
            if (config.SunBot.Enabled)
            {
                tempBot = config.SunBot;
                _bots.Add(new SunBot(tempBot));
            }

            if (config.SnowBot.Enabled)
            {
                tempBot = config.SnowBot;
                _bots.Add(new SnowBot(tempBot));
            }
        }
        public IEnumerable<IBot> GetBots() => _bots;
    }
}
