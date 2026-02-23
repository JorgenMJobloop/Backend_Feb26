public class Inventory
{
    /// <summary>
    /// Dictionary that keeps track of items inside of the players inventory: {"swords": 2}
    /// </summary>
    private readonly Dictionary<string, int> _items = new Dictionary<string, int>();

    /// <summary>
    /// Add new items or check if an item already exists inside of the players inventory
    /// </summary>
    /// <param name="itemName">name of the item</param>
    /// <param name="amount">number of a specific item in the inventory</param>
    public void Add(string itemName, int amount)
    {
        if (amount <= 0)
        {
            return;
        }
        _items.TryGetValue(itemName, out int existingItems);
        _items[itemName] = existingItems + amount;
    }

    public override string ToString()
    {
        if (_items.Count == 0)
        {
            return "Inventory: (Empty)";
        }
        return string.Join(", ", _items.Select(keyValuePairs => $"{keyValuePairs.Key} x{keyValuePairs.Value}"));
    }
}