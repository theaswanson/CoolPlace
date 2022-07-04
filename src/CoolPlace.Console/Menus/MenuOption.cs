namespace CoolPlace.Console.Menus
{
    public class MenuOption<T> where T : Enum
    {
        public string Name { get; set; }
        public T Action { get; set; }
        public override string ToString() => $"{(int)(object)Action}) {Name}";

        public MenuOption(T action)
        {
            Action = action;
            Name = action.ToString();
        }

        public MenuOption(T action, string name)
        {
            Action = action;
            Name = name;
        }
    }
}