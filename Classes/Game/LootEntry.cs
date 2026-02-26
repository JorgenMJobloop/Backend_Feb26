public enum Rarity
{
    Common = 1,
    Uncommon = 2,
    Rare = 3,
    Epic = 4,
    Mythic = 6,
    Legendary = 7
}

public class LootEntry
{
    public string ItemName { get; }
    public Rarity Rarity { get; }
    public int Weight { get; } // weigth for relative chance
    public int MinimumAmount { get; }
    public int MaximumAmount { get; }

    public LootEntry(string itemName, Rarity rarity, int weight, int minimumAmount = 1, int maximumAmount = 1)
    {
        ItemName = itemName;
        Rarity = rarity;
        Weight = weight;
        MinimumAmount = minimumAmount;
        MaximumAmount = maximumAmount;
    }
}