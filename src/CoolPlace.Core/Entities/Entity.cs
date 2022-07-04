using CoolPlace.Core.Actions;

namespace CoolPlace.Core.Entities
{
    /// <summary>
    /// An object with health.
    /// </summary>
    public abstract class Entity : IDamageable
    {
        public Entity()
        {
            Name = "Entity";
            Health = 10;
        }

        public string Name { get; set; }
        public int Health { get; set; }

        public abstract void Damage(int damageAmount);
    }
}