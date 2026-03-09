
public class Player : BattleSystem
{
    /// <summary>
    /// Name of the player
    /// </summary>
    public override string Name { get; }
    public override int AttackSpeed { get; }
    public override int Accuracy { get; }
    public override int CritChance { get; }
    public override double BaseDamage { get; }
    /// <summary>
    /// Character class (mage, warrior, ranger)
    /// </summary>
    public CharacterClass? CharacterClass { get; set; }
    public int XP { get; set; } = 0;

    public int Level { get; set; } = 1;

    public Inventory Inventory { get; } = new Inventory();

    public List<Party> PartyMembers { get; } = new List<Party>();

    public Player(string name, int attackSpeed, int accuracy, int critChance, double baseDamage, CharacterClass build)
        : base(hp: 100, mana: 50)
    {
        Name = name;
        CharacterClass = build;
        AttackSpeed = attackSpeed;
        Accuracy = accuracy;
        CritChance = critChance;
        BaseDamage = baseDamage;
    }

    /// <summary>
    /// Previous iteration of the combat system, might be discarded in a turn-based system
    /// </summary>
    /// <param name="rng">Random Number Generator</param>
    /// <returns>double</returns>
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