public class NPC : BattleSystem
{
    public List<LootEntry> DropTable { get; } = new List<LootEntry>();

    public override string Name { get; }

    public override int AttackSpeed { get; }

    public override int Accuracy { get; }

    public override int CritChance { get; }

    public override double BaseDamage { get; }

    public double XPWhenDefeated { get; set; } = 25;

    public NPC(string name, double hp, double baseDamage, int attackSpeed, int accuracy, int critChance) : base(hp, mana: 0)
    {
        Name = name;
        BaseDamage = baseDamage;
        AttackSpeed = attackSpeed;
        Accuracy = accuracy;
        CritChance = critChance;
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