using CoolPlace.Core.Entities;

namespace CoolPlace.Core.Handlers
{
    public class DamageHandler : IDamageHandler
    {
        public void Damage(Entity entity, int damageAmount)
        {
            int damageDealt = Math.Min(entity.Health, damageAmount);
            entity.Health -= damageDealt;
        }
    }
}
