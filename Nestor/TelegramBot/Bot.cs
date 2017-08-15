using System.Threading.Tasks;
using Nestor.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Nestor.TelegramBot
{
	public class Bot : IBotProvider
	{
		private readonly IBotSettings _settings;
		private readonly ILogger _logger;
		private static TelegramBotClient _client;

		public Bot(IBotSettings settings, ILogger logger)
		{
			_settings = settings;
			_logger = logger;
			_client = new TelegramBotClient(_settings.ApiKey);

			InitiateBot();
			_client.StartReceiving();
		}

		// OK, DO WE NEED THIS FUNCTIONS AND COULD WE MAKE IT PRIVATE?
		public async Task<Message> SendMessage(long chatId, string text)
		{
			return await _client.SendTextMessageAsync(chatId, text);
		}

		public async Task<Message> SendLocation(long chatId, float latitude, float longitude)
		{
			return await _client.SendLocationAsync(chatId, latitude, longitude);
		} 

		private void InitiateBot()
		{
			_client.OnMessage += OnMessageReceived;
			_client.OnMessageEdited += OnMessageReceived;
			_client.OnReceiveError += OnReceiveError;
		}

		private void OnReceiveError(object sender, ReceiveErrorEventArgs e)
		{
			_logger.LogError(e.ApiRequestException.ToString());
		}

		private void OnMessageReceived(object sender, MessageEventArgs e)
		{
			//TODO: ADD MESSAGE TYPE SWITCH & ADMIN FUNCTIONS
			_logger.LogMessage($"[BOT IN]: {e.Message.From.Username}:{e.Message.Text}");
		}
	}
}
