namespace CoolPlace.Core
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
