using System.Diagnostics.CodeAnalysis;

namespace CoolPlace.Tests
{
    [ExcludeFromCodeCoverage]
    public class TestEntity : Entity
    {
        private readonly IDamageHandler damageHandler;

        public TestEntity(IDamageHandler damageHandler)
        {
            this.damageHandler = damageHandler;
        }

        public override void Damage(int damageAmount)
        {
            damageHandler.Damage(this, damageAmount);
        }
    }
}