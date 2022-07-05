using CoolPlace.Console.Utilities;
using CoolPlace.Core.Options;
using Figgle;

namespace CoolPlace.Console.Menus
{
    public class MainMenu : Menu<MainMenuOption>
    {
        public MainMenu(ICLI cli) : base(cli)
        {
        }

        protected override string GetIntro() => FiggleFonts.SubZero.Render("Cool Place");

        protected override IEnumerable<MenuOption<MainMenuOption>> GetMenuOptions()
        {
            return new List<MenuOption<MainMenuOption>>
            {
                new (MainMenuOption.Quit),
                new (MainMenuOption.StartGame, "Start Game"),
            };
        }
    }
}