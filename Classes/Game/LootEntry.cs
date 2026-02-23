public class LootEntry
{
    public string ItemName { get; }
    public int Weigth { get; } // weigth for relative chance
    public int MinimumAmount { get; }
    public int MaximumAmount { get; }

    public LootEntry(string itemName, int weigth, int minimumAmount, int maximumAmount)
    {
        if (weigth <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weigth));
        }
        if (minimumAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minimumAmount));
        }
        if (maximumAmount < minimumAmount)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumAmount));
        }

        ItemName = itemName;
        Weigth = weigth;
        MinimumAmount = minimumAmount;
        MaximumAmount = maximumAmount;
    }
}