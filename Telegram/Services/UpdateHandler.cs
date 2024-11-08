using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Telegram.Services
{
    internal class UpdateHandler : IUpdateHandler
    {
        private readonly UserService _userService;
        private readonly ILogger<UpdateHandler> _logger;

        public UpdateHandler(ILogger<UpdateHandler> logger, UserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger.LogInformation("UpdateHandler Created");
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken) => throw new NotImplementedException();

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _logger.LogInformation(update.Message.Text);
        }
    }
}
