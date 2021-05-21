using System;
using System.Collections.Generic;

namespace Boxerspil
{
    public abstract class Boxer
    {
        public string Name { get; }
        public int Health { get; set; }
        public bool Dead { get; private set; }

        public int Victories { get; set; }

        public List<Attack> Attacks { get; } = new List<Attack>()
        {
            new Attack("Face punch", 2, 85),
            new Attack("Jawcracker", 6, 5),
            new Attack("Hook", 5, 75),
        };

        protected Random m_Random;

        private int m_StartingHealth;

        public Boxer(string name, int health)
        {
            Name = name;
            Health = health;
            Dead = false;

            m_StartingHealth = health;

            m_Random = new Random();
        }

        public abstract void MakeDecision(Boxer victim);

        public void Revive()
        {
            Health = m_StartingHealth;
            Dead = false;
        }

        public bool Attack(Attack attack)
        {
            int chance = m_Random.Next(100);
            bool hit = attack.HitChance > chance;
            if(hit)
            {
                Health -= attack.Damage;
                if (Health <= 0)
                {
                    Dead = true;
                }
            }
            return hit;
        }
    }
}
