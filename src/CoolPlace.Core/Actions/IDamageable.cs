namespace CoolPlace.Core.Actions
{
    public interface IDamageable
    {
        int Health { get; set; }
        bool IsAlive { get; }
        void Damage(int damageAmount);
    }
}
