using CoolPlace.Core.Actions;
using CoolPlace.Core.Handlers;

namespace CoolPlace.Tests.Handlers
{
    public class TheDamageHandler
    {
        private DamageHandler damageHandler;

        [SetUp]
        public virtual void Setup()
        {
            damageHandler = new DamageHandler();
        }

        public class GivenSomethingToDamage : TheDamageHandler
        {
            protected Mock<IDamageable> entity;
            public override void Setup()
            {
                base.Setup();
                entity = new Mock<IDamageable>();
                entity.SetupAllProperties();
                entity.Object.Health = 10;
            }

            [Test]
            public void CanDamage()
            {
                damageHandler.Damage(entity.Object, 1);
                Assert.That(entity.Object.Health, Is.EqualTo(9));
            }

            [Test]
            public void WhenDamageIsGreaterThanRemainingHealth_SetsHealthToZero()
            {
                damageHandler.Damage(entity.Object, 100);
                Assert.That(entity.Object.Health, Is.EqualTo(0));
            }
        }
    }
}