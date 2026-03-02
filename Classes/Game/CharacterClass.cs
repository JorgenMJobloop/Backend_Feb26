/// <summary>
/// Character build enums
/// </summary>
public enum CharacterBuild
{
    Warrior = 1,
    Mage = 2,
    Ranger = 3,
    Healer = 4
}
/// <summary>
/// Main character classes
/// </summary>
public class CharacterClass
{
    /// <summary>
    /// Warrior, mage, ranger, healer
    /// </summary>
    public CharacterBuild Build { get; }
    public string Weapon { get; set; } = string.Empty;
    /// <summary>
    /// Base damage
    /// </summary>
    public double BaseDamage { get; }
    /// <summary>
    /// Accuracy of attacks, 0 - 100
    /// </summary>    
    public int Accuracy { get; }
    /// <summary>
    /// Chance of landing a critical hit 0 - 100
    /// </summary>
    public int CritChance { get; }
    /// <summary>
    /// XP multiplier
    /// </summary>
    public double XPMultiplier { get; set; }

    /// <summary>
    /// Optional constructor that allows direct access to objects
    /// </summary>
    public CharacterClass()
    {

    }

    public CharacterClass(CharacterBuild build, double multiplier, string weapon)
    {
        Build = build;
        XPMultiplier = multiplier;
        Weapon = weapon;
    }
}