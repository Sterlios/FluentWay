using Telegram.Bot.Types;

namespace Telegram.Services
{
    internal class MessageHandler
    {
        private readonly UserService _userService;

        public MessageHandler(UserService userService) =>
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

        public async Task HandleMessage(Message message)
        {
            ArgumentNullException.ThrowIfNull(message);

            if (message.Text is not null)
                HandleText(message);
        }

        private void HandleText(Message message)
        {

        }
    }
}
