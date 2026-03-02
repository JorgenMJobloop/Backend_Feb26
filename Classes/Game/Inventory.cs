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

    public bool Remove(string itemName, int amount = 1)
    {
        if (!_items.TryGetValue(itemName, out int exists) || amount <= 0)
        {
            return false;
        }

        int itemsLeft = exists - amount;
        if (itemsLeft > 0)
        {
            _items[itemName] = itemsLeft;
        }
        else
        {
            _items.Remove(itemName);
        }
        return true;
    }

    public void ClearAndSetInventory(Dictionary<string, int> itemsInInventory)
    {
        // Clear the inventory
        _items.Clear();
        // Set items in inventory
        foreach (var keyValuePairs in itemsInInventory)
        {
            _items[keyValuePairs.Key] = keyValuePairs.Value;
        }
    }

    public IReadOnlyDictionary<string, int> Items => _items;
    public bool IsEmpty => _items.Count == 0;

    public override string ToString()
    {
        if (_items.Count == 0)
        {
            return "Inventory: (Empty)";
        }
        return string.Join(", ", _items.Select(keyValuePairs => $"{keyValuePairs.Key} : {keyValuePairs.Value}"));
    }
}