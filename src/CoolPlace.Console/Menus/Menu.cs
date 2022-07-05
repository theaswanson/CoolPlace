using CoolPlace.Console.Utilities;

namespace CoolPlace.Console.Menus
{
    public abstract class Menu<T> : IMenu<T> where T : Enum
    {
        protected readonly ICLI cli;
        protected IEnumerable<MenuOption<T>> menuOptions;

        public Menu(ICLI cli)
        {
            this.cli = cli;
            menuOptions = GetMenuOptions();
        }

        /// <summary>
        /// Select a menu option from user input.
        /// </summary>
        public T Choose()
        {
            while (true)
            {
                var choice = cli.ReadInt();
                if (choice == null)
                {
                    cli.WriteLine("Enter an option number.");
                    continue;
                }

                var values = ((int[])Enum.GetValues(typeof(T))).ToList();
                if (!values.Contains(choice.Value))
                {
                    cli.WriteLine("Oops, didn't recognize that option. Try again.");
                    continue;
                }

                var option = (T)(object)choice;
                if (option == null)
                {
                    cli.WriteLine("There was a problem choosing that option. Try again.");
                    continue;
                }

                cli.WriteLine();

                return option;
            }
        }

        /// <summary>
        /// Prints the menu intro.
        /// </summary>
        public void PrintIntro()
        {
            cli.WriteLine(GetIntro());
        }

        public void PrintOptions()
        {
            foreach (var option in menuOptions)
            {
                cli.WriteLine(option);
            }
        }

        /// <summary>
        /// Returns the menu intro.
        /// </summary>
        protected abstract string GetIntro();

        /// <summary>
        /// Returns the available menu options;
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<MenuOption<T>> GetMenuOptions();
    }
}