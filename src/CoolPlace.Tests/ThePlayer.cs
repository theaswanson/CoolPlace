using Moq;

namespace CoolPlace.Tests
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