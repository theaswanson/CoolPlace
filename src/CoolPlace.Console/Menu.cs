namespace CoolPlace.Console
{
    public abstract class Menu<T> : IMenu<T> where T : Enum
    {
        protected readonly ICLI cli;
        protected IEnumerable<MenuOption<T>> menuOptions;

        public Menu(ICLI cli)
        {
            this.cli = cli;
            menuOptions = new List<MenuOption<T>>();
        }

        /// <summary>
        /// Select a menu option from user input.
        /// </summary>
        public void Choose()
        {
            var option = GetOption();
            Choose(option);
        }

        public abstract void Choose(T option);

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
        /// Prompts the user to make a menu selection until a valid one is chosen.
        /// </summary>
        /// <returns></returns>
        private T GetOption()
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

                return option;
            }
        }
    }
}