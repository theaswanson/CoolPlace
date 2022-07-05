using CoolPlace.Console.Menus;
using CoolPlace.Console.Utilities;
using CoolPlace.Core.Entities;
using CoolPlace.Core.Events;
using CoolPlace.Core.Options;

namespace CoolPlace.Console
{
    public class Game
    {
        private readonly Menu<MainMenuOption> mainMenu;
        private readonly IPlayerCustomization playerCustomization;
        private readonly IEnemyBuilder enemyBuilder;
        private readonly FightCoordinator fightCoordinator;
        private readonly ICLI cli;

        public Game(
            Menu<MainMenuOption> mainMenu,
            IPlayerCustomization playerCustomization,
            IEnemyBuilder enemyBuilder,
            FightCoordinator fightCoordinator,
            ICLI cli)
        {
            this.mainMenu = mainMenu;
            this.playerCustomization = playerCustomization;
            this.enemyBuilder = enemyBuilder;
            this.fightCoordinator = fightCoordinator;
            this.cli = cli;
        }

        public void Boot()
        {
            mainMenu.PrintIntro();
            mainMenu.PrintOptions();

            var choice = mainMenu.Choose();

            switch (choice)
            {
                case MainMenuOption.Quit:
                    return;
                case MainMenuOption.StartGame:
                    Start();
                    break;
                default:
                    throw new Exception("Unknown menu choice.");
            }
        }

        private void Start()
        {
            var player = playerCustomization.Customize();
            var enemies = new List<IEnemy>
            {
                enemyBuilder.WithName("Scrub").WithHealth(25).WithDamageAmount(5).Build(),
                enemyBuilder.WithName("Geralt").WithHealth(30).WithDamageAmount(7).Build(),
                enemyBuilder.WithName("Lord Crumb").WithHealth(50).WithDamageAmount(15).Build(),
            };

            FightEnemies(player, enemies);
            PrintResults(player);
        }

        private void FightEnemies(IPlayer player, IEnumerable<IEnemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                fightCoordinator.Start(player, enemy);
                if (!player.IsAlive)
                {
                    break;
                }
            }
        }

        private void PrintResults(IPlayer player)
        {
            var results = player.IsAlive
                ? "You defeated all the enemies in this Cool Place! Congrats!!!"
                : "Evil overcame good...this time. Pick yourself up and brush off those wounds. Go give it another go!";
            cli.WriteLine(results);
        }
    }
}
