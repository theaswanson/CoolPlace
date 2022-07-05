using CoolPlace.Core.Handlers;

namespace CoolPlace.Core.Entities
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private string? _name;
        private int? _health;
        private int? _damageAmount;
        private readonly IDamageHandler damageHandler;

        public PlayerBuilder(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
        }

        public PlayerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public PlayerBuilder WithHealth(int health)
        {
            _health = health;
            return this;
        }

        public PlayerBuilder WithDamageAmount(int damageAmount)
        {
            _damageAmount = damageAmount;
            return this;
        }

        public Player Build()
        {
            var player = new Player(damageHandler);

            if (_name != null)
            {
                player.Name = _name;
            }

            if (_health.HasValue)
            {
                player.Health = _health.Value;
            }

            if (_damageAmount.HasValue)
            {
                player.DamageAmount = _damageAmount.Value;
            }

            return player;
        }
    }
}
