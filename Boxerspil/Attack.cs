namespace Boxerspil
{
    public struct Attack
    {
        public string Name { get; }
        public int Damage { get; }
        public int HitChance { get; }

        public Attack(string name, int damage, int chance)
        {
            Name = name;
            Damage = damage;
            HitChance = chance;
        }
    }
}
