using System.Text.Json.Serialization;

namespace TelegramSink.TelegramBotClient.Domain
{
    public class Message
	{
		[JsonPropertyName("message_id")]
		public string MessageId { get; set; }
		[JsonPropertyName("date")]
        public long Date { get; set; }
	}
}