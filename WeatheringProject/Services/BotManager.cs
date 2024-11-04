using Real_time_weather_monitoring_and_reporting_service.Bots;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;


namespace Real_time_weather_monitoring_and_reporting_service.Services
{
    public class BotManager
    {
        private readonly List<IBot> _bots;

        public BotManager(BotsConfig? config)
        {
            if (config == null)
            {
                Console.WriteLine("Config is null in BotManager");
                throw new ArgumentNullException(nameof(config));
            }

            _bots = [];
            var botConfigs = new List<(Bot? Config, Func<Bot, IBot> CreateBot)>
            {
            (config.RainBot, tmp => new RainBot(tmp)),

            (config.SunBot, tmp => new SunBot(tmp)),

            (config.SnowBot, tmp => new SnowBot(tmp))
            };

            foreach (var (bot, createBot) in botConfigs)
            {
                if (bot != null && bot.Enabled)
                {
                    _bots.Add(createBot(bot));
                }
            }
        }

        public IEnumerable<IBot> GetBots() => _bots;
    }

}
