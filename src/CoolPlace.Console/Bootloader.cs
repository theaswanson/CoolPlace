namespace CoolPlace.Console
{
    public class Bootloader
    {
        private readonly Game game;

        public Bootloader(Game game)
        {
            this.game = game;
        }

        public void Start()
        {
            game.Boot();
        }
    }
}
