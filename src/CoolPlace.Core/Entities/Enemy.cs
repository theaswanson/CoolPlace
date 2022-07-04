using CoolPlace.Core.Actions;
using CoolPlace.Core.Handlers;

namespace CoolPlace.Core.Entities
{
    /// <summary>
    /// A hostile character to a <see cref="Player" />.
    /// </summary>
    public class Enemy : IEnemy
    {
        private readonly IDamageHandler damageHandler;

        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive { get => Health > 0; }
        public int DamageAmount { get; set; }

        public Enemy(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
            Name = "Enemy";
            DamageAmount = 1;
        }

        public void Attack(IDamageable entity)
        {
            entity.Damage(DamageAmount);
        }

        public void Damage(int damageAmount)
        {
            damageHandler.Damage(this, damageAmount);
        }
    }
}