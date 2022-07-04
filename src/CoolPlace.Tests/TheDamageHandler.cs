namespace CoolPlace.Tests
{
    public class TheDamageHandler
    {
        private DamageHandler damageHandler;

        [SetUp]
        public virtual void Setup()
        {
            damageHandler = new DamageHandler();
        }

        public class GivenAnEntity : TheDamageHandler
        {
            protected Entity entity;
            public override void Setup()
            {
                base.Setup();
                entity = BuildEntity(10);
            }

            [Test]
            public void CanDamage()
            {
                damageHandler.Damage(entity, 1);
                Assert.That(entity.Health, Is.EqualTo(9));
            }

            [Test]
            public void WhenDamageIsGreaterThanRemainingHealth_SetsHealthToZero()
            {
                damageHandler.Damage(entity, 100);
                Assert.That(entity.Health, Is.EqualTo(0));
            }
        }

        private TestEntity BuildEntity(int health = 10)
            => new(damageHandler)
            {
                Health = health
            };
    }
}