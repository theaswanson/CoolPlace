using CoolPlace.Core.Actions;
using CoolPlace.Core.Entities;
using CoolPlace.Core.Handlers;
using Moq;

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