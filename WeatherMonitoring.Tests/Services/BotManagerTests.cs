using Real_time_weather_monitoring_and_reporting_service.Services;
using Real_time_weather_monitoring_and_reporting_service.Model;
using Real_time_weather_monitoring_and_reporting_service.Bots;

namespace WeatherMonitoring.Tests.Services
{
    public class BotManagerTests
    {
        [Fact]
        public void BotManager_ShouldCreateEnabledBots()
        {
            var botsConfig = new BotConfig
            {
                RainBot = new Bot
                {
                    Enabled = true,
                    HumidityThreshold = 70,
                    Message = "Rain is coming!"
                },
                SunBot = new Bot
                {
                    Enabled = false,
                    TemperatureThreshold = 30,
                    Message = "It's hot!"
                },
                SnowBot = new Bot
                {
                    Enabled = true,
                    TemperatureThreshold = 0,
                    Message = "Snow is coming!"
                }
            };

            var botManager = new BotManager(botsConfig);
            var bots = botManager.GetBots();

            Assert.Collection(bots,
                bot => Assert.IsType<RainBot>(bot),
                bot => Assert.IsType<SnowBot>(bot)
            );
        }
        [Fact]
        public void BotManager_ShouldNotCreateBots_WhenAllDisabled()
        {
            var botsConfig = new BotConfig
            {
                RainBot = new Bot
                {
                    Enabled = false,
                    HumidityThreshold = 70,
                    Message = "Rain is coming!"
                },
                SunBot = new Bot
                {
                    Enabled = false,
                    TemperatureThreshold = 30,
                    Message = "It's hot!"
                },
                SnowBot = new Bot
                {
                    Enabled = false,
                    TemperatureThreshold = 0,
                    Message = "Snow is coming!"
                }
            };

            var botManager = new BotManager(botsConfig);
            var bots = botManager.GetBots();

            Assert.Empty(bots);
        }
        [Fact]
        public void BotManager_ShouldHandleNullBotConfigurations()
        {
            var botsConfig = new BotConfig
            {
                RainBot = null,
                SunBot = new Bot
                {
                    Enabled = true,
                    TemperatureThreshold = 30,
                    Message = "Wow, it's a scorcher out there!"
                },
                SnowBot = null
            };

            var botManager = new BotManager(botsConfig);
            var bots = botManager.GetBots();

            Assert.Single(bots);
        }
        [Fact]
        public void BotManager_ShouldThrowException_WhenBotsConfigIsNull()
        {
            var exception = Record.Exception(() => new BotManager(null));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}
