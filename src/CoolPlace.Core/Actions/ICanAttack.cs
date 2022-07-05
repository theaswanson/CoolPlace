namespace CoolPlace.Core.Actions
{
    public interface ICanAttack
    {
        void Attack(IDamageable entity);
        int DamageAmount { get; set; }
    }
}