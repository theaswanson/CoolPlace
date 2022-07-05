using CoolPlace.Core.Actions;

namespace CoolPlace.Core.Handlers
{
    public interface IDamageHandler
    {
        void Damage(IDamageable entity, int damageAmount);
    }
}