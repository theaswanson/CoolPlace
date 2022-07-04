namespace CoolPlace.Core
{
    public class Player : Entity
    {
        private const int DamageAmount = 10;

        public Player(IDamageHandler damageHandler) : base(damageHandler)
        {
            Name = "Player";
            Health = 100;
        }

        public void Attack(IDamageable entity)
        {
            entity.Damage(DamageAmount);
        }
    }
}
