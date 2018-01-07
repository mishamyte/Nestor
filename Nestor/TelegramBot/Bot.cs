using System;
using System.Threading.Tasks;
using Nestor.Logging;
using Nestor.Settings;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Nestor.TelegramBot
{
	internal class Bot : IBotProvider
	{
		private static TelegramBotClient _client;
		private readonly IBotSettings _settings;

		internal Bot(IBotSettings settings)
		{
			_settings = settings;
			_client = new TelegramBotClient(_settings.ApiKey);

			InitiateBot();
			_client.StartReceiving();
		}

		public async Task SendImage(Uri uri, string caption = "")
		{
			await _client.SendPhotoAsync(_settings.ChatId, new FileToSend(uri), caption);
		}

		public async Task SendLocation(float latitude, float longitude)
		{
			await _client.SendLocationAsync(_settings.ChatId, latitude, longitude);
		}

		public async Task SendMessage(string text)
		{
			await _client.SendTextMessageAsync(_settings.ChatId, text);
		}
		private static void InitiateBot()
		{
			_client.OnReceiveError += OnReceiveError;
			_client.OnMessage += OnReceiveMessage;
		}

		private static void OnReceiveError(object sender, ReceiveErrorEventArgs e)
		{
			Logger.LogError(e.ApiRequestException.ToString());
		}

		private static void OnReceiveMessage(object sender, MessageEventArgs e)
		{
			Logger.LogMessage($"{e.Message.Chat.Username}:{e.Message.Chat.Id}");
		}
	}
}
