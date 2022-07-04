namespace CoolPlace.Console
{
    public interface IMenu<T> where T : Enum
    {
        /// <summary>
        /// Selects the given menu option.
        /// </summary>
        public void Choose(T option);
        /// <summary>
        /// Prints the available menu options.
        /// </summary>
        void PrintOptions();
    }
}