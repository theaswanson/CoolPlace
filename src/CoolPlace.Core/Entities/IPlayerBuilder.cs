namespace CoolPlace.Core.Entities
{
    public interface IPlayerBuilder
    {
        Player Build();
        PlayerBuilder WithDamageAmount(int damageAmount);
        PlayerBuilder WithHealth(int health);
        PlayerBuilder WithName(string name);
    }
}