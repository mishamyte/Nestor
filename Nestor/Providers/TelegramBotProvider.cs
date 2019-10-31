using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nestor.Core;
using Nestor.Core.Providers;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace Nestor.Providers
{
    public class TelegramBotProvider : IBotProvider, IDisposable
    {
        private readonly long _chatId;
        private readonly ITelegramBotClient _client;

        private bool _disposed;

        public TelegramBotProvider(ITelegramBotClient client, ILogger<TelegramBotProvider> logger, Settings settings)
        {
            _chatId = settings.Bot.ChatId;
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _client.OnReceiveError += (sender, args) =>
                logger?.LogError(args.ApiRequestException, "Telegram API exception");
            _client.StartReceiving();
        }

        public async Task SendImage(string uri, string caption)
        {
            await _client.SendPhotoAsync(_chatId, new InputOnlineFile(uri), caption);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            if (disposing) _client.StopReceiving();
        }
    }
}