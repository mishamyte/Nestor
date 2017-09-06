using System;
using System.Threading.Tasks;
using Nestor.Interfaces;
using Nestor.Interfaces.Settings;
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

		public async Task SendMessage(string text)
		{
			await _client.SendTextMessageAsync(_settings.ChatId, text);
		}

		public async Task SendLocation(float latitude, float longitude)
		{
			await _client.SendLocationAsync(_settings.ChatId, latitude, longitude);
		}

		public async Task SendImage(Uri uri, string caption = "")
		{
			await _client.SendPhotoAsync(_settings.ChatId, new FileToSend(uri), caption);
		} 

		private void InitiateBot()
		{
			_client.OnReceiveError += OnReceiveError;
			_client.OnMessage += OnReceiveMessage;
		}

		private void OnReceiveError(object sender, ReceiveErrorEventArgs e)
		{
			_logger.LogError(e.ApiRequestException.ToString());
		}

		private void OnReceiveMessage(object sender, MessageEventArgs e)
		{
			_logger.LogMessage($"{e.Message.Chat.Username}:{e.Message.Chat.Id}");
		}
	}
}
