using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Telegram.Services
{
    internal class UpdateHandler : IUpdateHandler
    {
        private readonly MessageHandler _messageHandler;

        public UpdateHandler(MessageHandler messageHandler)
        {
            _messageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) => throw new NotImplementedException();

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //switch (update.Type)
            //{
            //    case UpdateType.Message:
            //        await _messageHandler.HandleMessage(update.Message);
            //        break;
            //}


        }
    }
}
