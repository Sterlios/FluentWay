using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace Telegram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            hostBuilder.ConfigureServices((hostBuilder, services) =>
            {
                services.Configure<BotConfiguration>(hostBuilder.Configuration.GetSection("BotConfiguration"));
                services.AddHttpClient("telegram_bot_client").RemoveAllLoggers()
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    BotConfiguration? botConfiguration = sp.GetService<IOptions<BotConfiguration>>()?.Value;
                    ArgumentNullException.ThrowIfNull(botConfiguration);
                    TelegramBotClientOptions options = new(botConfiguration.BotToken);
                    return new TelegramBotClient(options, httpClient);
                });
                services.AddDbContext<UserContext>();
                services.AddSingleton<ITelegramBotClient>();
            });

            var host = hostBuilder.Build();

            await host.RunAsync();
        }
    }
}
