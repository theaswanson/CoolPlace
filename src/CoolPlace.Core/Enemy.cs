namespace CoolPlace.Core
{
    /// <summary>
    /// A hostile character to a <see cref="Player" />.
    /// </summary>
    public class Enemy : Entity, ICanAttack
    {
        private readonly IDamageHandler damageHandler;
        private const int DamageAmount = 1;

        public Enemy(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
            Name = "Enemy";
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