public class CharacterClass
{
    /// <summary>
    /// Warrior, mage, ranger, healer
    /// </summary>
    public string Build { get; set; } = string.Empty;
    /// <summary>
    /// Headgear equipped
    /// </summary>
    public string Head { get; set; } = string.Empty;
    /// <summary>
    /// Gear equipped in body slot
    /// </summary>
    public string Body { get; set; } = string.Empty;
    /// <summary>
    ///  Gear equipped in feet slot
    /// </summary>
    public string Feet { get; set; } = string.Empty;
    public string Weapon { get; set; } = string.Empty;
    /// <summary>
    /// XP multiplier
    /// </summary>
    public double XPMultiplier { get; set; }
    public int BaseLevel { get; set; }

    /// <summary>
    /// Optional constructor that allows direct access to objects
    /// </summary>
    public CharacterClass()
    {

    }

    public CharacterClass(string build, string head, string body, string feet, double multiplier, string weapon, int baseLevel)
    {
        Build = build;
        Head = head;
        Body = body;
        Feet = feet;
        XPMultiplier = multiplier;
        Weapon = weapon;
        BaseLevel = baseLevel;
    }
}