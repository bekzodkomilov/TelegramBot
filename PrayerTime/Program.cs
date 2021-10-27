using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrayerTime.Services;
using Telegram.Bot;

namespace PrayerTime
{
    class Program
    {
        static Task Main(string[] args)
            => CreateHostBuilder(args)
            .Build()
            .RunAsync();
        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices(Configure);
        private static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<TelegramBotClient>(b => new TelegramBotClient("1961222925:AAGL2i3ORlv1ShAodMOdLSb85PHwsUW3hBs"));
            services.AddHostedService<Bot>();
            services.AddTransient<IStorageService, InternalStorageService>();
            services.AddTransient<TimingsByLLService>();
            services.AddTransient<Handlers>();
        }
    }
}