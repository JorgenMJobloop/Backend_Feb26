using System.Text.Json.Serialization;
/// <summary>
/// DTO for a game save, using the game state as basis
/// </summary>
public sealed class SaveGame
{
    public int Version { get; set; } = 1;
    public string PlayerName { get; set; } = string.Empty;
    public CharacterClass? CharacterClass { get; set; }

    public double HP { get; set; }
    public double Mana { get; set; }
    public int Level { get; set; }
    public int XP { get; set; }

    public Dictionary<string, int> Inventory { get; set; } = new Dictionary<string, int>();

    public List<CharacterClass> Party { get; set; } = new List<CharacterClass>();
}
/// <summary>
/// Helps convert the character build enum easier to JSON-format
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CharacterBuildConverter
{
    Warrior = 1,
    Mage = 2,
    Ranger = 3,
    Healer = 4
}