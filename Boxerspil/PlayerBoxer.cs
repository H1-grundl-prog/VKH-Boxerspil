using System;

namespace Boxerspil
{
    public class PlayerBoxer : Boxer
    {
        public PlayerBoxer(string name) : base(name, 10)
        {
        }

        public override void MakeDecision(Boxer victim)
        {
            Attack attack = ChooseAttack();
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

        private Attack ChooseAttack()
        {
            int i = CLIUI.ChooseAttackMenu(Attacks);
            return Attacks[i];
        }
    }
}
