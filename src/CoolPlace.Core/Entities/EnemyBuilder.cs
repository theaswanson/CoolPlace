using CoolPlace.Core.Handlers;

namespace CoolPlace.Core.Entities
{
    public class EnemyBuilder : IEnemyBuilder
    {
        private string? _name;
        private int? _health;
        private int? _damageAmount;
        private readonly IDamageHandler damageHandler;

        public EnemyBuilder(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
        }

        public EnemyBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public EnemyBuilder WithHealth(int health)
        {
            _health = health;
            return this;
        }

        public EnemyBuilder WithDamageAmount(int damageAmount)
        {
            _damageAmount = damageAmount;
            return this;
        }

        public Enemy Build()
        {
            var enemy = new Enemy(damageHandler);

            if (_name != null)
            {
                enemy.Name = _name;
            }

            if (_health.HasValue)
            {
                enemy.Health = _health.Value;
            }

            if (_damageAmount.HasValue)
            {
                enemy.DamageAmount = _damageAmount.Value;
            }

            return enemy;
        }
    }
}
