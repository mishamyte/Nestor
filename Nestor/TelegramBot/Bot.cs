﻿using System.Threading.Tasks;
using Nestor.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Args;

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

		private void InitiateBot()
		{
			_client.OnReceiveError += OnReceiveError;
		}

		private void OnReceiveError(object sender, ReceiveErrorEventArgs e)
		{
			_logger.LogError(e.ApiRequestException.ToString());
		}
	}
}
