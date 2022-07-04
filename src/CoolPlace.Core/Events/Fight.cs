using CoolPlace.Core.Entities;

namespace CoolPlace.Core.Events
{
    public class Fight
    {
        public Fight(IFighter attacker, IFighter defender)
        {
            this.attacker = attacker;
            this.defender = defender;
        }

        private bool _finished;
        private readonly IFighter attacker;
        private readonly IFighter defender;

        public bool HasFinished()
        {
            return _finished;
        }

        public void NextTurn()
        {
            if (_finished)
            {
                return;
            }

            if (!attacker.IsAlive || !defender.IsAlive)
            {
                Finish();
                return;
            }

            attacker.Attack(defender);
            if (!defender.IsAlive)
            {
                Finish();
                return;
            }

            defender.Attack(attacker);
            if (!attacker.IsAlive)
            {
                Finish();
                return;
            }
        }

        private void Finish()
        {
            _finished = true;
        }
    }
}
