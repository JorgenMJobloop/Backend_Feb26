public static class LootRoller
{
    /// <summary>
    /// Static loot entry helper method that determines the weighting chance
    /// </summary>
    /// <param name="rng">Random Number Generator</param>
    /// <param name="entries">Loot entries</param>
    /// <returns>Loot entry</returns>
    public static LootEntry PickWeigth(Random rng, List<LootEntry> entries)
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