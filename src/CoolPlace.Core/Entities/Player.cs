using CoolPlace.Core.Actions;
using CoolPlace.Core.Handlers;

namespace CoolPlace.Core.Entities
{
    /// <summary>
    /// A gamer playing the game.
    /// </summary>
    public class Player : IPlayer
    {
        private readonly IDamageHandler damageHandler;

        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive { get => Health > 0; }
        public int DamageAmount { get; set; }

        public Player(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
            Name = "Player";
            Health = 100;
            DamageAmount = 10;
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
