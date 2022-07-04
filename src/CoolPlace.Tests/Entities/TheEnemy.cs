using CoolPlace.Core.Actions;
using CoolPlace.Core.Entities;
using CoolPlace.Core.Handlers;

namespace CoolPlace.Tests.Entities
{
    public class TheEnemy
    {
        private Mock<IDamageHandler> damageHandler;
        private Enemy enemy;

        [SetUp]
        public virtual void Setup()
        {
            damageHandler = new Mock<IDamageHandler>();
            enemy = new Enemy(damageHandler.Object);
        }

        public class IsAlive : TheEnemy
        {
            [TestCase(0)]
            [TestCase(-1)]
            public void WhenHealthIsZeroOrLess_ReturnsTrue(int health)
            {
                enemy.Health = health;
                Assert.That(enemy.IsAlive, Is.EqualTo(false));
            }

            [Test]
            public void WhenHealthIsGreaterThanZero_ReturnsTrue()
            {
                enemy.Health = 1;
                Assert.That(enemy.IsAlive, Is.EqualTo(true));
            }
        }

        public class WhenAttacking : TheEnemy
        {
            [Test]
            public void EntityIsDamaged()
            {
                var entity = new Mock<IDamageable>();
                enemy.Attack(entity.Object);
                entity.Verify(e => e.Damage(1), Times.Once);
            }
        }

        public class WhenDamaged : TheEnemy
        {
            [Test]
            public void CallsTheDamageHandler()
            {
                enemy.Damage(1);
                damageHandler.Verify(dh => dh.Damage(enemy, 1), Times.Once);
            }
        }
    }
}