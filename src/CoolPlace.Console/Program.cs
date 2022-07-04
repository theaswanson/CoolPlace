using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoolPlace.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(RegisterServices)
                .Build();

            StartGame(host.Services);

            await host.StopAsync();
        }

        static void StartGame(IServiceProvider serviceProvider) => serviceProvider.GetService<Game>()!.Start();

        static void RegisterServices(HostBuilderContext _, IServiceCollection services)
        {
            services
                .AddSingleton<ICLI, CLI>()
                .AddSingleton<Menu<MainMenuOption>, MainMenu>()
                .AddSingleton<Game>();
        }
    }
}