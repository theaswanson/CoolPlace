namespace CoolPlace.Core.Entities
{
    public interface IEnemyBuilder
    {
        Enemy Build();
        EnemyBuilder WithDamageAmount(int damageAmount);
        EnemyBuilder WithHealth(int health);
        EnemyBuilder WithName(string name);
    }
}