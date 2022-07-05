using CoolPlace.Console.Menus;
using CoolPlace.Console.Utilities;
using CoolPlace.Core.Entities;
using CoolPlace.Core.Events;
using CoolPlace.Core.Options;

namespace CoolPlace.Console
{
    public class FightCoordinator
    {
        private readonly ICLI cli;
        private readonly Menu<FightOption> fightMenu;

        public FightCoordinator(ICLI cli, Menu<FightOption> fightMenu)
        {
            this.cli = cli;
            this.fightMenu = fightMenu;
        }

        public void Start(IPlayer player, IEnemy enemy)
        {
            PrintIntro(enemy);

            var fight = new Fight(player, enemy);

            while (!fight.HasFinished())
            {
                PrintFightStats(player, enemy);

                fightMenu.PrintIntro();
                fightMenu.PrintOptions();

                var choice = fightMenu.Choose();

                switch (choice)
                {
                    case FightOption.DoNothing:
                        NextTurn(fight, player, enemy, skipPlayer: true);
                        break;
                    case FightOption.Attack:
                        NextTurn(fight, player, enemy);
                        break;
                    default:
                        throw new Exception($"Unknown {nameof(FightOption)}");
                }

                cli.WriteLine();
            }

            PrintOutro(player, enemy);
        }

        private void NextTurn(Fight fight, IPlayer player, IEnemy enemy, bool skipPlayer = false)
        {
            var startingPlayerHealth = player.Health;
            var startingEnemyHealth = enemy.Health;

            fight.NextTurn(skipAttacker: skipPlayer);

            var playerActionMessage = skipPlayer
                ? $"{player.Name} does nothing!"
                : $"{player.Name} slashes {enemy.Name}, dealing {startingEnemyHealth - enemy.Health} damage!";

            var enemyActionMessage = $"{enemy.Name} punches {player.Name}, dealing {startingPlayerHealth - player.Health} damage.";

            cli.WriteLine(playerActionMessage);
            cli.WriteLine(enemyActionMessage);
        }

        private void PrintFightStats(IPlayer player, IEnemy enemy)
        {
            cli.WriteLine($"{player.Name} / HP: {player.Health}");
            cli.WriteLine($"{enemy.Name} / HP: {enemy.Health}");
        }

        private void PrintIntro(IEnemy enemy)
        {
            cli.WriteLine("A new enemy approaches...");
            cli.WriteLine($"...it's {enemy.Name}!");
            cli.WriteLine();
        }

        private void PrintOutro(IPlayer player, IEnemy enemy)
        {
            var finalMessage = player.IsAlive
                ? $"You defeated {enemy.Name}!"
                : $"You were defeated by {enemy.Name}!";
            cli.WriteLine(finalMessage);
            cli.WriteLine();
        }
    }
}
