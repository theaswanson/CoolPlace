using CoolPlace.Core.Actions;
using CoolPlace.Core.Entities;
using CoolPlace.Core.Events;

namespace CoolPlace.Tests.Entities
{
    public class TheFight
    {
        private Mock<IFighter> attacker;
        private Mock<IFighter> defender;
        private Fight fight;

        [SetUp]
        public virtual void Setup()
        {
            attacker = new Mock<IFighter>();
            attacker.SetupAllProperties();

            defender = new Mock<IFighter>();
            defender.SetupAllProperties();

            fight = new Fight(attacker.Object, defender.Object);
        }

        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void GivenOneOfTheFightersIsNotAlive_FightIsFinished(bool attackerIsAlive, bool defenderIsAlive)
        {
            attacker.Setup(a => a.IsAlive).Returns(attackerIsAlive);
            defender.Setup(a => a.IsAlive).Returns(defenderIsAlive);
            fight.NextTurn();
            Assert.That(fight.HasFinished(), Is.True);
        }

        [Test]
        public void AttackerWinsAfterOneTurn()
        {
            SetupFighter(attacker, 1, 20);
            SetupFighter(defender, 1, 0);

            fight.NextTurn();
            Assert.That(fight.HasFinished(), Is.True);
        }

        [Test]
        public void AttackerWinsAfterTwoTurns()
        {
            SetupFighter(attacker, 5, 2);
            SetupFighter(defender, 3, 1);

            fight.NextTurn();
            Assert.Multiple(() =>
            {
                Assert.That(attacker.Object.Health, Is.EqualTo(4));
                Assert.That(defender.Object.Health, Is.EqualTo(1));
                Assert.That(fight.HasFinished(), Is.False);
            });

            fight.NextTurn();
            Assert.Multiple(() =>
            {
                Assert.That(attacker.Object.Health, Is.EqualTo(4));
                Assert.That(fight.HasFinished(), Is.True);
            });
        }

        [Test]
        public void DefenderWinsAfterOneTurn()
        {
            SetupFighter(attacker, 1, 0);
            SetupFighter(defender, 1, 20);

            fight.NextTurn();
            Assert.Multiple(() =>
            {
                Assert.That(attacker.Object.IsAlive, Is.False);
                Assert.That(defender.Object.Health, Is.EqualTo(1));
                Assert.That(fight.HasFinished(), Is.True);
            });
        }

        private static void SetupFighter(Mock<IFighter> fighter, int health, int damageAmount)
        {
            fighter.Object.Health = health;
            fighter.Object.DamageAmount = damageAmount;
            fighter.Setup(a => a.IsAlive).Returns(() => fighter.Object.Health > 0);
            fighter.Setup(a => a.Attack(It.IsAny<IDamageable>())).Callback<IDamageable>(d => d.Health -= fighter.Object.DamageAmount);
        }
    }
}