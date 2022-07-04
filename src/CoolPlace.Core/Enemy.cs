namespace CoolPlace.Core
{
    public class Enemy : Entity
    {
        public Enemy(IDamageHandler damageHandler) : base(damageHandler)
        {
            Name = "Enemy";
        }
    }
}