public class NPC
{
    public string Name { get; set; } = "Goblin";
    public double HP { get; set; } = 30;
    public double BaseDamage { get; set; } = 7;
    public List<LootEntry> DropTable { get; } = new List<LootEntry>();
    public bool IsAlive => HP > 0;

    public void TakeDamage(double amount)
    {
        HP = Math.Max(0, HP - amount);
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
            var entry = LootRoller.PickWeigth(rng, DropTable);
            int amount = rng.Next(entry.MinimumAmount, entry.MaximumAmount + 1);
            loot.Add((entry.ItemName, amount));
        }
        return loot;
    }
}