using System.Net.Http;
using System.Threading.Tasks;
using Nestor.Contracts;
using Nestor.Contracts.Settings;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;

namespace Nestor
{
	internal class TelegramBot : IBotProvider
	{
		private static TelegramBotClient _client;
		private readonly IBotSettings _settings;
		private readonly ILogger _logger;

		public TelegramBot(IBotSettings settings, HttpClient client, ILogger logger)
		{
			_settings = settings;
			_logger = logger;
			_client = new TelegramBotClient(_settings.ApiKey, client);

			InitiateBot();
			_client.StartReceiving();
		}

		public async Task SendImage(string uri, string caption)
		{
			await _client.SendPhotoAsync(_settings.ChatId, new InputOnlineFile(uri), caption);
		}

		public async Task SendLocation(float latitude, float longitude)
		{
			await _client.SendLocationAsync(_settings.ChatId, latitude, longitude);
		}

		public async Task SendMessage(string text)
		{
			await _client.SendTextMessageAsync(_settings.ChatId, text);
		}

		private void InitiateBot()
		{
			_client.OnReceiveError += OnReceiveError;
			_client.OnMessage += OnReceiveMessage;
		}

		private void OnReceiveError(object sender, ReceiveErrorEventArgs e)
		{
			_logger.Error(e.ApiRequestException, "Telegram API Exception");
		}

		private void OnReceiveMessage(object sender, MessageEventArgs e)
		{
			_logger.Information($"{e.Message.Chat.Username}:{e.Message.Chat.Id}");
		}
	}
}