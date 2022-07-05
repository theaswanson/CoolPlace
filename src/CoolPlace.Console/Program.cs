using CoolPlace.Console.Menus;
using CoolPlace.Console.Utilities;
using CoolPlace.Core.Entities;
using CoolPlace.Core.Handlers;
using CoolPlace.Core.Options;
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

        static void StartGame(IServiceProvider serviceProvider) => serviceProvider.GetService<Bootloader>()!.Start();

        static void RegisterServices(HostBuilderContext _, IServiceCollection services)
        {
            services
                .AddSingleton<ICLI, CLI>()
                .AddSingleton<Game>()
                .AddSingleton<IPlayerCustomization, PlayerCustomization>()
                .AddSingleton<IPlayerBuilder, PlayerBuilder>()
                .AddSingleton<IEnemyBuilder, EnemyBuilder>()
                .AddSingleton<IDamageHandler, DamageHandler>()
                .AddSingleton<FightCoordinator>()
                .AddSingleton<Menu<MainMenuOption>, MainMenu>()
                .AddSingleton<Menu<FightOption>, FightMenu>()
                .AddSingleton<Bootloader>();
        }
    }
}