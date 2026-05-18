namespace Attack
{
    public class AttackEventData
    {
        public Attacker Attacker { get; private set; }
        public EntityWithHealth Defender { get; private set; }
        public int Damage {  get; private set; }

        public AttackEventData(Attacker attacker, EntityWithHealth defender)
        {
            Damage = (attacker.AtkDamage - defender.Defense);
            this.Attacker = attacker;
            this.Defender = defender;
        }
    }
}