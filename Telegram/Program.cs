using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.DbContexts;

namespace Telegram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            hostBuilder.ConfigureServices((hostBuilder, services) =>
                services.AddDbContext<TelegramDbContext>(options =>
                    options.UseSqlServer(hostBuilder.Configuration.GetConnectionString("TelegramDb"))));

            var host = hostBuilder.Build();

            await host.RunAsync();
        }
    }
}
