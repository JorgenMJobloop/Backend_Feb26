public static class Combat
{
    public static (bool hit, bool crit, double damage) ResolveAttack(Random rng, int accuracy, int critChance, double baseDamage)
    {
        int roll = rng.Next(1, 101);
        if (roll > accuracy)
        {
            return (hit: false, crit: false, damage: 0);
        }

        bool crit = rng.Next(1, 101) <= critChance;
        double dmg = baseDamage * (crit ? 2.0 : 1.0);

        dmg *= 0.9 + rng.NextDouble() * 0.2;
        return (hit: true, crit, damage: Math.Round(dmg, 1));
    }
}