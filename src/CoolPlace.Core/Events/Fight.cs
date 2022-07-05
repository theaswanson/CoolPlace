using CoolPlace.Core.Entities;

namespace CoolPlace.Core.Events
{
    public class Fight
    {
        public Fight(IFighter attacker, IFighter defender)
        {
            this.attacker = attacker;
            this.defender = defender;
            _finished = !attacker.IsAlive || !defender.IsAlive;
        }

        private bool _finished;
        private readonly IFighter attacker;
        private readonly IFighter defender;

        public bool HasFinished()
        {
            return _finished;
        }

        public void NextTurn(bool skipAttacker = false)
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

            if (!skipAttacker)
            {
                attacker.Attack(defender);
                if (!defender.IsAlive)
                {
                    Finish();
                    return;
                }
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
