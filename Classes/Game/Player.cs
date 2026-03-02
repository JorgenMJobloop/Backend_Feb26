
public class Player
{
    /// <summary>
    /// Name of the player
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// Hitpoints property
    /// </summary>
    public double HP { get; set; } = 100;
    /// <summary>
    /// Mana property
    /// </summary>
    public double Mana { get; set; } = 50;
    /// <summary>
    /// Character class (mage, warrior, ranger)
    /// </summary>
    public CharacterClass? CharacterClass { get; set; }
    public int XP { get; set; } = 0;

    public int Level { get; set; } = 1;

    public Inventory Inventory { get; } = new Inventory();

    public Party? Party { get; } = new Party();

    public bool IsAlive => HP > 0; // if the player has more than 0 Hitpoints, this value is true, else it is false.

    /// <summary>
    /// Constructor that allows for "empty" initalization when an object is created to referance this class
    /// </summary>
    public Player(string name, CharacterClass characterClass)
    {
        Name = name;
        CharacterClass = characterClass;
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

        var damage = 30.0;

        // check each character class/build
        switch (CharacterClass!.Build)
        {
            case CharacterBuild.Warrior:
                damage *= 1.2; // 20% extra damage dealt
                break;
            case CharacterBuild.Ranger:
                damage *= 1.1; // 10% extra damage dealt
                break;
            case CharacterBuild.Mage:
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