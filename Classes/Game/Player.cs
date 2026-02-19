using System.Security.Cryptography.X509Certificates;

public class Player : IBattleSystem
{
    /// <summary>
    /// Name of the player
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// Hitpoints property
    /// </summary>
    public double HP { get; private set; }
    /// <summary>
    /// Mana property
    /// </summary>
    public double Mana { get; private set; }
    /// <summary>
    /// List collection for the Stats field
    /// </summary>
    public List<string>? Stats = new List<string>();
    /// <summary>
    /// Character class (mage, warrior, ranger)
    /// </summary>
    public CharacterClass? CharacterClass { get; set; }

    public double BaseDamage { get; private set; } = 30;

    public bool IsAlive => HP > 0; // if the player has more than 0 Hitpoints, this value is true, else it is false.

    /// <summary>
    /// Constructor that allows for "empty" initalization when an object is created to referance this class
    /// </summary>
    public Player()
    {
        Name = string.Empty;
    }

    /// <summary>
    /// Constructor that takes in values and passes them along to the object
    /// </summary>
    /// <param name="hp">Hitpoints</param>
    /// <param name="mana">Mana</param>
    /// <param name="stats">Overall stats</param>
    /// <param name="character">type of char class</param>
    public Player(string name, double hp, double mana, List<string> stats, CharacterClass character)
    {
        Name = name;
        HP = hp;
        Mana = mana;
        Stats = stats;
        CharacterClass = character;
    }

    public void TakeDamage(double amount)
    {
        HP = Math.Max(0, HP - amount);
    }

    public double DealDamage(Random rng)
    {
        int rolledDamage = rng.Next(1, 101);
        bool criticalHit = rng.Next(1, 101) <= 25; // 25% dmg if a critial hit has landed.

        // we can check how many times an attack misses, by using the rolledDamage variable.
        if (rolledDamage <= 20)
        {
            return 0; // 20% missed hits
        }

        var damage = BaseDamage;

        // check each character class/build
        switch (CharacterClass!.Build)
        {
            case "Warrior":
                damage *= 1.2; // 20% extra damage dealt
                break;
            case "Ranger":
                damage *= 1.1; // 10% extra damage dealt
                break;
            case "Mage":
                damage *= 1.5; // 50% extra damage dealt
                break;
        }

        if (criticalHit)
        {
            damage *= 2;
        }

        return Math.Round(damage, 1);
    }
}