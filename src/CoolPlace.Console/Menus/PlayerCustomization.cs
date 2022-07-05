using CoolPlace.Console.Utilities;
using CoolPlace.Core.Entities;

namespace CoolPlace.Console.Menus
{
    public class PlayerCustomization : IPlayerCustomization
    {
        private readonly ICLI cli;
        private readonly IPlayerBuilder playerBuilder;

        public PlayerCustomization(ICLI cli, IPlayerBuilder playerBuilder)
        {
            this.cli = cli;
            this.playerBuilder = playerBuilder;
        }

        public Player Customize()
        {
            while (true)
            {
                var name = GetName();
                var confirmed = GetConfirmation(name);

                if (!confirmed)
                {
                    cli.WriteLine("Restarting player customization...");
                    continue;
                }

                cli.WriteLine();

                return playerBuilder
                    .WithName(name)
                    .Build();
            }
        }

        /// <summary>
        /// Prompts the user to confirm their choices until a valid confirmation is given.
        /// </summary>
        /// <param name="name">The chosen name.</param>
        /// <returns></returns>
        private bool GetConfirmation(string name)
        {
            var confirmedByDefault = false;
            cli.WriteLine($"Is the following information correct? ({(confirmedByDefault ? 'Y' : 'y')}/{(confirmedByDefault ? 'n' : 'N')})");
            cli.WriteLine($"Name: {name}");

            while (true)
            {
                var confirmation = cli.ReadString();
                if (string.IsNullOrWhiteSpace(confirmation))
                {
                    return confirmedByDefault;
                }
                else if (confirmation.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else if (confirmation.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                else
                {
                    cli.WriteLine("Oops, couldn't understand that. Please enter y or n:");
                    continue;
                }
            }
        }

        /// <summary>
        /// Prompts the user for a name until a valid one is provided.
        /// </summary>
        /// <returns></returns>
        private string GetName()
        {
            cli.WriteLine("Enter your name:");

            while (true)
            {
                var name = cli.ReadString();

                if (string.IsNullOrWhiteSpace(name))
                {
                    cli.WriteLine("That name is invalid! Try again.");
                    continue;
                }

                return name;
            }
        }
    }
}
