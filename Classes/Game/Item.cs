public enum ItemType
{
    Consumeable = 1,
    Equipment = 2
}
public sealed class Item
{
    public string? ItemName { get; }
    public ItemType TypeOfItem { get; }
    public string? Description { get; }

    public Item(string itemName, ItemType typeOfItem, string description)
    {
        ItemName = itemName;
        TypeOfItem = typeOfItem;
        Description = description;
    }
}