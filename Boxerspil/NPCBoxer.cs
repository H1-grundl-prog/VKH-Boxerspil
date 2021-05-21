using System;

namespace Boxerspil
{
    public class NPCBoxer : Boxer
    {
        public NPCBoxer(string name) : base(name, 10)
        { 
        }

        public override void MakeDecision(Boxer victim)
        {
            Attack attack = GetRandomAttack();
            bool hit = victim.Attack(attack);
            if (hit)
            {
                Console.WriteLine($"{Name} attacked {victim.Name} by using {attack.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} missed the attack on {victim.Name} using {attack.Name}");
            }
        }

        private Attack GetRandomAttack()
        {
            int i = m_Random.Next(0, Attacks.Count);
            Attack attack = Attacks[i];
            return attack;
        }
    }
}
