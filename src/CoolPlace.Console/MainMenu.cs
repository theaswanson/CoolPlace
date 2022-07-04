using Figgle;

namespace CoolPlace.Console
{
    public class MainMenu : Menu<MainMenuOption>
    {
        public MainMenu(ICLI cli) : base(cli)
        {
            menuOptions = new List<MenuOption<MainMenuOption>>
            {
                new (MainMenuOption.Quit),
                new (MainMenuOption.StartGame, "Start Game"),
            };
        }

        protected override string GetIntro() => FiggleFonts.SubZero.Render("Cool Place");

        public override void Choose(MainMenuOption option)
        {
            switch (option)
            {
                case MainMenuOption.Quit:
                    break;
                case MainMenuOption.StartGame:
                    break;
                default:
                    break;
            }
        }
    }
}