public class NPC : IBattleSystem
{
    public string Name => TypeOfFoe;
    public string TypeOfFoe { get; set; } = string.Empty;
    public double HP { get; set; }
    public double Mana { get; set; }
    public double XPWhenDefeated { get; set; }
    public double BaseDamage { get; set; }
    public bool SpecialAttack { get; set; }
    public List<LootEntry> DropTable { get; } = new List<LootEntry>();
    public bool IsAlive => HP > 0;

    public void TakeDamage(double amount)
    {
        HP = Math.Max(0, HP - amount);
    }

    public double DealDamage(Random rng)
    {
        var rolledDamage = rng.Next(1, 101);

        if (rolledDamage <= 15)
        {
            return 0;
        }

        return Math.Round(BaseDamage, 1);
    }

    /// <summary>
    /// When an NPC is defeated, we roll it's drop table for a chance at different items as loot
    /// </summary>
    /// <param name="rng">Random Number Generator</param>
    /// <param name="rolls">Number of loot rolls</param>
    /// <param name="dropChance">drop chance percentage</param>
    /// <returns></returns>
    public List<(string ItemName, int Amount)> RollLoot(Random rng, int rolls = 1, double dropChance = 1.0)
    {
        var loot = new List<(string ItemName, int Amount)>();
        if (DropTable.Count == 0)
        {
            return loot;
        }
        if (rng.NextDouble() > dropChance)
        {
            return loot;
        }

        for (var i = 0; i < rolls; i++)
        {
            var entry = PickWeigth(rng, DropTable);
            int amount = rng.Next(entry.MinimumAmount, entry.MaximumAmount + 1);
            loot.Add((entry.ItemName, amount));
        }
        return loot;
    }

    /// <summary>
    /// Static loot entry helper method that determines the weighting chance
    /// </summary>
    /// <param name="rng">Random Number Generator</param>
    /// <param name="entries">Loot entries</param>
    /// <returns>Loot entry</returns>
    private static LootEntry PickWeigth(Random rng, List<LootEntry> entries)
    {
        int totalWeigth = entries.Sum(entry => entry.Weigth);
        int roll = rng.Next(1, totalWeigth + 1);
        int cumulative = 0;

        foreach (var entry in entries)
        {
            cumulative += entry.Weigth;
            if (roll <= cumulative)
            {
                return entry;
            }
        }
        return entries[^1];
    }
}