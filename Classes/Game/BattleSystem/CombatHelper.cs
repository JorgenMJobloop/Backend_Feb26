public static class CombatHelper
{
    public static (bool isHit, bool crit, double damage) ResolveAttacks(Random rng, int accuracy, int critChance, double baseDamage)
    {
        int hitRolled = rng.Next(1, 101);
        if (hitRolled > accuracy)
        {
            return (false, false, 0);
        }
        bool crit = rng.Next(1, 101) <= critChance;

        double dmg = baseDamage * (crit ? 2.0 : 1.0);
        dmg *= 0.9 + rng.NextDouble() * 0.2;

        return (true, crit, Math.Round(dmg, 1));
    }
}