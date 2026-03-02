public static class ItemService
{
    /// <summary>
    /// Health potion field, readonly static value
    /// </summary>
    public static readonly Item HealthPotion = new Item("Health potion", ItemType.Consumeable, "A potion that heals a portion of health (30)");
    /// <summary>
    /// Mana regeneration potion
    /// </summary>
    public static readonly Item ManaPotion = new Item("Mana regeneration potion", ItemType.Consumeable, "A potion that restores some mana over time (15) each round");
    /// <summary>
    /// A golden platebody
    /// </summary>
    public static readonly Item GoldenPlatebody = new Item("A golden plate body", ItemType.Equipment, "A golden plate body");
}