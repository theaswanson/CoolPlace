namespace CoolPlace.Core
{
    public abstract class Entity : IDamageable
    {
        private readonly IDamageHandler damageHandler;

        public Entity(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
            Name = "Entity";
            Health = 10;
        }

        public string Name { get; set; }
        public int Health { get; set; }

        public void Damage(int damageAmount)
        {
            damageHandler.Damage(this, damageAmount);
        }
    }
}