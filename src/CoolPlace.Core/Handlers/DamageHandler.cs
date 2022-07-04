using CoolPlace.Core.Actions;

namespace CoolPlace.Core.Handlers
{
    public class DamageHandler : IDamageHandler
    {
        public void Damage(IDamageable entity, int damageAmount)
        {
            int damageDealt = Math.Min(entity.Health, damageAmount);
            entity.Health -= damageDealt;
        }
    }
}
