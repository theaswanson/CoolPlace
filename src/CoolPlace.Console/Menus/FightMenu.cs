using CoolPlace.Console.Utilities;
using CoolPlace.Core.Options;

namespace CoolPlace.Console.Menus
{
    public class FightMenu : Menu<FightOption>
    {
        public FightMenu(ICLI cli) : base(cli)
        {
        }

        protected override string GetIntro() => "Choose your action!";

        protected override IEnumerable<MenuOption<FightOption>> GetMenuOptions()
        {
            return new List<MenuOption<FightOption>>
            {
                new MenuOption<FightOption>(FightOption.DoNothing, "Do Nothing"),
                new MenuOption<FightOption>(FightOption.Attack),
            };
        }
    }
}
