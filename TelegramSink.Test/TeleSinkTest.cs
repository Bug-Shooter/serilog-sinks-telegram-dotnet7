using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Serilog;
using TelegramSink.TelegramBotClient;
using System;
using System.Threading.Tasks;

namespace TelegramSink.Test
{
    public class TeleSinkTest
    {
        private const string PrivateConfigFilePostfix = "private";

        private BotConfiguration LoadConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder()
				.SetBasePath($"{Directory.GetCurrentDirectory()}/Configuration")
                .AddJsonFile("TestConfig.json", optional:true, reloadOnChange:true)
                .AddJsonFile($"TestConfig_{PrivateConfigFilePostfix}.json", optional: false, reloadOnChange: true)
				.Build();

            return config.GetSection("Telegram").Get<BotConfiguration>();
        }

        [Fact]
        public void ConfigurationTest()
        {
            var botConfig = LoadConfiguration();
            var log = new LoggerConfiguration().MinimumLevel.Information().WriteTo.TeleSink(telegramApiKey:botConfig.ApiKey, telegramChatId:botConfig.ChatId).CreateLogger();
            Assert.NotNull(log);
        }

        [Fact]
        public void ShouldLogMessage()
        {
            var botConfig = LoadConfiguration();
			var log = new LoggerConfiguration().MinimumLevel.Information().WriteTo.TeleSink(telegramApiKey: botConfig.ApiKey, telegramChatId: botConfig.ChatId).CreateLogger();
            log.Information("Hello World!");
            Task.Delay(1000).Wait();
		}
    }
}
