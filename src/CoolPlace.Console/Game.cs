using CoolPlace.Console.Menus;

namespace CoolPlace.Console
{
    public class Game
    {
        private readonly Menu<MainMenuOption> menu;

        public Game(Menu<MainMenuOption> menu)
        {
            this.menu = menu;
        }

        public void Start()
        {
            menu.PrintIntro();
            menu.PrintOptions();
            menu.Choose();
        }
    }
}
