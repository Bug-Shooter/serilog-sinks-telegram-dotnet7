using System;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace TelegramSink
{
    public static class TeleSinkExtensions
    {
        public static LoggerConfiguration TeleSink(
            this LoggerSinkConfiguration config, 
            string telegramApiKey, 
            string telegramChatId, 
            IFormatProvider formatProvider = null, 
            LogEventLevel minimumLevel=LogEventLevel.Verbose)
        {
            return config.Sink(new TeleSink(formatProvider, telegramApiKey, telegramChatId, minimumLevel));
        }
    }
}
