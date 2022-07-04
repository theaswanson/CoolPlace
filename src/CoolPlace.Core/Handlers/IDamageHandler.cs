using CoolPlace.Core.Entities;

namespace CoolPlace.Core.Handlers
{
    public interface IDamageHandler
    {
        void Damage(Entity entity, int damageAmount);
    }
}