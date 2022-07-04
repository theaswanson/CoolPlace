using CoolPlace.Core.Actions;
using CoolPlace.Core.Handlers;

namespace CoolPlace.Core.Entities
{
    /// <summary>
    /// A gamer playing the game.
    /// </summary>
    public class Player : Entity, ICanAttack
    {
        private readonly IDamageHandler damageHandler;
        private const int DamageAmount = 10;

        public Player(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
            Name = "Player";
            Health = 100;
        }

        public void Attack(IDamageable entity)
        {
            entity.Damage(DamageAmount);
        }

        public override void Damage(int damageAmount)
        {
            damageHandler.Damage(this, damageAmount);
        }
    }
}
