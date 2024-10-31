using Microsoft.Extensions.Hosting;

namespace Telegram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

            var host = hostBuilder.Build();

            await host.RunAsync();
        }
    }
}
