using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.DbContexts;
using Telegram.Repositories;
using Telegram.Services;

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

                services.AddDbContext<TelegramDbContext>(options =>
                    options.UseSqlServer(hostBuilder.Configuration.GetConnectionString("TelegramDb")));

                services
                    .AddHttpClient("telegram_bot_client")
                    .RemoveAllLoggers()
                    .AddTypedClient((httpClient, serviceProvider) => CreateBot(httpClient, serviceProvider));

                services
                    .AddScoped<IUpdateHandler, UpdateHandler>()
                    .AddScoped<UserService>()
                    .AddScoped<UserRepository>()
                    .AddScoped<ReceiverService<UpdateHandler>>();
            });

            var host = hostBuilder.Build();

            await host.Services
                .GetService<ReceiverService<UpdateHandler>>()
                .ReceiveAsync(default);
        }

        private static ITelegramBotClient CreateBot(HttpClient httpClient, IServiceProvider serviceProvider)
        {
            BotConfiguration? botConfiguration = serviceProvider.GetService<IOptions<BotConfiguration>>()?.Value;

            ArgumentNullException.ThrowIfNull(botConfiguration);

            var token = botConfiguration.Token;

            TelegramBotClientOptions options = new(botConfiguration.Token);

            return new TelegramBotClient(options, httpClient);
        }
    }
}
