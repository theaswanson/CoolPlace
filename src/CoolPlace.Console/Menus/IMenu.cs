namespace CoolPlace.Console.Menus
{
    public interface IMenu<T> where T : Enum
    {
        /// <summary>
        /// Get a selected menu option from the user.
        /// </summary>
        T Choose();
        /// <summary>
        /// Prints the available menu options.
        /// </summary>
        void PrintOptions();
    }
}