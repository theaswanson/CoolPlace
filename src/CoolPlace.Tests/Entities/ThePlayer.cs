using CoolPlace.Core.Actions;
using CoolPlace.Core.Entities;
using CoolPlace.Core.Handlers;

namespace CoolPlace.Tests.Entities
{
    public class ThePlayer
    {
        private Mock<IDamageHandler> damageHandler;
        private Player player;

        [SetUp]
        public virtual void Setup()
        {
            damageHandler = new Mock<IDamageHandler>();
            player = new Player(damageHandler.Object);
        }

        public class IsAlive : ThePlayer
        {
            [TestCase(0)]
            [TestCase(-1)]
            public void WhenHealthIsZeroOrLess_ReturnsFalse(int health)
            {
                player.Health = health;
                Assert.That(player.IsAlive, Is.EqualTo(false));
            }

            [Test]
            public void WhenHealthIsGreaterThanZero_ReturnsTrue()
            {
                player.Health = 1;
                Assert.That(player.IsAlive, Is.EqualTo(true));
            }
        }

        public class WhenAttacking : ThePlayer
        {
            [Test]
            public void EntityIsDamaged()
            {
                var entity = new Mock<IDamageable>();
                player.Attack(entity.Object);
                entity.Verify(e => e.Damage(10), Times.Once);
            }
        }

        public class WhenDamaged : ThePlayer
        {
            [Test]
            public void CallsTheDamageHandler()
            {
                player.Damage(1);
                damageHandler.Verify(dh => dh.Damage(player, 1), Times.Once);
            }
        }
    }
}