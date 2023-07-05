using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TelegramSink.TelegramBotClient.Domain;


namespace TelegramSink.TelegramBotClient
{
    public class Bot
    {
        private readonly BotConfiguration _botConfiguration;
        private const string TelegramApiBaseUrl = "https://api.telegram.org";

        public Bot(BotConfiguration botConfiguration)
        {
            _botConfiguration = botConfiguration;
        }

        public async Task<RestResult> SendMessage(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{TelegramApiBaseUrl}/bot{_botConfiguration.ApiKey}/sendMessage";
                var parameters = new
                    {
                        chat_id = _botConfiguration.ChatId,
                        text = message
                    };
                var response = await client.PostAsJsonAsync(apiUrl, parameters);
                var result = await response.Content.ReadFromJsonAsync<RestResult>();
                return result;
            }
        }
    }

    public class RestResult
    {
		public bool Ok { get; set; }
        public Message Result { get; set; }
	}
}
