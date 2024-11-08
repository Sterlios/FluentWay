using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace Telegram.Services
{
    internal class ReceiverService<TUpdateHandler> where TUpdateHandler : IUpdateHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IUpdateHandler _updateHandler;
        private readonly ILogger<ReceiverService<TUpdateHandler>> _logger;

        public ReceiverService(
            ITelegramBotClient botClient,
            IUpdateHandler updateHandler,
            ILogger<ReceiverService<TUpdateHandler>> logger)
        {
            _botClient = botClient ?? throw new ArgumentNullException(nameof(botClient));
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task ReceiveAsync(CancellationToken stoppingToken)
        {
            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = [],
                DropPendingUpdates = true,
            };

            var me = await _botClient.GetMe(stoppingToken);
            _logger.LogInformation("Start receiving updates for {BotName}", me.Username ?? "My Awesome Bot");

            await _botClient.ReceiveAsync(
                updateHandler: _updateHandler,
                receiverOptions: receiverOptions,
                cancellationToken: stoppingToken);
        }
    }
}
